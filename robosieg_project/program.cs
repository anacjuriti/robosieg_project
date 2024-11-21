using System;
using System.Threading.Tasks;

namespace robosieg_project
{
    class Program
    {
        static async Task Main(string[] args)
        {
            //configura as pastas para armazenar os arquivos baixados
            DirectoryManager.CreateDirectories();

            //inicializa o robô que realizará as ações
            Robo robo = new Robo();
            
            //passo 1: acessa o Google
            robo.CarregarGoogle();
            //passo 2: realiza a pesquisa pelo termo desejado
            robo.PesquisarTestFiles();
            //passo 3: localiza e clica no site específico
            robo.ClicarNoSite();

            //passo 4: baixa os arquivos usando diferentes métodos
            //método 4.1: baixa os arquivos por meio de requisições diretas
            await robo.BaixarArquivosPorRequisicao();
            //método 4.2: baixa os arquivos simulando cliques
            await robo.BaixarArquivosPorClique();

            //passo 5: finaliza o processo
            robo.Finalizar();
        }
    }
}

/* 
    Objetivo do projeto:
    Este robô automatizado foi desenvolvido para realizar as seguintes tarefas:
    - Acessar o Google e buscar o termo "Test-Files".
    - Identificar e clicar no link de um site específico.
    - Realizar o download de arquivos de diferentes tamanhos:
        - Usando requisições programadas.
        - Simulando cliques manuais.
    - Organizar e salvar os arquivos baixados em pastas estruturadas.
    - Implementar testes unitários para garantir o funcionamento correto do robô.
*/

// Classe Program (program.cs): Define o ponto de entrada do programa e organiza o fluxo principal do robô.

// Classe Robo (robo.cs): Contém a lógica central, como acesso à web e operações de download.


/*objetivo criar um robô automatizado em C#, que:

Acesse o Google.
Pesquise pelo termo "Test-Files".
Clique no link de um site específico.
Baixe arquivos de tamanhos diferentes tanto por clique quanto por requisição (downloads programados).
Salve os arquivos em pastas organizadas no seu computador.
Utilize testes unitários para garantir que o robô funcione corretamente. */


//Classe Program (program.cs): Onde o programa é iniciado e o fluxo principal é definido

//Classe Robo (robo.cs): Contém a lógica principal, como acessar páginas da web e baixar arquivos.