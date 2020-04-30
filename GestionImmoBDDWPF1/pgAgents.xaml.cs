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
    /// Logique d'interaction pour pgAgents.xaml
    /// </summary>
    public partial class pgAgents : Page
    {
        BDDSingleton BDD = BDDSingleton.Instance;
        public ReadOnlyObservableCollection<Villes> Villes => BDD.Villes;

        public pgAgents()
        {
            InitializeComponent();
            grpAgents.DataContext = BDD.Agents;
        }

        private void AjouterAgent(object sender, RoutedEventArgs e)
        {
            Statics.TryCatch(() => { lvAgents.SelectedItem = BDD.AjouterAgent("Nouvel", "Agent", BDD.Villes.FirstOrDefault(), ""); }, nameof(AjouterAgent));
        }

        private void SupprimerAgent(object sender, RoutedEventArgs e)
        {
            Agents selection = (Agents)lvAgents.SelectedItem;
            if (selection != null)
            {
                if (MessageBox.Show($"Etes-vous sur de vouloir supprimer l'agent {selection.NomComplet} de la liste ?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    Statics.TryCatch(() => { BDD.SupprimerAgent(selection); }, nameof(SupprimerAgent));
                }
            }
        }
    }
}
