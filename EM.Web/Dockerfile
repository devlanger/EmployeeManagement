FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["EM.Web/EM.Web.csproj", "EM.Web/"]
RUN dotnet restore "EM.Web/EM.Web.csproj"
COPY . .
WORKDIR "/src/EM.Web"
RUN dotnet build "EM.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "EM.Web.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EM.Web.dll"]
