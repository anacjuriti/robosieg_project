using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

public class Robo
{
    IWebDriver driver;

    public Robo()
    {
        driver = new ChromeDriver();
    }

    public void CarregarGoogle()
    {
        driver.Navigate().GoToUrl("https://www.google.com");
    }

    public void PesquisarTestFiles()
    {
        var searchBox = driver.FindElement(By.Name("q"));
        searchBox.SendKeys("Test-Files");
        searchBox.Submit();
    }

    public void ClicarNoSite()
    {
        var link = driver.FindElement(By.CssSelector("a[href='https://ash-speed.hetzner.com/']"));
        link.Click();
    }

    public async Task BaixarArquivosPorRequisicao()
    {
        string[] urls = 
        {
            "https://ash-speed.hetzner.com/100MB.zip",
            "https://ash-speed.hetzner.com/1GB.zip",
            "https://ash-speed.hetzner.com/10GB.zip"
        };

        string[] paths = 
        {
            @"C:\Downloads\DownloadRequest\100MB\100MB.zip",
            @"C:\Downloads\DownloadRequest\1GB\1GB.zip",
            @"C:\Downloads\DownloadRequest\10GB\10GB.zip"
        };

        for (int i = 0; i < urls.Length; i++)
        {
            await BaixarArquivoPorRequisicao(urls[i], paths[i]);
        }
    }

    public async Task BaixarArquivosPorClique()
    {
        var links = driver.FindElements(By.XPath("//a[contains(text(), 'MB') or contains(text(), 'GB')]"));
        foreach (var link in links)
        {
            string text = link.Text.ToUpper();
            string folder = text.Contains("100MB") ? "100MB" : text.Contains("1GB") ? "1GB" : "10GB";
            string path = $@"C:\Downloads\DownloadClick\{folder}\{text}.zip";

            await BaixarArquivoPorRequisicao(link.GetAttribute("href"), path);
        }
    }

    public async Task BaixarArquivoPorRequisicao(string url, string caminho)
    {
        using (HttpClient client = new HttpClient())
        {
            var response = await client.GetAsync(url);
            using (var fileStream = new FileStream(caminho, FileMode.Create))
            {
                await response.Content.CopyToAsync(fileStream);
            }
        }
    }

    public void Finalizar()
    {
        driver.Quit();
    }
}
