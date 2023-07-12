FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 5000

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /
COPY ./ /

RUN dotnet restore "./src/{{project_name}}.{{project_type}}/{{project_name}}.{{project_type}}.csproj"
RUN dotnet build "./src/{{project_name}}.{{project_type}}/{{project_name}}.{{project_type}}.csproj"

FROM build AS publish
RUN dotnet publish "./src/{{project_name}}.{{project_type}}/{{project_name}}.{{project_type}}.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "{{project_name}}.{{project_type}}.dll"]