# Etapa 1: Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copia arquivos do projeto
COPY . . 

# Restaura dependências
RUN dotnet restore

# Publica o app em modo Release
RUN dotnet publish -c Release -o out

# Etapa 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app

# Copia os arquivos publicados da etapa anterior
COPY --from=build /app/out .

# Expõe a porta padrão do ASP.NET
EXPOSE 80

# Comando de entrada
ENTRYPOINT ["dotnet", "SistemaIntegradoDeGestao.dll"]
