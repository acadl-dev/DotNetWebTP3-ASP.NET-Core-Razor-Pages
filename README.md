# 🏖️ CityBreaks Portal (em produção...)

> Sistema completo de cadastro e consulta de propriedades turísticas desenvolvido em ASP.NET Core com Razor Pages

## 🎯 Sobre o Projeto

O CityBreaks Portal é uma aplicação web moderna que simula um sistema real de reservas turísticas, demonstrando domínio completo do ecossistema .NET para desenvolvimento web. O projeto implementa desde conceitos básicos até técnicas avançadas de persistência de dados e arquitetura de software.

## ✨ Funcionalidades

### ✅ Fase 1: Fundação (Exercícios 1-5)
-  Configuração completa do Entity Framework Core
-  Modelagem relacional (1:N) entre Country → City → Property
-  Sistema de migrações automatizado
-  Configurações avançadas com Fluent API
-  Validação e constraints de dados


### 🚧 Fase 2: Operações CRUD (Exercícios 6-12)
- Seed Data para população inicial
- Serviços com consultas otimizadas (Include/ThenInclude)
- Páginas dinâmicas com parâmetros de URL
- Formulários seguros com validação server-side
- Sistema de Soft Delete para auditoria
- Filtros dinâmicos e consultas complexas


## 📁 Estrutura do Projeto

```
CityBreaks.Web/
├── 📁 Data/
│   ├── CityBreaksContext.cs      # DbContext principal
│   └── 📁 Configurations/        # Fluent API configurations
│       ├── CountryConfiguration.cs
│       ├── CityConfiguration.cs
│       └── PropertyConfiguration.cs
├── 📁 Models/                    # Entidades de domínio
│   ├── Country.cs               # Países
│   ├── City.cs                  # Cidades
│   └── Property.cs              # Propriedades turísticas
├── 📁 Services/                 # Camada de negócio
│   ├── ICityService.cs
│   ├── CityService.cs
│   └── PropertyService.cs
└── 📁 Pages/                    # Interface Razor Pages
```

## 🔧 Como Executar

### Pré-requisitos
- .NET 8.0 SDK
- SQL Server LocalDB ou instância completa
- Visual Studio 2022 ou VS Code

### Instalação
```bash
# Clone o repositório
git clone https://github.com/acadl-dev/DotNetWebTP3-ASP.NET-Core-Razor-Pages.git

# Navegue até o diretório
cd CityBreaks.Web/

# Execute a aplicação
dotnet run
```

### Acesso
- **URL:** `https://localhost:5001`


## 💡 Destaques Técnicos

### Processamento de Dados
- **Arquitetura Limpa** Separação clara de responsabilidades com Data, Models e Services
- **Entity Framework Core** Implementação completa com Code First, Migrations e Fluent API
- **Design Patterns**  Repository Pattern, Dependency Injection e Service Layer
- **Segurança de Dados**  Validação robusta com TryUpdateModel e proteção contra over-posting
- **Performance:**  Lazy Loading otimizado e consultas eficientes com LINQ
- **Soft Delete**  Implementação de exclusão lógica para auditoria e recuperação de dados



## 📈 Próximos Passos

- API REST: Exposição de endpoints para integração mobile
- Autenticação: Sistema de usuários com ASP.NET Identity
- Cache: Implementação com Redis para alta performance
- Testes: Cobertura completa com xUnit e Moq
- Docker: Containerização para deploy simplificado














## 📈 Métricas do Sistema

O dashboard apresenta métricas calculadas dinamicamente:
- Agregação de dados em tempo real
- Filtros por status automatizados
- Cálculos financeiros precisos
- Ordenação cronológica inteligente

## 🎓 Contexto Acadêmico

Este projeto foi desenvolvido como trabalho prático da disciplina de **Desenvolvimento Back-end**, demonstrando:

- **Aplicação prática** de conceitos teóricos
- **Resolução de problemas** do mundo real
- **Arquitetura escalável** e mantível
- **Boas práticas** de desenvolvimento

---

⭐ **Se este projeto foi útil, considere dar uma estrela no repositório!**