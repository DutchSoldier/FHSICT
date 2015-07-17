package week3910;
/**
 *
 * @author me
 */
public class Week3910 {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) throws Exception {
       
        for (int i = 0; i < args.length; i=i+2)
        {
            String s = args[i] + " " + args[i+1];
            execProcess(s);
        }
    }

    public static void execProcess(String process) throws Exception{
        Runtime runtime =  Runtime.getRuntime();
        try
        {
            Process p = runtime.exec(process);
        }
        catch(Exception e)
        {
            throw e;
        }      
    }

}
