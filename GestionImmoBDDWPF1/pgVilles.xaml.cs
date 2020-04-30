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

namespace GestionImmoBDDWPF
{
    /// <summary>
    /// Logique d'interaction pour pgVilles.xaml
    /// </summary>
    public partial class pgVilles : Page
    {
        BDDSingleton BDD = BDDSingleton.Instance;

        public pgVilles()
        {
            InitializeComponent();
            grpListeVilles.DataContext = BDD.Villes;
        }

        private void AjouterVille(object sender, RoutedEventArgs e)
        {
            Statics.TryCatch(() => { lvVilles.SelectedItem = BDD.AjouterVille("Nouvelle Ville", "CP"); }, nameof(AjouterVille));
        }

        private void SupprimerVille(object sender, RoutedEventArgs e)
        {
            Villes selection = (Villes)lvVilles.SelectedItem;
            if (selection != null)
            {
                if (MessageBox.Show($"Etes-vous sur de vouloir supprimer la ville {selection.Nom} de la liste ?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    Statics.TryCatch(() => { BDD.SupprimerVille(selection); }, nameof(SupprimerVille));
                }
            }
        }
    }
}
