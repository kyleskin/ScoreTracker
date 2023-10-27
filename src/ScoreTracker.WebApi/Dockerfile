FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
ENV TZ=US/Mountain
RUN ln -snf /usr/share/zoneinfo/$TZ /etc/localtime && echo $TZ > /etc/timezone
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["ScoreTracker.WebApi/ScoreTracker.WebApi.csproj", "ScoreTracker.WebApi/"]
RUN dotnet restore "ScoreTracker.WebApi/ScoreTracker.WebApi.csproj"
COPY . .
WORKDIR "/src/ScoreTracker.WebApi"
RUN dotnet build "ScoreTracker.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ScoreTracker.WebApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ScoreTracker.WebApi.dll"]