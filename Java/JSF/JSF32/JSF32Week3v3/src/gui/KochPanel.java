/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

/*
 * KochPanel.java
 *
 * Created on 2-jul-2011, 10:08:42
 */
package gui;

import calculate.*;
import console.Console;
import java.awt.Color;
import java.awt.Graphics;
import java.io.BufferedInputStream;
import java.io.BufferedOutputStream;
import java.io.BufferedReader;
import java.io.BufferedWriter;
import java.io.DataInputStream;
import java.io.DataOutputStream;
import java.io.FileInputStream;
import java.io.FileNotFoundException;
import java.io.FileOutputStream;
import java.io.FileReader;
import java.io.FileWriter;
import java.io.IOException;
import java.io.RandomAccessFile;
import java.nio.MappedByteBuffer;
import java.nio.channels.FileChannel;
import java.nio.channels.FileLock;
import java.util.ArrayList;
import java.util.List;
import java.util.Observable;
import java.util.Observer;
import java.util.Scanner;
import java.util.logging.Level;
import java.util.logging.Logger;
import timeutil.TimeStamp;

/**
 *
 * @author Peter Boots
 */
public class KochPanel extends javax.swing.JPanel implements Observer {

    private final ArrayList<Edge> edges = new ArrayList<Edge>();
    FileChannel fc;
    RandomAccessFile ras;
    private KochFractal fractal;
    private int level;
    FileLock exclusiveLock;
    Thread writer;

    /**
     * Creates new form KochPanel
     */
    @SuppressWarnings("LeakingThisInConstructor")
    public KochPanel() {
        initComponents();
        fractal = new KochFractal();
        fractal.addObserver(this);
    }

    void WriterThread() throws FileNotFoundException {
        ras = new RandomAccessFile("/home/me/Mount/mapped_file.dat", "rw");
        fc = ras.getChannel();

        if (writer != null) {
            writer.interrupt();
        }
        writer = new Thread(new Runnable() {
            @Override
            public void run() {
                exclusiveLock = null;
                TimeStamp stamp = new TimeStamp();
                stamp.setBegin("START FILE MAPPING SAVING");
                MappedByteBuffer out = null;
                try {
                    out = fc.map(FileChannel.MapMode.READ_WRITE, 0, (edges.size() * 36) + 4);
                } catch (IOException ex) {
                    Logger.getLogger(KochPanel.class.getName()).log(Level.SEVERE, null, ex);
                }

                try {
                    exclusiveLock = fc.lock(0, 4, false);
                } catch (IOException ex) {
                    Logger.getLogger(KochPanel.class.getName()).log(Level.SEVERE, null, ex);
                }
                out.putInt(level); // 4 bytes
                try {
                    exclusiveLock.release();
                } catch (IOException ex) {
                    Logger.getLogger(KochPanel.class.getName()).log(Level.SEVERE, null, ex);
                }
                long tempByte = 4;
                try {
                    for (Edge edge : edges) {
                        if (writer.isInterrupted()) {
                            return;
                        }
                        exclusiveLock = fc.lock(tempByte, 36, false);
                        out.putDouble(edge.X1); // 8 bytes
                        out.putDouble(edge.Y1); // 8 bytes
                        out.putDouble(edge.X2); // 8 bytes
                        out.putDouble(edge.Y2); // 8 bytes
                        out.putInt(edge.color.getRGB()); // 4 bytes
                        tempByte += 36;
                        exclusiveLock.release();
                        repaint();
                    }
                    out.force();
                    //fc.close();
                    stamp.setEnd("END FILE MAPPING SAVING");
                    System.out.println(stamp.toString());
                } catch (IOException ex) {
                    Logger.getLogger(KochPanel.class.getName()).log(Level.SEVERE, null, ex);
                }
            }
        });

        writer.start();

    }

    public void changeLevel(int nxt) {
        this.level = nxt;
        fractal.setLevel(nxt);
        edges.clear();
        fractal.generateBottomEdge();
        fractal.generateLeftEdge();
        fractal.generateRightEdge();
        try {
            WriterThread();
        } catch (FileNotFoundException ex) {
            Logger.getLogger(KochPanel.class.getName()).log(Level.SEVERE, null, ex);
        }
        this.repaint();
    }

