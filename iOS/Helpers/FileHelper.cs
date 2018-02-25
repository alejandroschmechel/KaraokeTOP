using System;
using System.IO;
using KaraokeTOP.Helpers;
using KaraokeTOP2.iOS.Helpers;
using Xamarin.Forms;

[assembly: Dependency(typeof(FileHelper))]
namespace KaraokeTOP2.iOS.Helpers
{
    public class FileHelper : IFileHelper
    {
        public string GetLocalFilePath(string filename)
        {
            string docFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string libFolder = Path.Combine(docFolder, "..", "Library", "Databases");

            if (!Directory.Exists(libFolder))
            {
                Directory.CreateDirectory(libFolder);
            }

            return Path.Combine(libFolder, filename);
        }
    }
}
