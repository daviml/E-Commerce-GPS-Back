# 💻 Backend - Sistema de Gerenciamento de E-commerce

O backend é uma API RESTful desenvolvida em ASP.NET Core que gerencia todas as operações de dados do sistema, seguindo as regras de negócio de um e-commerce fictício.

## ✨ Funcionalidades da API

- **Autenticação:** Endpoint de login simples.
- **CRUD de Entidades:** Endpoints para Clientes, Produtos e Pedidos.
- **Lógica de Negócio:**
    - Validação de dados de entrada usando DTOs.
    - Regras de negócio para pedidos (pagar e cancelar).
    - Armazenamento de histórico de alterações de status.
- **Arquitetura:**
    - Segue o padrão de Arquitetura de Camadas (Controller -> Service -> Repository).
    - Utiliza Injeção de Dependência para um código desacoplado.
    - Dados armazenados em memória para simplificar a demo.

## 🛠️ Tecnologias e Ferramentas

- **Linguagem:** C#
- **Framework:** .NET 8
- **ORM:** Nenhum (dados em memória)
- **Testes:** xUnit
- **Documentação:** Swagger/OpenAPI

## 📦 Como Rodar o Projeto

### Pré-requisitos
- .NET 8 SDK

Para executar o projeto, navegue até a pasta do backend e utilize os seguintes comandos:

```bash
# Para rodar a aplicação
dotnet run

# Para rodar os testes unitários
dotnet test