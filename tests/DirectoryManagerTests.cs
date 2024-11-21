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
            DirectoryManager.CreateDirectories();
            Assert.That(Directory.Exists(@"C:\Downloads\DownloadClick\100MB"), Is.True);
            Assert.That(Directory.Exists(@"C:\Downloads\DownloadRequest\1GB"), Is.True);
        }
    }
}
