using System;
using System.Windows.Forms;
using CSLauncher.Forms;
using CSLauncher.ResourceDownloader;

namespace CSLauncher {
    static class Program {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var rc = new ResourceCreator();
            rc.GetResources();
            Application.Run(new LoginForm());
        }
    }
}
