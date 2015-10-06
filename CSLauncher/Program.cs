using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using CSLauncher.Forms;
using CSLauncher.ResourceDownloader;

namespace CSLauncher {
    static class Program {
        private const uint ECM_FIRST = 0x1500;
        private const uint EM_SETCUEBANNER = ECM_FIRST + 1;

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = false)]
        private static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, uint wParam, [MarshalAs(UnmanagedType.LPWStr)] string lParam);

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

        public static void SetWatermark(TextBox textBox, string watermarkText) {
            SendMessage(textBox.Handle, EM_SETCUEBANNER, 0, watermarkText);
        }

        public static void SetWatermark(ComboBox textBox, string watermarkText) {
            SendMessage(textBox.Handle, EM_SETCUEBANNER, 0, watermarkText);
        }
    }
}
