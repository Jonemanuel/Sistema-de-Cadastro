# 📋 Sistema de Cadastro com Integração ao SQL Server

Bem-vindo ao **Sistema de Cadastro**, uma solução robusta para gerenciamento de dados com integração direta ao **SQL Server**. Este projeto foi desenvolvido para demonstrar uma aplicação funcional e eficiente, conectando uma interface amigável a um banco de dados relacional.

---

## 🚀 Funcionalidades

- **Cadastro de Usuários**: Insira informações como nome, e-mail e outros dados relevantes.
- **Atualização de Dados**: Edite as informações cadastradas diretamente no sistema.
- **Exclusão de Registros**: Remova registros indesejados de forma prática.
- **Consulta de Dados**: Pesquise e visualize informações armazenadas no banco de dados.
- **Integração com SQL Server**: Totalmente conectado ao banco de dados para persistência e manipulação de dados.

---

## 📷 Capturas de Tela

### Tela Principal
<div align="center">
    <img src="caminho/para/imagem1.png" alt="Tela Principal" width="600">
</div>

---

## 🛠️ Tecnologias Utilizadas

- **.NET Framework/Core**: Para desenvolvimento do backend e interface.
- **C#**: Linguagem de programação principal.
- **SQL Server**: Banco de dados utilizado para armazenar e gerenciar informações.
- **Entity Framework**: Para mapeamento objeto-relacional (opcional).
- **Windows Forms (WinForms)** ou **ASP.NET MVC**: Para a interface, dependendo do tipo de aplicação.

---

## 📄 Como Configurar e Executar

1. **Pré-requisitos**:
   - SQL Server instalado e configurado.
   - Ambiente de desenvolvimento .NET (Visual Studio recomendado).

2. **Configuração do Banco de Dados**:
   - Crie um banco de dados no SQL Server com a seguinte estrutura:
   ```sql
   CREATE TABLE Usuarios (
       Id INT PRIMARY KEY IDENTITY(1,1),
       Nome NVARCHAR(100),
       Email NVARCHAR(100),
       DataCadastro DATETIME DEFAULT GETDATE()
   );
