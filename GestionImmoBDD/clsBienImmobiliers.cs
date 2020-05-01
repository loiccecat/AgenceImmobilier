using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace GestionImmoBDD
{
    public class BienImmobiliers : INotifyPropertyChanged
    {
        public int ID { get; set; }
        public string RueNumero { get; set; }
        public DateTime DateLocation { get; set; }


        #region Cardinalité de type [1:N], côté 1 : 1 ville par bien immobilier.
        public Villes Villes { get; set; }
        public int VillesID { get; internal set; }
        #endregion


        #region Cardinalité de type [1:N], côté 1 : 1 propriétaire par bien immobilier.
        public Proprietaires Proprietaires { get; set; }
        public int ProprietairesID { get; internal set; }
        #endregion


        #region Cardinalité de type [1:N], côté 1 : 1 type par bien immobilier.
        public Types Types { get; set; }
        public int TypesID { get; internal set; }
        #endregion


        #region Cardinalité de type [1:N], côté N : Plusieurs locations possibles par bien immobilier.
        public ObservableCollection<Locations> Locations { get; set; } = new ObservableCollection<Locations>();
        #endregion

        public event PropertyChangedEventHandler PropertyChanged;
    }
}