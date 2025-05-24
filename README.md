# Aplicação de Cadastro de Clientes com Windows Forms e MySQL

Este projeto consiste em uma aplicação desktop desenvolvida com **C#** e **Windows Forms** para o cadastro, consulta, alteração e exclusão de clientes, utilizando MySQL como banco de dados e seguindo o padrão Repository disponibilizado pelo professor **Pablo Rodrigo Gonçalves**.

## Funcionalidades

- **Cadastro de Clientes:** Inserção de dados como nome, endereço e telefone.

- **Consulta por ID:** Buscar cliente com base no código informado.

- **Alteração de Dados:** Permite atualizar os dados existentes no banco.

- **Exclusão de Cliente:** Remoção segura de clientes cadastrados.

- **Interface Simples e Funcional:** Formulários limpos, com foco em usabilidade.

- **Separação em Camadas:** Modelo **(Cliente.cs)**, Repositório **(ClienteRepository.cs)** e Interface **(Windows Forms)**.

## Tecnologias Utilizadas

### Linguagens:
- <a href="https://dotnet.microsoft.com/pt-br/languages/csharp" target="_blank"><img src="https://cdn.jsdelivr.net/gh/devicons/devicon@latest/icons/csharp/csharp-original.svg" height="30" alt="Csharp logo"/></a><img width="12"/>

- <a href="https://www.mysql.com/" target="_blank"><img src="https://cdn.jsdelivr.net/gh/devicons/devicon@latest/icons/mysql/mysql-original-wordmark.svg" height="30" alt="MySQL logo"/></a><img width="12"/>

### Frameworks e Bibliotecas:
- Windows Forms (.NET Framework 4.7.2) <a href="https://dotnet.microsoft.com/" target="_blank"><img src="https://cdn.jsdelivr.net/gh/devicons/devicon@latest/icons/dot-net/dot-net-original-wordmark.svg" height="30" alt="Microsoft .NET logo"/></a><img width="12"/>

- <a href="https://visualstudio.microsoft.com/" target="_blank"><img src="https://cdn.jsdelivr.net/gh/devicons/devicon@latest/icons/visualstudio/visualstudio-original.svg" height="30" alt="Visual Studio logo"/></a><img width="12"/>

- MySql.Data (via NuGet) <a href="https://www.nuget.org/" target="_blank"><img src="https://cdn.jsdelivr.net/gh/devicons/devicon@latest/icons/nuget/nuget-original.svg" height="30" alt="NuGet logo"/></a><img width="12"/>

## Funcionalidades Implementadas

- **FormInserir:** Tela para inserir novos clientes no banco.

- **FormBuscar:** Tela única para:

  - Pesquisar cliente por ID

  - Alterar dados do cliente

  - Excluir cliente

- **ClienteRepository:** Classe responsável pelas operações no banco (CRUD), usando o padrão Repository.

- Validação básica de entrada e mensagens de feedback amigáveis ao usuário.


## Banco de Dados
- O sistema utiliza um banco MySQL com a seguinte estrutura:
   ```bash
   CREATE DATABASE cadastro_clientes;
    USE cadastro_clientes;
    CREATE TABLE Clientes (
      IdClientes INT PRIMARY KEY,
      Nome VARCHAR(100),
      Endereco VARCHAR(200),
      Telefone VARCHAR(20)
    );
   ```
- A connectionString está configurada no arquivo App.config:
   ```bash
    <connectionStrings>
      <add name="MySQLConnectionString" connectionString="Server=localhost Database=cadastro_clientes;Uid=root;Pwd=root;Connect Timeout=30;" providerName="MySql.Data.MySqlClient" />
    </connectionStrings>
   ```

## Como Rodar o Projeto

### Pré-Requisitos:

- MySQL Server instalado e rodando localmente
- Visual Studio 2022 ou superior
- .NET Framework 4.7.2
- Pacote NuGet MySql.Data instalado

### Passos:

1. Clone este repositório:
   ```bash
   git clone https://github.com/viniciuslft/repository-refactor.git
   cd repository-refactor
   ```
2. Abra o projeto no Visual Studio.
3. Verifique se o MySQL está rodando e a base cadastro_clientes está criada.
4. Pressione F5 para executar a aplicação.
5. Use o menu Clientes > Inserir para adicionar registros e Clientes > Pesquisar para editar ou excluir.

### Organização do Projeto
  ```bash
    repository1/
    │
    ├── Cliente.cs
    ├── ClienteRepository.cs
    ├── Form1.cs
    ├── FormInserir.cs
    ├── FormBuscar.cs
    ├── App.config
    └── ...
  ```

  ### Atividade da Aula 11/06
  - Esta aplicação foi desenvolvida como entrega da atividade de banco de dados da aula do dia 11/04 da disciplina Programação Comercial, com os seguintes aprimoramentos:
    - Código refatorado em camadas
    - Separação de formulários
    - Funções de inserção, pesquisa, alteração e exclusão

  ### Observações
  - Removi as opções "Alterar" e "Excluir" do menu porque essas funcionalidades já estão incluídas no formulário "Pesquisar" (FormBuscar). Dessa forma, tudo ficou centralizado em um único lugar, evitando formulários repetidos e deixando o sistema mais simples e funcional.