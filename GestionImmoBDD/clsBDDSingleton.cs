using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace GestionImmoBDD
{
    public class BDDSingleton
    {
        #region Propriétés représentant la Base de données ou la rendant accessible à l'extérieur du projet
        public static BDDSingleton Instance { get; set; } = new BDDSingleton();
        private BDDAgenceImmo BDD { get; set; }
        #endregion

        #region Propriétés
        public bool ModificationsEnAttente => BDD?.ChangeTracker.HasChanges() ?? false;
        #endregion

        #region Tables de la BDD (sous forme de ReadOnlyObservableCollection)
        private ReadOnlyObservableCollection<Agents> _agents;
        private ReadOnlyObservableCollection<Clients> _clients;
        private ReadOnlyObservableCollection<Proprietaires> _proprietaires;
        private ReadOnlyObservableCollection<BienImmobiliers> _bienimmobiliers;
        private ReadOnlyObservableCollection<Visiter> _visiter;
        private ReadOnlyObservableCollection<Locations> _locations;
        private ReadOnlyObservableCollection<Types> _types;
        private ReadOnlyObservableCollection<Villes> _villes;

        public ReadOnlyObservableCollection<Agents> Agents => _agents;
        public ReadOnlyObservableCollection<Clients> Clients => _clients;
        public ReadOnlyObservableCollection<Proprietaires> Proprietaires => _proprietaires;
        public ReadOnlyObservableCollection<BienImmobiliers> BienImmobiliers => _bienimmobiliers;
        public ReadOnlyObservableCollection<Visiter> Visiter => _visiter;
        public ReadOnlyObservableCollection<Locations> Locations => _locations;
        public ReadOnlyObservableCollection<Types> Types => _types;
        public ReadOnlyObservableCollection<Villes> Villes => _villes;
        #endregion

        #region Constructeur de la classe
        public BDDSingleton()
        {
            BDD = new BDDAgenceImmo();
            BDD.Database.EnsureCreated();

            BDD.Agents.Load();
            _agents = new ReadOnlyObservableCollection<Agents>(BDD?.Agents.Local.ToObservableCollection());

            BDD.Clients.Load();
            _clients = new ReadOnlyObservableCollection<Clients>(BDD?.Clients.Local.ToObservableCollection());

            BDD.Proprietaires.Load();
            _proprietaires = new ReadOnlyObservableCollection<Proprietaires>(BDD?.Proprietaires.Local.ToObservableCollection());

            BDD.BienImmobiliers.Load();
            _bienimmobiliers = new ReadOnlyObservableCollection<BienImmobiliers>(BDD?.BienImmobiliers.Local.ToObservableCollection());

            BDD.Visiter.Load();
            _visiter = new ReadOnlyObservableCollection<Visiter>(BDD?.Visiter.Local.ToObservableCollection());

            BDD.Locations.Load();
            _locations = new ReadOnlyObservableCollection<Locations>(BDD?.Locations.Local.ToObservableCollection());

            BDD.Types.Load();
            _types = new ReadOnlyObservableCollection<Types>(BDD?.Types.Local.ToObservableCollection());

            BDD.Villes.Load();
            _villes = new ReadOnlyObservableCollection<Villes>(BDD?.Villes.Local.ToObservableCollection());
        }
        #endregion

        #region Méthodes permettant d'ajouter/d'enlever des données dans les tables de la BDD
        public Agents AjouterAgent(string aNom, string aPrenom, Villes aVille, string aRueNumero) { return BDD?.AjouterAgent(aNom, aPrenom, aVille, aRueNumero); }
        public Clients AjouterClient(string aNom, string aPrenom, Villes aVille, string aRueNumero) { return BDD?.AjouterClient(aNom, aPrenom, aVille, aRueNumero); }
        public Proprietaires AjouterProprietaire(string aNom, string aPrenom, Villes aVille, string aRueNumero) { return BDD?.AjouterProprietaire(aNom, aPrenom, aVille, aRueNumero); }
        public BienImmobiliers AjouterBienImmobilier(DateTime aDateLocation, Villes aVille, string aRueNumero) { return BDD?.AjouterBienImmobilier(aDateLocation, aVille, aRueNumero); }
        public Visiter AjouterVisiter(Locations aLocation, Clients aClient) { return BDD?.AjouterVisiter(aLocation, aClient); }
        public Locations AjouterLocation(uint aPrix) { return BDD?.AjouterLocation(aPrix); }
        public Types AjouterType(string aDesignation) { return BDD?.AjouterType(aDesignation); }
        public Villes AjouterVille(string aNom, string aCodePostal) { return BDD?.AjouterVille(aNom, aCodePostal); }

        public void SupprimerAgent(Agents aAgent) { BDD?.SupprimerAgent(aAgent); }
        public void SupprimerClient(Clients aClient) { BDD?.SupprimerClient(aClient); }
        public void SupprimerProprietaire(Proprietaires aProprietaire) { BDD?.SupprimerProprietaire(aProprietaire); }
        public void SupprimerBienImmobilier(BienImmobiliers aBienImmobilier) { BDD?.SupprimerBienImmobilier(aBienImmobilier); }
        public void SupprimerVisiter(Visiter aVisiter) { BDD?.SupprimerVisiter(aVisiter); }
        public void SupprimerLocation(Locations aLocation) { BDD?.SupprimerLocation(aLocation); }
        public void SupprimerType(Types aType) { BDD?.SupprimerType(aType); }
        public void SupprimerVille(Villes aVille) { BDD?.SupprimerVille(aVille); }
        #endregion

        #region Méthodes effectuant des modifications/actions plus spécifiques sur les données
        public void SauvegarderModifications() { BDD?.SaveChanges(); }
        #endregion
    }
}
