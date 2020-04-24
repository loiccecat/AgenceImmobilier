using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace GestionImmoBDD
{
    public class Locations : INotifyPropertyChanged
    {
        public int ID { get; set; }
        private uint cPrix { get; set; }

        public uint Prix
        {
            get => cPrix;

            set
            {
                uint lValue = value;

                if (lValue > 0) cPrix = lValue;
            }
        }

        public string PrixText => $"{Prix}€/mois";

        #region Cardinalité de type [1:N], côté 1 : 1 client par location.
        public Clients Clients { get; set; }
        public int ClientsID { get; internal set; }
        #endregion


        #region Cardinalité de type [1:N], côté 1 : 1 agent par location.
        public Agents Agents { get; set; }
        public int AgentsID { get; internal set; }
        #endregion


        #region Cardinalité de type [1:N], côté 1 : 1 bien immobilier par location.
        public BienImmobiliers BienImmobiliers { get; set; }
        public int BienImmobiliersID { get; internal set; }
        #endregion


        public event PropertyChangedEventHandler PropertyChanged;
    }
}