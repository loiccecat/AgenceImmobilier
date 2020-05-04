using GestionImmoBDD;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace ImmoWPF
{
    /// <summary>
    /// Logique d'interaction pour pgProprietaires.xaml
    /// </summary>
    public partial class pgProprietaires : Page
    {
        BDDSingleton BDD = BDDSingleton.Instance;
        public ReadOnlyObservableCollection<Villes> Villes => BDD.Villes;

        public pgProprietaires()
        {
            InitializeComponent();
            grpProprietaires.DataContext = BDD.Proprietaires;
        }

        private void AjouterProprietaire(object sender, RoutedEventArgs e)
        {
            Statics.TryCatch(() => { lvProprietaires.SelectedItem = BDD.AjouterProprietaire("Nouveau", "Proprietaire", BDD.Villes.FirstOrDefault(), "", "0032"); }, nameof(AjouterProprietaire));
        }

        private void SupprimerProprietaire(object sender, RoutedEventArgs e)
        {
            Proprietaires selection = (Proprietaires)lvProprietaires.SelectedItem;
            if (selection != null)
            {
                if (MessageBox.Show($"Etes-vous sur de vouloir supprimer le proprietaire {selection.NomComplet} de la liste ?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    Statics.TryCatch(() => { BDD.SupprimerProprietaire(selection); }, nameof(SupprimerProprietaire));
                }
            }
        }

    }
}
