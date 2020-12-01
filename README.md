Os arquivos de migrations estão no projeto BAckEndTest.Infra.Data
Na tela de console executar o Migrations com os seguites comandos

PM>EntityFrameworkCore\update-database -Context BackEndTestContext
PM>EntityFrameworkCore\update-database -Context EventStoreSQLContext

  Eu executei na tela de package manager Console, por isso os "PM>"
## Technologies implemented:

- ASP.NET Core 2.2 (with .NET Core 2.2)
 - ASP.NET MVC Core 
 - ASP.NET WebApi Core
 - ASP.NET Identity Core
- Entity Framework Core 2.2
- .NET Core Native DI
- AutoMapper
- FluentValidator
- MediatR
- Swagger UI

## Architecture:

- Full architecture with responsibility separation concerns, SOLID and Clean Code
- Domain Driven Design (Layers and Domain Model Pattern)
- Domain Events
- Domain Notification
- CQRS (Imediate Consistency)
- Event Sourcing
- Unit of Work
- Repository and Generic Repository
