/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package calculate;

import com.sun.javaws.Main;
import com.sun.org.apache.bcel.internal.generic.AALOAD;
import java.io.BufferedWriter;
import java.io.FileWriter;
import java.io.IOException;
import java.io.Writer;
import java.util.ArrayList;
import java.util.List;
import java.util.concurrent.Callable;
import java.util.concurrent.CyclicBarrier;
import java.util.concurrent.ExecutionException;
import java.util.concurrent.ExecutorService;
import java.util.concurrent.Executors;
import java.util.concurrent.Future;
import java.util.logging.Level;
import java.util.logging.Logger;
import jsf31kochfractalfx.JSF31KochFractalFX;
import timeutil.TimeStamp;

/**
 *
 * @author me
 */
public class KochManager {
    
    private JSF31KochFractalFX application;
    private KochFractal fractal = new KochFractal();
    private List<Edge> edges = new ArrayList<>();
    private List<Future<ArrayList<Edge>>> futures = new ArrayList<>();
    private ExecutorService executor;
    private int threads;
    private CyclicBarrier cb;
    private boolean finished = false;
    
    public KochManager(JSF31KochFractalFX application) {
        this.application = application;
        this.threads = 3;
        this.executor = Executors.newFixedThreadPool(threads);
        this.cb = new CyclicBarrier(threads);
    }
    
    public void changeLevel(int nxt) {
        fractal.setLevel(nxt);
        futures.clear();
        //Make Callable, CyclicBarrier, Future and ExecutorService
        cb.reset();
        Callable callerLeft = new Caller(cb, this, nxt, "left");
        Callable callerRight = new Caller(cb, this, nxt, "right");
        Callable callerBottom = new Caller(cb, this, nxt, "bottom");

        //Start the calculating
        TimeStamp tsCalc = new TimeStamp();
        tsCalc.setBegin();
        Future<ArrayList<Edge>> f1 = executor.submit(callerLeft);
        futures.add(f1);
        Future<ArrayList<Edge>> f2 = executor.submit(callerRight);
        futures.add(f2);
        Future<ArrayList<Edge>> f3 = executor.submit(callerBottom);
        futures.add(f3);
        
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
    
    public void drawEdges() {
        application.clearKochPanel();
        TimeStamp tsDraw = new TimeStamp();
        if (finished) {
            edges.clear();
            try {
                for (Future<ArrayList<Edge>> f : futures) {
                    edges.addAll(f.get());
                }
            } catch (InterruptedException | ExecutionException ex1) {
                Logger.getLogger(Main.class.getName()).log(Level.SEVERE, null, ex1);
            }
           finished = false;
        }
        
        tsDraw.setBegin();
        for (Edge e : edges) {
            application.drawEdge(e);
        }
        tsDraw.setEnd();
        application.setTextDraw(tsDraw.toString());
    }
    
    public void getEdgesFromCaller() {        
        finished = true;
        application.requestDrawEdges();
    }
}