    /*this.edges.clear();

     // Zonder buffer - binair
     stamp.setBegin("START BINAIR NO-BUFFER LOADING");
     DataInputStream binairStream = new DataInputStream(new FileInputStream(Console.file + "binair_no_buffer.dat"));
     int level1 = binairStream.readInt();
     while (binairStream.available() > 0) {
     this.edges.add(new Edge(binairStream.readDouble(), binairStream.readDouble(), binairStream.readDouble(), binairStream.readDouble(), new Color(binairStream.readInt())));
     }
     binairStream.close();
     stamp.setEnd("END BINAIR NO-BUFFER LOADING");
     System.in.println(stamp.toString());*/

    /*this.edges.clear();

     // Met buffer - binair
     stamp.setBegin("START BINAIR BUFFER LOADING");
     DataInputStream bufferedBinairStream = new DataInputStream(new BufferedInputStream(new FileInputStream(Console.file + "binair_buffer.dat")));
     int level2 = bufferedBinairStream.readInt();
     while (bufferedBinairStream.available() > 0) {
     this.edges.add(new Edge(bufferedBinairStream.readDouble(), bufferedBinairStream.readDouble(), bufferedBinairStream.readDouble(), bufferedBinairStream.readDouble(), new Color(bufferedBinairStream.readInt())));
     }
     bufferedBinairStream.close();
     stamp.setEnd("END BINAIR BUFFER LOADING");
     System.in.println(stamp.toString());

     this.edges.clear();

     // Met buffer - text  
     stamp.setBegin("START TEXT BUFFER LOADING");
     Scanner scanner = new Scanner(new FileReader(Console.file + "text_buffer.dat"));
     int level3 = scanner.nextInt();
     while (scanner.hasNext()) {
     scanner.next();
     double x1 = scanner.nextDouble();
     scanner.next();
     double y1 = scanner.nextDouble();
     scanner.next();
     double x2 = scanner.nextDouble();
     scanner.next();
     double y2 = scanner.nextDouble();
     scanner.next();
     int rgb = scanner.nextInt();

     this.edges.add(new Edge(x1, y1, x2, y2, new Color(rgb)));
     }
     scanner.close();
     stamp.setEnd("END TEXT BUFFER LOADING");
     System.in.println(stamp.toString());*/
    /**
     * This method is called from within the constructor to initialize the form.
     * WARNING: Do NOT modify this code. The content of this method is always
     * regenerated by the Form Editor.
     */
    @SuppressWarnings("unchecked")
    // <editor-fold defaultstate="collapsed" desc="Generated Code">//GEN-BEGIN:initComponents
    private void initComponents() {

        setBackground(new java.awt.Color(0, 0, 0));
        setDoubleBuffered(false);

        javax.swing.GroupLayout layout = new javax.swing.GroupLayout(this);
        this.setLayout(layout);
        layout.setHorizontalGroup(
            layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGap(0, 481, Short.MAX_VALUE)
        );
        layout.setVerticalGroup(
            layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGap(0, 309, Short.MAX_VALUE)
        );
    }// </editor-fold>//GEN-END:initComponents

    // Variables declaration - do not modify//GEN-BEGIN:variables
    // End of variables declaration//GEN-END:variables
    @Override
    public void paintComponent(Graphics g) {
        TimeStamp stamp = new TimeStamp();
        stamp.setBegin("START PAINT");
        super.paintComponent(g);
        MappedByteBuffer in = null;
        try {
            in = fc.map(FileChannel.MapMode.READ_ONLY, 0, ras.length());
        } catch (IOException ex) {
            Logger.getLogger(KochPanel.class.getName()).log(Level.SEVERE, null, ex);
        }
        int level0 = in.getInt(); // 4 bytes
        while (in.remaining() > 0) {
            Edge e = KochFrame.edgeAfterZoomAndDrag(new Edge(in.getDouble(), in.getDouble(), in.getDouble(), in.getDouble(), new Color(in.getInt())));
            g.setColor(e.color);
            g.drawLine((int) e.X1, (int) e.Y1, (int) e.X2, (int) e.Y2);
        }
        if (exclusiveLock == null) {
            try {
                fc.close();
            } catch (IOException ex) {
                Logger.getLogger(KochPanel.class.getName()).log(Level.SEVERE, null, ex);
            }
        }
        stamp.setEnd("EINDE PAINT");
        System.out.println(stamp.toString());
        //System.in.println(this.koch.getNrOfEdges());
    }

    @Override
    public void update(Observable o, Object arg) {
        Edge e = (Edge) arg;
        this.edges.add(e);
    }
}
