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

        #region Cardinalité de type [1:N], côté 1 : 1 client par location.
        public Clients Clients { get; set; }
        #endregion


        #region Cardinalité de type [1:N], côté 1 : 1 agent par location.
        public Agents Agents { get; set; }
        #endregion


        #region Cardinalité de type [1:N], côté 1 : 1 bien immobilier par location.
        public BienImmobiliers BienImmobiliers { get; set; }
        #endregion


        public event PropertyChangedEventHandler PropertyChanged;
    }
}