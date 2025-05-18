# Etapa 1: Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copia apenas o arquivo do projeto primeiro para otimizar cache
COPY ["SistemaIntegradoDeGestao.csproj", "./"]
RUN dotnet restore

# Agora copia o restante dos arquivos
COPY . .
RUN dotnet publish -c Release -o out

# Etapa 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app

# Copia os arquivos publicados da etapa anterior
COPY --from=build /app/out .

# Expõe a porta padrão do ASP.NET
EXPOSE 80

# Define a entrada do contêiner
ENTRYPOINT ["dotnet", "SistemaIntegradoDeGestao.dll"]
