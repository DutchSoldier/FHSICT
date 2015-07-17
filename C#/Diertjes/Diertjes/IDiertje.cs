// -----------------------------------------------------------------------
// <copyright file="IDiertje.cs" company="">
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
    interface IBeestje
    {
        string naam {get; set; } 
        int leeftijd { get; set; }
        bool levend { get; set; }
        
        void Lopen();
        void Schijten();
        void Schaften();
    }
}
