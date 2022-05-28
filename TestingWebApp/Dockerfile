FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["TestingWebApp/TestingWebApp.csproj", "TestingWebApp/"]
RUN dotnet restore "TestingWebApp/TestingWebApp.csproj"
COPY . .
WORKDIR "/src/TestingWebApp"
RUN dotnet build "TestingWebApp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TestingWebApp.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TestingWebApp.dll"]
