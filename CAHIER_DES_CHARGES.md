# Cahier des charges - Application FixInfo

## 1. Présentation du projet

FixInfo est une application Windows Forms permettant la gestion d'un parc matériel informatique.
L'objectif est de centraliser les informations sur les équipements et de suivre les interventions de maintenance.

## 2. Objectifs

L'application doit permettre :

- de sécuriser l'accès avec un écran de connexion ;
- d'ajouter du matériel informatique ;
- d'enregistrer des interventions liées à un matériel ;
- de conserver les informations dans une base SQL Server ;
- de permettre à un utilisateur de modifier son mot de passe.

## 3. Fonctionnalités attendues

### 3.1 Authentification

L'utilisateur doit saisir un identifiant et un mot de passe.
Les informations sont vérifiées dans la table `Login`.

### 3.2 Gestion du matériel

L'application permet d'ajouter un matériel avec :

- un nom ;
- un prix ;
- une description ;
- une date d'installation ;
- un MTBF.

### 3.3 Gestion des interventions

L'application permet d'ajouter une intervention sur un matériel existant avec :

- une date d'intervention ;
- un prix ;
- un commentaire ;
- le matériel concerné.

### 3.4 Modification du mot de passe

L'utilisateur peut accéder à une fenêtre de changement de mot de passe depuis la fenêtre de connexion.

## 4. Environnement technique

- Langage : C#
- Interface : Windows Forms
- Framework : .NET Framework 4.8
- Base de données : SQL Server
- IDE : Visual Studio 2022

## 5. Base de données

La base de données s'appelle `Fixinfo`.
Elle contient les tables :

- `Login`
- `Materiel`
- `Inter`

La table `Inter` contient une clé étrangère vers la table `Materiel`.

La modélisation complète est disponible dans [docs/modelisation.md](docs/modelisation.md).
