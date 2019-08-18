FROM mcr.microsoft.com/dotnet/core/aspnet:2.2 AS base
WORKDIR /app

FROM threax/build AS build
WORKDIR /src
COPY . .
WORKDIR /src/Shopping
RUN npm install
RUN dotnet restore Shopping.csproj
RUN dotnet build Shopping.csproj -c Release -o /app
RUN npm run clean
RUN npm run build

FROM build AS publish
RUN dotnet publish Shopping.csproj -c Release -o /app

FROM base AS final
ENV DOTNET_CLI_TELEMETRY_OPTOUT=1
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Shopping.dll"]
