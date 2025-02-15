using System.Text;
using EM.Core.Models;
using EM.Infrastructure;
using EM.Infrastructure.Configuration.Extensions;
using EM.Infrastructure.Data;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using EM.Web.Components;
using EM.Web.Components.Account;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Azure;
using IdentityConstants = Microsoft.AspNetCore.Identity.IdentityConstants;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddCascadingAuthenticationState();
builder.Services.AddScoped<IdentityUserAccessor>();
builder.Services.AddScoped<IdentityRedirectManager>();
builder.Services.AddScoped<AuthenticationStateProvider, IdentityRevalidatingAuthenticationStateProvider>();

builder.Services.ConfigureDataServices(builder.Configuration);
builder.Services.ConfigureCQRS();

builder.Services.AddAuthentication(options =>
    {
        options.DefaultScheme = IdentityConstants.ApplicationScheme;
        options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
    })
    .AddIdentityCookies();


if (!builder.Environment.IsDevelopment())
{
    var connectionString = builder.Configuration["ConnectionStrings:Azure:SqlDb"] ??
                           throw new InvalidOperationException("Connection string 'ConnectionStrings:Azure:SqlDb' not found.");
    builder.Services.AddDbContext<ApplicationDbContext>(options =>
        options.UseSqlServer(connectionString));
    
    var storageConnectionString = builder.Configuration["ConnectionStrings:Azure:Storage"] 
                                  ?? throw new InvalidOperationException("Connection string 'ConnectionStrings:Azure:Storage' not found.");
    
    builder.Services.AddAzureClients(azureBuilder =>
    {
        azureBuilder.AddBlobServiceClient(storageConnectionString);
    });
}
else
{
    builder.AddSqlServerDbContext<ApplicationDbContext>("database");
}

builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddHttpClient();
builder.Services.AddControllers();

builder.Services.AddIdentityCore<ApplicationUser>(options => { options.SignIn.RequireConfirmedAccount = false; })
    .AddRoles<ApplicationRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddSignInManager()
    .AddUserManager<UserManager<ApplicationUser>>()
    .AddRoleManager<RoleManager<ApplicationRole>>();

builder.Services.AddSingleton<IEmailSender<ApplicationUser>, IdentityNoOpEmailSender>();
builder.Services.AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:SecretKey"]))
        };
    });

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReactApp", policy =>
    {
        policy.WithOrigins("https://localhost:5173") // Your React app's URL
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials();
    });
});

var app = builder.Build();

app.UseMiddleware<RefreshClaimsMiddleware>();
app.UseCors("AllowReactApp");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.MapFallbackToFile("index.html");
app.UseStaticFiles();
app.UseAntiforgery();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<ApplicationDbContext>();
    var pendingMigrations = await context.Database.GetPendingMigrationsAsync();

    if (pendingMigrations.Any())
    {
        await context.Database.MigrateAsync();
    }
    await SeedData.Initialize(services);
}

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

// Add additional endpoints required by the Identity /Account Razor components.
app.MapAdditionalIdentityEndpoints();
app.MapControllers();

app.Run();