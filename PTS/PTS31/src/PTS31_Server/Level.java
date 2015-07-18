package PTS31_Server;

import java.awt.Color;
import java.awt.Point;
import java.awt.geom.Point2D;
import java.util.ArrayList;

/**
 *
 * @author Simon
 */
public class Level
{
    private ArrayList<Edge> edges = new ArrayList<>();
    
    public Level() {
        edges.add(new Edge(new Point2D.Double(0, 433), new Point2D.Double(150, 433),  Color.RED));
        edges.add(new Edge(new Point2D.Double(350, 433), new Point2D.Double(500, 433),  Color.RED));
        edges.add(new Edge(new Point2D.Double(500, 433), new Point2D.Double(425, 303),  Color.BLUE));
        edges.add(new Edge(new Point2D.Double(325, 130), new Point2D.Double(250, 0),  Color.BLUE));
        edges.add(new Edge(new Point2D.Double(250, 0), new Point2D.Double(175, 130),  Color.GREEN));
        edges.add(new Edge(new Point2D.Double(75, 303), new Point2D.Double(0, 433),  Color.GREEN));
        
        edges.add(new Edge(new Point2D.Double(150, 433), new Point2D.Double(350, 433),  Color.WHITE));
        edges.add(new Edge(new Point2D.Double(425, 303), new Point2D.Double(325, 130),  Color.WHITE));
        edges.add(new Edge(new Point2D.Double(175, 130), new Point2D.Double(75, 303),  Color.WHITE));
    }   
    
    public ArrayList<Edge> getEdges() {
        return this.edges;
    }
}
