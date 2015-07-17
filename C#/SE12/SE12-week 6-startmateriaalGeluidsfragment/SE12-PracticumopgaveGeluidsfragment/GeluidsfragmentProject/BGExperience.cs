using System;
using System.Collections.Generic;
using System.Text;
using System.Media;
using System.Windows.Forms;

namespace Hilversum
{
  class BGExperience
  {
    /******** datavelden ******************************************************/

    private List<Geluidsfragment> fragmenten;

    private DatabaseClass dbc;

    /******** constructoren ***************************************************/
    public BGExperience()
    {
      fragmenten = new List<Geluidsfragment>();
      dbc = new DatabaseClass();
    }

    /******** properties ********************************************************/


      /******** methoden ********************************************************/
   
    // returns het geluidsfragment met nummer nr, 
    // tenzij dat niet bekend is, dan wordt er null geretourneerd
    public void Remove(int i)
    {
        dbc.RemoveItem(i);

    }
      
    public Geluidsfragment GetFragment(List<Geluidsfragment> gf, int nr)
    {
        foreach (Geluidsfragment ga in gf)
        {
            if (ga.Nr == nr)
            {
                return ga;
            }
        }
        return null;
        
    }

    // returns een list met alle geluidsfragmenten.
   public List<Geluidsfragment> GetAlleFragmenten()
    {
        return dbc.Getallefragmenten();
    }
      
    // returns een list met alle geluidsfragmenten met patroon p in de titel.
  /*  public List<Geluidsfragment> GetFragment(String p)
    {
        //TODO
        //Hint: Maak gebruik van de methode IndexOf van een String om te
        //achterhalen of een zeker patroon voor komt in een string.
    }*/

    // indien het opgegeven nummer nr nog niet is toegewezen aan een ander geluidsfragment,
    // dan: wordt een geluidsfragment met de overgedragen gegevens gecreeerd en
    // bij aan de list fragmenten toegevoegd; de returnwaarde is dan true,
    // anders: er is geen nieuw Geluidsfragment-object toegevoegd en de
    // returnwaarde is false
    public void AddFragment(int nr, String bestandsnaam, String titel, int min, int sec) 
    {
      // TODO 
            //fragmenten.Add(new Geluidsfragment(nr, bestandsnaam, titel, min, sec));
            dbc.VoegToe(nr, titel, bestandsnaam, (min * 60) + sec);

    }

  }
}
