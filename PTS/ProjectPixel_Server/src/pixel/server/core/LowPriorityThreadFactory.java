/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package pixel.server.core;

import java.util.concurrent.ThreadFactory;
import java.util.concurrent.atomic.AtomicInteger;

/**
 *
 * @author Frank
 * A thread factory for a threadpool that creates low priority threads.
 */
public class LowPriorityThreadFactory implements ThreadFactory {
    private static final AtomicInteger poolNumber = new AtomicInteger(1);
    private final ThreadGroup group;
    private final AtomicInteger threadNumber = new AtomicInteger(1);
    private final String namePrefix;

    /**
     *
     */
    public LowPriorityThreadFactory() {
        SecurityManager s = System.getSecurityManager();
        group = (s != null) ? s.getThreadGroup() : Thread.currentThread().getThreadGroup();
        namePrefix = "thread_" + poolNumber.getAndIncrement() + "_low_priority";
    }

    @Override
    public Thread newThread(Runnable r) {
        Thread t = new Thread(group, r, namePrefix + threadNumber.getAndIncrement(), 0);
        if (t.isDaemon()) {
            t.setDaemon(false);
        }
        if (t.getPriority() != Thread.MIN_PRIORITY) {
            t.setPriority(Thread.MIN_PRIORITY);
        }
        return t;
    }
}
