/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package calculate;

import java.util.ArrayList;
import java.util.List;
import java.util.Observable;
import java.util.Observer;
import java.util.concurrent.Callable;
import java.util.concurrent.CyclicBarrier;

/**
 *
 * @author me
 */
public class Caller implements Callable<List<Edge>>, Observer {

    private KochFractal fractal;
    private KochManager manager;
    private List<Edge> edges = new ArrayList<>();
    private CyclicBarrier barrier;
    private String side;

    public Caller(CyclicBarrier barrier, KochManager manager, int level, String side) {
        this.barrier = barrier;
        this.manager = manager;
        this.fractal = new KochFractal();
        fractal.addObserver(this);
        this.side = side;
        fractal.setLevel(level);
    }

    @Override
    public List<Edge> call() throws Exception {
        generateEdges();
        if (barrier.await() == 0) {
            manager.getEdgesFromCaller();
        }
        return edges;
    }

    @Override
    public void update(Observable o, Object arg) {
        edges.add((Edge) arg);
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
}
