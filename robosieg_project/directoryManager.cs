using System.IO;

namespace robosieg_project
{
    public class DirectoryManager
    {
        public static void CreateDirectories()
        {
            string basePath = @"C:\Downloads";

            string[] mainFolders = { "DownloadClick", "DownloadRequest" };
            string[] subFolders = { "100MB", "1GB", "10GB" };

            foreach (var mainFolder in mainFolders)
            {
                string mainPath = Path.Combine(basePath, mainFolder);
                Directory.CreateDirectory(mainPath);

                foreach (var subFolder in subFolders)
                {
                    string subPath = Path.Combine(mainPath, subFolder);
                    Directory.CreateDirectory(subPath);
                }
            }
        }
    }
}
