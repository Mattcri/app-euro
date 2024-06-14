# Contruccion
FROM --platform=$BUILDPLATFORM mcr.microsoft.com/dotnet/sdk:8.0-alpine AS build
ARG TARGETARCH

WORKDIR /source

# copiar archivos y restaurar dependencias 
COPY . .

# Build the application.
# Leverage a cache mount to /root/.nuget/packages so that subsequent builds don't have to re-download packages.
# If TARGETARCH is "amd64", replace it with "x64" - "x64" is .NET's canonical name for this and "amd64" doesn't
RUN --mount=type=cache,id=nuget,target=/root/.nuget/packages \
  dotnet publish -a ${TARGETARCH/amd64/x64} --use-current-runtime --self-contained false -o /app
# RUN dotnet build -c Debug -o /app/build

# Ejecuccion de aspnet con multistage
FROM mcr.microsoft.com/dotnet/aspnet:8.0-alpine AS final
WORKDIR /app
COPY --from=build /app .

EXPOSE 5000

ENTRYPOINT ["dotnet", "net-api.dll", "--urls", "http://0.0.0.0:5000"]
# ENTRYPOINT [ "dotnet", "run" ]
