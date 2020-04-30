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
    /// Logique d'interaction pour pgTypes.xaml
    /// </summary>
    public partial class pgTypes : Page
    {
        BDDSingleton BDD = BDDSingleton.Instance;
        public ReadOnlyObservableCollection<Villes> Villes => BDD.Villes;

        public pgTypes()
        {
            InitializeComponent();
            grpTypes.DataContext = BDD.Types;
        }

        private void AjouterType(object sender, RoutedEventArgs e)
        {
            Statics.TryCatch(() => { lvTypes.SelectedItem = BDD.AjouterType("Nouveau"); }, nameof(AjouterType));
        }

        private void SupprimerType(object sender, RoutedEventArgs e)
        {
            Types selection = (Types)lvTypes.SelectedItem;
            if (selection != null)
            {
                if (MessageBox.Show($"Etes-vous sur de vouloir supprimer le type de bien {selection.Designation} de la liste ?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    Statics.TryCatch(() => { BDD.SupprimerType(selection); }, nameof(SupprimerType));
                }
            }
        }

    }
}
