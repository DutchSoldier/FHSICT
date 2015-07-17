/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package calculate;

import java.util.Observable;
import java.util.Observer;

/**
 *
 * @author me
 */
public class Runner implements Runnable, Observer{
    private KochFractal fractal;
    private KochManager manager;
    private String side;

    public Runner(KochManager manager, String side, int level) {
        this.manager = manager;
        this.fractal = new KochFractal();
        fractal.setLevel(level);
        fractal.addObserver(this);
        this.side = side;
    }

    @Override
    public void run() {
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
        manager.increaseCount();
    }

    @Override
    public void update(Observable o, Object arg) {
        manager.addEdges((Edge) arg);
    } 
}
