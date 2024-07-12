#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["ComputerAggregator.Kulebyakin.DNSParser/ComputerAggregator.Kulebyakin.DNSParser.csproj", "ComputerAggregator.Kulebyakin.DNSParser/"]
RUN dotnet restore "ComputerAggregator.Kulebyakin.DNSParser/ComputerAggregator.Kulebyakin.DNSParser.csproj"
COPY . .
WORKDIR "/src/ComputerAggregator.Kulebyakin.DNSParser"
RUN dotnet build "ComputerAggregator.Kulebyakin.DNSParser.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ComputerAggregator.Kulebyakin.DNSParser.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ComputerAggregator.Kulebyakin.DNSParser.dll"]