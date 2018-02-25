using System;
using System.IO;

using KaraokeTOP.Helpers;
using KaraokeTOP2.Droid.Helpers;
using Xamarin.Forms;

[assembly: Dependency(typeof(FileHelper))]
namespace KaraokeTOP2.Droid.Helpers
{
    public class FileHelper : IFileHelper
    {
        public string GetLocalFilePath(string filename)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            return Path.Combine(path, filename);
        }
    }
}
