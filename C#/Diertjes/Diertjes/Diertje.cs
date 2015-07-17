// -----------------------------------------------------------------------
// <copyright file="Diertje.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Diertjes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;


    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class Diertje : IBeestje
    {
        public Diertje(string naam, int leeftijd, bool levend)
        {
            this.naam = naam;
            this.leeftijd = leeftijd;
            this.levend = levend;
        }

        public string naam { get; set; }
        public int leeftijd { get; set; }
        public bool levend { get; set; }


        public void Lopen()
        {
            Console.WriteLine("Diertje loopt");
        }

        public void Schaften()
        {
            Console.WriteLine("Diertje schaft");
        }

        public void Schijten()
        {
            Console.WriteLine("Diertje schijt");
        }
    }
   
}
