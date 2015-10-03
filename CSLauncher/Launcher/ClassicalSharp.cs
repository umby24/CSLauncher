using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace CSLauncher.Launcher {
    public static class ClassicalSharp {
        private const string ClassicubeSkinServer = "http://www.classicube.net/static/skins/";
        private const string MissingExeMessage = "Failed to start ClassicalSharp. (classicalsharp.exe was not found)";

        public static void Launch(ConnectionInfo info) {
            string args = info.Username + " " + info.Mppass + " " +
                          info.Ip + " " + info.Port + " " + ClassicubeSkinServer;

			Debug.WriteLine( "Starting..." + args );

            if (!File.Exists("ClassicalSharp.exe")) {
                MessageBox.Show(MissingExeMessage);
                return;
            }

			if( Type.GetType( "Mono.Runtime" ) != null ) {
				Process.Start( "mono", "\"ClassicalSharp.exe\" " + args );
			} else {
				Process.Start( "ClassicalSharp.exe", args );
			}
        }

        public static void LaunchSinglePlayer() {
            if (!File.Exists("ClassicalSharp.exe")) {
                MessageBox.Show(MissingExeMessage);
                return;
            }

            if (Type.GetType("Mono.Runtime") != null) {
                Process.Start("mono", "\"ClassicalSharp.exe\" ");
            } else {
                Process.Start("ClassicalSharp.exe");
            }
        }
    }
}
