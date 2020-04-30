using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace GestionImmoBDD
{
    internal class BDDAgenceImmo : DbContext
    {
        #region Tables de la BDD
        internal DbSet<Agents> Agents { get; set; }
        internal DbSet<Clients> Clients { get; set; }
        internal DbSet<BienImmobiliers> BienImmobiliers { get; set; }
        internal DbSet<Locations> Locations { get; set; }
        internal DbSet<Proprietaires> Proprietaires { get; set; }
        internal DbSet<Villes> Villes { get; set; }
        internal DbSet<Types> Types { get; set; }
        internal DbSet<Visiter> Visiter { get; set; }
        #endregion

        #region Méthodes d'initialisation de la base de données
        /// <summary>
        /// Méthode de configuration de la connexion à la base de données.
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=Bibliotheque;Integrated Security=true");
            optionsBuilder.UseSqlite($@"Data Source={Path.Combine(Directory.GetCurrentDirectory(), "BDDAgenceImmo.db")}");
        }

        /// <summary>
        /// Méthode contenant le code lié aux contraintes du modèle de données et aux données présentes par défaut
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Contraintes liées au modèle de la BDD
            modelBuilder.Entity<Visiter>().HasKey(sc => new { sc.ClientsID, sc.LocationsID });
            #endregion

            #region Données présentes par défaut dans la BDD
            modelBuilder.Entity<Villes>().HasData(
                new Villes() { ID = 1, CodePostal = "2000", Nom = "Anvers" },
                new Villes() { ID = 2, CodePostal = "1000", Nom = "Bruxelles" },
                new Villes() { ID = 3, CodePostal = "6000", Nom = "Charleroi" },
                new Villes() { ID = 4, CodePostal = "9000", Nom = "Gand" },
                new Villes() { ID = 5, CodePostal = "7000", Nom = "Mons" },
                new Villes() { ID = 6, CodePostal = "7700", Nom = "Mouscron" },
                new Villes() { ID = 7, CodePostal = "7500", Nom = "Tournai" }
            );

            modelBuilder.Entity<Agents>().HasData(
                new Agents() { ID = 1, Nom = "Jean-Philippe", Prenom = "Hubert" },
                new Agents() { ID = 2, Nom = "George", Prenom = "De Monaco Des Iles" }
            );

            modelBuilder.Entity<Proprietaires>().HasData(
                new Proprietaires() { ID = 1, Nom = "Jean-Yve", Prenom = "Jean-Pascal", RueNumero = "Rue de la Lorenne, 25", VillesID = 2},
                new Proprietaires() { ID = 2, Nom = "Gérard",   Prenom = "Dubuissier",  RueNumero = "Chaussée de Wavre, 50", VillesID = 5 },
                new Proprietaires() { ID = 3, Nom = "Julie",    Prenom = "Vanschroven", RueNumero = "Koningstraat, 100",     VillesID = 1 },
                new Proprietaires() { ID = 4, Nom = "Martijn",  Prenom = "Vankleurte",  RueNumero = "Brusselstraat, 300",    VillesID = 4 },
                new Proprietaires() { ID = 5, Nom = "Kévin",    Prenom = "Carapils",    RueNumero = "Rue des barakis, 1",    VillesID = 7 }
                );

            modelBuilder.Entity<BienImmobiliers>().HasData(
                new BienImmobiliers() { ID = 1, DateLocation = new DateTime(2015, 03, 24), RueNumero = "Rue de Morlanwelz, 17",       TypesID = 1 },
                new BienImmobiliers() { ID = 2, DateLocation = new DateTime(2015, 07, 15), RueNumero = "Rue de Zaventem, 150",        TypesID = 2 },
                new BienImmobiliers() { ID = 3, DateLocation = new DateTime(2017, 12, 15), RueNumero = "Rue de Peruwelz, 190",        TypesID = 1 },
                new BienImmobiliers() { ID = 4, DateLocation = new DateTime(2018, 05, 07), RueNumero = "Chaussée de Bruxelles, 320",  TypesID = 2 },
                new BienImmobiliers() { ID = 5, DateLocation = new DateTime(2019, 01, 24), RueNumero = "Rue de La petite Glace, 1",   TypesID = 1 },
                new BienImmobiliers() { ID = 6, DateLocation = new DateTime(2019, 01, 24), RueNumero = "Rue Paul Pastur, A2",         TypesID = 2 }
            );

            modelBuilder.Entity<Types>().HasData(
                new Types() { ID = 1, Designation = "Maison" },
                new Types() { ID = 2, Designation = "Appartement" }
                );

            modelBuilder.Entity<Locations>().HasData(
                new Locations() { ID = 1, Prix = 550, BienImmobiliersID = 1, AgentsID = 2, ClientsID = 5 },
                new Locations() { ID = 2, Prix = 500, BienImmobiliersID = 2, AgentsID = 1, ClientsID = 4 },
                new Locations() { ID = 3, Prix = 600, BienImmobiliersID = 3, AgentsID = 4, ClientsID = 2 },
                new Locations() { ID = 4, Prix = 499, BienImmobiliersID = 4, AgentsID = 3, ClientsID = 3 },
                new Locations() { ID = 5, Prix = 450, BienImmobiliersID = 5, AgentsID = 2, ClientsID = 1 }
                );

            modelBuilder.Entity<Visiter>().HasData(
                new Visiter() { ClientsID = 1, LocationsID = 1, DateVisite = new DateTime(2020, 09, 24, 14, 00, 00) },
                new Visiter() { ClientsID = 2, LocationsID = 1, DateVisite = new DateTime(2020, 11, 01, 15, 00, 00) },
                new Visiter() { ClientsID = 3, LocationsID = 1, DateVisite = new DateTime(2020, 10, 01, 16, 00, 00) },
                new Visiter() { ClientsID = 4, LocationsID = 2, DateVisite = new DateTime(2020, 11, 01, 14, 00, 00) },
                new Visiter() { ClientsID = 5, LocationsID = 2, DateVisite = new DateTime(2020, 10, 01, 9, 00, 00)  },
                new Visiter() { ClientsID = 6, LocationsID = 2, DateVisite = new DateTime(2020, 11, 01, 11, 00, 00) }
            );

            modelBuilder.Entity<Clients>().HasData(
                new Clients() { ID = 1, Nom = "Toomuch",    Prenom = "Thérèse",  RueNumero = "Rue de Fontigny 170",  VillesID = 6 },
                new Clients() { ID = 2, Nom = "Goudron",    Prenom = "Joseph",   RueNumero = "Rue Libert 140",       VillesID = 2 },
                new Clients() { ID = 3, Nom = "Alla",       Prenom = "Hubert",   RueNumero = "Perksesteenweg 204",   VillesID = 4 },
                new Clients() { ID = 4, Nom = "Decubertin", Prenom = "Mohamed",  RueNumero = "Rue du Monument 157",  VillesID = 7 },
                new Clients() { ID = 5, Nom = "Binetto",    Prenom = "Vincenzo", RueNumero = "Rue du Stade 494",     VillesID = 7 }
                );
            #endregion
        }
        #endregion

        #region Méthodes permettant d'ajouter des données dans les tables de la BDD
        internal Agents AjouterAgent(string aNom, string aPrenom, Villes aVille, string aRueNumero)
        {
            //Gestion des erreurs
            if (aNom == null || aNom == "") { throw new ArgumentNullException($"{nameof(AjouterAgent)} : L'agent doit avoir un nom (valeur NULL ou chaine vide)."); }
            if (aPrenom == null || aPrenom == "") { throw new ArgumentNullException($"{nameof(AjouterAgent)} : L'agent doit avoir un prénom (valeur NULL ou chaine vide)."); }
            if (aVille == null) { throw new ArgumentNullException($"{nameof(AjouterAgent)} : L'agent doit avoir une ville (valeur NULL)."); }

            //Ajout du nouvel agent
            Agents lAgent = new Agents() { Nom = aNom, Prenom = aPrenom, Villes = aVille, RueNumero = aRueNumero };
            Agents.Local.Add(lAgent);
            return lAgent;
        }
        internal Clients AjouterClient(string aNom, string aPrenom, Villes aVille, string aRueNumero)
        {
            //Gestion des erreurs
            if (aNom == null || aNom == "") { throw new ArgumentNullException($"{nameof(AjouterClient)} : Le client doit avoir un nom (valeur NULL ou chaine vide)."); }
            if (aPrenom == null || aPrenom == "") { throw new ArgumentNullException($"{nameof(AjouterClient)} : Le client doit avoir un prénom (valeur NULL ou chaine vide)."); }
            if (aVille == null) { throw new ArgumentNullException($"{nameof(AjouterClient)} : Le client doit avoir une ville (valeur NULL)."); }

            //Ajout du nouveau client
            Clients lClient = new Clients() { Nom = aNom, Prenom = aPrenom, Villes = aVille, RueNumero = aRueNumero };
            Clients.Local.Add(lClient);
            return lClient;
        }
        internal Proprietaires AjouterProprietaire(string aNom, string aPrenom, Villes aVille, string aRueNumero)
        {
            //Gestion des erreurs
            if (aNom == null || aNom == "") { throw new ArgumentNullException($"{nameof(AjouterClient)} : Le propriétaire doit avoir un nom (valeur NULL ou chaine vide)."); }
            if (aPrenom == null || aPrenom == "") { throw new ArgumentNullException($"{nameof(AjouterClient)} : Le propriétaire doit avoir un prénom (valeur NULL ou chaine vide)."); }
            if (aVille == null) { throw new ArgumentNullException($"{nameof(AjouterClient)} : Le propriétaire doit avoir une ville (valeur NULL)."); }

            //Ajout du nouveau propriétaire
            Proprietaires lProprietaire = new Proprietaires() { Nom = aNom, Prenom = aPrenom, Villes = aVille, RueNumero = aRueNumero };
            Proprietaires.Local.Add(lProprietaire);
            return lProprietaire;
        }
        internal BienImmobiliers AjouterBienImmobilier(DateTime aDateLocation, Villes aVille, string aRueNumero)
        {
            //Gestion des erreurs
            if (aDateLocation == null) { throw new ArgumentNullException($"{nameof(AjouterBienImmobilier)} : Le bien immobilier doit avoir une date de mise en location (valeur NULL)."); }
            if (aVille == null) { throw new ArgumentNullException($"{nameof(AjouterBienImmobilier)} : Le bien immobilier doit avoir une ville (valeur NULL)."); }

            //Ajout du nouveau bien immobilier
            BienImmobiliers lBienImmobilier = new BienImmobiliers() { DateLocation = aDateLocation, Villes = aVille, RueNumero = aRueNumero };
            BienImmobiliers.Local.Add(lBienImmobilier);
            return lBienImmobilier;
        }
        internal Visiter AjouterVisiter(Locations aLocation, Clients aClient)
        {
            //Gestion des erreurs.
            if (aLocation == null) { throw new ArgumentNullException($"{nameof(AjouterVisiter)} : Il faut une location pour le lien client/location (valeur NULL)."); }
            if (aClient == null) { throw new ArgumentNullException($"{nameof(AjouterVisiter)} : Il faut un client pour le lien client/location (valeur NULL)."); }
            if (Visiter.Local.FirstOrDefault(ecr => ecr.ClientsID == aClient.ID && ecr.LocationsID == aLocation.ID) != null)
                                  { throw new InvalidOperationException($"{nameof(AjouterVisiter)} : Le lien visiter existe déjà."); }

            //Ajout du nouveau lien visiter (location/client).
            Visiter lVisiter = new Visiter() { Locations = aLocation, Clients = aClient };
            Visiter.Local.Add(lVisiter);
            return lVisiter;
        }
        internal Villes AjouterVille(string aNom, string aCodePostal)
        {
            //Gestion des erreurs
            if (aNom == null || aNom == "") { throw new ArgumentNullException($"{nameof(AjouterVille)} : La ville doit avoir un nom (valeur NULL ou chaine vide)."); }
            if (aCodePostal == null || aCodePostal == "") { throw new ArgumentNullException($"{nameof(AjouterVille)} : La ville doit avoir un code postal (valeur NULL ou chaine vide)."); }

            //Ajout de la nouvelle ville
            Villes lVille = new Villes() { Nom = aNom, CodePostal = aCodePostal };
            Villes.Local.Add(lVille);
            return lVille;
        }
        internal Types AjouterType(string aDesignation)
        {
            //Gestion des erreurs
            if (aDesignation == null || aDesignation == "") { throw new ArgumentNullException($"{nameof(AjouterType)} : Le type doit avoir une désignation (valeur NULL ou chaine vide)."); }
           
            //Ajout du nouveau type
            Types lType = new Types() { Designation = aDesignation };
            Types.Local.Add(lType);
            return lType;
        }
        internal Locations AjouterLocation(uint aPrix)
        {
            //Gestion des erreurs
            if (aPrix == 0) { throw new ArgumentNullException($"{nameof(AjouterLocation)} : La location doit avoir un prix (valeur NULL ou chaine vide)."); }

            //Ajout du nouveau type
            Locations lLocation = new Locations() { Prix = aPrix };
            Locations.Local.Add(lLocation);
            return lLocation;
        }
        #endregion
       
        #region Méthodes permettant d'enlever des données dans les tables de la BDD
        internal void SupprimerAgent(Agents aAgent)
        {
            //Gestion des erreurs
            if (aAgent == null) { throw new ArgumentNullException($"{nameof(SupprimerAgent)} : Il faut un agent en argument (valeur NULL)."); }
            if ((aAgent.Locations?.Count ?? 0) > 0) { throw new InvalidOperationException($"{nameof(SupprimerAgent)} : Il faut d'abord supprimer les locations liés a l'agent ou désassocier l'agent de ceux-ci."); }

            //Suppression de l'auteur
            Agents.Local.Remove(aAgent);
        }
        internal void SupprimerClient(Clients aClient)
        {
            //Gestion des erreurs
            if (aClient == null) { throw new ArgumentNullException($"{nameof(SupprimerClient)} : Il faut un client en argument (valeur NULL)."); }

            //Suppression du client
            Clients.Local.Remove(aClient);
        }
        internal void SupprimerProprietaire(Proprietaires aProprietaire)
        {
            //Gestion des erreurs
            if (aProprietaire == null) { throw new ArgumentNullException($"{nameof(SupprimerProprietaire)} : Il faut un proprietaire en argument (valeur NULL)."); }

            //Avant de supprimer le propriétaire, suppression de tous les biens immobiliers liés à celui-ci.
            if (aProprietaire.BienImmobiliers != null)
            {
                foreach (BienImmobiliers e in aProprietaire.BienImmobiliers)
                {
                    BienImmobiliers.Local.Remove(e);
                }
            }

            //Suppression du propriétaire
            Proprietaires.Local.Remove(aProprietaire);
        }
        internal void SupprimerBienImmobilier(BienImmobiliers aBienImmobilier)
        {
            //Gestion des erreurs
            if (aBienImmobilier == null) { throw new ArgumentNullException($"{nameof(SupprimerBienImmobilier)} : Il faut un bien immobilier en argument (valeur NULL)."); }

            //Suppression du bien immobilier
            BienImmobiliers.Local.Remove(aBienImmobilier);
        }
        internal void SupprimerVisiter(Visiter aVisiter)
        {
            //Gestion des erreurs
            if (aVisiter == null) { throw new ArgumentException($"{nameof(SupprimerVisiter)} : Il faut un lien visiter(client/location) en argument (valeur NULL)."); }

            //Suppression du lien ecrire
            Visiter.Local.Remove(aVisiter);
        }
        internal void SupprimerType(Types aType)
        {
            //Gestion des erreurs
            if (aType == null) { throw new ArgumentException($"{nameof(SupprimerType)} : Il faut un type en argument (valeur NULL)."); }

            //Suppression de l'emprunt
            Types.Local.Remove(aType);
        }
        internal void SupprimerLocation(Locations aLocation)
        {
            //Gestion des erreurs
            if (aLocation == null) { throw new ArgumentNullException($"{nameof(SupprimerLocation)} : Il faut une Location en argument (valeur NULL)."); }
            
            //Suppression du livre.
            Locations.Local.Remove(aLocation);
        }
        internal void SupprimerVille(Villes aVille)
        {
            //Gestion des erreurs
            if (aVille == null) { throw new ArgumentNullException($"{nameof(SupprimerVille)} : Il faut une ville en argument (valeur NULL)."); }
            if ((aVille.Clients?.Count ?? 0) > 0) { throw new InvalidOperationException($"{nameof(SupprimerVille)} : Il faut d'abord supprimer les clients habitant la ville."); }
            if ((aVille.Agents?.Count ?? 0) > 0) { throw new InvalidOperationException($"{nameof(SupprimerVille)} : Il faut d'abord supprimer les agents habitant la ville."); }
            if ((aVille.Proprietaires?.Count ?? 0) > 0) { throw new InvalidOperationException($"{nameof(SupprimerVille)} : Il faut d'abord supprimer les propriétaires habitant la ville."); }
            if ((aVille.BienImmobiliers?.Count ?? 0) > 0) { throw new InvalidOperationException($"{nameof(SupprimerVille)} : Il faut d'abord supprimer les bien immobiliers étant installés dans la ville."); }

            //Suppression de la ville.
            Villes.Local.Remove(aVille);
        }
        #endregion
    }
}
