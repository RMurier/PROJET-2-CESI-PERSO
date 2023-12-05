# Cahier de Test - Application d'Annuaire Entreprise

## Introduction
Ce document présente le cahier de test pour l'évaluation de l'application d'annuaire entreprise. L'application doit permettre aux utilisateurs de visualiser et de gérer les informations des salariés, des sites et des services.

## 1. Tests des Rôles

### 1.1 Visiteur
1. **Affichage des Informations**
   - [ ] L'utilisateur visiteur peut afficher les informations d'un salarié.
   - [ ] Les informations affichées comprennent le nom, prénom, téléphone fixe, téléphone portable, email, service et site.

2. **Recherche par Nom**
   - [ ] La recherche par nom fonctionne correctement en saisissant X lettres.
   - [ ] Les résultats correspondent aux salariés dont le nom contient les lettres saisies.

3. **Recherche par Site**
   - [ ] La liste des sites est correctement affichée.
   - [ ] La recherche par site renvoie les salariés associés à ce site.

4. **Recherche par Service**
   - [ ] La liste des services est correctement affichée.
   - [ ] La recherche par service renvoie les salariés associés à ce service.

### 1.2 Administration
1. **Ajout, Modification, Suppression d'Informations**
   - [ ] L'administrateur peut ajouter un nouveau salarié avec toutes les informations.
   - [ ] L'administrateur peut modifier les informations d'un salarié existant.
   - [ ] L'administrateur peut supprimer un salarié.

2. **Accès Secret et Mot de Passe**
   - [ ] L'accès secret (combinaison de touches) demande correctement un mot de passe.
   - [ ] L'administrateur peut accéder aux fonctionnalités secrètes après avoir fourni le mot de passe.

3. **CRUD des Sites**
   - [ ] L'administrateur peut créer, lire, mettre à jour et supprimer des sites.
   - [ ] Les modifications sont correctement reflétées dans la liste des sites.

4. **CRUD des Services**
   - [ ] L'administrateur peut créer, lire, mettre à jour et supprimer des services.
   - [ ] Les modifications sont correctement reflétées dans la liste des services.

5. **CRUD des Salariés**
   - [ ] L'administrateur peut créer, lire, mettre à jour et supprimer des salariés.
   - [ ] Les modifications sont correctement reflétées dans la liste des salariés.

## 2. Tests API

### 2.1 Interaction avec la Base de Données
1. **Select**
   - [ ] L'API peut récupérer les données des salariés, sites et services.
   - [ ] Les données récupérées sont correctes.

2. **Insert**
   - [ ] L'API peut ajouter de nouvelles entrées pour les salariés, sites et services.
   - [ ] Les nouvelles entrées sont correctement enregistrées dans la base de données.

3. **Update**
   - [ ] L'API peut mettre à jour les informations des salariés, sites et services.
   - [ ] Les mises à jour sont correctement enregistrées dans la base de données.

4. **Delete**
   - [ ] L'API peut supprimer des entrées pour les salariés, sites et services.
   - [ ] Les entrées supprimées ne sont plus présentes dans la base de données.

### 2.2 Gestion de l'Accès Concurrent
1. **Lecture Concurrente**
   - [ ] Plusieurs visiteurs peuvent ouvrir l'application en accès concurrent en lecture.
   - [ ] Les données affichées restent cohérentes malgré l'accès concurrent.

2. **Modification Concurrente (Administrateur)**
   - [ ] Deux administrateurs ne peuvent pas modifier la base de données simultanément si cela est bloquant.
   - [ ] Un message de refus est affiché pour le second administrateur.

## 3. Tests Git
1. **Création du Repo**
   - [ ] Le repo Git a été créé avec la date de création correspondant à celle de la remise du document.
   - [ ] Le repo est privé.
   - [ ] Le pilote est invité en tant que collaborateur.

2. **Vitalité du Repo**
   - [ ] Le repo a plusieurs commits.
   - [ ] Un bon équilibre entre les développeurs est maintenu.
   - [ ] Pas de first-commit, le repo évolue au fil du temps.

3. **Fichier Readme.MD**
   - [ ] Le fichier Readme.MD comprend le nom
