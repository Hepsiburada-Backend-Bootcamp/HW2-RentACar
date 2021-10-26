#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["HW2-RentACar.API/HW2-RentACar.API.csproj", "HW2-RentACar.API/"]
COPY ["HW2-RentACar.Application/HW2-RentACar.Application.csproj", "HW2-RentACar.Application/"]
COPY ["HW2-RenACar.Domain/HW2-RenACar.Domain.csproj", "HW2-RenACar.Domain/"]
COPY ["HW2-RentACar.Infrastructure/HW2-RentACar.Infrastructure.csproj", "HW2-RentACar.Infrastructure/"]
RUN dotnet restore "HW2-RentACar.API/HW2-RentACar.API.csproj"
COPY . .
WORKDIR "/src/HW2-RentACar.API"
RUN dotnet build "HW2-RentACar.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "HW2-RentACar.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "HW2-RentACar.API.dll"]