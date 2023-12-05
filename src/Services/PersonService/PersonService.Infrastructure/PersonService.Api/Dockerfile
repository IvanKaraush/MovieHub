FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/Services/PersonService/PersonService.Infrastructure/PersonService.Api/PersonService.Api.csproj", "Services/PersonService/PersonService.Infrastructure/PersonService.Api/"]
COPY ["../Libraries/ExceptionsLibrary/ExceptionsLibrary.csproj", "../Libraries/ExceptionsLibrary/"]
COPY ["src/Services/PersonService/PersonService.Application/PersonService.Application.Services/PersonService.Application.Services.csproj", "Services/PersonService/PersonService.Application/PersonService.Application.Services/"]
COPY ["src/Services/PersonService/PersonService.Domain/PersonService.Domain/PersonService.Domain.csproj", "Services/PersonService/PersonService.Domain/PersonService.Domain/"]
COPY ["src/GuardExtensions/GuardExtensions.csproj", "GuardExtensions/"]
COPY ["src/Services/PersonService/PersonService.Infrastructure/PersonService.Infrastructure.Repositories/PersonService.Infrastructure.Repositories.csproj", "Services/PersonService/PersonService.Infrastructure/PersonService.Infrastructure.Repositories/"]
COPY ["src/Services/PersonService/PersonService.Infrastructure/PersonService.Infrastructure.Data/PersonService.Infrastructure.Data.csproj", "Services/PersonService/PersonService.Infrastructure/PersonService.Infrastructure.Data/"]
RUN dotnet restore "Services/PersonService/PersonService.Infrastructure/PersonService.Api/PersonService.Api.csproj"
COPY . .
WORKDIR "src/Services/PersonService/PersonService.Infrastructure/PersonService.Api/"
RUN dotnet build "PersonService.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PersonService.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PersonService.Api.dll"]
