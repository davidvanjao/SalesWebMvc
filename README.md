# SalesWebMvc

Projeto ASP.NET Core MVC para gerenciamento de vendas, com funcionalidades para controle de departamentos, vendedores e registros de vendas. Inclui tela de login e geração de relatórios em PDF.

## Pré requisitos

- Visual Studio Code
- .NET Core SDK 2.1
- MySQL
- Ferramenta `dotnet-ef` instalada

Caso não tenha instalado a ferramenta dotnet-ef, que é usada para gerenciar migrações do Entity Framework. Para instalá-la, execute o seguinte comando no terminal:

1. No prompt, realize a instalação do dotnet-ef
```bash
 dotnet tool install --global dotnet-ef
```
2. Verifique se a intalação foi bem sucessida: 
```bash
  dotnet ef --version
```
Se a versão for exibida corretamente, a ferramenta está pronta para uso.

## Instalação

1. Clone este repositório:
   ```bash
   git clone https://github.com/davidvanjao/SalesWebMvc.git
   ```
2. Abra o projeto no Visual Studio Code ou Visual Studio.
3. Restaure os pacotes NuGet:
   ```bash
   dotnet restore
   ```
4. Configure a string de conexão com o banco de dados no arquivo appsettings.json:

   ```bash
    "ConnectionStrings": {
    "SalesWebMvcContext": "server=localhost;userid=USUARIO;password=SENHA;database=saleswebmvcappdb"
    }
   ```

5. Execute as migrações para criar o banco de dados:
   ```bash
   dotnet ef database update
   ```

## Uso

1. Execute o projeto:
   ```bash
   dotnet run
   ```
2. No terminal, verifique a porta em que a aplicação está sendo executada (geralmente algo como https://localhost:5001 ou https://localhost:7040).

3. Acesse o aplicativo no navegador utilizando o endereço exibido, por exemplo:
   ```bash
   https://localhost:5001   
   ```
4. Use as seguintes credenciais para acessar o sistema: 
- Login: admin@admin.com 
- Senha: 123

## Funcionalidades

- Cadastro, edição e exclusão de departamentos
- Cadastro, edição e exclusão de vendedores
- Registro e consulta de vendas realizadas
- Tela de login para autenticação de usuários
- Tela de login para autenticação de usuários

## Licença

Este projeto está licenciado sob a Licença MIT.

## Resumo da Licença MIT:

A Licença MIT permite que você faça quase qualquer coisa com o código, incluindo usá-lo, copiá-lo, modificá-lo, mesclá-lo, publicá-lo, distribuí-lo, sublicenciá-lo e/ou vendê-lo, desde que a seguinte declaração de copyright e a isenção de responsabilidade sejam incluídas em todas as cópias ou partes substanciais do software.

O software é fornecido "no estado em que se encontra", sem qualquer tipo de garantia expressa ou implícita, incluindo, mas não se limitando a, garantias de comercialização ou adequação a um propósito específico. Em nenhum caso os autores ou detentores de direitos autorais serão responsáveis por qualquer reclamação, dano ou outra responsabilidade, seja em uma ação contratual, delito ou de outro tipo, decorrente de, ou em conexão com, o software ou o uso ou outros negócios no software.

