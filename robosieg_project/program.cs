using System;
using System.Threading.Tasks;

namespace robosieg_project
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // Cria as pastas necessárias
            DirectoryManager.CreateDirectories();

            // Cria uma instância do robô
            Robo robo = new Robo();
            
            // Executa as ações do robô
            robo.CarregarGoogle();
            robo.PesquisarTestFiles();
            robo.ClicarNoSite();

            // Baixa os arquivos por requisição
            await robo.BaixarArquivosPorRequisicao();
            // Baixa os arquivos por clique
            await robo.BaixarArquivosPorClique();

            // Finaliza o robô
            robo.Finalizar();
        }
    }
}


/*objetivo criar um robô automatizado em C#, que:

Acesse o Google.
Pesquise pelo termo "Test-Files".
Clique no link de um site específico.
Baixe arquivos de tamanhos diferentes tanto por clique quanto por requisição (downloads programados).
Salve os arquivos em pastas organizadas no seu computador.
Utilize testes unitários para garantir que o robô funcione corretamente. */


//Classe Program (program.cs): Onde o programa é iniciado e o fluxo principal é definido

//Classe Robo (robo.cs): Contém a lógica principal, como acessar páginas da web e baixar arquivos.