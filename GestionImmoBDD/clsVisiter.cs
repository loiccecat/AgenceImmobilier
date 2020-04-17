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
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}