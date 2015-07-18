/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package pixel.server.core;

import java.util.concurrent.ExecutorService;
import java.util.concurrent.Executors;
import java.util.concurrent.ScheduledExecutorService;

/**
 *
 * @author Frank
 */
public class CoresManager {
  
    private static ExecutorService highPriorityThreadPool;

    /**
     *
     * @return
     */
    public static ExecutorService getHighPriorityThreadPool() {
        return highPriorityThreadPool;
    }

    private static ScheduledExecutorService lowPriorityThreadPool;
    
    /**
     *
     * @return
     */
    public static ScheduledExecutorService getLowPriorityThreadPool() {
        return lowPriorityThreadPool;
    }
    
    /**
     *
     */
    public static void initialize() {                
        highPriorityThreadPool = Executors.newFixedThreadPool(5, new HighPriorityThreadFactory());
        lowPriorityThreadPool = Executors.newScheduledThreadPool(2, new LowPriorityThreadFactory());
    }
    
    /**
     *
     */
    public static void shutdown() {
        highPriorityThreadPool.shutdown();
        lowPriorityThreadPool.shutdown();
    }
    
    private CoresManager() {
        
    }    
}
