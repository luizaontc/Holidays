# Imagem base com o ASP.NET Core Runtime
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

# Definir o ambiente de produção
ENV ASPNETCORE_ENVIRONMENT=Production

# Imagem de build com SDK
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Copiar o arquivo .csproj e restaurar as dependências
COPY ["Calendario.csproj", "."]
RUN dotnet restore "./Calendario.csproj"

# Copiar o restante do código fonte
COPY . .

# Publicar a aplicação
RUN dotnet publish "./Calendario.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Imagem final para a execução da aplicação
FROM base AS final
WORKDIR /app

# Copiar os arquivos publicados do container de build
COPY --from=build /app/publish .

# Configurar o ponto de entrada da aplicação
ENTRYPOINT ["dotnet", "Calendario.dll"]
