package week311;

public class Week311 {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) throws Exception {
        TimeStamp ts = new TimeStamp();
        ts.setBegin("begin meting");
        
        try
        {
            for (int i = 0; i < args.length; i=i+2)
            {
                //Runnable runnable = new Runnable(args[i], args[i+1]);
                Runner runner = new Runner(args[i],args[i+1]);
                Thread thread1 = new Thread(runner);
                thread1.start();
            }
        }
        catch (Exception e)
        {
            throw e;
        }
    
        ts.setEnd("eind meting");
        System.out.print(ts.toString()); 
    }

}
