# RegularReport – Gestion Sûreté Tour Le Mirabeau

RegularReport est une application interne destinée au PC Sûreté de la **Tour Le Mirabeau (IGH – 22 étages)**.  
Elle permet la gestion centralisée des **mains courantes**, **tickets d’incidents**, et **rapports d’évènements**, dans l’attente de la mise en place du logiciel GuardTek TrackForce.

---

## 🎯 Objectifs du logiciel

L'application a pour but de :

- Fournir un **intranet de main courante** simple et fiable pour la sécurité du site.
- Créer des **tickets**, automatiquement transmis par **email** à une adresse dédiée.
- Rédiger et consulter les **mains courantes journalières**.
- Générer des **rapports d'évènements particuliers** (pannes, incidents techniques, intrusions, etc.).
- Faciliter le suivi opérationnel du PC Sûreté et la traçabilité des actions.

---

## 🛠 Fonctionnalités prévues

### ✓ v1 – MVP
- Interface intranet (web ou desktop interne).
- Formulaire de création de **ticket**.
- Envoi automatique d’un ticket par **email** à une adresse définie.
- Saisie d’une **main courante journalière**.
- Enregistrement en base locale (SQLite ou SQL Server localdb).
- Export PDF simple des rapports.

### 🔜 v2 – Évolutions
- Système d'autorisations / comptes utilisateurs.
- Historique détaillé et recherche avancée.
- Tableaux de bord (statistiques / incidents).
- Modèles de rapports personnalisables.
- Impression normalisée (format PC Sûreté).

---

## 📦 Architecture (proposée)
