#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["../ShoppingCart.API/ShoppingCart.API.csproj", "ShoppingCart.API/"]
COPY ["../ShoppingCart.Repositories/ShoppingCart.Repositories.csproj", "ShoppingCart.Repositories/"]
COPY ["../ShoppingCart.Contracts/ShoppingCart.Contracts.csproj", "ShoppingCart.Contracts/"]
COPY ["../ShoppingCart.Entities/ShoppingCart.Entities.csproj", "ShoppingCart.Entities/"]
COPY ["../ShoppingCart.Services/ShoppingCart.Services.csproj", "ShoppingCart.Services/"]
RUN dotnet restore "ShoppingCart.API/ShoppingCart.API.csproj"
COPY . .
WORKDIR "/src/ShoppingCart.API"
RUN dotnet build "ShoppingCart.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ShoppingCart.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ShoppingCart.API.dll"]