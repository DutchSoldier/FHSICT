/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package calculate;

import java.io.FileInputStream;
import java.io.FileOutputStream;
import java.io.IOException;
import java.io.ObjectInputStream;
import java.io.ObjectOutputStream;
import java.util.logging.Level;
import java.util.logging.Logger;

/**
 *
 * @author me
 */
public class Util_FractalEdge_ObjectStream implements IReadWriteFractalEdge {

    @Override
    public KochFractal readFractal() {
        KochFractal returnvalue = null;
        try {
            ObjectInputStream in = new ObjectInputStream(new FileInputStream(
                    "KochFractal.dat"));
            //
            returnvalue = (KochFractal) in.readObject();

        } catch (IOException ioe) {
            ioe.printStackTrace();
        } catch (ClassNotFoundException cnfe) {
            cnfe.printStackTrace();
        } finally {
            return returnvalue;
        }
    }

    @Override
    public void writeFractal(KochFractal fractal) {
        try {
            final ObjectOutputStream fos;
            fos = new ObjectOutputStream(new FileOutputStream("KochFractal.dat"));
            fos.writeObject(fractal);
            fos.flush();
            fos.close();

        } catch (IOException ex) {
            Logger.getLogger(Util_FractalEdge_ObjectStream.class.getName()).log(Level.SEVERE, null, ex);
        }
    }


    public static void main(String[] args) {
        IReadWriteFractalEdge utilObject = new Util_FractalEdge_ObjectStream();
        KochFractal testFractal = new KochFractal();
        testFractal.setLevel(2);
        testFractal.generateBottomEdge();
        testFractal.generateLeftEdge();
        testFractal.generateRightEdge();
        //
        utilObject.writeFractal(testFractal);
        //
        KochFractal readFractal = utilObject.readFractal();
        //
        System.out.println("Level: " + readFractal.getLevel());
        System.out.println("NrOfEdges: " + readFractal.getNrOfEdges());
        for (Edge e : readFractal.edges) {
            System.out.println("Edge: " + e.toString());
        }
    }
}
