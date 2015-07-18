/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package PTS31_Server;

import java.util.ArrayList;

/**
 *
 * @author Jan-Laptop
 */
public class Chat 
{
    private ArrayList<String> berichten;
    public ArrayList<String> oldvalue;
    public int regels;
    
    public Chat(int regels)
    {
        berichten = new ArrayList<>();
        this.regels = regels;
    }
    
    public ArrayList<String> getBerichten()
    {
        return berichten;
    }
    
    public void addBericht(String bericht, String verzender)
    {
        oldvalue = new ArrayList();
        oldvalue.addAll(berichten);
        if(berichten.size() > regels-1) {
            berichten.remove(0);
        }
        berichten.add(verzender + ": " + bericht);
    }
}
