using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Newtonsoft.Json;

namespace CSLauncher {
    public class UserAccount {
        public string Username { get; set; }
        public string Password { get; set; }

        public UserAccount() {
            Username = "";
            Password = "";
        }
    }

    public class LauncherPrefs {
        public string ResumeUrl { get; set; }
        public bool RememberUsernames { get; set; }
        public bool RememberPasswords { get; set; }
        public bool RememberServers { get; set; }
        public bool KeepLauncherOpen { get; set; }
        public int SelectedAccount { get; set; }
        public List<UserAccount> ClassicubeAccounts { get; set; } 

        public LauncherPrefs() {
            ResumeUrl = "mc://127.0.0.1:25565/user/mpass";
            RememberUsernames = true;
            RememberPasswords = false;
            ClassicubeAccounts = new List<UserAccount>();
        }
    }
    public class Preferences {
        public LauncherPrefs Launcher { get; set; }
        public static Preferences Settings { get; private set; }

        public Preferences() {
            Launcher = new LauncherPrefs();
        }

        public static void Load() {
            if (!Directory.Exists(Path.Combine(Directory.GetParent(Assembly.GetExecutingAssembly().Location).FullName, "Prefs")))
                Directory.CreateDirectory(Path.Combine(Directory.GetParent(Assembly.GetExecutingAssembly().Location).FullName, "Prefs"));

            var path = Path.Combine(Directory.GetParent(Assembly.GetExecutingAssembly().Location).FullName, "Prefs", "prefs.json");

            if (!File.Exists(path)) {
                Settings = new Preferences();
                File.WriteAllText(path, JsonConvert.SerializeObject(Settings, Formatting.Indented));
            }

            try {
                Settings = JsonConvert.DeserializeObject<Preferences>(File.ReadAllText(path));
            }
            catch {
                // Failed to Load settings, use defaults.
                Settings = new Preferences();
            }
        }

        public static void Save() {
            if (!Directory.Exists(Path.Combine(Directory.GetParent(Assembly.GetExecutingAssembly().Location).FullName, "Prefs")))
                Directory.CreateDirectory(Path.Combine(Directory.GetParent(Assembly.GetExecutingAssembly().Location).FullName, "Prefs"));

            var path = Path.Combine(Directory.GetParent(Assembly.GetExecutingAssembly().Location).FullName, "Prefs", "prefs.json");
            File.WriteAllText(path, JsonConvert.SerializeObject(Settings, Formatting.Indented));
        }
    }
}
