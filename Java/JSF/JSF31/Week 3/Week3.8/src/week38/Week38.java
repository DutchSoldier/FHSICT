package week38;
/**
 *
 * @author me
 */
public class Week38 {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) throws Exception {
        TimeStamp ts = new TimeStamp();
        ts.setBegin("Begin:");
        
        createProcessPb();
        ts.setEndBegin("Eind process PB");
        
        createProcessExec();
        ts.setEnd("Eind process Exec");
        
        System.out.print(ts.toString()); 
    }
    
    public static void createProcessPb() throws Exception{
        try
        {
            ProcessBuilder pb = new ProcessBuilder("gnome-calculator");
            Process p = pb.start();
            p.destroy();
        }
        catch(Exception e)
        {
            throw e;
        }
    }
    
    public static void createProcessExec() throws Exception{
        Runtime runtime =  Runtime.getRuntime();
        try
        {
            Process p = runtime.exec("gnome-calculator");
            p.destroy();
        }
        catch(Exception e)
        {
            throw e;
        }      
    }
}
