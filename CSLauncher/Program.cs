using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using CSLauncher.Forms;

namespace CSLauncher {
    static class Program {
        private const uint EcmFirst = 0x1500;
        private const uint EmSetcuebanner = EcmFirst + 1;

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = false)]
        private static extern IntPtr SendMessage(IntPtr hWnd, uint msg, uint wParam, [MarshalAs(UnmanagedType.LPWStr)] string lParam);

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LoginForm());
        }

        public static void SetWatermark(TextBox textBox, string watermarkText) {
            SendMessage(textBox.Handle, EmSetcuebanner, 0, watermarkText);
        }

        public static void SetWatermark(ComboBox textBox, string watermarkText) {
            SendMessage(textBox.Handle, EmSetcuebanner, 0, watermarkText);
        }
    }
}
