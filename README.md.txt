# AgendaApp.API

AgendaApp.API é um projeto desenvolvido para permitir o controle de cadastro, edição, consulta e exclusão de tarefas, organizadas de acordo com suas prioridades.

## Funcionalidades

- **Cadastro de Tarefas**: Permite adicionar novas tarefas com nome, descrição, data/hora e prioridade.
- **Edição de Tarefas**: Permite atualizar os dados de uma tarefa existente.
- **Consulta de Tarefas**: Permite visualizar as tarefas cadastradas.
- **Exclusão de Tarefas**: Permite remover tarefas cadastradas.

## Tecnologias Utilizadas

- **ASP.NET Core**: Framework principal utilizado para desenvolvimento da API.
- **SQL Server**: Banco de dados utilizado para persistência dos dados.
- **Entity Framework Core**: ORM utilizado para interagir com o banco de dados.
- **DDD (Domain-Driven Design)**: Padrão arquitetural utilizado para organizar o código.
- **XUnit**: Framework de testes utilizado para garantir a qualidade do código.

## Estrutura do Projeto

O projeto segue os princípios do DDD, dividindo as responsabilidades em camadas distintas:

- **Domain**: Contém as entidades, agregados, repositórios e serviços de domínio.
- **Application**: Contém os serviços de aplicação que coordenam as operações.
- **Infrastructure**: Contém a implementação dos repositórios e a configuração do banco de dados.
- **API**: Contém os controladores da API e os modelos de request/response.

## Requisitos

- **.NET 6.0 SDK** ou superior
- **SQL Server**

## Configuração

1. Clone o repositório:
   ```bash
   git clone https://github.com/seu-usuario/AgendaApp.API.git
   cd AgendaApp.API
