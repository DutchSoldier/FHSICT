using System;
using System.Collections.Generic;
using System.Text;

namespace Algoritmiek1
{
  class Program
  {
    static void Main()
    {
      Container c = new Container();
     
      Random r = new Random();
      for (int i = 0; i < 10; i++)
      {
        c.Add( r.Next( 500 ) );
      }

      for (int i=0; i<c.Count; i++) {
        Console.Write(c.GetItem(i)+" ");
      }
      Console.WriteLine();

      c.Add( 250 );
      for (int i = 0; i < c.Count; i++)
      {
        Console.Write( c.GetItem( i ) + " " );
      }
      Console.WriteLine();


      Console.WriteLine( c.Search( 250 ) + "" );

      Console.ReadLine();
    }

  }
}
