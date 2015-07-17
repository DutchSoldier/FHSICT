/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package console;

import calculate.Edge;
import calculate.KochFractal;
import java.io.BufferedInputStream;
import java.io.BufferedOutputStream;
import java.io.BufferedWriter;
import java.io.DataOutputStream;
import java.io.File;
import java.io.FileOutputStream;
import java.io.FileWriter;
import java.io.IOException;
import java.io.ObjectOutputStream;
import java.io.OutputStream;
import java.nio.ByteBuffer;
import java.nio.channels.FileChannel;
import java.nio.charset.StandardCharsets;
import java.nio.file.Files;
import java.nio.file.Paths;
import java.util.ArrayList;
import java.util.InputMismatchException;
import java.util.Observable;
import java.util.Observer;
import java.util.Scanner;
import java.util.logging.Level;
import java.util.logging.Logger;
import timeutil.TimeStamp;

/**
 *
 * @author Frank
 */
public class Console implements Observer {

    public static final String file = "fractal";

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        Console console = new Console();

        MenuItem choice = console.kiesMenuItem();
        while (choice != MenuItem.EXIT) {

            switch (choice) {
                case CHLVL:
                    int level = console.readInt("voer een level in");
                    console.setLevel(level);
                    break;
                case GENERATE:
                    console.generateEdges();
                    break;
                case SAVE:
                    console.saveFractalToFile();
                    break;
            }
            choice = console.kiesMenuItem();
        }
    }
    // **********datavelden**********************************************
    private Scanner input;
    private KochFractal fractal;
    private int level = 1;
    private ArrayList<Edge> edges;

    // **********constructoren*******************************************
    public Console() {
        input = new Scanner(System.in);
        fractal = new KochFractal();
        edges = new ArrayList<Edge>();
        fractal.setLevel(level);
        fractal.addObserver(this);
    }

    public void generateEdges() {
        fractal.generateBottomEdge();
        fractal.generateLeftEdge();
        fractal.generateRightEdge();
    }

    public void setLevel(int level) {
        this.level = level;
        this.fractal.setLevel(level);
    }

    public void saveFractalToFile() {
        try {
            TimeStamp stamp = new TimeStamp();

            // Zonder buffer - binair
            stamp.setBegin("START BINAIR NO-BUFFER SAVING");
            DataOutputStream nonBufferedBinairStream = new DataOutputStream(new FileOutputStream(file + "binair_no_buffer.dat"));
            nonBufferedBinairStream.writeInt(level);
            for (Edge edge : edges) {
                nonBufferedBinairStream.writeDouble(edge.X1);
                nonBufferedBinairStream.writeDouble(edge.Y1);
                nonBufferedBinairStream.writeDouble(edge.X2);
                nonBufferedBinairStream.writeDouble(edge.Y2);
                nonBufferedBinairStream.writeInt(edge.color.getRGB());
            }
            nonBufferedBinairStream.close();
            stamp.setEnd("END BINAIR NO-BUFFER SAVING");
            System.out.println(stamp.toString());

            stamp = new TimeStamp();

            // Zonder buffer - text  
            stamp.setBegin("START TEXT NO-BUFFER SAVING");
            ArrayList<String> strings = new ArrayList<String>();
            strings.add("" + level);
            for (Edge edge : edges) {
                strings.add(edge.toString().replace(".", ","));
            }
            Files.write(Paths.get(file + "text_no_buffer.dat"), strings, StandardCharsets.UTF_8);
            stamp.setEnd("END TEXT NO-BUFFER SAVING");
            System.out.println(stamp.toString());

            stamp = new TimeStamp();

            // Met buffer - binair
            stamp.setBegin("START BINAIR BUFFER SAVING");
            DataOutputStream bufferedBinairStream = new DataOutputStream(new BufferedOutputStream(new FileOutputStream(file + "binair_buffer.dat")));
            bufferedBinairStream.writeInt(level);
            for (Edge edge : edges) {
                bufferedBinairStream.writeDouble(edge.X1);
                bufferedBinairStream.writeDouble(edge.Y1);
                bufferedBinairStream.writeDouble(edge.X2);
                bufferedBinairStream.writeDouble(edge.Y2);
                bufferedBinairStream.writeInt(edge.color.getRGB());
            }
            bufferedBinairStream.close();
            stamp.setEnd("END BINAIR BUFFER SAVING");
            System.out.println(stamp.toString());

            stamp = new TimeStamp();

            // Met buffer - text  
            stamp.setBegin("START TEXT BUFFER SAVING");
            BufferedWriter writer = new BufferedWriter(new FileWriter(file + "text_buffer.dat"));
            writer.write("" + level);
            writer.newLine();
            for (Edge edge : edges) {
                writer.write(edge.toString().replace(".", ","));
                writer.newLine();
            }
            writer.close();
            stamp.setEnd("END TEXT BUFFER SAVING");
            System.out.println(stamp.toString());

        } catch (IOException ex) {
            Logger.getLogger(Console.class.getName()).log(Level.SEVERE, null, ex);
        }
    }

    public MenuItem kiesMenuItem() {
        System.out.println();
        for (MenuItem m : MenuItem.values()) {
            System.out.println(m.ordinal() + "\t" + m.getOmschr());
        }
        System.out.println();
        int maxNr = MenuItem.values().length - 1;
        int nr = readInt("maak een keuze uit 0 t/m " + maxNr);
        while (nr < 0 || nr > maxNr) {
            nr = readInt("maak een keuze uit 0 t/m " + maxNr);
        }
        input.nextLine();
        return MenuItem.values()[nr];
    }

    public int readInt(String helptekst) {
        boolean invoerOk = false;
        int invoer = -1;
        while (!invoerOk) {
            try {
                System.out.print(helptekst + " ");
                invoer = input.nextInt();
                invoerOk = true;
            } catch (InputMismatchException exc) {
                System.out.println("Let op, invoer moet een getal zijn!");
                input.nextLine();
            }
        }
        return invoer;
    }

    @Override
    public void update(Observable o, Object arg) {
        Edge e = (Edge) arg;
        edges.add(e);
    }
}
