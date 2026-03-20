# FixInfo - Gestion de Maintenance Informatique

## Présentation
**FixInfo** est une application de bureau (Windows Forms) conçue pour centraliser et suivre le parc matériel informatique ainsi que les interventions de maintenance effectuées sur chaque équipement.

## Prérequis
- **IDE :** Rider ou Visual Studio.
- **Framework :** .NET Framework 4.8.
- **Base de données :** SQL Server.

## Installation et Configuration
1. **Base de données :** 
   - Localisez le fichier `FixInfo.sql` à la racine du projet.
   - Exécutez ce script sur votre instance SQL Server pour créer la base de données `Fixinfo` et ses tables.
2. **Chaîne de connexion :** 
   - Ouvrez le projet dans votre IDE.
   - Modifiez la variable `cn` dans `Form1.cs` (et `FormCHMDP.cs` si nécessaire) pour correspondre à votre serveur SQL (par défaut : `Server=MSI\SQLEXPRESS`).
3. **Exécution :**
   - Compilez et lancez la solution `WindowsFormsAppFixInfo.sln`.
   - Utilisez les identifiants suivants pour vous connecter :
     - **Login :** `root`
     - **Mot de passe :** `root2`

## Documentation
Pour plus de détails sur les fonctionnalités et les spécifications techniques, veuillez consulter le [Cahier des Charges](CAHIER_DES_CHARGES.md).
