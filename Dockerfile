FROM mcr.microsoft.com/dotnet/nightly/sdk:10.0 AS build
WORKDIR /app

COPY . ./

RUN dotnet restore
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/nightly/aspnet:10.0

WORKDIR /app

COPY --from=build /app/out .

ENV ASPNETCORE_URLS=http://+:10000

EXPOSE 10000

ENTRYPOINT ["dotnet", "HRMS-MVC.dll"]