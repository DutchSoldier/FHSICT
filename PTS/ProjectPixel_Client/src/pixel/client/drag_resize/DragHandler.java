package pixel.client.drag_resize;

import java.awt.Component;
import java.awt.event.MouseAdapter;
import java.awt.event.MouseEvent;
import javax.swing.JFrame;

/**
 *
 * @author Frank
 */
public class DragHandler extends MouseAdapter
{
    private Component parent;
    private int posX = 0;
    private int posY = 0;
    
    /**
     * Constructor which registers parent container of the draggable component
     * @param container 
     */
    public DragHandler(Component container) {
        parent = container;
    }
     
    /**
     *  @param component
     */
    public void addComponent(Component component) {
        component.addMouseMotionListener(this);
    }
    
    /**
     * 
     * @param e MouseEvent
     */
    @Override
    public void mouseDragged(MouseEvent e) {
        if(e.getComponent() instanceof JFrame)
            dragWindow(e);
        dragControl(e);
    }
    
    /**
     * Method responsible to handle drag events
     * @param evt
     */
    private void dragControl(MouseEvent evt) {
        Component c=(Component)evt.getSource();
        int locX=c.getX() + evt.getX()-c.getWidth()/2;
        int locY=c.getY()+ evt.getY()-c.getHeight()/2;
       
        if(ActionComponent.isInside(parent,locX,locY)&&ActionComponent.isInside(parent,locX+c.getWidth(),locY+c.getHeight()))
            {
                c.setLocation(locX,locY );
                c.validate();
            }
    }
    
    /**
     * @param evt
     */
    private void dragWindow(MouseEvent evt)
    {
        evt.getComponent().setLocation (evt.getXOnScreen()-posX,evt.getYOnScreen()-posY);
    }
    @Override
    public void mousePressed(MouseEvent evt)
    {
        posX = evt.getX();
        posY = evt.getY();
    }
}