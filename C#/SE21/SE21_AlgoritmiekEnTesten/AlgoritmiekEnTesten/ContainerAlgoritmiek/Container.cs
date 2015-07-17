using System;
using System.Collections.Generic;
using System.Text;


namespace Algoritmiek
{
  class Result
  {
    public int p;
    public int q;
  }

  // een container die objecten registreert; voor alle objecten in deze container 
  // is de interface IComparable op een zelfde manier geimplementeerd
  public class Container
  {
    /****************** datavelden *********************************************/

    private List<IComparable> items;

    /****************** constructor ********************************************/ 

    // creatie lege container
    public Container()
    {
      items = new List<IComparable>();
    }

    /****************** properties *********************************************/

    // de items in de volgorde dat ze nu bij de container geregistreerd staan
    public Object[] Items { get { return items.ToArray(); } }

    /****************** methoden ***********************************************/

    // retourneert het aantal keren dat het obj conform CompareTo voorkomt in deze 
    // container
    public int Count(IComparable obj)
    {
      //ToDo
      return 0;
    }

    // obj wordt aan de container toegevoegd
    public void Add(IComparable obj)
    {
      items.Add( obj );
    }

    // de items worden in de container van klein naar groot gesorteerd;
    public void Sort()
    {
      //ToDo
    }


    //   alle objectgelijken (conform CompareTo) zijn uit de container verwijderd, dwz
    //   neem aan dat de container vooraf gelijk is aan C0 en achteraf gelijk is aan C1 dan:
    //   voor elk object obj in C0: C1.Count(obj) = 1 en  
    //   voor elk object obj in C1: C0.Count(obj) >= 1
    public void Compress()
    {
      //ToDo
    }

  }

}