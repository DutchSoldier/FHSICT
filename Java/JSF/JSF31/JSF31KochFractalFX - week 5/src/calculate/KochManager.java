/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package calculate;

import java.io.BufferedWriter;
import java.io.FileWriter;
import java.io.IOException;
import java.io.Writer;
import java.util.ArrayList;
import jsf31kochfractalfx.JSF31KochFractalFX;
import timeutil.TimeStamp;

/**
 *
 * @author me
 */
public class KochManager{

    public JSF31KochFractalFX application;
    public KochFractal fractal = new KochFractal();
    public ArrayList<Edge> edges = new ArrayList<>();
    private int count = 0;

    public KochManager(JSF31KochFractalFX application) {
        this.application = application;
    }

    public void changeLevel(int nxt) {
        edges.clear();
        count = 0;
        fractal.setLevel(nxt);
        //Make Threads and runnables
        Runner left = new Runner(this,"left", nxt);
        Runner right = new Runner(this, "right", nxt);
        Runner bottom = new Runner(this,"bottom", nxt);
        Thread threadLeft = new Thread(left);
        Thread threadRight = new Thread(right);
        Thread threadBottom = new Thread(bottom);

        //Start the calculating
        TimeStamp tsCalc = new TimeStamp();
        tsCalc.setBegin();
        threadLeft.start();
        threadRight.start();
        threadBottom.start();
        tsCalc.setEnd();
        
        //Set labels
        application.setTextCalc(tsCalc.toString());
        application.setTextNrEdges(Integer.toString(fractal.getNrOfEdges()));

        //Writes to Kochfile.txt in project folder
        Writer writer = null;
        try {
            writer = new BufferedWriter(new FileWriter("Kochfile.txt", true));
            writer.write("Level: " + Integer.toString(nxt) + "   Edges: " + fractal.getNrOfEdges()
                    + "     CalcTime: " + tsCalc.toString());
        } catch (IOException ex) {
            System.out.print(ex);
        } finally {
            try {
                writer.close();
            } catch (Exception ex) {
            }
        }
    }
    
    public synchronized void increaseCount(){
        count++;
        if (count ==3){
           application.requestDrawEdges(); 
        }
    }

    public void drawEdges() {
        application.clearKochPanel();
        TimeStamp tsDraw = new TimeStamp();
        tsDraw.setBegin();
        for (Edge e : edges) {
            application.drawEdge(e);
        }
        tsDraw.setEnd();
        application.setTextDraw(tsDraw.toString());
    }
    
    public synchronized void addEdges(Edge e){
        edges.add(e);
    }
}
