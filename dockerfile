ARG ASPNET_VERSION=5.0
ARG SDK_VERSION=5.0

FROM mcr.microsoft.com/dotnet/aspnet:${ASPNET_VERSION} AS base
RUN groupadd -g 5000 appuser && \
    useradd -u 5000 -g appuser appuser

WORKDIR /app
ENV ASPNETCORE_URLS=http://+:7000
EXPOSE 7000

FROM mcr.microsoft.com/dotnet/sdk:${SDK_VERSION} AS build
WORKDIR /src
COPY ./ .
RUN dotnet restore "API/API.csproj" && \
    dotnet build "API/API.csproj" -c Release

FROM build AS publish
ENV PATH $PATH:/root/.dotnet/tools
RUN dotnet tool install -g dotnet-ef --version 5.0.11 && \
    dotnet publish "API/API.csproj" -c Release -o /app/publish

FROM base AS final
RUN apt-get install coreutils
USER appuser:appuser
WORKDIR /app
COPY --from=publish /app .
WORKDIR /app/publish
ENTRYPOINT ["dotnet", "API.dll"]