#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["WebApiMegnetron/WebApiMegnetron.csproj", "WebApiMegnetron/"]
COPY ["POS.Aplication/POS.Aplication.csproj", "POS.Aplication/"]
COPY ["POS.Domain/POS.Domain.csproj", "POS.Domain/"]
COPY ["POS.Infraestructura/POS.Infraestructura.csproj", "POS.Infraestructura/"]
COPY ["POS.Utility/POS.Utility.csproj", "POS.Utility/"]
RUN dotnet restore "./WebApiMegnetron/WebApiMegnetron.csproj"
COPY . .
WORKDIR "/src/WebApiMegnetron"
RUN dotnet build "./WebApiMegnetron.csproj" -c %BUILD_CONFIGURATION% -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./WebApiMegnetron.csproj" -c %BUILD_CONFIGURATION% -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WebApiMegnetron.dll"]