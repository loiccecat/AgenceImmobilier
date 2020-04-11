using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace GestionImmoBDD
{
    public class Types : INotifyPropertyChanged
    {
        public int ID { get; set; }
        
        public string Designation { get; set; }


        #region Cardinalité de type [1:N], côté N : Plusieurs biens immobiliers possibles par type.
        public ObservableCollection<BienImmobiliers> BienImmobiliers { get; set; } = new ObservableCollection<BienImmobiliers>();
        #endregion

        public event PropertyChangedEventHandler PropertyChanged;
    }
}