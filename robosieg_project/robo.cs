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
            //inicializando o driver do chrome para automação do navegador
            driver = new ChromeDriver();
        }

        public void CarregarGoogle()
        {
            //acessando a página inicial do google
            driver.Navigate().GoToUrl("https://www.google.com");
        }

        public void PesquisarTestFiles()
        {
            //localizando a barra de pesquisa do google e digitando o termo de busca
            var searchBox = driver.FindElement(By.Name("q"));
            searchBox.SendKeys("Test-Files");
            searchBox.Submit(); //enviando o formulário de pesquisa
        }

        public void ClicarNoSite()
        {
            //encontrando o link do site solicitado nos resultados e clicando
            var link = driver.FindElement(By.CssSelector("a[href='https://ash-speed.hetzner.com/']"));
            link.Click();
        }

        public async Task BaixarArquivosPorRequisicao()
        {
            //lista de URLs de arquivos para download direto por requisição
            string[] urls =
            {
                "https://ash-speed.hetzner.com/100MB.bin",
                "https://ash-speed.hetzner.com/1GB.bin",
                "https://ash-speed.hetzner.com/10GB.bin"
            };

            //caminhos de destino para salvar os arquivos no disco local
            string[] paths =
            {
                @"C:\Users\didig\Downloads\DownloadRequest\100MB\100MB.bin",
                @"C:\Users\didig\Downloads\DownloadRequest\1GB\1GB.bin",
                @"C:\Users\didig\Downloads\DownloadRequest\10GB\10GB.bin"
            };

            //criação das pastas necessárias para salvar os arquivos
            for (int i = 0; i < paths.Length; i++)
            {
                string? directory = Path.GetDirectoryName(paths[i]);
                if (directory != null && !Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }
            }

            //baixando os arquivos individualmente
            for (int i = 0; i < urls.Length; i++)
            {
                try
                {
                    Console.WriteLine($"Iniciando download de {urls[i]} para {paths[i]}...");
                    await BaixarArquivoPorRequisicao(urls[i], paths[i]);
                    Console.WriteLine($"Download concluído: {urls[i]}");
                }
                catch (HttpRequestException e)
                {
                    // Logando falhas específicas de requisições HTTP
                    Console.WriteLine($"Erro ao baixar {urls[i]}: {e.Message}");
                }
                catch (Exception ex)
                {
                    // Lidando com erros inesperados
                    Console.WriteLine($"Erro inesperado ao baixar {urls[i]}: {ex.Message}");
                }
            }
        }

        public async Task BaixarArquivosPorClique()
        {
            //selecionar links que tenham "MB" ou "GB" no texto
            var links = driver.FindElements(By.XPath("//a[contains(text(), 'MB') or contains(text(), 'GB')]"));
            foreach (var link in links)
            {
                string text = link.Text.ToUpper();
                //determinando a pasta com base no tamanho do arquivo
                string folder = text.Contains("100MB") ? "100MB" : text.Contains("1GB") ? "1GB" : "10GB";
                string path = $@"C:\Users\didig\Downloads\DownloadClick\{folder}\{text}.bin";

                //criando o diretório de destino, se necessário
                string? directory = Path.GetDirectoryName(path);
                if (directory != null && !Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }

                try
                {
                    Console.WriteLine($"Iniciando download via clique: {link.GetAttribute("href")} para {path}");
                    await BaixarArquivoPorRequisicao(link.GetAttribute("href"), path);
                    Console.WriteLine($"Download via clique concluído: {link.GetAttribute("href")}");
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
                    Console.WriteLine($"Baixando arquivo de {url}...");
                    var response = await client.GetAsync(url, HttpCompletionOption.ResponseHeadersRead);
                    response.EnsureSuccessStatusCode(); //aqui confirma se a resposta foi bem sucedida

                    //salvando o conteudo do arquivo no caminho especificado
                    using (var stream = await response.Content.ReadAsStreamAsync())
                    using (var fileStream = new FileStream(caminho, FileMode.Create, FileAccess.Write, FileShare.None, 8192, useAsync: true))
                    {
                        var buffer = new byte[8192];
                        int bytesRead;
                        while ((bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length)) > 0)
                        {
                            await fileStream.WriteAsync(buffer, 0, bytesRead);
                        }
                    }
                    Console.WriteLine($"Arquivo salvo com sucesso em {caminho}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Erro ao realizar download de {url}: {ex.Message}");
                    throw;
                }
            }
        }

        public void Finalizar()
        {
            //fechar o driver e encerrar a sessão do navegador
            driver.Quit();
        }

        public IWebDriver GetDriver()
        {
            //retorna o driver atual para uso em testes
            return driver;
        }
    }
}


