FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

ENV ASPNETCORE_URLS=http://+:80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["mvc-web-app/mvc-web-app.csproj", "mvc-web-app/"]
RUN dotnet restore "mvc-web-app/mvc-web-app.csproj"
COPY . .
WORKDIR "/src/mvc-web-app"
RUN dotnet build "mvc-web-app.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "mvc-web-app.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "mvc-web-app.dll"]
