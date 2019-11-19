# Architecture d'une solution (workspace) dotnet
* Isen.DotnetCode est un projet console sous dotnet

## Setup du projet
### Création du projet principale
créer un dossier src/ dans la racine du projet (ASP.net)

sous src/ créé un dossier Isen.DotnetCode
Depuis ce dossier
* lancer la commande : dotnet new console
ceci crée un nouveau projet dotnet console (hello world)

Depuis le dossier racine (ASP.net)
* lancer la commande : dotnet new sln (création d'un fichier sln)
* lancer la commande : dotnet sln add src\Isen.DotnetCode\
ceci ajoute le code au dossier référenciel que constitue le sln

Pour vérifier si le projet c'est correctement installé
depuis le dossier src/Isen.DotnetCode
* lancer la commande : dotnet run
"Hello World!" devrait s'afficher dans la console

### Création d'un dossier gérant les librairies
sous src/ créé un dossier Isen.Dotnet.Library
Depuis ce dossier
* lancer la commande : dotnet new classlib
* supprimer "Class1.cs"
Revenir à la racine du projet et référencer le nouveau projet dans le sln
* lancer la commande : dotnet sln add src\Isen.Dotnet.Library\
ceci ajoute le code au dossier référenciel que constitue le sln

Ajouter ce projet (library) comme référence du projet console.
De cette manière, le projet console pourra utiliser des classes codées dans le projet Library.
Depuis le dossier src/Isen.DotnetCode
* lancer la commande : dotnet add reference ..\Isen.Dotnet.Library\

### Création de tests unitaire

Créer un nouveau dossier "test" à la racine
Y créer un dossier "Isen.Dotnet.UniTests"

sous src/ créé un dossier Isen.DotnetCode
Depuis ce dossier
* lancer la commande : dotnet new xunit
ceci crée un nouveau projet de test unitaire
Depuis le dossier \test\Isen.Dotnet.UniTests\
* lancer la commande : dotnet add reference ..\..\src\Isen.Dotnet.Library\
Depuis le dossier racine (ASP.net)
* lancer la commande : dotnet sln add test\Isen.Dotnet.UniTests\
