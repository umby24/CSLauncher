using System.IO;
using System.IO.Compression;
using System.Linq;

namespace CSLauncher.ResourceDownloader {
    static class ZipHelper {
        public static void UnzipFile(string file, string outDir) {
            if (!Directory.Exists(outDir))
                Directory.CreateDirectory(outDir); 

            ZipFile.ExtractToDirectory(file, outDir);
        }

        public static void UnzipModern(string file, string outDir) {
           // outDir = Path.Combine(outDir, "assets", "minecraft", "textures");

            if (!Directory.Exists(outDir))
                Directory.CreateDirectory(outDir);

            using (var fs = new FileStream(file, FileMode.Open)) {
                using (var zs = new ZipArchive(fs, ZipArchiveMode.Read)) {
                    var items = zs.Entries.Where(a => a.FullName.Contains("assets/minecraft/textures"));

                    foreach (var entry in items) {
                        var parent = Directory.GetParent(Path.Combine(outDir, entry.FullName)).ToString();

                        if (!Directory.Exists(parent))
                            Directory.CreateDirectory(parent);

                        entry.ExtractToFile(Path.Combine(outDir, entry.FullName), true);
                    }
                }
            }

        }
    }
}
