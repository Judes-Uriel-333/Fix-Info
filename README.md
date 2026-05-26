# FixInfo - Gestion de maintenance informatique

FixInfo est une application Windows Forms en C# qui permet de gérer le suivi d'un parc matériel informatique et les interventions de maintenance associées.

Ce projet correspond à une situation professionnelle BTS SIO SLAM.

## Technologies utilisées

- C#
- Windows Forms
- .NET Framework 4.8
- SQL Server Express
- SQL Server Management Studio
- Visual Studio 2022

## Fonctionnalités principales

- Authentification par identifiant et mot de passe
- Modification du mot de passe utilisateur
- Ajout de matériel informatique
- Enregistrement d'interventions sur un matériel
- Stockage des données dans une base SQL Server

## Structure du projet

```text
WindowsFormsAppFixInfoLrd/
|-- docs/
|   `-- modelisation.md
|-- WindowsFormsAppFixInfo/
|   |-- Form1.cs
|   |-- FormLogin.cs
|   |-- FormCHMDP.cs
|   |-- App.config
|   |-- FixInfo.sql
|   `-- WindowsFormsAppFixInfo.csproj
|-- CAHIER_DES_CHARGES.md
|-- FixInfo.sql
|-- README.md
`-- WindowsFormsAppFixInfo.sln
```

## Documentation

- [Cahier des charges](CAHIER_DES_CHARGES.md)
- [MCD, MLD et MPD](docs/modelisation.md)
- [Script SQL](FixInfo.sql)

## Documentation d'installation

### 1. Prérequis

Installer les outils suivants :

- Visual Studio 2022
- SQL Server Express
- SQL Server Management Studio
- .NET Framework 4.8

### 2. Installer la base de données

Ouvrir SQL Server Management Studio, puis exécuter le script SQL situé à la racine :

```text
FixInfo.sql
```

Ce script crée la base `Fixinfo`, les tables nécessaires et les données de test.

### 3. Vérifier la chaîne de connexion

Dans le code de l'application, la chaîne de connexion utilisée est :

```text
Server=MSI\SQLEXPRESS;Database=Fixinfo;Trusted_Connection=True;
```

Si le nom de votre serveur SQL Server est différent, il faut adapter cette valeur dans les fichiers concernés.

### 4. Lancer l'application

Ouvrir la solution :

```text
WindowsFormsAppFixInfo.sln
```

Puis lancer le projet depuis Visual Studio.

Compte de test :

```text
Login : root
Mot de passe : root2
```

## Documentation utilisateur

### Se connecter

Au lancement de l'application, une fenêtre de connexion apparaît.
L'utilisateur saisit son identifiant et son mot de passe.

### Ajouter un matériel

Dans la fenêtre principale, l'utilisateur renseigne :

- le nom du matériel
- le prix
- la description
- la date d'installation
- le MTBF

Après validation, le matériel est ajouté dans la base.

### Ajouter une intervention

L'utilisateur sélectionne un matériel, puis renseigne :

- la date de l'intervention
- le prix de l'intervention
- un commentaire

Après validation, l'intervention est enregistrée et liée au matériel choisi.

### Modifier le mot de passe

Depuis la fenêtre de connexion, l'utilisateur peut accéder à la fenêtre de changement de mot de passe.

## Base de données

La base `Fixinfo` contient trois tables principales :

- `Login` : comptes utilisateurs
- `Materiel` : matériel informatique
- `Inter` : interventions de maintenance

La table `Inter` possède une clé étrangère vers `Materiel`.

## Remarque

Le projet reste volontairement simple afin de correspondre à un niveau BTS SIO SLAM.
