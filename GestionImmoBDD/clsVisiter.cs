using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using System.ComponentModel;



namespace GestionImmoBDD
{
    /// <summary>
    /// Classe représeant la Cardinalité de type [M:N] entre clients et locations.
    /// </summary>
    public class Visiter : INotifyPropertyChanged
    {
        private DateTime cDateVisite = DateTime.Now;

        public static readonly int VisiteHeureMax = 17;

        public static readonly int VisiteHeureMin = 8;
        

        public int LocationsID { get; set; }
        public Locations Locations { get; set; }

        public int ClientsID { get; set; }
        public Clients Clients { get; set; }

        public DateTime DateVisite
        {
            get => cDateVisite;

            set
            {
                if (value <= DateTime.Now) { throw new ArgumentException($"{nameof(DateVisite)} : La date de visite doit être supérieur à la date d'aujourd'hui."); }
                if (value.Hour > VisiteHeureMax) { throw new ArgumentException($"{nameof(DateVisite)} : L'heure de visite ne peut être supérieur à 17h."); }
                if (value.Hour < VisiteHeureMin) { throw new ArgumentException($"{nameof(DateVisite)} : L'heure de visite ne peut être inférieur à 8h."); }
                cDateVisite = value;
            }
        }

       

        public event PropertyChangedEventHandler PropertyChanged;
    }
}