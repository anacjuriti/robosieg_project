using System.IO;

public class DirectoryManager
{
    public static void CreateDirectories()
    {
        string basePath = @"C:\Downloads";

        string[] subDirectories = { "DownloadClick", "DownloadRequest" };
        string[] sizeDirectories = { "100MB", "1GB", "10GB" };

        foreach (var subDir in subDirectories)
        {
            string subDirPath = Path.Combine(basePath, subDir);
            Directory.CreateDirectory(subDirPath);

            foreach (var sizeDir in sizeDirectories)
            {
                string sizeDirPath = Path.Combine(subDirPath, sizeDir);
                Directory.CreateDirectory(sizeDirPath);
            }
        }
    }
}
