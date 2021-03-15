#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/runtime:3.1-buster-slim AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["Product.Subscriber/Product.Subscriber.csproj", "Product.Subscriber/"]
COPY ["DeliVeggieApp.Services/Product.Messages/ProductMessages/Product.Messages.csproj", "DeliVeggieApp.Services/Product.Messages/ProductMessages/"]
RUN dotnet restore "Product.Subscriber/Product.Subscriber.csproj"
COPY . .
WORKDIR "/src/Product.Subscriber"
RUN dotnet build "Product.Subscriber.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Product.Subscriber.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Product.Subscriber.dll"]