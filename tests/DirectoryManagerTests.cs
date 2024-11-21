using NUnit.Framework;
using System.IO;
using robosieg_project;

namespace tests
{
    [TestFixture]
    public class DirectoryManagerTests
    {
        [Test]
        public void TestCreateDirectories()
        {
            //chama o método para criar todas as pastas necessárias
            DirectoryManager.CreateDirectories();
            
            //verifica se a pasta para downloads via clique (100MB) foi criada corretamente
            Assert.That(Directory.Exists(@"C:\Downloads\DownloadClick\100MB"), Is.True, "A pasta para DownloadClick de 100MB não foi encontrada.");
            
            //verifica se a pasta para downloads via requisição (1GB) foi criada corretamente
            Assert.That(Directory.Exists(@"C:\Downloads\DownloadRequest\1GB"), Is.True, "A pasta para DownloadRequest de 1GB não foi encontrada.");
            
            //verifica se a pasta para downloads via requisição (10GB) foi criada corretamente
            Assert.That(Directory.Exists(@"C:\Downloads\DownloadRequest\10GB"), Is.True, "A pasta para DownloadRequest de 10GB não foi encontrada.");
        }
    }
}



/*using NUnit.Framework;
using System.IO;
using robosieg_project;

namespace tests
{
    [TestFixture]
    public class DirectoryManagerTests
    {
        [Test]
        public void TestCreateDirectories()
        {
            //chama o método para criar as pastas necessárias para os downloads
            DirectoryManager.CreateDirectories();
            
            //verifica se a pasta para downloads via clique (100MB) foi criada corretamente
            Assert.That(Directory.Exists(@"C:\Downloads\DownloadClick\100MB"), Is.True, "A pasta para DownloadClick de 100MB não foi encontrada.");
            
            //verifica se a pasta para downloads via requisição (1GB) foi criada corretamente
            Assert.That(Directory.Exists(@"C:\Downloads\DownloadRequest\1GB"), Is.True, "A pasta para DownloadRequest de 1GB não foi encontrada.");
        }
    }
}
 */