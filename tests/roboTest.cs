using NUnit.Framework;
using System.Threading.Tasks;
using robosieg_project;
using OpenQA.Selenium;

namespace tests
{
    [TestFixture]
    public class RoboTests
    {
        [Test]
        public void TestCarregarGoogle()
        {
            Robo robo = new Robo();
            robo.CarregarGoogle();
            Assert.That(((OpenQA.Selenium.Chrome.ChromeDriver)robo.GetDriver()).Title, Is.EqualTo("Google"));
            robo.Finalizar();
        }

        [Test]
        public async Task TestBaixarArquivosPorRequisicao()
        {
            Robo robo = new Robo();
            await robo.BaixarArquivosPorRequisicao();
            Assert.That(File.Exists(@"C:\Downloads\DownloadRequest\100MB\100MB.zip"), Is.True);
            Assert.That(File.Exists(@"C:\Downloads\DownloadRequest\1GB\1GB.zip"), Is.True);
            Assert.That(File.Exists(@"C:\Downloads\DownloadRequest\10GB\10GB.zip"), Is.True);
            robo.Finalizar();
        }
    }
}
