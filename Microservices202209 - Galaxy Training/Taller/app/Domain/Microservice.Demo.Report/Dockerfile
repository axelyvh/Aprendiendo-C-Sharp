#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["app/Domain/Microservice.Demo.Report/Microservice.Demo.Report.csproj", "app/Domain/Microservice.Demo.Report/"]
RUN dotnet restore "app/Domain/Microservice.Demo.Report/Microservice.Demo.Report.csproj"
COPY . .
WORKDIR "/src/app/Domain/Microservice.Demo.Report"
RUN dotnet build "Microservice.Demo.Report.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Microservice.Demo.Report.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Microservice.Demo.Report.dll"]