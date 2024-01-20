using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TGASharpLib;

namespace Faf_TGA_Packer
{
    internal class PNGtoTGA
    {
        public static void Convert(string path)
        {
            // Saves a new .tga

            using (Bitmap pngBitmap = new Bitmap(path))
            {
                TGA tga = TGA.FromBitmap(pngBitmap, true);
                tga.Save(path.Remove(path.Length - 3) + "tga");
            }

            // Deletes the temporary .png
            File.Delete(path);
        }
    }
}
