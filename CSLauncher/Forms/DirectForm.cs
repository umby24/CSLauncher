using System;
using System.Windows.Forms;
using CSLauncher.Launcher;

namespace CSLauncher.Forms {
    public partial class DirectForm : Form {
        public DirectForm() {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e) {
            ConnectionInfo info;

            if (!ConnectionInfo.TryParseUrl(textBox1.Text, out info)) {
                MessageBox.Show("Invalid Direct-Connect url.", "Invalid URL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (Preferences.Settings.Launcher.RememberServers) {
                Preferences.Settings.Launcher.ResumeUrl = textBox1.Text;
                Preferences.Save();
            }

            ClassicalSharp.Launch(info);

            if (!Preferences.Settings.Launcher.KeepLauncherOpen)
                Application.Exit();
            else
                Close();
        }

        private void btnCancel_Click(object sender, EventArgs e) {
            Close();
        }

        private void DirectForm_Load(object sender, EventArgs e) {
            textBox1.Text = Preferences.Settings.Launcher.ResumeUrl;
        }
    }
}
