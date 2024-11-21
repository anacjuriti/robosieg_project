using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace robosieg_project.tests
{
    public class UnitTest1
    {
        private ChromeDriver? driver;

        [SetUp]
        public void Setup()
        {
            // Inicializa o ChromeDriver
            var options = new ChromeOptions();
            options.AddArgument("--headless"); // Roda sem interface gráfica para melhorar desempenho
            driver = new ChromeDriver(options);
        }

        [Test]
        public void TestMethod1()
        {
            // Verifica se o driver foi inicializado
            Assert.That(driver, Is.Not.Null, "Driver não foi inicializado.");

            // Usa o operador de exclusão de anulabilidade (!) após garantir que driver não é nulo
            driver!.Navigate().GoToUrl("https://www.google.com");
            Assert.That(driver.Url, Is.EqualTo("https://www.google.com/"), "A URL não é a esperada.");
        }

        [TearDown]
        public void Teardown()
        {
            // Fecha o navegador e libera recursos
            driver?.Quit();
            driver?.Dispose();
        }
    }
}



/*using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace robosieg_project.tests
{
    public class UnitTest1
    {
        private IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            // Inicializa o WebDriver antes de cada teste
            driver = new ChromeDriver();
        }

        [Test]
        public void TestMethod1()
        {
            driver.Navigate().GoToUrl("https://www.google.com");
            Assert.Pass("Teste concluído com sucesso!");
        }

        [TearDown]
        public void Teardown()
        {
            // Fecha o navegador após cada teste
            driver.Quit();
        }
    }
}
 */