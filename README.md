
# 📘 Desafio Target Sistemas – API .NET (Comissões, Estoque e Juros)

Este projeto implementa uma API REST em **ASP.NET Core 8**, contendo três operações principais:

1. **Cálculo de comissões de vendedores**
2. **Movimentação de estoque (entrada/saída)**
3. **Cálculo de juros por atraso (2,5% ao dia)**

O projeto foi estruturado utilizando:

* Injeção de dependência (Dependency Injection)
* Controllers REST
* Swagger/OpenAPI para testes
* Services organizados por interface
* DTOs de Request e Response
* Validações básicas de domínio

---

# 🚀 Como Executar o Projeto

## ✅ Pré-requisitos

Certifique-se de ter instalado:

* **.NET SDK 8 ou superior**
  [https://dotnet.microsoft.com/en-us/download](https://dotnet.microsoft.com/en-us/download)
* Editor recomendado:

  * VS Code + C# DevKit
  * Visual Studio 2022
---

## ▶️ Passo a passo para executar

### 1. Clone ou baixe o repositório:

```bash
git clone https://github.com/KleberJuca/desafio-target-sistemas.git
cd desafio-target-sistemas
```

### 2. Restaure os pacotes:

```bash
dotnet restore
```

### 3. Compile:

```bash
dotnet build
```

### 4. Execute a API:

```bash
dotnet run
```

---

## 🌐 Acessando o Swagger

Após rodar, abra no navegador:
IIS
```
https://localhost:44300/
```

ou (dependendo da porta configurada)

```
https://localhost:5001/
http://localhost:5000/
```

O Swagger abrirá automaticamente com todos os endpoints organizados.

---

# 🏗️ Arquitetura do Projeto

A estrutura principal segue o padrão:

```
📁 Desafio_Target_Sistemas
 ├── 📁 Controllers
 │    └── DesafioController.cs
 ├── 📁 Service
 │    └── DesafioService.cs
 ├── 📁 Interface
 │    └── IDesafioService.cs
 ├── 📁 Configurations
 │    └── DependencyInjection.cs
 ├── 📁 Models
 │    └── (Requests e Responses)
 ├── Program.cs
 └── README.md
```

### ✔️ Principles utilizados

* **SOLID**
* **Separação de responsabilidades**
* **Services desacoplados de Controllers**
* **Injeção de dependência configurada via extensão**

---

# 📡 Endpoints Disponíveis

## 1️⃣ Calcular Comissões

`POST /api/desafio/comissoes`

### Body esperado:

```json
[
  { "vendedor": "João", "valor": 1200.50 },
  { "vendedor": "João", "valor": 300.00 }
]
```

### Regra:

* Venda < 100 → 0%
* Venda < 500 → 1%
* Venda ≥ 500 → 5%

Retorna total vendido + total de comissão por vendedor.

---

## 2️⃣ Movimentar Estoque

`POST /api/desafio/estoque/movimentar`

### Body esperado:

```json
{
  "estoque": [
    { "codigoProduto": 101, "descricaoProduto": "Caneta Azul", "estoque": 150 }
  ],
  "codigoProduto": 101,
  "tipo": "S",
  "quantidade": 10,
  "descricao": "Venda balcão"
}
```

### Regras:

* `E` → Entrada
* `S` → Saída
* Não permite saída maior que estoque
* Retorna estoque atualizado + ID da movimentação

---

## 3️⃣ Calcular Juros

`POST /api/desafio/juros`

### Body:

```json
{
  "valor": 1000.00,
  "dataVencimento": "2025-01-10"
}
```

### Regra:

* Juros = **2,5% ao dia atrasado**

Retorna juros total e valor final.

---

# 🧩 Implementação Técnica

## ✔️ Dependency Injection

Arquivo: `DependencyInjection.cs`

```csharp
services.AddScoped<IDesafioService, DesafioService>();
```

## ✔️ Controller centralizado

`DesafioController.cs`
(expõe 3 endpoints REST)

## ✔️ Service responsável pela lógica

`DesafioService.cs`
(contem todas regras de negócio)

## ✔️ DTOs

Modelos de entrada/saída bem definidos:

* `VendaRequest`, `ComissaoResponse`
* `MovimentacaoRequest`, `MovimentacaoResponse`
* `JurosRequest`, `JurosResponse`

---

# 🛠️ Como Foi Feito

* Criado projeto base com `dotnet new webapi`
* Adicionado Swagger com versão customizada
* Criado controller `DesafioController`
* Separado regras de negócio em `DesafioService`
* Criada interface `IDesafioService` para desacoplamento
* Implementadas validações por exceções no service
* Criado método de extensão para registrar serviços
* Documentação automática via Swagger
* Testado e validado todos os casos com payloads completos

---

# 📄 Licença

Projeto criado como desafio técnico.
Pode usar, alterar, melhorar e reutilizar à vontade.

---
