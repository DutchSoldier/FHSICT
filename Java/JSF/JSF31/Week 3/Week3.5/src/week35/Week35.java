package week35;
/**
 *
 * @author me
 */
public class Week35 {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) throws Exception {
        try
        {
            ProcessBuilder pb = new ProcessBuilder("gnome-calculator");
            Process p = pb.start();
            Thread.sleep(3000);
            p.destroy();
        }
        catch(Exception e)
        {
            throw e;
        }
        
        Runtime runtime =  Runtime.getRuntime();
        try
        {
            Process p = runtime.exec("gnome-calculator");
            Thread.sleep(3000);
            p.destroy();
        }
        catch(Exception e)
        {
            throw e;
        }      
    }

}
