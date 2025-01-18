[![EM Demo](https://img.youtube.com/vi/dDwdu6Elq8c/0.jpg)](https://www.youtube.com/watch?v=dDwdu6Elq8c)

<h2>1. Entity Framework</h2>
<h3>1.1 Adding Migration</h3>
* Migrations are executed with code-first approach and will try to apply all migrations at the startup.

Add migration command:

`dotnet ef migrations add AddEmployees -s ./EM.Web/EM.Web.csproj -p ./EM.Infrastructure/EM.Infrastructure.csproj -c ApplicationDbContext`

<h2>Todo</h2>
-[x] Add CQRS and use to communicate (FE <-> Controllers <-> MediatR)
-[x] Add AutoMapper and use for View Model mappings
-[x] Add roles and authorization to add employees and give salaries