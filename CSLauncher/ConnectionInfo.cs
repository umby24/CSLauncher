using System;
using System.Linq;
using System.Net;
using System.Net.Sockets;

namespace CSLauncher {
    public class ConnectionInfo {
        public string Ip;
        public int Port;
        public string Username;
        public string Mppass;

        /// <summary>
        /// Tries to parse a MC url, mc://ip:port/username/mppass
        /// </summary>
        /// <param name="mcUrl">The url to try to parse</param>
        /// <param name="info">The connectioninfo instance to push results to.</param>
        /// <returns>True if successful, false if failed.</returns>
        public static bool TryParseUrl(string mcUrl, out ConnectionInfo info) {
            if (!mcUrl.StartsWith("mc://")) {
                info = null;
                return false;
            }

            mcUrl = mcUrl.Substring(5, mcUrl.Length - 5); // -- Remove mc:// from the string.
            string[] parts = mcUrl.Split(new [] {'/'}, StringSplitOptions.RemoveEmptyEntries);

            if (parts.Length < 2) {
                info = null;
                return false;
            }

            info = new ConnectionInfo();

            // -- Check if a port was included.
            if (parts[0].Contains(":")) {
                string[] portSplit = parts[0].Split(':');

                if (!int.TryParse(portSplit[1], out info.Port)) {
                    info = null;
                    return false;
                }

                info.Ip = portSplit[0];
            }
            else {
                info.Ip = parts[0];
                info.Port = 25565;
            }

            // -- Verify IP Addresses.
            if (!VerifyAddress(info.Ip))
                return false;

            info.Username = parts[1];

            info.Mppass = parts.Length == 3 ? parts[2] : "";

            return true;
        }

        private static bool VerifyAddress(string address) {
            IPAddress add;

            if (IPAddress.TryParse(address, out add)) {
                return true;
            }

            IPAddress ipA = Dns.GetHostAddresses(address).First(ip => ip.AddressFamily == AddressFamily.InterNetwork);

            if (ipA == null)
                return false;

            return true;
        }
    }
}
