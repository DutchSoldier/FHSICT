/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package aex.banner;
import java.util.Timer;
import javax.swing.Timer;
/**
 *
 * @author Remi_Arts
 */
public class MockEffectenbeurs extends java.util.TimerTask implements IEffectenbeurs{

    int aandeelkoers;
    
    @Override
    public IFonds getKoersen() {
        throw new UnsupportedOperationException("Not supported yet.");
    }
    
    public void random()
    {
        aandeelkoers = (int)Math.random();
    }
    
    public void run() 
    {
        try
        {
            while(true)
            {
                
                random();
                sleep(20);
            }
        } 
        catch (InterruptedException e)
        {
        }
    }   
}
