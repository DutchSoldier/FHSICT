/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package movingballsfx;

import javafx.scene.paint.Color;

/**
 *
 * @author Peter Boots
 */
public class BallRunnable implements Runnable {

    private Ball ball;
    private Monitor monitor;
    public boolean cs;
    
    public BallRunnable(Ball ball, Monitor monitor) {
        this.ball = ball;
        this.monitor = monitor;
    }

    public Ball getBall() {
        return ball;
    }

    @Override
    public void run() {
        while (!Thread.currentThread().isInterrupted()) {
            try {
                ball.move();
                if (ball.isEnteringCs()) {
                    try {
                        if (ball.getColor() == Color.RED) {
                            monitor.enterReader();
                        } else {
                            monitor.enterWriter();
                        }
                        cs = true;
                    } catch (Exception e) {
                        System.out.println(e);
                    }
                } else if (ball.isLeavingCs()) {
                    if (ball.getColor() == Color.RED) {
                        monitor.exitReader();
                    } else {
                        monitor.exitWriter();
                    }
                    cs = false;
                }
                Thread.sleep(ball.getSpeed());

            } catch (InterruptedException ex) {
                    if (cs) {
                        if (ball.getColor() == Color.RED) {
                            monitor.exitReader();
                        } else {
                            monitor.exitWriter();
                        }
                    }
                Thread.currentThread().interrupt();
            }
        }
    }
}
