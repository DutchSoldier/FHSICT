using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using Algoritmiek;


namespace ContainerTest
{
  [TestFixture]
  public class UnitTestContainer
  {
 
    /************* testmethoden *********************************/

    [Test]
    public void TestLegeContainer()
    {
      Container container = new Container();
      Assert.AreEqual( 0, container.Items.Length );
      Assert.AreEqual( 0, container.Count( "wat dan ook" ) );
      //controle of de Sort- en Compressmethode geen Exception veroorzaken
      container.Compress();
      Assert.AreEqual( 0, container.Items.Length );
      container.Sort();
      Assert.AreEqual( 0, container.Items.Length );
    }

    [Test]
    public void TestCountMetInts()
    {
      Container container = new Container();
      container.Add( 2 );
      container.Add( 7 );
      container.Add( 5 );
      container.Add( 3 );
      container.Add( 2 );
      Assert.AreEqual( 5, container.Items.Length );
      Assert.AreEqual( 2, container.Count( 2 ) );
      Assert.AreEqual( 1, container.Count( 7 ) );
      Assert.AreEqual( 0, container.Count( 6 ) );

    }

    [Test]
    public void TestCountMetStrings()
    {
      Container container = new Container();
      container.Add( "c" );
      container.Add( "A" );
      container.Add( "goedemorgen" );
      container.Add( "c" );
      container.Add( "a" );
      Assert.AreEqual( 2, container.Count( "c" ) );
      Assert.AreEqual( 1, container.Count( "a" ) );
      Assert.AreEqual( 1, container.Count( String.Copy( "a" ) ) );
      Assert.AreEqual( 0, container.Count( "Goedemorgen" ) );
    }

    [Test]
    public void TestCountMetPersoon()
    {
      Container container = new Container();
      Persoon p = new Persoon( "jan", "eindhoven" );
      container.Add( new Persoon( "jan", "eindhoven" ) );
      container.Add( new Persoon( "jan", "eindhoven" ) );
      container.Add( p );
      container.Add( p );
      Assert.AreEqual( 4, container.Items.Length );
      Assert.AreEqual( 2, container.Count( p ) );
      Assert.AreEqual( 0, container.Count( new Persoon( "jan", "eindhoven" ) ) );
    }

    [Test]
    public void TestSortMetInts()
    {
      Container container = new Container();
      container.Add( 2 );
      container.Add( 7 );
      container.Add( 5 );
      container.Add( 3 );
      container.Add( 7 );
      container.Add( 2 );
      container.Sort();
      Object[] items = container.Items;
      Assert.AreEqual( 6, items.Length );
      Assert.AreEqual( 2, items[0] );
      Assert.AreEqual( 2, items[1] );
      Assert.AreEqual( 3, items[2] );
      Assert.AreEqual( 5, items[3] );
      Assert.AreEqual( 7, items[4] );
      Assert.AreEqual( 7, items[5] );
    }

    [Test]
    public void TestSortMetStrings()
    {
      Container container = new Container();

      container.Add( "c" );
      container.Add( "c" );
      container.Add( "A" );
      container.Add( "Goedemorgen" );
      container.Add( "a" );
      container.Add( "thee" );
      container.Add( "Koffie" );
      container.Add( "Groot" );
      container.Add( "goedemorgen" );
      container.Add( "klein" );

      container.Sort();
      Object[] items = container.Items;
      Assert.AreEqual( 10, items.Length );
      Assert.AreEqual( "a", items[0] );
      Assert.AreEqual( "A", items[1] );
      Assert.AreEqual( "c", items[2] );
      Assert.AreEqual( "c", items[3] );
      Assert.AreEqual( "goedemorgen", items[4] );
      Assert.AreEqual( "Goedemorgen", items[5] );
      Assert.AreEqual( "Groot", items[6] );
      Assert.AreEqual( "klein", items[7] );
      Assert.AreEqual( "Koffie", items[8] );
      Assert.AreEqual( "thee", items[9] );
    }

