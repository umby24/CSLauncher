using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CSLauncher.Forms {
    public partial class PreferencesForm : Form {
        public PreferencesForm() {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e) {
            Preferences.Settings.Launcher.RememberUsernames = chkUsernames.Checked;
            Preferences.Settings.Launcher.RememberPasswords = chkPasswords.Checked;
            Preferences.Settings.Launcher.KeepLauncherOpen = chkLauncherOpen.Checked;
            Preferences.Settings.Launcher.RememberServers = chkServers.Checked;
            Preferences.Save();
            Close();
        }

        private void button4_Click(object sender, EventArgs e) {
            Close();
        }

        private void btnForgetUsernames_Click(object sender, EventArgs e) {
            Preferences.Settings.Launcher.ClassicubeAccounts = new List<UserAccount>();
            Preferences.Save();
        }

        private void btnForgetPasswords_Click(object sender, EventArgs e) {
            foreach (var account in Preferences.Settings.Launcher.ClassicubeAccounts) {
                if (string.IsNullOrWhiteSpace(account.Password))
                    continue;

                account.Password = "";
            }
            Preferences.Save();
        }

        private void btnForgetServer_Click(object sender, EventArgs e) {
            Preferences.Settings.Launcher.ResumeUrl = "";
            Preferences.Save();
        }

        private void PreferencesForm_Load(object sender, EventArgs e) {
            chkLauncherOpen.Checked = Preferences.Settings.Launcher.KeepLauncherOpen;
            chkPasswords.Checked = Preferences.Settings.Launcher.RememberPasswords;
            chkUsernames.Checked = Preferences.Settings.Launcher.RememberUsernames;
            chkServers.Checked = Preferences.Settings.Launcher.RememberServers;
        }
    }
}
