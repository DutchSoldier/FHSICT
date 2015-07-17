package week334;

import java.lang.Runtime;
/**
 *
 * @author me
 */
public class Week334 {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        //Vraag 3
        Runtime runtime =  Runtime.getRuntime();
        
        int aantalProcessoren = runtime.availableProcessors();
        int kb = 1024;
        
        System.out.println("Aantal processoren: " + aantalProcessoren);
        System.out.println("Gebruikt geheugen: " + (runtime.totalMemory() - runtime.freeMemory()) /kb + " KB");
        System.out.println("Vrije geheugen: " + runtime.freeMemory() /kb + " KB");
        System.out.println("Totaal geheugen: " + runtime.totalMemory() /kb + " KB");
        System.out.println("Maximale geheugen: " + runtime.maxMemory() / kb + " KB");
        
        //vraag 4
        System.out.println("Voor loop ");
        System.out.println("Gebruikt geheugen: " + (runtime.totalMemory() -runtime.freeMemory()) /kb + "KB");
        
        for (int i = 0; i < 100000; i++)
        {
            String s = "BLAAT"+i;
            //System.out.println(s);
        }
        System.out.println("Na loop");
        System.out.println("Gebruikt geheugen: " + (runtime.totalMemory() -runtime.freeMemory()) /kb + "KB");
        
        runtime.gc();
        System.out.println("Voor garbage collector");
        System.out.println("Gebruikt geheugen: " + (runtime.totalMemory() -runtime.freeMemory()) /kb + "KB");  
    }
}
