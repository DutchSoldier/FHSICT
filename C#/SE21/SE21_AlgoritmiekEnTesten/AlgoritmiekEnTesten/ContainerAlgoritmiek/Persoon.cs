using System;
using System.Collections.Generic;
using System.Text;

namespace Algoritmiek
{
  public class Persoon : IComparable
  {
    private static int nextId = 1;

    /**** datavelden***************************************************/

    private int id;
    private String naam;
    private String woonplaats;

    /**** constructor**************************************************/

    public Persoon(String naam, String woonplaats)
    {
      id = nextId;
      nextId++;
      this.naam = naam;
      this.woonplaats = woonplaats;
    }

    /**** properties***************************************************/

    public String Naam { get { return naam; } }
    public int Id { get { return id; } }
    public String Woonplaats { get { return woonplaats; } }

    /***** methoden ***************************************************/

    /// <returns>
    /// een negatief getal als de Id van deze persoon kleiner is dan de Id van obj; 
    /// nul als de Id van deze persoon gelijk aan de Id van obj;
    /// een positief getal als de Id van deze persoon groter is dan de Id van obj
    /// </returns>
    public int CompareTo(Object obj)
    {
      Persoon p = (Persoon)obj;
      return Id - p.Id;
    }


  }
}

