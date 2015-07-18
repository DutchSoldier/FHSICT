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
 * A thread factory for a threadpool that creates high priority threads.
 */
public class HighPriorityThreadFactory implements ThreadFactory {
    private static final AtomicInteger poolNumber = new AtomicInteger(1);
    private final ThreadGroup group;
    private final AtomicInteger threadNumber = new AtomicInteger(1);
    private final String namePrefix;

    /**
     *
     */
    public HighPriorityThreadFactory() {
        SecurityManager s = System.getSecurityManager();
        group = (s != null) ? s.getThreadGroup() : Thread.currentThread().getThreadGroup();
        namePrefix = "thread_" + poolNumber.getAndIncrement() + "_high_priority";
    }

    @Override
    public Thread newThread(Runnable r) {
        Thread t = new Thread(group, r, namePrefix + threadNumber.getAndIncrement(), 0);
        if (t.isDaemon()) {
            t.setDaemon(false);
        }
        if (t.getPriority() != Thread.MAX_PRIORITY - 1) {
            t.setPriority(Thread.MAX_PRIORITY - 1);
        }
        return t;
    }
}
