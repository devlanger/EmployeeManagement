<h2>1. Entity Framework</h2>
<h3>1.1 Adding Migration</h3>
* Migrations are executed with code-first approach and will try to apply all migrations at the startup.

Add migration command:

`dotnet ef migrations add AddEmployees -s ./EM.Web/EM.Web.csproj -p ./EF.Infrastructure/EM.Infrastructure.csproj -c ApplicationDbContex`

<h2>Todo</h2>
-[x] Add CQRS   
-[ ] Add roles and authorization to add employees and give salaries