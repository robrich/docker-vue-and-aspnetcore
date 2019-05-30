FROM mcr.microsoft.com/dotnet/core/sdk:3.0-alpine as build

WORKDIR /src

COPY NetApi.csproj .
RUN dotnet restore

COPY . .
RUN dotnet build -c Release

# RUN dotnet test ...

RUN dotnet publish -c Release -o /dist


FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-alpine

WORKDIR /app

ENV ASPNETCORE_ENVIRONMENT Production
ENV ASPNETCORE_URLS http://+:5000
EXPOSE 5000

COPY --from=build /dist .

CMD ["dotnet", "NetApi.dll"]
