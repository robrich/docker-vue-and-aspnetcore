# build .NET app:
FROM mcr.microsoft.com/dotnet/core/sdk:3.0-alpine as buildnet

WORKDIR /src

COPY NetApi/NetApi.csproj .
RUN dotnet restore

COPY NetApi .
RUN dotnet build -c Release

# RUN dotnet test ...

RUN dotnet publish -c Release -o /dist


# build Vue app:
FROM node:alpine as buildvue

WORKDIR /src

COPY vueapp/package.json .
RUN npm install

# webpack build
COPY vueapp .
RUN npm run build


# Copy results from both places into production container:
FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-alpine

WORKDIR /app

ENV ASPNETCORE_ENVIRONMENT Production
ENV ASPNETCORE_URLS http://+:5000
EXPOSE 5000

# copy .net content
COPY --from=buildnet /dist .
# copy vue content into .net's static files folder:
COPY --from=buildvue /src/dist /app/wwwroot

CMD ["dotnet", "NetApi.dll"]
