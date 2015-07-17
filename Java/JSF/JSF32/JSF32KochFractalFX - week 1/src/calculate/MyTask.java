/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package calculate;

import java.util.ArrayList;
import java.util.List;
import java.util.Observable;
import java.util.Observer;
import java.util.logging.Level;
import java.util.logging.Logger;
import javafx.concurrent.Task;

/**
 *
 * @author me
 */
public class MyTask extends Task<List<Edge>> implements Observer {

    private KochFractal fractal = new KochFractal();
    private List<Edge> edges = new ArrayList<>();
    private String side;
    private KochManager manager;

    public MyTask(String side, int level, KochManager manager) {
        this.edges.clear();
        this.manager = manager;
        this.side = side;
        this.fractal.addObserver(this);
        this.fractal.setLevel(level);
        
    }

    @Override
    protected List<Edge> call() throws Exception {
        generateEdges();
        
        return edges;
    }

    public void generateEdges() {
        switch (side) {
            case "right":
                fractal.generateRightEdge();
                break;
            case "left":
                fractal.generateLeftEdge();
                break;
            case "bottom":
                fractal.generateBottomEdge();
                break;
        }
    }

    @Override
    public void update(Observable o, Object arg) {
        Edge e = (Edge) arg;
        edges.add(e);
        
        updateProgress(edges.size(), (fractal.getNrOfEdges()/3));
        updateMessage(""+edges.size());
        try {
            Thread.sleep(100);
        } catch (InterruptedException ex) {
            Logger.getLogger(MyTask.class.getName()).log(Level.SEVERE, null, ex);
        }
        manager.getEdgesFromTask(edges);  
    }
}
