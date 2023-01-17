#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/Books.Api/Books.Api.csproj", "src/Books.Api/"]
RUN dotnet restore "src/Books.Api/Books.Api.csproj"
COPY . .
WORKDIR "/src/src/Books.Api"
RUN dotnet build "Books.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Books.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Books.Api.dll"]