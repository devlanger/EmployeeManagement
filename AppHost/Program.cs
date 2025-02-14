var builder = DistributedApplication.CreateBuilder(args);

var db = builder.AddSqlServer("em-sql")
    .WithLifetime(ContainerLifetime.Persistent)
    .AddDatabase("main");


var webApp = builder
    .AddProject("em-web", "../EM.Web/EM.Web.csproj")
    .WithReference(db);

builder.Build().Run();