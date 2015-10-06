using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.IO.Compression;
using System.Net;

namespace CSLauncher.ResourceDownloader {
    public class ResourceCreator {
        const string ClassicJarUri = "http://s3.amazonaws.com/Minecraft.Download/versions/c0.30_01c/c0.30_01c.jar";
        const string ModernJarUri = "http://s3.amazonaws.com/Minecraft.Download/versions/1.6.2/1.6.2.jar";
        const string TerrainPatchUri = "http://static.classicube.net/terrain-patch.png";
        #region AnimationTxt
        const string AnimationsTxt = @"# This file defines the animations used in a texture pack for ClassicalSharp and other supporting applications.
# Each line is in the format: <TileX> <TileY> <FrameX> <FrameY> <Frame size> <Frames count> <Tick delay>
# - TileX and TileY indicate the coordinates of the tile in terrain.png that 
#     will be replaced by the animation frames. These range from 0 to 15. (inclusive of 15)
# - FrameX and FrameY indicates the pixel coordinates of the first animation frame in animations.png.
# - Frame Size indicates the size in pixels of an animation frame.
# - Frames count indicates the number of used frames.  The first frame is located at 
#     (FrameX, FrameY), the second one at (FrameX + FrameSize, FrameY) and so on.
# - Tick delay is the number of ticks a frame doesn't change. For instance, a value of 0
#     means that the frame would be changed every tick, while a value of 2 would mean 
#    'replace with frame 1, don't change frame, don't change frame, replace with frame 2'.

# still water
14 0 0 0 16 32 2
# still lava
14 1 0 16 16 39 2
# fire
6 2 0 32 16 32 0";
#endregion

        public void GetResources() {
            if (File.Exists("default.zip"))
                return;

            if (!File.Exists("classic.jar"))
                DownloadFile(ClassicJarUri, "classic.jar");

            if (!File.Exists("1.6.2.jar"))
                DownloadFile(ModernJarUri, "1.6.2.jar");

            if (!File.Exists("terrain-patch.png"))
                DownloadFile(TerrainPatchUri, "terrain-patch.png");

            if (Directory.Exists("DefaultZip"))
                Directory.Delete("DefaultZip", true);

            Directory.CreateDirectory("DefaultZip");

            var animBitmap = new Bitmap(1024, 64, PixelFormat.Format32bppArgb);
            ProcessClassicJar();
            ProcessModernJar(animBitmap);
            PatchTerrain();

            File.WriteAllText(Path.Combine("DefaultZip", "animations.txt"), AnimationsTxt);
            animBitmap.Save(Path.Combine("DefaultZip", "animations.png"),ImageFormat.Png);
            ZipFile.CreateFromDirectory("DefaultZip", "default.zip");

            // -- Cleanup!
            Directory.Delete("classicjar", true);
            Directory.Delete("DefaultZip", true);
            Directory.Delete("modernjar", true);
        }

        private void ProcessClassicJar() {
            if (Directory.Exists("classicjar"))
                Directory.Delete("classicjar", true);

             ZipHelper.UnzipFile("classic.jar", "classicjar");

            var classicFiles = Directory.GetFiles("classicjar","*",SearchOption.TopDirectoryOnly);

            if (!Directory.Exists("DefaultZip")) {
                Directory.CreateDirectory("DefaultZip");
            }

            foreach (var file in classicFiles) { // -- Copy the root dir to the zip file..
                File.Copy(file, Path.Combine("DefaultZip", Path.GetFileName(file)));
            }
            // -- Copy the mob images..
            classicFiles = Directory.GetFiles(Path.Combine("classicjar", "mob"));

            Directory.CreateDirectory(Path.Combine("DefaultZip", "mob"));

            foreach (var file in classicFiles) { // -- Copy the root dir to the zip file..
                File.Copy(file, Path.Combine("DefaultZip", "mob", Path.GetFileName(file)));
            }
        }

