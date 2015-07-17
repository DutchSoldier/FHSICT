/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package calculate;

import com.sun.javaws.Main;
import java.io.BufferedWriter;
import java.io.FileWriter;
import java.io.IOException;
import java.io.Writer;
import java.util.ArrayList;
import java.util.List;
import java.util.Observable;
import java.util.Observer;
import java.util.concurrent.ExecutionException;
import java.util.logging.Level;
import java.util.logging.Logger;
import javafx.concurrent.Task;
import javafx.scene.control.Label;
import javafx.scene.control.ProgressBar;
import jsf32kochfractalfx.JSF32KochFractalFX;
import timeutil.TimeStamp;

/**
 *
 * @author me
 */
public class KochManager implements Observer {

    private JSF32KochFractalFX application;
    public KochFractal fractal;
    private ArrayList<Edge> edges = new ArrayList<>();
    private TimeStamp tsDraw;
    private TimeStamp tsCalc;
    private Task taskLeft;
    private Task taskRight;
    private Task taskBottom;
    private ProgressBar barLeft, barRight, barBottom;
    private Label lbLeft, lbRight, lbBottom;

    public KochManager(JSF32KochFractalFX application) {
        this.application = application;
        this.fractal = new KochFractal();
        fractal.addObserver(this);
    }

    public void changeLevel(int nxt) {
        edges.clear();
        fractal.cancel();
        fractal.setLevel(nxt);
        taskLeft = new MyTask("left", nxt, this);
        taskRight = new MyTask("right", nxt, this);
        taskBottom = new MyTask("bottom", nxt, this);

        barLeft = application.getLeftBar();
        barLeft.progressProperty().bind(taskLeft.progressProperty());
        lbLeft = application.getLeftLabel();
        lbLeft.textProperty().bind(taskLeft.messageProperty());

        barRight = application.getRightBar();
        barRight.progressProperty().bind(taskRight.progressProperty());
        lbRight = application.getRightLabel();
        lbRight.textProperty().bind(taskRight.messageProperty());

        barBottom = application.getBottomBar();
        barBottom.progressProperty().bind(taskBottom.progressProperty());
        lbBottom = application.getBottomLabel();
        lbBottom.textProperty().bind(taskBottom.messageProperty());

        //Start the calculating
        tsCalc = new TimeStamp();
        tsCalc.setBegin();
        new Thread(taskRight).start();
        new Thread(taskLeft).start();
        new Thread(taskBottom).start();
        tsCalc.setEnd();

        //Sets the label
        application.setTextCalc(tsCalc.toString());

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
        tsDraw = new TimeStamp();
        tsDraw.setBegin();

        if (taskBottom.isDone() || taskLeft.isDone() || taskRight.isDone()) {
            taskBottom.setOnSucceeded(null);
            taskLeft.setOnSucceeded(null);
            taskRight.setOnSucceeded(null);
            List<Task> tasks = new ArrayList<>();
            tasks.add(taskBottom);
            tasks.add(taskLeft);
            tasks.add(taskRight);
            
            try {
                for (Task<ArrayList<Edge>> t : tasks) {
                    edges.addAll(t.get());
                }
            } catch (InterruptedException | ExecutionException ex1) {
                Logger.getLogger(Main.class.getName()).log(Level.SEVERE, null, ex1);
            }
            for (Edge e : edges) {
                application.drawEdge(e);
            }
        }
        tsDraw.setEnd();
        application.setTextNrEdges(Integer.toString(fractal.getNrOfEdges()));
        application.setTextDraw(tsDraw.toString());
    }

    public void drawSingleEdge(List<Edge> edges) {
        for (Edge e : edges) {
            application.drawWhiteEdge(e);
        }
    }

    @Override
    public void update(Observable o, Object arg) {
        edges.add((Edge) arg);
    }

    public void getEdgesFromTask(List<Edge> edges) {
        if (taskBottom.isDone() || taskLeft.isDone() || taskRight.isDone()) {
            application.requestDrawEdges();
        } else {
            application.requestDrawWhiteEdges(edges);
        }
    }
}
