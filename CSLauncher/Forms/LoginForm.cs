using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using CSLauncher.Launcher;
using CSLauncher.Services;

namespace CSLauncher.Forms {
    public partial class LoginForm : Form {
        public LoginForm() {
            if (!File.Exists("default.zip")) {
                var result = MessageBox.Show("Some required resources are missing, would you like to download them?",
                    "ClassicalSharp Launcher", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes) {
                    var downloadForm = new DownloadForm();
                    downloadForm.ShowDialog();
                }
            }

            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e) {
            Preferences.Load();
            PopulateUsernames();
            Program.SetWatermark(comboUsername, "Username...");
            Program.SetWatermark(txtPassword, "Password...");
        }

        #region Buttom Clicks
        private void comboUsername_SelectedIndexChanged(object sender, EventArgs e) {
            if (comboUsername.SelectedIndex == -1) return;

            PopulatePassword(comboUsername.SelectedIndex);
            Preferences.Settings.Launcher.SelectedAccount = comboUsername.SelectedIndex;
            Preferences.Save();
        }

        private void comboUsername_TextChanged(object sender, EventArgs e) {

            if (string.IsNullOrWhiteSpace(txtPassword.Text) || string.IsNullOrWhiteSpace(comboUsername.Text)) {
                btnSignIn.Enabled = false;
            } else {
                btnSignIn.Enabled = true;
            }

            if (string.IsNullOrWhiteSpace(comboUsername.Text)) {
                txtPassword.Clear();
            }
        }

        private void txtPassword_TextChanged(object sender, EventArgs e) {
            if (string.IsNullOrWhiteSpace(txtPassword.Text) || string.IsNullOrWhiteSpace(comboUsername.Text)) {
                btnSignIn.Enabled = false;
            }
            else {
                btnSignIn.Enabled = true;
            }
        }

        private void btnOptions_Click(object sender, EventArgs e) {
            var btnSender = (Button)sender;
            var ptLowerLeft = new Point(0, btnSender.Height);
            ptLowerLeft = btnSender.PointToScreen(ptLowerLeft);
            btnOptions.ContextMenuStrip.Show(ptLowerLeft);
        }

        private void btnSignIn_Click(object sender, EventArgs e) {
            SaveCredentials();
            SignIn();
        }

        private void btnResume_Click(object sender, EventArgs e) {
            ResumeGame();
        }

        private void btnPrefs_Click(object sender, EventArgs e) {
            var prefs = new PreferencesForm();
            prefs.ShowDialog();
            comboUsername.Text = "";
            txtPassword.Clear();
            
            PopulateUsernames();
        }

        private void directToolStripMenuItem_Click(object sender, EventArgs e) {
            var direct = new DirectForm();
            direct.ShowDialog();
        }

        private void singlePlayerToolStripMenuItem_Click(object sender, EventArgs e) {
            ClassicalSharp.LaunchSinglePlayer();

            if (!Preferences.Settings.Launcher.KeepLauncherOpen)
                Application.Exit();
        }
        #endregion

        #region Form Utility Functions

        private void SignIn() {
            var cc = new ClassicubeService(comboUsername.Text, txtPassword.Text);

            if (!cc.Login()) {
                MessageBox.Show("Failed to login, bad username or password?", "ClassicalSharp Launcher",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var servers = cc.GetAllServers();
            var list = new ListForm(servers, cc);
            list.ShowDialog();
            Show();
        }

        private void ResumeGame() {
            if (string.IsNullOrWhiteSpace(Preferences.Settings.Launcher.ResumeUrl)) {
                MessageBox.Show("There is no resume data.", "ClassicalSharp Launcher", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            ConnectionInfo info;

            if (!ConnectionInfo.TryParseUrl(Preferences.Settings.Launcher.ResumeUrl, out info)) {
                MessageBox.Show("Failed to resume the game.", "ClassicalSharp Launcher", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            ClassicalSharp.Launch(info);

            if (!Preferences.Settings.Launcher.KeepLauncherOpen)
                Application.Exit();
        }

        private void SaveCredentials() {
            // -- If we are not saving credentials, skip this.
            if (!Preferences.Settings.Launcher.RememberPasswords && !Preferences.Settings.Launcher.RememberUsernames)
                return;

            if (string.IsNullOrWhiteSpace(comboUsername.Text))
                return;

            UserAccount account;
            var newAccount = false;

                account =
                    Preferences.Settings.Launcher.ClassicubeAccounts.FirstOrDefault(
                        a => a.Username == comboUsername.Text);

            // -- if account is null, create a new one. (we're at this point at least saving username)
            if (account == null) {
                account = new UserAccount {
                    Username = comboUsername.Text
                };
                newAccount = true;
            }

            account.Password = Preferences.Settings.Launcher.RememberPasswords ? txtPassword.Text : "";

            // -- Now save it to whichever service we're using..
            if (!newAccount) {
                var index =
                    Preferences.Settings.Launcher.ClassicubeAccounts.FindIndex(a => a.Username == account.Username);
                Preferences.Settings.Launcher.ClassicubeAccounts[index] = account;

            }
            else {
                Preferences.Settings.Launcher.ClassicubeAccounts.Add(account);
            }

            PopulateUsernames(false); // -- Repopulate
            Preferences.Settings.Launcher.SelectedAccount = comboUsername.SelectedIndex;
            // -- Save it to disk..
            Preferences.Save();
            
            // -- And done!
        }

        private void PopulateUsernames(bool noSelect = true) {
            if (!Preferences.Settings.Launcher.RememberUsernames) {
                return;
            }

            comboUsername.Items.Clear();

            foreach (var classicubeAccount in Preferences.Settings.Launcher.ClassicubeAccounts) {
                comboUsername.Items.Add(classicubeAccount.Username);
            }

            if (!noSelect)
                return;

            try {
                if (comboUsername.Items.Count > 0)
                    comboUsername.SelectedIndex = Preferences.Settings.Launcher.SelectedAccount;
            }
            catch {
                comboUsername.SelectedIndex = 0;
            }
        }

        private void PopulatePassword(int index) {
            if (!Preferences.Settings.Launcher.RememberPasswords) {
                return;
            }

            txtPassword.Clear();

            txtPassword.Text = Preferences.Settings.Launcher.ClassicubeAccounts.ElementAt(index).Password;
        }
        #endregion

        private void txtPassword_Enter(object sender, EventArgs e) {
            SaveCredentials();
        }

        private void LoginForm_FormClosing(object sender, FormClosingEventArgs e) {
        }







        




    }
}
