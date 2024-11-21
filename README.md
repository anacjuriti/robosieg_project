# RoboSieG
---
## Descrição

O RoboSieG é um robô de automação desenvolvido em C# usando Selenium WebDriver e HttpClient. Ele navega na web para encontrar e baixar arquivos de teste de sites específicos.

## Funcionalidades

- **Navegação na web**:
  - Acessa a página inicial do Google.
  - Realiza pesquisas por "Test-Files".
  - Clica em links para acessar sites de arquivos de teste.

- **Download de arquivos**:
  - Baixa arquivos diretamente via requisições HTTP.
  - Identifica e baixa arquivos clicando em links na página web.
  - Cria diretórios necessários antes do download.
  - Monitora o progresso do download com logs detalhados.

## Tecnologias Utilizadas

- **Linguagem de Programação**: C#
- **Framework**: .NET 9.0
- **Bibliotecas/Pacotes**:
  - Selenium.WebDriver (4.26.1)
  - Selenium.WebDriver.ChromeDriver (131.0.6778.8500)
  - Selenium.Support (4.26.1)
  - HttpClient

## Estrutura do Projeto

- `Robo.cs`: Classe principal contendo métodos para navegação e download de arquivos.
- Métodos principais:
  - `CarregarGoogle()`
  - `PesquisarTestFiles()`
  - `ClicarNoSite()`
  - `BaixarArquivosPorRequisicao()`
  - `BaixarArquivosPorClique()`
  - `BaixarArquivoPorRequisicao(string url, string caminho)`
  - `Finalizar()`

## Pré-requisitos

Certifique-se de ter o .NET SDK instalado em sua máquina. Você pode baixar a versão mais recente [aqui](https://dotnet.microsoft.com/download).

## Instalação

1. Clone o repositório para sua máquina local:
   ```sh
   git clone https://github.com/seu_usuario/URL_DO_SEU_REPOSITORIO.git
   cd URL_DO_SEU_REPOSITORIO
   ```

2. Restaure os pacotes NuGet:
   ```sh
   dotnet restore
   ```

## Uso

### Compilar o Projeto

Para compilar o projeto, use o seguinte comando:
```sh
dotnet build
```

### Executar o Projeto

Para executar o projeto, use o seguinte comando:
```sh
dotnet run --project robosieg_project/robosieg_project.csproj
```

### Logs e Debugging

O projeto inclui logs detalhados para monitorar o progresso dos downloads e identificar possíveis erros. Verifique o console para mensagens de log durante a execução.

## Contribuição

Se quiser contribuir com este projeto, siga os passos abaixo:

1. Faça um fork do repositório.
2. Crie uma branch para sua feature ou correção (`git checkout -b feature/nova-feature`).
3. Commit suas alterações (`git commit -m 'Adicionar nova feature'`).
4. Envie para a branch (`git push origin feature/nova-feature`).
5. Abra um Pull Request.

## Licença

Este projeto está licenciado sob a Licença MIT. Veja o arquivo [LICENSE](LICENSE) para mais detalhes.

## Contato

Se tiver dúvidas ou sugestões, entre em contato:
- Nome: Ana Guimarães
- E-mail: anacjuriti@gmail.com

---

