/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package jsf31kochfractalfx;

import calculate.Edge;
import calculate.KochFractal;
import java.util.ArrayList;
import java.util.Observable;
import java.util.Observer;

/**
 *
 * @author me
 */
public class newform implements Observer {

    private ArrayList<Edge> edges = new ArrayList<>();
    private static KochFractal frac;

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        frac = new KochFractal();
        newform fr = new newform();
        frac.addObserver(fr);
        frac.setLevel(2);
        frac.generateBottomEdge();
        frac.generateLeftEdge();
        frac.generateRightEdge();
    }

    @Override
    public void update(Observable o, Object arg) {
        edges.add((Edge) arg);
        int teller = 0;
        if (frac.getNrOfEdges() == edges.size()) {
            for (Edge e : edges) {
                teller = teller + 1;
                System.out.println("Edgenummer:" + teller + " Coordinaten:" + e.X1 + "/" + e.X2 + "/" + e.Y1 + "/" + e.Y2);
            }
        }
    }
}
