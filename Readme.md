<h1>Employee Management Application</h1>
<h2>1. Watch demo video: </h2>

[![EM Demo](https://img.youtube.com/vi/dDwdu6Elq8c/0.jpg)](https://www.youtube.com/watch?v=dDwdu6Elq8c)

<h2>2. Entity Framework</h2>
<h3>2.2 Adding Migration</h3>
* Migrations are executed with code-first approach and will try to apply all migrations at the startup.

Add migration command:

`dotnet ef migrations add AddEmployees -s ./EM.Web/EM.Web.csproj -p ./EM.Infrastructure/EM.Infrastructure.csproj -c ApplicationDbContext`

<h2>3. Todo List</h2>
-[x] Add CQRS and use to communicate (FE <-> Controllers <-> MediatR)
-[x] Add AutoMapper and use for View Model mappings
-[x] Add roles and authorization to add employees and give salaries
-[ ] Refresh roles after user update
-[ ] Rewrite identity to mediator and api
