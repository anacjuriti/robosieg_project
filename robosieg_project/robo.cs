
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;  
using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace robosieg_project
{
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
                "https://ash-speed.hetzner.com/100MB.bin",
                "https://ash-speed.hetzner.com/1GB.bin",
                "https://ash-speed.hetzner.com/10GB.bin"
            };

            string[] paths =
            {
                @"C:\Users\didig\Downloads\DownloadRequest\100MB\100MB.bin",
                @"C:\Users\didig\Downloads\DownloadRequest\1GB\1GB.bin",
                @"C:\Users\didig\Downloads\DownloadRequest\10GB\10GB.bin"
            };

            // Criar diretórios
            for (int i = 0; i < paths.Length; i++)
            {
                string? directory = Path.GetDirectoryName(paths[i]);
                if (directory != null && !Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }
            }

            for (int i = 0; i < urls.Length; i++)
            {
                try
                {
                    Console.WriteLine($"Baixando {urls[i]} para {paths[i]}");
                    await BaixarArquivoPorRequisicao(urls[i], paths[i]);
                    Console.WriteLine($"Download de {urls[i]} concluído.");
                }
                catch (HttpRequestException e)
                {
                    Console.WriteLine($"Erro ao baixar {urls[i]}: {e.Message}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Erro inesperado ao baixar {urls[i]}: {ex.Message}");
                }
            }
        }

        public async Task BaixarArquivosPorClique()
        {
            var links = driver.FindElements(By.XPath("//a[contains(text(), 'MB') or contains(text(), 'GB')]"));
            foreach (var link in links)
            {
                string text = link.Text.ToUpper();
                string folder = text.Contains("100MB") ? "100MB" : text.Contains("1GB") ? "1GB" : "10GB";
                string path = $@"C:\Users\didig\Downloads\DownloadClick\{folder}\{text}.bin";

                // Criar diretórios
                string? directory = Path.GetDirectoryName(path);
                if (directory != null && !Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }

                try
                {
                    Console.WriteLine($"Baixando {link.GetAttribute("href")} para {path}");
                    await BaixarArquivoPorRequisicao(link.GetAttribute("href"), path);
                    Console.WriteLine($"Download de {link.GetAttribute("href")} concluído.");
                }
                catch (HttpRequestException e)
                {
                    Console.WriteLine($"Erro ao baixar {link.GetAttribute("href")}: {e.Message}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Erro inesperado ao baixar {link.GetAttribute("href")}: {ex.Message}");
                }
            }
        }

        public async Task BaixarArquivoPorRequisicao(string url, string caminho)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    Console.WriteLine($"Iniciando download de {url}");
                    var response = await client.GetAsync(url, HttpCompletionOption.ResponseHeadersRead);
                    response.EnsureSuccessStatusCode();
                    using (var stream = await response.Content.ReadAsStreamAsync())
                    using (var fileStream = new FileStream(caminho, FileMode.Create, FileAccess.Write, FileShare.None, 8192, useAsync: true))
                    {
                        var buffer = new byte[8192];
                        int bytesRead;
                        long totalBytesRead = 0;
                        var startTime = DateTime.Now;

                        while ((bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length)) > 0)
                        {
                            await fileStream.WriteAsync(buffer, 0, bytesRead);
                            totalBytesRead += bytesRead;
                            Console.WriteLine($"Baixando {bytesRead} bytes do arquivo {url}, Total de bytes baixados: {totalBytesRead}");

                            // Limitar tempo de download para 5 minutos (300 segundos)
                            if ((DateTime.Now - startTime).TotalSeconds > 300)
                            {
                                Console.WriteLine($"Tempo limite de download excedido para {url}");
                                break;
                            }
                        }
                    }
                    Console.WriteLine($"Arquivo salvo em {caminho}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Erro ao baixar arquivo de {url}: {ex.Message}");
                    throw;
                }
            }
        }

        public void Finalizar()
        {
            driver.Quit();
        }

        public IWebDriver GetDriver()
        {
            return driver;
        }
    }

    // A definição da classe DirectoryManager é removida
}



