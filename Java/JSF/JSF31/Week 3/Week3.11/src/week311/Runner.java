/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package week311;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStream;
import java.io.InputStreamReader;
import java.util.logging.Level;
import java.util.logging.Logger;

/**
 *
 * @author me
 */
public class Runner implements java.lang.Runnable {
    private String process;
    private String parameter;

    public Runner(String process, String parameter) {
        this.parameter = parameter;
        this.process = process;
    }

    @Override
    public void run() {
        try {
            Runtime runtime = Runtime.getRuntime();
            Process p;
            InputStream is;
            InputStreamReader isr;
            BufferedReader br;

            p = runtime.exec(process + " " + parameter);

            is = p.getInputStream();
            isr = new InputStreamReader(is);
            br = new BufferedReader(isr);

            String line;
            while ((line = br.readLine()) != null) {
                System.out.println(line);
            }
            br.close();
            try {
                p.waitFor();
            } catch (InterruptedException ex) {
                Logger.getLogger(Runner.class.getName()).log(Level.SEVERE, null, ex);
            }
            System.out.println("Process " + process + " " + parameter + " terminated");
        } catch (IOException ex) {
            Logger.getLogger(Runner.class.getName()).log(Level.SEVERE, null, ex);
        }

    }
}
