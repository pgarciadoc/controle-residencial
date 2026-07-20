
# Controle Residencial

O Controle Residencial é uma aplicação web full stack desenvolvida utilizando **ASP.NET Core (C#)** no backend e **React com TypeScript** no frontend.

O sistema permite o gerenciamento de pessoas e de suas transações financeiras, aplicando regras de negócio, calculando indicadores financeiros e apresentando as informações por meio de uma interface moderna e intuitiva.

Embora tenha sido desenvolvido como parte de um teste técnico, o projeto foi estruturado seguindo boas práticas de engenharia de software, incluindo arquitetura em camadas, utilização de DTOs, separação de responsabilidades por meio de Services, consumo de API REST e componentização no frontend com Material UI.

# Controle Residencial

Sistema desenvolvido como solução para o teste técnico proposto, utilizando **ASP.NET Core (C#)** no backend e **React + TypeScript** no frontend.

O objetivo do projeto é realizar o gerenciamento de pessoas e suas transações financeiras, aplicando regras de negócio, cálculos de totais e apresentando uma interface moderna e intuitiva.

---

# Tecnologias Utilizadas

## Backend

- ASP.NET Core 8
- C#
- Entity Framework Core
- SQLite
- Swagger / OpenAPI

## Frontend

- React
- TypeScript
- Material UI (MUI)
- Axios
- React Router

---

# Arquitetura do Projeto

O projeto foi desenvolvido utilizando separação em camadas, visando organização, reutilização de código e facilidade de manutenção.

## Backend

```
Controllers
│
├── DTOs
│
├── Services
│
├── Models
│
├── Data (DbContext)
│
└── Migrations
```

Cada camada possui uma responsabilidade específica:

- **Controllers:** recebem as requisições HTTP.
- **Services:** concentram toda a regra de negócio.
- **DTOs:** realizam a comunicação entre API e Frontend.
- **Models:** representam as entidades do banco.
- **Data:** configuração do Entity Framework.
- **Migrations:** controle de versão do banco de dados.

---

## Frontend

```
components
│
├── dashboard
├── layout
├── pessoa
├── totais
└── transacao

pages

services

types

routes
```

A interface foi organizada em componentes reutilizáveis, permitindo escalabilidade e manutenção facilitada.

---

# Funcionalidades Implementadas

## Cadastro de Pessoas

Implementado:

- Cadastro de pessoas
- Listagem de pessoas
- Exclusão de pessoas
- Atualização automática da tabela após operações

Campos:

- Nome
- Idade

---

## Cadastro de Transações

Implementado:

- Cadastro de transações
- Listagem de transações
- Associação obrigatória com uma pessoa

Campos:

- Pessoa
- Descrição
- Valor
- Tipo (Receita ou Despesa)

---

## Regra de Negócio

Foi implementada integralmente a regra solicitada no desafio.

Caso a pessoa possua idade inferior a 18 anos:

- Receitas não podem ser cadastradas;
- Apenas despesas são permitidas.

Quando essa regra é violada:

- a API retorna **HTTP 400 (BadRequest)**;
- o frontend exibe a mensagem utilizando Snackbar.

---

## Exclusão em Cascata

Ao excluir uma pessoa:

- todas as suas transações são removidas automaticamente.

Essa funcionalidade foi implementada utilizando o relacionamento entre as entidades no Entity Framework.

---

# Página de Totais

Foi criada uma página exclusiva para exibir indicadores financeiros.

São apresentados:

- Total de Receitas
- Total de Despesas
- Saldo Líquido

Todos os valores são calculados no backend.

---

## Totais por Pessoa

Além do total geral, também foi implementado o cálculo individual por pessoa.

Cada pessoa possui:

- Total de Receitas
- Total de Despesas
- Saldo Individual

---

# Dashboard

Como funcionalidade adicional, foi desenvolvido um Dashboard para fornecer uma visão geral do sistema.

O Dashboard apresenta:

- Quantidade total de pessoas cadastradas
- Quantidade total de transações
- Saldo líquido geral
- Últimas transações cadastradas

Essa funcionalidade não fazia parte dos requisitos originais do desafio.

---

# Interface

Toda a interface foi construída utilizando Material UI.

Foram implementados:

- Layout responsivo
- Menu lateral
- Navegação entre páginas
- Cards informativos
- Dialog para cadastros
- Snackbar para mensagens de sucesso e erro
- DataGrid com paginação
- Formatação monetária em Real (R$)
- Destaque visual para receitas e despesas
- Saldo negativo destacado em vermelho
- Saldo positivo destacado em verde

---

# Estrutura da API

## Pessoas

| Método | Endpoint |
|---------|----------|
| GET | /api/Pessoas |
| GET | /api/Pessoas/{id} |
| POST | /api/Pessoas |
| DELETE | /api/Pessoas/{id} |

---

## Transações

| Método | Endpoint |
|---------|----------|
| GET | /api/Transacoes |
| POST | /api/Transacoes |

---

## Totais

| Método | Endpoint |
|---------|----------|
| GET | /api/Totais |

---

# Banco de Dados

O projeto utiliza SQLite.

A criação do banco é realizada automaticamente através das migrations do Entity Framework Core.

---

# Documentação da API

Foi configurado o Swagger para documentação e testes dos endpoints.

Ao iniciar a aplicação backend, basta acessar:

```
https://localhost:{porta}/swagger
```

---

# Como Executar o Projeto

## Backend

Entrar na pasta do backend

```
cd ControleResidencial
```

Restaurar pacotes

```
dotnet restore
```

Executar migrations

```
dotnet ef database update
```

Executar aplicação

```
dotnet run
```

---

## Frontend

Entrar na pasta

```
cd cr_frontend
```

Instalar dependências

```
npm install
```

Executar

```
npm run dev
```

---

# Diferenciais Implementados

Além dos requisitos obrigatórios do teste técnico, foram implementadas diversas melhorias para tornar a aplicação mais organizada, escalável e agradável ao usuário.

## Backend

✔ Arquitetura em camadas

✔ Utilização de DTOs

✔ Separação completa entre Controller e Service

✔ Entity Framework Core

✔ SQLite

✔ Swagger

✔ Tratamento de erros HTTP

✔ Regra de negócio centralizada

✔ Exclusão em cascata

✔ Endpoint exclusivo para Dashboard/Totais

---

## Frontend

✔ React com TypeScript

✔ Componentização

✔ Organização por módulos

✔ Material UI

✔ DataGrid

✔ Cards informativos

✔ Dashboard

✔ Página exclusiva de Totais

✔ Snackbar

✔ Dialog para cadastros

✔ Paginação

✔ Formatação monetária

✔ Valores positivos e negativos destacados por cor

✔ Interface limpa e moderna

✔ Atualização automática das informações após operações

---

# Requisitos Atendidos

## Backend

✅ Cadastro de Pessoas

✅ Listagem de Pessoas

✅ Exclusão de Pessoas

✅ Exclusão em Cascata

✅ Cadastro de Transações

✅ Listagem de Transações

✅ Regra para menores de idade

✅ Endpoint de Totais

✅ Entity Framework

✅ SQLite

✅ Swagger

---

## Frontend

✅ Layout completo

✅ Menu lateral

✅ Página de Pessoas

✅ Página de Transações

✅ Página de Totais

✅ Dashboard

✅ Cards informativos

✅ Últimas transações

✅ Dialog de cadastro

✅ Snackbar

✅ Paginação

✅ Formatação monetária

✅ Indicadores coloridos

---

# Decisões Técnicas

Durante o desenvolvimento do projeto foram adotadas algumas decisões técnicas visando organização, escalabilidade e facilidade de manutenção da aplicação.

## Arquitetura em Camadas

O backend foi estruturado em camadas, separando responsabilidades entre Controllers, Services, DTOs, Models e Data.

Essa organização proporciona:

- Melhor manutenção do código;
- Separação entre regras de negócio e requisições HTTP;
- Facilidade para evolução do projeto;
- Maior reutilização de código.

---

## Utilização de DTOs

Foram utilizados DTOs (Data Transfer Objects) para realizar a comunicação entre a API e o frontend.

Essa abordagem evita a exposição direta das entidades do banco de dados e permite controlar exatamente quais informações são enviadas e recebidas pela aplicação.

Também facilita futuras alterações nas entidades sem impactar o frontend.

---

## Entity Framework Core

Foi utilizado o Entity Framework Core como ORM da aplicação.

As principais vantagens dessa escolha foram:

- Maior produtividade no acesso aos dados;
- Mapeamento objeto-relacional simplificado;
- Controle de versionamento do banco através de Migrations;
- Facilidade na implementação dos relacionamentos entre entidades.

---

## SQLite

O SQLite foi escolhido como banco de dados devido à sua simplicidade de configuração e facilidade de execução durante o desenvolvimento e avaliação do teste técnico.

Como o banco é baseado em arquivo, não há necessidade de instalação de um servidor dedicado, tornando a execução do projeto mais simples.

---

## Material UI

No frontend foi utilizada a biblioteca Material UI.

A escolha foi motivada por oferecer:

- Componentes prontos e consistentes;
- Layout responsivo;
- Facilidade de customização;
- Interface moderna e profissional.

Isso permitiu focar no desenvolvimento da aplicação sem abrir mão da qualidade visual.

---

## Componentização

Toda a interface foi dividida em componentes reutilizáveis.

Exemplos:

- DashboardCard
- TotalCard
- PessoaTable
- TransacaoTable
- UltimasTransacoesTable
- Dialogs de cadastro

Essa abordagem reduz duplicação de código e facilita futuras alterações.

---

## React com TypeScript

O frontend foi desenvolvido utilizando React juntamente com TypeScript.

A utilização do TypeScript trouxe benefícios como:

- Tipagem estática;
- Maior segurança durante o desenvolvimento;
- Melhor experiência com IntelliSense;
- Redução de erros em tempo de execução.

---

## Separação dos Services

Toda comunicação com a API foi centralizada na pasta `services`.

Cada módulo possui seu próprio serviço:

- pessoaService
- transacaoService
- totaisService

Essa organização evita repetição de código e facilita futuras alterações na comunicação com a API.

---

## Tratamento de Erros

Foi implementado tratamento de erros tanto no backend quanto no frontend.

No backend:

- retorno adequado de códigos HTTP;
- validações de regras de negócio;
- mensagens claras para o consumidor da API.

No frontend:

- tratamento utilizando Axios;
- exibição de mensagens através de Snackbar;
- feedback visual para operações realizadas com sucesso ou erro.

---

## Dashboard

Embora não fosse um requisito obrigatório do desafio, foi desenvolvido um Dashboard para fornecer uma visão geral da aplicação.

O Dashboard apresenta:

- quantidade de pessoas cadastradas;
- quantidade de transações;
- saldo líquido geral;
- últimas transações realizadas.

Essa funcionalidade aproxima a aplicação da experiência encontrada em sistemas ERP utilizados no mercado.

---

## Experiência do Usuário

Algumas melhorias foram implementadas pensando na experiência do usuário:

- atualização automática das tabelas após operações;
- formulários em Dialog;
- Snackbar para feedback imediato;
- formatação de valores em Real (R$);
- destaque visual para receitas e despesas;
- indicadores financeiros em Cards;
- organização visual através do Material UI.

Essas melhorias não eram obrigatórias no desafio, porém foram implementadas para tornar a aplicação mais intuitiva e agradável de utilizar.

# Considerações Finais

Durante o desenvolvimento, buscou-se seguir boas práticas de organização, separação de responsabilidades e componentização tanto no backend quanto no frontend.

Embora o desafio propusesse apenas os requisitos básicos, foram implementadas funcionalidades adicionais, como Dashboard, indicadores financeiros, melhorias visuais e organização em camadas, visando entregar uma solução mais completa, escalável e próxima de uma aplicação utilizada em ambiente corporativo.