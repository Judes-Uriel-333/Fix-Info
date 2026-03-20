# Cahier des Charges - Application FixInfo

## 1. Présentation du Projet
**FixInfo** est une application de bureau (Windows Forms) permettant la gestion de la maintenance informatique au sein d'une organisation. Elle permet de suivre le parc matériel ainsi que les interventions techniques réalisées sur chaque équipement.

## 2. Objectifs de l'Application
L'objectif principal est de centraliser les informations relatives au matériel informatique et de garder une trace historique des réparations et opérations de maintenance (interventions).

## 3. Fonctionnalités

### 3.1 Gestion des Accès (Sécurité)
*   **Authentification :** Accès sécurisé à l'application via un nom d'utilisateur et un mot de passe.
*   **Gestion du compte :** Possibilité pour un utilisateur de modifier son mot de passe.

### 3.2 Gestion du Matériel
*   **Enregistrement :** Ajouter de nouveaux équipements au parc.
*   **Informations suivies :**
    *   Nom du matériel.
    *   Prix d'achat.
    *   Description technique.
    *   Date d'installation.
    *   MTBF (*Mean Time Between Failures*) : Temps moyen entre pannes.

### 3.3 Gestion des Interventions
*   **Saisie d'intervention :** Enregistrer une opération de maintenance sur un matériel existant.
*   **Informations suivies :**
    *   Sélection du matériel concerné.
    *   Date de l'intervention.
    *   Coût de l'intervention.
    *   Commentaires/Détails de l'opération effectuée.

## 4. Spécifications Techniques

### 4.1 Environnement de Développement
*   **Langage :** C#.
*   **Interface :** Windows Forms Classic.
*   **IDE recommandé :** Rider ou Visual Studio.

### 4.2 Base de Données
L'application utilise une base de données **SQL Server** nommée `Fixinfo`.

#### Modèle de données (Tables) :
1.  **Login :** Stocke les comptes utilisateurs (`ID_LOGIN`, `Nom`, `PWD`).
2.  **Materiel :** Stocke les équipements (`ID_MATOS`, `Nom`, `Prix`, `Description`, `DateInstall`, `MTBF`).
3.  **Inter :** Stocke les interventions liées au matériel (`ID_INTER`, `Date_Inter`, `IDMATERIEL`, `Prix`, `Comment`).

## 5. Annexes
Veuillez vous référer au fichier [README.md](README.md) pour les instructions d'installation et de configuration de l'environnement de développement.
