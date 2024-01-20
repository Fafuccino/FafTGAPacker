using Emgu.CV.Structure;
using Emgu.CV;
using Emgu.CV.Util;
using Faf_TGA_Packer;
using System.IO;
using System.Diagnostics;

internal class Program
{
    private static void Main(string[] args)
    {
        // Diagnostics
        Stopwatch watch = new Stopwatch();
        watch.Start();

        string outputFolder = "./output/";

        if (args.Length > 0)
        {
            PathGrappler.Grab(true, args);
        }
        else
        {
            PathGrappler.Grab();
        }
        // PROGRAM

        List<string> fileQueue = new();
        short queueIndex = 0;
        foreach (string item in PathGrappler.FileRefs.Keys)
        {
            if (!PathGrappler.SkipList.Contains(item))
            {
                fileQueue.Add(item);
                queueIndex++;
            }
        }

        for (int q = 0; q < fileQueue.Count; q++)
        {
            string file = fileQueue[q];

            Console.WriteLine($"Merging to '{file}' | {q + 1}/{fileQueue.Count} files...");

            if (args.Length > 0)
            {
                outputFolder = Path.GetDirectoryName(PathGrappler.FileRefs[file][0]) + "/";
            }

            string outputPath = outputFolder + file + ".png";

            string fileName = Path.GetFileNameWithoutExtension(PathGrappler.FileRefs[file][3]); // Gets the Alpha

            Image<Gray, byte>[] channels = new Image<Gray, byte>[4];

            Mat rgbaMat = new Mat();

            if (fileName == null)
            {
                // BGR mode
                for (int i = 0; i < PathGrappler.FileRefs[file].Length - 1; i++)
                {
                    Image<Gray, byte> img = CvInvoke.Imread(Path.GetFullPath(PathGrappler.FileRefs[file][i])).ToImage<Gray, byte>();
                    channels[i] = img;
                }

                CvInvoke.Merge(new VectorOfMat(channels[0].Mat, channels[1].Mat, channels[2].Mat), rgbaMat);

            }
            else
            {
                // BGRA mode
                for (int i = 0; i < PathGrappler.FileRefs[file].Length; i++)
                {
                    Image<Gray, byte> img = CvInvoke.Imread(Path.GetFullPath(PathGrappler.FileRefs[file][i])).ToImage<Gray, byte>();
                    channels[i] = img;
                }
                CvInvoke.Merge(new VectorOfMat(channels[0].Mat, channels[1].Mat, channels[2].Mat, channels[3].Mat), rgbaMat);
            }
            // SAVE
            rgbaMat.Save(outputPath);

            // CONVERT TO TGA
            PNGtoTGA.Convert(outputPath);
        }
        watch.Stop();
        Console.WriteLine($"Execution Time : {watch.ElapsedMilliseconds} ms");
        Console.WriteLine($"Skipped : {PathGrappler.SkipList.Count}/{PathGrappler.FileRefs.Count} files.");
    }
}

/* CUDA ONLY
GpuMat bMat = new GpuMat(bArray) ;
GpuMat gMat = new GpuMat(gArray);
GpuMat rMat = new GpuMat(rArray);
GpuMat aMat = new GpuMat(aArray);

GpuMat rgbaMat = new GpuMat();

rgbaMat.MergeFrom([bMat, gMat, rMat, aMat]);

rgbaMat.Save("./output/barbara.tga");
*/