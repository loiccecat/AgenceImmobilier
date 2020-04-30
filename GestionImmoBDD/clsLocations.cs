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

        private DateTime cDateDebut { get; set; }
        public DateTime DateDebut
        {
            get => cDateDebut;

            set
            {
                if (value < BienImmobiliers?.DateLocation) { throw new ArgumentException($"{nameof(DateDebut)} : La date de début de location doit être postérieure ou égale à la date de mise en location du bien immobilier."); }
                if (value > DateFin)                       { throw new ArgumentException($"{nameof(DateDebut)} : La date de début de location doit être inférieur à la date de fin de location du bien immobilier."); }
                if (value > DateTime.Now)                  { throw new ArgumentException($"{nameof(DateDebut)} : La date de début de location doit être inférieur ou égale à la date d'aujourd'hui."); }
            }
        }

        private DateTime cDateFin { get; set; }
        public DateTime DateFin
        {
            get => cDateDebut;

            set
            {
                if (value < BienImmobiliers?.DateLocation) { throw new ArgumentException($"{nameof(DateFin)} : La date de fin de location doit être postérieure ou égale à la date de mise en location du bien immobilier."); }
                if (value < DateDebut)                     { throw new ArgumentException($"{nameof(DateFin)} : La date de fin de location doit être supérieur à la date de début de location du bien immobilier."); }
                if (value < DateTime.Now)                  { throw new ArgumentException($"{nameof(DateFin)} : La date de fin de location doit être supérieur ou égale à la date d'aujourd'hui."); }
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