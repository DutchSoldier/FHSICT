/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package SocketServer;

import calculate.Edge;
import calculate.KochFractal;
import enums.EdgeID;
import java.util.ArrayList;
import java.util.List;
import java.util.Observable;
import java.util.Observer;
import java.util.concurrent.Callable;

/**
 *
 * @author Remi_Arts
 */
public class SocketCalcTask implements Callable<List<Edge>>, Observer {

    private EdgeID edgeToGen;
    private KochFractal fractal;
    private List<Edge> edges;

    public SocketCalcTask(int lvl, EdgeID side) {
        this.edgeToGen = side;
        this.edges = new ArrayList<>();
        this.fractal = new KochFractal();
        this.fractal.setLevel(lvl);
        this.fractal.addObserver(this);
    }

    @Override
    public List<Edge> call() throws Exception {
        fractal.generateEdge(edgeToGen);
        System.out.println(edgeToGen.toString() + " done");
        return this.edges;
    }

    @Override
    public void update(Observable o, Object arg) {
        this.edges.add((Edge) arg);
    }

}
