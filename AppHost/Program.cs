var builder = DistributedApplication.CreateBuilder(args);

var db = builder.AddSqlServer("sql")
    .WithLifetime(ContainerLifetime.Persistent)
    .AddDatabase("database");


var webApp = builder
    .AddProject("em-web", "../EM.Web/EM.Web.csproj")
    .WithReference(db)
    .WaitFor(db);

builder.Build().Run();