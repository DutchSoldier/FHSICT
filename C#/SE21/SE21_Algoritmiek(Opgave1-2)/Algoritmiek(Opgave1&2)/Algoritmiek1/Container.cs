using System;
using System.Collections.Generic;
using System.Text;

namespace Algoritmiek1
{
  /// <summary>
  /// een container met objecten van een zeker specifiek type die
  /// aan de interface IComparable voldoen
  /// </summary>
  public class Container
  {
    /***********datavelden*****************************************/

    private List<IComparable> items;

    /***********constructoren**************************************/

    public Container()
    {
      items = new List<IComparable>();
    }

    /***********properties*****************************************/

    public int Count { get { return items.Count; } }

    /***********methoden  *****************************************/

    /// <returns>als 0 <= i < Count dan het ie item uit de container,
    /// anders null (nummering van de items geschiedt vanaf 0)
    /// </returns>
    public Object GetItem(int i)
    {
      if (0 <= i && i < Count)
        return items[i];
      else
        return null;
    }

    public void Add(IComparable obj)
    {
      items.Add( obj );
      items.Sort();
    }


    /// <returns>de index waarop obj in container voorkomt, als obj niet 
    /// in container voorkomt dan wordt er -1 geretourneerd</returns>
    public int Search(IComparable obj)
    {
      if (Count == 0) return -1;

      
      int vanaf = 0;
      int tot = Count;
      while (tot - vanaf > 1)
      {
        int m = (tot + vanaf) / 2;
        if (obj.CompareTo( items[m] ) < 0) tot = m;
        else vanaf = m;
        
      }

      if (items[vanaf].CompareTo( obj ) == 0) return vanaf;

      return -1;
    }
  }
}
