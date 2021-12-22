FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build-env
WORKDIR app-desafio
EXPOSE 80
EXPOSE 5024

# Copy csproj and restore as distinct layers
COPY src/AppDesafio.Api/AppDesafio.Api.csproj ./
RUN dotnet restore

# Copy everything else and build
COPY . ./
RUN dotnet publish AppDesafio.sln -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/sdk:5.0
WORKDIR /app-desafio
COPY --from=build-env /app-desafio/out .

ENTRYPOINT ["dotnet", "AppDesafio.Api.dll"]