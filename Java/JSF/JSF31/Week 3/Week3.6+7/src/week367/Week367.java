package week367;

import java.io.*;
/**
 *
 * @author me
 */
public class Week367 {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) throws Exception {
        Runtime runtime =  Runtime.getRuntime();
        
        try
        {
            Process proc = runtime.exec("/bin/ls");
            InputStream is = proc.getInputStream();
            InputStreamReader isr = new InputStreamReader(is);
            BufferedReader br = new BufferedReader(isr);

            String line;
            while ( (line = br.readLine()) != null)
            System.out.println(line);
            br.close();           
        }
        catch(Exception e)
        {
            throw e;
        }         
    }

}
