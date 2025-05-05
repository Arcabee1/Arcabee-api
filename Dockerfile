# Etapa base: Define a imagem de runtime para a aplicação final
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 8080

ENV ASPNETCORE_URLS=http://+:8080

# Etapa de build: Usa o SDK do .NET para compilar a aplicação
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG configuration=Release
WORKDIR /src
COPY ["Arcabee.Api/Arcabee.Api.csproj", "Arcabee.Api/"]
COPY ["Arcabee.DataTransfer/Arcabee.DataTransfer.csproj", "Arcabee.DataTransfer/"]
COPY ["Arcabee.Aplicacao/Arcabee.Aplicacao.csproj", "Arcabee.Aplicacao/"]
COPY ["Arcabee.Infra/Arcabee.Infra.csproj", "Arcabee.Infra/"]
COPY ["Arcabee.Ioc/Arcabee.Ioc.csproj", "Arcabee.Ioc/"]
RUN dotnet restore "Arcabee.Api/Arcabee.Api.csproj"
COPY . .
WORKDIR "/src/Arcabee.Api"
RUN dotnet build "Arcabee.Api.csproj" -c $configuration -o /app/build
# Etapa de publish: Publica a aplicação em modo release
FROM build AS publish
ARG configuration=Release
RUN dotnet publish "Arcabee.Api.csproj" -c $configuration -o /app/publish /p:UseAppHost=false
# Etapa final: Cria a imagem de runtime com os binários publicados
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Arcabee.Api.dll"]
