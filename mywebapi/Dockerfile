FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

ENV ASPNETCORE_URLS=http://+:80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["mywebapi/mywebapi.csproj", "mywebapi/"]
RUN dotnet restore "mywebapi/mywebapi.csproj"
COPY . .
WORKDIR "/src/mywebapi"
RUN dotnet build "mywebapi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "mywebapi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "mywebapi.dll"]