    [Test]
    public void TestSortMetPersoon()
    {
      Container container = new Container();

      Persoon p1 = new Persoon( "jan", "eindhoven" ),
              p2 = new Persoon( "Jan", "Amsterdam" ),
              p3 = new Persoon( "Piet", "Eindhoven" ),
              p4 = new Persoon( "jan", "eindhoven" );
      //in andere testen worden ook personen gecreeerd, dus eerst even kijken waar de
      //nummering voor deze test begint
      int startId = p1.Id;
      container.Add( new Persoon( "jan", "Tilburg" ) );
      container.Add( p3 );
      container.Add( p2 );
      container.Add( new Persoon( "piet", "Utrecht" ) );
      container.Add( p4 );
      container.Add( p3 );
      container.Add( p1 );

      container.Sort( );
      Assert.AreEqual( 7, container.Items.Length );
      Object[] items = container.Items;
      Assert.AreEqual( p1, items[0] );
      Assert.AreEqual( p2, items[1] );
      Assert.AreEqual( p3, items[2] );
      Assert.AreEqual( p3, items[3] );
      Assert.AreEqual( p4, items[4] );
      Assert.AreEqual( startId + 4, ((Persoon)items[5]).Id );
      Assert.AreEqual( startId + 5, ((Persoon)items[6]).Id );
    }

    [Test]
    public void TestCompressMetInts()
    {
      Container c1 = new Container();
      Container c2 = new Container();

      c1.Add( 2 );
      c1.Add( 7 );
      c1.Add( 5 );
      c1.Add( 3 );
      c1.Add( 2 );

      c2.Add( 2 );
      c2.Add( 7 );
      c2.Add( 5 );
      c2.Add( 3 );
      c2.Add( 2 );

      c2.Compress();

      Object[] items = c1.Items;
      foreach (IComparable o in c1.Items)
      {
        Assert.AreEqual( c2.Count( o ), 1 );
      }
      foreach (IComparable o in c2.Items)
      {
        Assert.AreNotEqual( 0, c1.Count( o ) );

      }

    }

    [Test]
    public void TestCompressMetStrings()
    {
      Container c1 = new Container();

      c1.Add( "c" );
      c1.Add( "c" );
      c1.Add( "A" );
      c1.Add( "Goedemorgen" );
      c1.Add( "a" );
      c1.Add( "thee" );
      c1.Add( "Koffie" );
      c1.Add( "Groot" );
      c1.Add( "goedemorgen" );
      c1.Add( "klein" );

      Container c2 = new Container();
      c2.Add( "c" );
      c2.Add( "c" );
      c2.Add( "A" );
      c2.Add( "Goedemorgen" );
      c2.Add( "a" );
      c2.Add( "thee" );
      c2.Add( "Koffie" );
      c2.Add( "Groot" );
      c2.Add( "goedemorgen" );
      c2.Add( "klein" );

      c2.Compress();

      Object[] items = c1.Items;
      foreach (IComparable o in c1.Items)
      {
        Assert.AreEqual( c2.Count( o ), 1 );
      }
      foreach (IComparable o in c2.Items)
      {
        Assert.AreNotEqual( 0, c1.Count( o ) );

      }
    }

    [Test]
    public void TestCompressMetPersoon()
    {
      Container c1 = new Container();

      Persoon p1 = new Persoon( "jan", "eindhoven" ),
              p2 = new Persoon( "Jan", "Amsterdam" ),
              p3 = new Persoon( "Piet", "Eindhoven" ),
              p4 = new Persoon( "jan", "eindhoven" ),
              p5 = new Persoon( "jan", "Tilburg" ),
              p6 = new Persoon( "piet", "Utrecht" );
      
      c1.Add( p5 );
      c1.Add( p3 );
      c1.Add( p2 );
      c1.Add( p6 );
      c1.Add( p4 );
      c1.Add( p3 );
      c1.Add( p1 );
      c1.Add( p5 );
      c1.Add( p2 );
      c1.Add( p5 );
      
      Container c2 = new Container();

      c2.Add( p5 );
      c2.Add( p3 );
      c2.Add( p2 );
      c2.Add( p6 );
      c2.Add( p4 );
      c2.Add( p3 );
      c2.Add( p1 );
      c2.Add( p5 );
      c2.Add( p2 );
      c2.Add( p5 );

      c2.Compress();

      Object[] items = c1.Items;
      foreach (IComparable o in c1.Items)
      {
        Assert.AreEqual( c2.Count( o ), 1 );
      }
      foreach (IComparable o in c2.Items)
      {
        Assert.AreNotEqual( 0, c1.Count( o ) );

      }
    }

  }
}