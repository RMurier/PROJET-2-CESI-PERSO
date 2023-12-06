# Cahier de Test - Application d'Annuaire Entreprise

## Introduction
Ce document présente le cahier de test pour l'évaluation de l'application d'annuaire entreprise. L'application doit permettre aux utilisateurs de visualiser et de gérer les informations des salariés, des sites et des services.

## 1. Tests des Rôles

### 1.1 Visiteur
1. **Affichage des Informations**
   - [x] L'utilisateur visiteur peut afficher les informations d'un salarié.
   - [x] Les informations affichées comprennent le nom, prénom, téléphone fixe, téléphone portable, email, service et site.

2. **Recherche par Nom**
   - [x] La recherche par nom fonctionne correctement en saisissant 1 lettres.
   - [x] Les résultats correspondent aux salariés dont le nom contient les lettres saisies.

3. **Recherche par Site**
   - [x] La liste des sites est correctement affichée.
   - [x] La recherche par site renvoie les salariés associés à ce site.

4. **Recherche par Service**
   - [x] La liste des services est correctement affichée.
   - [x] La recherche par service renvoie les salariés associés à ce service.

### 1.2 Administration
1. **Ajout, Modification, Suppression d'Informations**
   - [x] L'administrateur peut ajouter un nouveau salarié avec toutes les informations.
   - [x] L'administrateur peut modifier les informations d'un salarié existant.
   - [x] L'administrateur peut supprimer un salarié.

2. **Accès Secret et Mot de Passe**
   - [x] L'accès secret (combinaison de touches) demande correctement un mot de passe.
   - [x] L'administrateur peut accéder aux fonctionnalités secrètes après avoir fourni le mot de passe.

3. **CRUD des Sites**
   - [x] L'administrateur peut créer, lire, mettre à jour et supprimer des sites.
   - [x] Les modifications sont correctement reflétées dans la liste des sites.

4. **CRUD des Services**
   - [x] L'administrateur peut créer, lire, mettre à jour et supprimer des services.
   - [x] Les modifications sont correctement reflétées dans la liste des services.

5. **CRUD des Salariés**
   - [x] L'administrateur peut créer, lire, mettre à jour et supprimer des salariés.
   - [x] Les modifications sont correctement reflétées dans la liste des salariés.

## 2. Tests API

### 2.1 Interaction avec la Base de Données
1. **Select**
   - [x] L'API peut récupérer les données des salariés, sites et services.
   - [x] Les données récupérées sont correctes.

2. **Insert**
   - [x] L'API peut ajouter de nouvelles entrées pour les salariés, sites et services.
   - [x] Les nouvelles entrées sont correctement enregistrées dans la base de données.

3. **Update**
   - [x] L'API peut mettre à jour les informations des salariés, sites et services.
   - [x] Les mises à jour sont correctement enregistrées dans la base de données.

4. **Delete**
   - [x] L'API peut supprimer des entrées pour les salariés, sites et services.
   - [x] Les entrées supprimées ne sont plus présentes dans la base de données.

## 3. Tests Git
1. **Création du Repo**
   - [x] Le repo Git a été créé avec la date de création correspondant à celle de la remise du document.
   - [x] Le repo est privé.
   - [x] Le pilote est invité en tant que collaborateur.

2. **Vitalité du Repo**
   - [x] Le repo a plusieurs commits.
   - [x] Un bon équilibre entre les développeurs est maintenu.
   - [x] Pas de first-commit, le repo évolue au fil du temps.

3. **Fichier Readme.MD**
   - [x] Le fichier Readme.MD comprend le nom
