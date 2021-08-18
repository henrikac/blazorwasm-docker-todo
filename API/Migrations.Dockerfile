# https://dotnetthoughts.net/docker-compose-asp-net-core-application/
FROM mcr.microsoft.com/dotnet/sdk:5.0 as build-env

WORKDIR /app

COPY *.csproj .
COPY setup.sh setup.sh

RUN dotnet tool install --global dotnet-ef
ENV PATH="${PATH}:/root/.dotnet/tools"

RUN dotnet restore
COPY . .
#WORKDIR "/app/."

RUN dotnet-ef migrations add InitialMigration

RUN chmod +x ./setup.sh
CMD /bin/bash ./setup.sh
#CMD dotnet-ef database update
