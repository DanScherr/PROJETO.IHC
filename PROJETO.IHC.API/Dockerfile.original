#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["PROJETO.IHC.API/PROJETO.IHC.API.csproj", "PROJETO.IHC.API/"]
RUN dotnet restore "PROJETO.IHC.API/PROJETO.IHC.API.csproj"
COPY . .
WORKDIR "/src/PROJETO.IHC.API"
RUN dotnet build "PROJETO.IHC.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PROJETO.IHC.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PROJETO.IHC.API.dll"]