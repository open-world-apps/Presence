FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Presence/Presence.csproj", "Presence/"]
RUN dotnet restore "Presence/Presence.csproj"
COPY . .
WORKDIR "/src/Presence"
RUN dotnet build "Presence.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Presence.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Presence.dll"]
