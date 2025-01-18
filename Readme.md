[![Demo Video](https://raw.githubusercontent.com/username/repository/branch/path/to/thumbnail.jpg)](https://raw.githubusercontent.com/devlanger/EmployeeManagement/Assets/demo.mp4)

<h2>1. Entity Framework</h2>
<h3>1.1 Adding Migration</h3>
* Migrations are executed with code-first approach and will try to apply all migrations at the startup.

Add migration command:

`dotnet ef migrations add AddEmployees -s ./EM.Web/EM.Web.csproj -p ./EM.Infrastructure/EM.Infrastructure.csproj -c ApplicationDbContext`

<h2>Todo</h2>
-[x] Add CQRS and use to communicate (FE <-> Controllers <-> MediatR)
-[x] Add AutoMapper and use for View Model mappings
-[x] Add roles and authorization to add employees and give salaries