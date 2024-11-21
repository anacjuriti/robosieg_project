using NUnit.Framework; //framework para testes unitários
using OpenQA.Selenium; //biblioteca para controle de navegadores
using OpenQA.Selenium.Chrome; //implementação  para o navegador Chrome

namespace robosieg_project.tests
{
    public class UnitTest1
    {
        private ChromeDriver? driver; //instância do ChromeDriver, usada para controlar o navegador

        [SetUp]
        public void Setup()
        {
            //configuração inicial-> nova instância do ChromeDriver
            var options = new ChromeOptions();
            
            //adc o argumento "--headless", para permitir rodar no navegador sem interface gráfica
            options.AddArgument("--headless");
            driver = new ChromeDriver(options); //inicializa o driver
        }

        [Test]
        public void TestMethod1()
        {
            // Garante que o driver foi inicializado corretamente antes de prosseguir
            Assert.That(driver, Is.Not.Null, "Driver não foi inicializado.");

            //atenção ao driver verificado como não nulo (para evitar alertas de nulabilidade)
            driver!.Navigate().GoToUrl("https://www.google.com"); //url do google
            
            //verifica se a URL acessada corresponde a esperada
            Assert.That(driver.Url, Is.EqualTo("https://www.google.com/"), "A URL não é a esperada.");
        }

        [TearDown]
        public void Teardown()
        {
            //chama método após cada teste para limpar os recursos
            //fecha o navegador e libera a memória
            driver?.Quit(); 
            driver?.Dispose();
        }
    }
}
