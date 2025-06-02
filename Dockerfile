FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /app

# Copia somente o arquivo csproj para a pasta de trabalho no container
COPY ["Sistema_Integrado_de_Gestao.csproj", "./"]

# Restaura as dependências usando o csproj copiado
RUN dotnet restore "Sistema_Integrado_de_Gestao.csproj"

# Copia o resto do código para a pasta de trabalho dentro do container
COPY . .

# Faz o build do projeto
RUN dotnet build "Sistema_Integrado_de_Gestao.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Sistema_Integrado_de_Gestao.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Sistema_Integrado_de_Gestao.dll"]
