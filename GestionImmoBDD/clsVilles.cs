using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace GestionImmoBDD
{
    public class Villes : INotifyPropertyChanged
    {
        public int ID { get; set; }
        public string Nom { get; set; }
        public string CodePostal { get; set; }


        #region Cardinalité de type [1:N], côté N : Plusieurs clients possibles par ville.
        public ObservableCollection<Clients> Clients { get; set; } = new ObservableCollection<Clients>();
        #endregion


        #region Cardinalité de type [1:N], côté N : Plusieurs agents possibles par ville.
        public ObservableCollection<Agents> Agents { get; set; } = new ObservableCollection<Agents>();
        #endregion


        #region Cardinalité de type [1:N], côté N : Plusieurs propriétaires possibles par ville.
        public ObservableCollection<Proprietaires> Proprietaires { get; set; } = new ObservableCollection<Proprietaires>();
        #endregion


        #region Cardinalité de type [1:N], côté N : Plusieurs biens immobiliers possibles par ville.
        public ObservableCollection<BienImmobiliers> BienImmobiliers { get; set; } = new ObservableCollection<BienImmobiliers>();
        #endregion

        public event PropertyChangedEventHandler PropertyChanged;
    }
}