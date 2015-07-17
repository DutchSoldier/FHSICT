package week311;

import java.io.*;

public class Runnable {
    
    public Runnable(String process, String parameter) throws Exception
    {
        Runtime runtime =  Runtime.getRuntime();
        Process p;
        InputStream is;
        InputStreamReader isr;
        BufferedReader br;
        
        try
        {
            p = runtime.exec(process + " " + parameter);
                
            is = p.getInputStream();
            isr = new InputStreamReader(is);
            br = new BufferedReader(isr);
                
            String line;
            while ( (line = br.readLine()) != null)
            System.out.println(line);
            br.close();   
            
            p.waitFor();
            System.out.println("Process " + process + " " + parameter + " terminated");
        }
        catch(Exception e)
        {
            throw e;
        }
    }
    
}
