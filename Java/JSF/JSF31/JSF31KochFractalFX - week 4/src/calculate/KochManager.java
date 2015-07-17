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
import java.util.Observable;
import java.util.Observer;
import jsf31kochfractalfx.JSF31KochFractalFX;
import timeutil.TimeStamp;

/**
 *
 * @author me
 */
public class KochManager implements Observer {

    private JSF31KochFractalFX application;
    private KochFractal fractal;
    private ArrayList<Edge> edges = new ArrayList<>();
    private TimeStamp tsDraw;
    private TimeStamp tsCalc;

    public KochManager(JSF31KochFractalFX application) {
        this.application = application;
        this.fractal = new KochFractal();
        fractal.addObserver(this);
    }

    public void changeLevel(int nxt) {
        edges.clear();
        fractal.setLevel(nxt);
        
        //Start the calculating
        tsCalc = new TimeStamp();
        tsCalc.setBegin();
        fractal.generateLeftEdge();
        fractal.generateBottomEdge();
        fractal.generateRightEdge();
        tsCalc.setEnd();
        
        //Start the drawing
        drawEdges();
  
        //Sets the label
        application.setTextCalc(tsCalc.toString());
        
        //Writes to Kochfile.txt in project folder
        Writer writer = null;
        try {
            writer = new BufferedWriter(new FileWriter("Kochfile.txt", true));
            writer.write("Level: " + Integer.toString(nxt) + "   Edges: " + fractal.getNrOfEdges() 
                    +"     CalcTime: "+tsCalc.toString());
        } catch (IOException ex) {
            System.out.print(ex);
        } finally {
            try {
                writer.close();
            } catch (Exception ex) {
            }
        }
    }

    public void drawEdges() {
        application.clearKochPanel();
        /*fractal.generateLeftEdge();
        fractal.generateBottomEdge();
        fractal.generateRightEdge();*/
        tsDraw = new TimeStamp();
        tsDraw.setBegin();
        for (Edge e : edges) {
            application.drawEdge(e);
        }
        tsDraw.setEnd();
        application.setTextNrEdges(Integer.toString(fractal.getNrOfEdges()));
        application.setTextDraw(tsDraw.toString());
    }

    @Override
    public void update(Observable o, Object arg) {
        //application.drawEdge((Edge)arg);
        edges.add((Edge) arg);   
    }
}
