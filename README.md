# Sistema Integrado de Gestão 📋

## 🚧 Status do Projeto

Projeto em desenvolvimento ativo com foco em aplicar princípios de **Domain-Driven Design (DDD)** e **Clean Architecture** para melhorar a organização, manutenção e escalabilidade do código.

Contribuições, sugestões e relatórios de problemas são bem-vindos via issues ou pull requests.

---

## 📖 Sobre o Projeto

O **Sistema Integrado de Gestão** é uma API construída com **ASP.NET Core** que gerencia processos relacionados a funcionários, equipes e materiais, aplicando conceitos de DDD e Clean Architecture para garantir um código modular, desacoplado e testável.

O projeto estrutura claramente as responsabilidades em camadas e domínios, facilitando a evolução e manutenção.

---

## 🚀 Funcionalidades

* Gestão completa de **Funcionários** (CRUD).
* Gestão de **Materiais** (CRUD).
* Gestão de **Equipes** (CRUD).
* Associação entre funcionários e equipes.
* Registro de solicitações de materiais por equipes.
* Paginação para endpoints de listagem.

---

## 🏗️ Arquitetura e Organização

O projeto segue a **Clean Architecture** combinada com os princípios de **Domain-Driven Design (DDD)**, organizado nas seguintes camadas:

* **Domain (Domínio):**
  Contém as entidades, agregados, objetos de valor, interfaces de repositório e regras de negócio essenciais do sistema. Esta camada não depende de nenhuma outra.

* **Application (Aplicação):**
  Contém a lógica de caso de uso, serviços de aplicação, interfaces e DTOs. Responsável por coordenar as operações do domínio e preparar os dados para a camada externa.

* **Infrastructure (Infraestrutura):**
  Implementações específicas de acesso a dados (por exemplo, EF Core com MySQL), integrações externas e outras dependências técnicas.

* **API (Interface):**
  Camada de apresentação que expõe os endpoints HTTP via controllers do ASP.NET Core, orquestrando chamadas à camada de aplicação.

---

## 📂 Estrutura de Pastas

```
/src
  /Domain
    /Entities
    /Interfaces
    /ValueObjects
    /Specifications
  /Application
    /DTOs
    /Services
    /Interfaces
    /Mappings (AutoMapper)
  /Infrastructure
    /Data
    /Repositories
    /Configurations (EF Core)
  /API
    /Controllers
    /Models (ViewModels)
    /Configurations
```

---

## 📚 Tecnologias Utilizadas

* **Linguagem:** C#
* **Framework:** ASP.NET Core
* **Banco de Dados:** MySQL com Entity Framework Core (Pomelo.EntityFrameworkCore.MySql)
* **Padrões:**

  * Domain-Driven Design (DDD)
  * Clean Architecture
  * Repositório
  * Injeção de Dependência
* **Bibliotecas:** AutoMapper, FluentValidation (para validações, opcional)

---

## 📋 Domínios Principais

* **Funcionário:** Informações pessoais e profissionais.
* **Equipe:** Conjunto de funcionários.
* **Material:** Recursos gerenciados e solicitados.
* **Requisição de Material:** Solicitações feitas pelas equipes.

---

## 🔧 Melhorias Futuras

* [X] Implementar autenticação e autorização com Identity ou JWT.
* [ ] Criar testes unitários e de integração para as camadas.
* [ ] Melhorar logging e tratamento de exceções.
* [ ] Implementar CQRS e Mediator para comandos e consultas.
* [ ] Automatizar CI/CD para deploy contínuo.
