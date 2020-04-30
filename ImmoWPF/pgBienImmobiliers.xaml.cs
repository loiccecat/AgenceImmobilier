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
    /// Logique d'interaction pour pgBienImmobiliers.xaml
    /// </summary>
    public partial class pgBienImmobiliers : Page
    {
        BDDSingleton BDD = BDDSingleton.Instance;
        public ReadOnlyObservableCollection<Villes> Villes => BDD.Villes;

        public pgBienImmobiliers()
        {
            InitializeComponent();
            grpBienImmobiliers.DataContext = BDD.BienImmobiliers;
        }

        private void AjouterBienImmobilier(object sender, RoutedEventArgs e)
        {
            Statics.TryCatch(() => { lvBienImmobiliers.SelectedItem = BDD.AjouterBienImmobilier(DateTime.Now, BDD.Villes.FirstOrDefault(), ""); }, nameof(AjouterBienImmobilier));
        }

        private void SupprimerBienImmobilier(object sender, RoutedEventArgs e)
        {
            BienImmobiliers selection = (BienImmobiliers)lvBienImmobiliers.SelectedItem;
            if (selection != null)
            {
                if (MessageBox.Show($"Etes-vous sur de vouloir supprimer le bien immobilier {selection.RueNumero} de la liste ?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    Statics.TryCatch(() => { BDD.SupprimerBienImmobilier(selection); }, nameof(SupprimerBienImmobilier));
                }
            }
        }
    }
}
