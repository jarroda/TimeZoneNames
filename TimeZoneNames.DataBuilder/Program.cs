using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Extensions.PlatformAbstractions;

namespace TimeZoneNames.DataBuilder
{
    class Program
    {
        static void Main(string[] args)
        {
            var path = Path.Combine(PlatformServices.Default.Application.ApplicationBasePath, "data");
            var extractor = DataExtractor.Load(path, overwrite: true);
            extractor.SaveData(path);
            
            // Copy to PCL project for embedding
            var filePath = Path.Combine(path, "tz.dat");
            var destPath = Path.Combine("..", "TimeZoneNames", "tz.dat");
            Console.WriteLine("Copy from: " + filePath);
            Console.WriteLine("Copy to: " + destPath);
            File.Copy(filePath, destPath, true);
        }
    }
}
