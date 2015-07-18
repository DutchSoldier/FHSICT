/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package nl.fontys.vangeenen.rmi;

import java.rmi.RemoteException;
import java.util.Collection;
import java.util.Timer;
import java.util.TimerTask;
import java.util.concurrent.ConcurrentLinkedDeque;
import java.util.logging.Level;
import java.util.logging.Logger;

abstract class NodeImpl<T extends Node> implements Node<T>{
    
    
    
    private final Collection<T> others = new ConcurrentLinkedDeque<>();
    
    @Override
    public void register(T other) throws RemoteException{
        others.add(other);
    }

    @Override
    public void onMessage(String message) {
        Logger.getLogger(this.getClass().getSimpleName()).log(Level.INFO, "received: {0}", message);
    }

    
    protected final Timer pushTimer = new Timer(), waitTimer = new Timer();
    
    protected final TimerTask pushTask = new TimerTask(){
        //the number of sent messages
        private int sent=0;
                @Override
        public void run() {
                for(T other : others){
                    String message = "Hello World (" + sent + ") from " + NodeImpl.this.getClass().getSimpleName();
                    try {
                        other.onMessage( message );
                        sent++;
                    } catch (RemoteException ex) {
                        Logger.getLogger(getClass().getName()).log(Level.SEVERE, "an error occurred upon sending a message. Unregistering " + other, ex);
                        others.remove(other);
                    }
                } 
            }
        };
    
    protected final TimerTask waitTask = new TimerTask(){
        @Override
        public void run() {
            Logger.getLogger(getClass().getSimpleName()).log(Level.INFO, "waiting...");
        }
        
    };
    
    /**
     * starts pushing messages to all {@code others}
     */
    protected void startPushing(){
        pushTimer.scheduleAtFixedRate(pushTask,1000,1000);
    }
    
    
    
    
    
}