/*using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;  // Adicionando referência ao Selenium.Support
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace robosieg_project
{
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
                "https://ash-speed.hetzner.com/100MB.bin",
                "https://ash-speed.hetzner.com/1GB.bin",
                "https://ash-speed.hetzner.com/10GB.bin"
            };

            string[] paths =
            {
                @"C:\Users\didig\Downloads\DownloadRequest\100MB\100MB.bin",
                @"C:\Users\didig\Downloads\DownloadRequest\1GB\1GB.bin",
                @"C:\Users\didig\Downloads\DownloadRequest\10GB\10GB.bin"
            };

            // Criar diretórios
            for (int i = 0; i < paths.Length; i++)
            {
                string? directory = Path.GetDirectoryName(paths[i]);
                if (directory != null && !Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }
            }

            for (int i = 0; i < urls.Length; i++)
            {
                try
                {
                    Console.WriteLine($"Baixando {urls[i]} para {paths[i]}");
                    await BaixarArquivoPorRequisicao(urls[i], paths[i]);
                    Console.WriteLine($"Download de {urls[i]} concluído.");
                }
                catch (HttpRequestException e)
                {
                    Console.WriteLine($"Erro ao baixar {urls[i]}: {e.Message}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Erro inesperado ao baixar {urls[i]}: {ex.Message}");
                }
            }
        }

        public async Task BaixarArquivosPorClique()
        {
            var links = driver.FindElements(By.XPath("//a[contains(text(), 'MB') or contains(text(), 'GB')]"));
            foreach (var link in links)
            {
                string text = link.Text.ToUpper();
                string folder = text.Contains("100MB") ? "100MB" : text.Contains("1GB") ? "1GB" : "10GB";
                string path = $@"C:\Users\didig\Downloads\DownloadClick\{folder}\{text}.bin";

                // Criar diretórios
                string? directory = Path.GetDirectoryName(path);
                if (directory != null && !Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }

                try
                {
                    Console.WriteLine($"Baixando {link.GetAttribute("href")} para {path}");
                    await BaixarArquivoPorRequisicao(link.GetAttribute("href"), path);
                    Console.WriteLine($"Download de {link.GetAttribute("href")} concluído.");
                }
                catch (HttpRequestException e)
                {
                    Console.WriteLine($"Erro ao baixar {link.GetAttribute("href")}: {e.Message}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Erro inesperado ao baixar {link.GetAttribute("href")}: {ex.Message}");
                }
            }
        }

        public async Task BaixarArquivoPorRequisicao(string url, string caminho)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                using (var response = await client.GetAsync(url, HttpCompletionOption.ResponseHeadersRead))
                {
                    response.EnsureSuccessStatusCode();
                    using (var stream = await response.Content.ReadAsStreamAsync())
                    using (var fileStream = new FileStream(caminho, FileMode.Create, FileAccess.Write, FileShare.None, 8192, useAsync: true))
                    {
                        var buffer = new byte[8192];
                        int bytesRead;
                        long totalBytesRead = 0;
                        while ((bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length)) > 0)
                        {
                            await fileStream.WriteAsync(buffer, 0, bytesRead);
                            totalBytesRead += bytesRead;
                            Console.WriteLine($"Baixando {bytesRead} bytes do arquivo {url}, Total de bytes baixados: {totalBytesRead}");
                        }
                    }
                    Console.WriteLine($"Arquivo salvo em {caminho}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao baixar arquivo de {url}: {ex.Message}");
                throw;
            }
        }

        public void Finalizar()
        {
            driver.Quit();
        }

        public IWebDriver GetDriver()
        {
            return driver;
        }
    }

    // A definição da classe DirectoryManager é removida
}


 */