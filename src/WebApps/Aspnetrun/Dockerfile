FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["WebApps/Aspnetrun/Aspnetrun.csproj", "WebApps/Aspnetrun/"]
RUN dotnet restore "WebApps/Aspnetrun/Aspnetrun.csproj"
COPY . .
WORKDIR "/src/WebApps/Aspnetrun"
RUN dotnet build "Aspnetrun.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Aspnetrun.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Aspnetrun.dll"]