FROM mcr.microsoft.com/dotnet/sdk:10.0

WORKDIR /app

COPY . .

RUN dotnet restore TaskManagement.API/TaskManagement.API.csproj

RUN dotnet publish TaskManagement.API/TaskManagement.API.csproj -c Release -o /app/publish

WORKDIR /app/publish

EXPOSE 8080

ENTRYPOINT ["dotnet", "TaskManagement.API.dll"]