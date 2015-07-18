package pixel.client.drag_resize;

import java.awt.Component;

/**
 *
 * @author Frank
 */
public class ActionComponent
{
    /**
     * The method that checks whether a component is inside of another component/container
     * @param object the component needs to be checked for existence
     * @param parent the component which will contain the other one
     * @return true if inside false otherwise
     */
    public static boolean isInside(Component object,Component parent) {
        int locx=object.getLocation().x;
        int locy=object.getLocation().y;
        int width=object.getWidth();
        int height=object.getHeight();
        if(isInside(parent,locx,locy)&& isInside(parent,locx+width,locy+height))
                return true;
        else return false;
    }
    
    /**
     * The method that checks whether a point is inside of a component
     * @param parent the container or component
     * @param x the points x coordinate
     * @param y the points y coordinate
     * @return true if inside or false otherwise
     */
    public static boolean isInside(Component parent,int x,int y) {
        if(parent.contains(x,y))
            return true;
        else return false;
    }
    
    /**
     * Checks whether two components intersects each other
     * @param one a component
     * @param two another component
     * @return true if intersects false otherwise
     */
    public static boolean isIntersected(Component one,Component two) {
        if(one.getBounds().intersects(two.getBounds()))
            return true;
        else return false;
    }

}