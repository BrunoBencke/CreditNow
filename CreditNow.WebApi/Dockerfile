FROM mcr.microsoft.com/dotnet/aspnet:7.0 as base
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build

WORKDIR /source

#Copiar csproj e restaurar as camadas
COPY src/CreditNow.Core/*.csproj ./src/CreditNow.Core/
COPY src/CreditNow.WebApi/*.csproj ./src/CreditNow.WebApi/
RUN dotnet restore src/CreditNow.WebApi/

#Copiar tudo e fazer a build
COPY . .
WORKDIR /source/src/CreditNow.WebApi/
RUN dotnet publish -c Release -o /app
FROM base AS final

#Build com a imagem do runtime

WORKDIR /app
COPY --from=build /app/ .
#ENTRYPOINT ["dotnet", "CreditNow.WebApi.dll"]

#Usa porta dinamica
CMD ASPNETCORE_URLS="http://*:$PORT" dotnet CreditNow.WebApi.dll
