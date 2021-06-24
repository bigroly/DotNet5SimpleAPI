ProductsApi

## Notes
### Dependencies to get the thing workign initially:
`dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL --version 5.0.2`
`dotnet add package Microsoft.EntityFrameworkCore.Design --version 5.0.5`
`dotnet tool install --global dotnet-ef`

## Building:
### Docker Build Command
`docker-compose up -d`

### Migrations
`dotnet ef migrations add InitialMigration`
`dotnet ef database update`