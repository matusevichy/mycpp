package com.shpp.p2p.cs.ychornyi.assignment3;

import acm.graphics.GOval;
import acm.util.RandomGenerator;
import com.shpp.cs.a.graphics.WindowProgram;

/**
 * add few constants for first ball size, for balloons size range, for pause time and animation time (5 sec)
 */
public class Assignment3Part6 extends WindowProgram {
    private static final int BALL_SIZE = 30;
    private static final int BALLOON_LARGEST_SIZE = 100;
    private static final int BALLOON_SMALLEST_SIZE = 80;
    private static final int PAUSE_TIME = 2;
    private static final int ANIMATION_TIME = 5000;

    /**
     * at first create a ball what falling, when they in the middle of window, remove ball.
     * We start creating a balloons (with size range what we announced in constants)
     * balloons flying up all the time left and remove at the highest point of the window
     */
    public void run() {
        GOval ball = new GOval(getWidth() / 2 - BALL_SIZE / 2, 0, BALL_SIZE, BALL_SIZE);
        ball.setFilled(true);
        add(ball);
        long startTime = System.currentTimeMillis();
        while (System.currentTimeMillis() - startTime < ANIMATION_TIME) {
            ball.move(0, 2);
            pause(PAUSE_TIME);
            if (ball.getY() >= getHeight() / 2 - BALL_SIZE / 2) {
                createFlyingBalloons();
                remove(ball);
            }
        }
    }

    /**
     * add random generator for starting position, color and size of our balloons
     * whats generated randomly in the lower part of window.
     * then balloon flying up and when they in the highest point of window they remove
     */
    private void createFlyingBalloons() {
        RandomGenerator rgen = RandomGenerator.getInstance();
        /* so that it does not touch the edge of window i subtracted the value of balloon largest size */
        double x = rgen.nextDouble(BALLOON_LARGEST_SIZE, getWidth() - BALLOON_LARGEST_SIZE);
        double y = rgen.nextDouble(getHeight(), BALLOON_LARGEST_SIZE);
        double size = rgen.nextDouble(BALLOON_SMALLEST_SIZE, BALLOON_LARGEST_SIZE);

        GOval balloon = new GOval(x, y, size, size);
        balloon.setColor(rgen.nextColor());
        balloon.setFilled(true);
        add(balloon);
        while (balloon.getY() > 0) {
            balloon.move(0, -3);
            pause(PAUSE_TIME);
        }
        remove(balloon);
    }
}


