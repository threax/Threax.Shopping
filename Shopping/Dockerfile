FROM microsoft/dotnet:2.1.3-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM threax/build AS build
WORKDIR /src
COPY Shopping/Shopping.csproj Shopping/
RUN dotnet restore Shopping/Shopping.csproj
COPY . .
WORKDIR /src/Shopping
RUN yarn run yarn-install
RUN yarn run clean
RUN yarn run build
RUN dotnet build Shopping.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish Shopping.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Shopping.dll"]
