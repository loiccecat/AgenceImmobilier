using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace GestionImmoBDD
{
    public class Proprietaires : INotifyPropertyChanged
    {
        public int ID { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string RueNumero { get; set; }
        public string RNN { get; set; }

        private string cNumeroTelephone = "";

        public string NumeroTelephone
        {
            get => cNumeroTelephone;
            set
            {
                if (value != null && value.Length >= 4 && (value.Substring(0, 4) == "0032" || value.Substring(0, 3) == "+32")) { cNumeroTelephone = value; }
            }
        }

        #region Cardinalité de type [1:N], côté 1 : 1 ville par propriétaire.
        public Villes Villes { get; set; }
        public int VillesID { get; internal set; }
        #endregion

        #region Cardinalité de type [1:N], côté N : Plusieurs biens immobiliers possibles par propriétaires.
        public ObservableCollection<BienImmobiliers> BienImmobiliers { get; set; } = new ObservableCollection<BienImmobiliers>();
        #endregion

        public string NomComplet => $"{Nom} {Prenom}";

        public event PropertyChangedEventHandler PropertyChanged;
    }
}