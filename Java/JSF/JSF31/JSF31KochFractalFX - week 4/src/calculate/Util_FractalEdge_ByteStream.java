/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package calculate;

import java.io.DataInputStream;
import java.io.DataOutputStream;
import java.io.FileInputStream;
import java.io.FileNotFoundException;
import java.io.FileOutputStream;
import java.io.IOException;
import java.util.logging.Level;
import java.util.logging.Logger;

/**
 *
 * @author me
 */
public class Util_FractalEdge_ByteStream implements IReadWriteFractalEdge {

    @Override
    public KochFractal readFractal() {
                DataInputStream dis;
        KochFractal returnvalue = null;
        try {
            dis = new DataInputStream(new FileInputStream("KochFractal.byte"));
            int level = dis.readInt();
            returnvalue = new KochFractal();
            returnvalue.setLevel(level);

        } catch (FileNotFoundException e) {
            Logger.getLogger(Util_FractalEdge_ByteStream.class.getName()).log(Level.SEVERE, null, e);
        
        } catch (IOException e) {
            e.printStackTrace();
        } finally {
            return returnvalue;
        }
    }

    @Override
    public void writeFractal(KochFractal fractal) {
        FileOutputStream out = null;
        try {
            out = new FileOutputStream("KochFractal.byte");
            // DataOutputStream voor de mooie methodes
            DataOutputStream dos = new DataOutputStream(out);

            dos.writeInt(fractal.getLevel());
            //
            out.close();
        } catch (FileNotFoundException ex) {
            Logger.getLogger(Util_FractalEdge_ByteStream.class.getName()).log(Level.SEVERE, null, ex);
        } catch (IOException ioe) {
            ioe.printStackTrace();
        } finally {
            try {
                out.close();
            } catch (IOException ex) {
                Logger.getLogger(Util_FractalEdge_ByteStream.class.getName()).log(Level.SEVERE, null, ex);
            }
        }
    }
}

