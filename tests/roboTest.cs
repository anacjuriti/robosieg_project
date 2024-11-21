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
            //configura uma instância do robô para testes
            Robo robo = new Robo();
            
            //testa se o robô consegue carregar a página do Google
            robo.CarregarGoogle();
            
            //verifica se o título da página corresponde a "Google"
            Assert.That(((OpenQA.Selenium.Chrome.ChromeDriver)robo.GetDriver()).Title, Is.EqualTo("Google"));
            
            //finaliza o processo para evitar recursos abertos desnecessariamente
            robo.Finalizar();
        }

        [Test]
        public async Task TestBaixarArquivosPorRequisicao()
        {
            //instancia o robô para realizar os testes de download
            Robo robo = new Robo();
            
            //testa a funcionalidade de download via requisição
            await robo.BaixarArquivosPorRequisicao();
            
            //valida se os arquivos esperados foram baixados corretamente
            Assert.That(File.Exists(@"C:\Downloads\DownloadRequest\100MB\100MB.zip"), Is.True, "Arquivo 100MB.zip não encontrado.");
            Assert.That(File.Exists(@"C:\Downloads\DownloadRequest\1GB\1GB.zip"), Is.True, "Arquivo 1GB.zip não encontrado.");
            Assert.That(File.Exists(@"C:\Downloads\DownloadRequest\10GB\10GB.zip"), Is.True, "Arquivo 10GB.zip não encontrado.");
            
            //encerra o robô para garantir que os testes não deixem processos em execução
            robo.Finalizar();
        }
    }
}
