using System.IO; //biblioteca com classes para trabalhar com arquivos e diretórios

namespace robosieg_project
{
    public class DirectoryManager
    {
        /// <summary>
        ///Aqui começa o método para criar uma estrutura de diretórios no sistema de arquivos:
        /// </summary>
        public static void CreateDirectories()
        {
            //caminho base onde os diretórios serão criados
            string basePath = @"C:\Downloads";

            //diretórios principais que serão criados diretamente na pasta base
            string[] mainFolders = { "DownloadClick", "DownloadRequest" };

            //subdiretórios criados dentro de cada diretório principal
            string[] subFolders = { "100MB", "1GB", "10GB" };

            //diretório principal
            foreach (var mainFolder in mainFolders)
            {
                //associar o caminho base com o nome do diretório principal
                string mainPath = Path.Combine(basePath, mainFolder);

                //criação do diretorio principal caso ainda não exista
                Directory.CreateDirectory(mainPath);

                //subdiretórios
                foreach (var subFolder in subFolders)
                {
                    //caminho do diretório principal com o subdiretório
                    string subPath = Path.Combine(mainPath, subFolder);

                    //criar o subdiretório
                    Directory.CreateDirectory(subPath);
                }
            }
        }
    }
}
