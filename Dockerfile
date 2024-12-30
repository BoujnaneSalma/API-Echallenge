# Étape 1 : Construire l'application
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /app

# Copier les fichiers .csproj et restaurer les dépendances
COPY *.csproj ./
RUN dotnet restore

# Copier le reste des fichiers et construire l'application
COPY . ./
RUN dotnet publish -c Release -o out

# Étape 2 : Construire l'image runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build-env /app/out .

# Exposer le port 80
EXPOSE 80

# Commande d'exécution
ENTRYPOINT ["dotnet", "GestionBiblio.dll"]
