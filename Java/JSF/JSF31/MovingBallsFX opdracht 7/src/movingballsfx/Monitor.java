/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package movingballsfx;

import java.util.concurrent.locks.Condition;
import java.util.concurrent.locks.Lock;
import java.util.concurrent.locks.ReentrantLock;

/**
 *
 * @author me
 */
public class Monitor {

    private final Lock monLock;
    private final Condition okToWrite;
    private final Condition okToRead;
    private int writersActive;
    private int readersActive;
    private int readersWaiting;
    private int writersWaiting;

    public Monitor() {
        this.monLock = new ReentrantLock();
        this.okToRead = monLock.newCondition();
        this.okToWrite = monLock.newCondition();
        this.readersActive = 0;
        this.writersActive = 0;
        this.readersWaiting = 0;
        this.writersWaiting = 0;
    }

    public void enterWriter() throws InterruptedException {
        monLock.lock();
        try {
            while (writersActive > 0 || readersActive > 0) {
                writersWaiting++;
                okToWrite.await();
                writersWaiting--;
            }
            writersActive++;
        } catch (InterruptedException e) {
            writersWaiting--;
            throw new InterruptedException();
        } finally {
            monLock.unlock();
        }
    }

    public void enterReader() throws InterruptedException {
        monLock.lock();
        try {
            while (writersActive > 0) {
                readersWaiting++;
                okToRead.await();
                readersWaiting--;
            }
            readersActive++;
        } catch (InterruptedException e) {
            readersWaiting--;
            throw new InterruptedException();
        } finally {
            monLock.unlock();
        }
    }

    public void exitWriter(){
        monLock.lock();
        try {
            writersActive--;
            if (writersWaiting > 0) {
                okToWrite.signal();
            } else {
                okToRead.signalAll();
            }
        } finally {
            monLock.unlock();
        }
    }

    public void exitReader(){
        monLock.lock();
        try {
            readersActive--;
            if (readersActive == 0) {
                okToWrite.signal();
            }
        } finally {
            monLock.unlock();
        }
    }
}
