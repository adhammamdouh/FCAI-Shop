#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-alpine AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

RUN apk add --no-cache icu-libs
ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-alpine AS build
WORKDIR /src
COPY ["FCAI-Shop/FCAI-Shop.csproj", "FCAI-Shop/"]
RUN dotnet restore "FCAI-Shop/FCAI-Shop.csproj"
COPY . .
WORKDIR "/src/FCAI-Shop"
RUN dotnet build "FCAI-Shop.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "FCAI-Shop.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .


ENTRYPOINT ["dotnet", "FCAI-Shop.dll"]

#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.