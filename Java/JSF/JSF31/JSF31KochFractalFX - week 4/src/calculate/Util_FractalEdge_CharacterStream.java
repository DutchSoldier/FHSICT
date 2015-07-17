/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package calculate;

import java.io.FileReader;
import java.io.FileWriter;
import java.io.IOException;
import java.io.PrintWriter;
import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;
import java.util.logging.Level;
import java.util.logging.Logger;

/**
 *
 * @author me
 */
public class Util_FractalEdge_CharacterStream implements IReadWriteFractalEdge {

    @Override
    public KochFractal readFractal() {
        KochFractal returnvalue = null;
        try {
            FileReader fr = new FileReader("KochFractal.txt");
            // weinig methoden om te lezen, gebruik Scanner klasse hiervoor
            Scanner inputScanner = new Scanner(fr);
            String regel = inputScanner.nextLine();

            returnvalue = new KochFractal();
        } catch (IOException e) {
            e.printStackTrace();
        } finally {
            return returnvalue;
        }
    }

    @Override
    public void writeFractal(KochFractal fractal) {
        FileWriter fw;
        try {
            fw = new FileWriter("KochFractal.txt");
            PrintWriter pr = new PrintWriter(fw);
            pr.println(fractal);
            //writeEdges(fractal.edges);

            pr.close();
        } catch (IOException ex) {
            Logger.getLogger(Util_FractalEdge_CharacterStream.class.getName()).log(Level.SEVERE, null, ex);
        }
    }
    
    public static void main(String[] args) {
        IReadWriteFractalEdge utilObject = new Util_FractalEdge_CharacterStream();
        KochFractal writeFractal = new KochFractal();
        writeFractal.setLevel(2);
        writeFractal.generateBottomEdge();
        writeFractal.generateLeftEdge();
        writeFractal.generateRightEdge();
        //
        utilObject.writeFractal(writeFractal);
        //
        KochFractal readFractal = utilObject.readFractal();
        //
        System.out.println(readFractal.getLevel());
        System.out.println(readFractal.getNrOfEdges());
        
        for(Edge e:readFractal.edges){
            System.out.println(e.toString());
        }
    }
}
