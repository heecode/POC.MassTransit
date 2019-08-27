FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["Poc.MassTransit.ClientWeb/Poc.MassTransit.ClientWeb.csproj", "Poc.MassTransit.ClientWeb/"]
RUN dotnet restore "Poc.MassTransit.ClientWeb/Poc.MassTransit.ClientWeb.csproj"
COPY . .
WORKDIR "/src/Poc.MassTransit.ClientWeb"
RUN dotnet build "Poc.MassTransit.ClientWeb.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Poc.MassTransit.ClientWeb.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Poc.MassTransit.ClientWeb.dll"]