        private void ProcessModernJar(Bitmap animationBitmap) {
            if (Directory.Exists("modernjar"))
                Directory.Delete("modernjar", true);

            ZipHelper.UnzipModern("1.6.2.jar", "modernjar");

            var mainPath = Path.GetFullPath("modernjar");
            mainPath = Path.Combine(mainPath, "assets", "minecraft", "textures");
            var files = MakePaths(mainPath);

            foreach (var file in files) {
                switch (Path.GetFileName(file)) {
                    case "snow.png":
                        File.Copy(file, Path.Combine("DefaultZip", "snow.png"));
                        break;
                    case "chicken.png":
                        File.Copy(file, Path.Combine("DefaultZip", "mob", "chicken.png"));
                        break;
                    case "water_still.png":
                        var bit = (Bitmap)Bitmap.FromFile(file);
                        CopyDefault(bit, 0, animationBitmap);
                        break;
                    case "lava_still.png":
                        var bit3 = (Bitmap)Bitmap.FromFile(file);
                        CopyCycle(bit3, 16, animationBitmap);
                        break;
                    case "fire_layer_1.png":
                        var bit9 = (Bitmap) Bitmap.FromFile(file);
                        CopyDefault(bit9, 32, animationBitmap);
                        break;
                }
            }
        }

        private void PatchTerrain() {
            var mainImage = (Bitmap)Bitmap.FromFile(Path.Combine("DefaultZip", "terrain.png"));
            Bitmap maskImage = (Bitmap)Bitmap.FromFile("terrain-patch.png");
            var col = maskImage.GetPixel(0, 0);
            Console.WriteLine(col.R + " " + col.G + " " + col.B + " " + col.A);

            for (int x = 176; x < 192; x++) { // -- Replace the spiderweb =/
                for (int y = 0; y < 16; y++) {
                    mainImage.SetPixel(x, y, Color.Transparent);
                }
            }

            var replaceColor = Color.FromArgb(128, 0,0,0);
            var map = new ColorMap[1];

            map[0] = new ColorMap {
                OldColor = replaceColor,
                NewColor = Color.Transparent
            };

            var attr = new ImageAttributes();
            attr.SetRemapTable(map);

            using (Graphics g = Graphics.FromImage(mainImage)) { // -- Draws a rectangle across the image that removes some informational colors =/
                var rect = new Rectangle(0, 0, maskImage.Width, maskImage.Height);
                g.DrawImage(maskImage, rect, 0, 0, rect.Width, rect.Height, GraphicsUnit.Pixel, attr); // -- Also places the mask image on top of the original.
            }

            mainImage.Save(Path.Combine("DefaultZip", "terrain-patched.png"));
            mainImage.Dispose();

            File.Delete(Path.Combine("DefaultZip", "terrain.png"));
            File.Copy(Path.Combine("DefaultZip", "terrain-patched.png"), Path.Combine("DefaultZip", "terrain.png"));
            File.Delete(Path.Combine("DefaultZip", "terrain-patched.png"));
        }

        private void CopyDefault(Bitmap data, int y, Bitmap ani) {
            for (int t = 0; t < data.Height; t += 16) {
                AddAnimationBitmap(t, t, y, data, ani);
            }
        }

        private void CopyCycle(Bitmap data, int y, Bitmap ani) {
            int dst = 0;
            for (int tile = 0; tile < data.Height; tile += 16, dst += 16) {
                AddAnimationBitmap(tile, dst, y, data, ani);
            }
            // Cycle back to first frame.
            for (int tile = data.Height - 32; tile >= 0; tile -= 16, dst += 16) {
                AddAnimationBitmap(tile, dst, y, data, ani);
            }
        }

        private void AddAnimationBitmap(int source, int destination, int yy, Bitmap from, Bitmap to) {
            for (int y = 0; y < 16; y++) {
                for (int x = 0; x < 16; x++) {
                    to.SetPixel(destination + x, y + yy, from.GetPixel(x, source + y));
                }
            }
        }

        private string[] MakePaths(string mainPath) {
            var myList = new List<string> {
                Path.Combine(mainPath, "environment", "snow.png"),
                Path.Combine(mainPath, "blocks", "water_still.png"),
                Path.Combine(mainPath, "blocks", "lava_still.png"),
                Path.Combine(mainPath, "blocks", "fire_layer_1.png"),
                Path.Combine(mainPath, "entity", "chicken.png")
            };
            return myList.ToArray();
        }

        public static bool ResourcesExist() {
            return File.Exists("default.zip") && File.Exists("terrain-patched.png");
        }

        private void DownloadFile(string url, string outFile) {
            var downloader = new WebClient();
            downloader.DownloadFile(url, outFile);
        }
    }
}
