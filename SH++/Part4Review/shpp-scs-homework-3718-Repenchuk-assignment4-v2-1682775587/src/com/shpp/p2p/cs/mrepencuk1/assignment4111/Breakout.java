package com.shpp.p2p.cs.mrepencuk1.assignment4;


import acm.graphics.GLabel;
import acm.graphics.GObject;
import acm.graphics.GOval;
import acm.graphics.GRect;
import acm.util.RandomGenerator;
import com.shpp.cs.a.graphics.WindowProgram;

import java.awt.*;
import java.awt.event.MouseEvent;

public class Breakout extends WindowProgram {

    /**
     * Width and height of application window in pixels
     */
    public static final int APPLICATION_WIDTH = 900;
    public static final int APPLICATION_HEIGHT = 900;

    /**
     * Dimensions of the paddle
     */
    private static final int PADDLE_WIDTH = 60;
    private static final int PADDLE_HEIGHT = 10;

    /**
     * Offset of the paddle up from the bottom
     */
    private static final int PADDLE_Y_OFFSET = 30;

    /**
     * Number of bricks per row
     */
    private static final int NBRICKS_PER_ROW = 10;

    /**
     * Number of rows of bricks
     */
    private static final int NBRICK_ROWS = 10;

    /**
     * Separation between bricks
     */
    private static final int BRICK_SEP = 4;

    /** It's a bad idea to calculate brick width from APPLICATION_WIDTH */
    // private static final int BRICK_WIDTH =
    //        (APPLICATION_WIDTH - (NBRICKS_PER_ROW - 1) * BRICK_SEP) / NBRICKS_PER_ROW;

    /**
     * Height of a brick
     */
    private static final int BRICK_HEIGHT = 15;

    /**
     * Radius of the ball in pixels
     */
    private static final int BALL_RADIUS = 10;

    /**
     * Offset of the top brick row from the top
     */
    private static final int BRICK_Y_OFFSET = 70;

    /**
     * Number of turns
     */
    private static final int NTURNS = 3;

    private static final double PAUSE_TIME = 30;
    //added variables and constants
    //===================================================================================
    //vector speed Y
    private static final double FAST_AND_FURIOUS_Y = 3;
    //ceiling coordinates by vector Y
    private static final double CELLING = 0;
    GRect paddle = null;
    int howMuchBricksInWall = NBRICK_ROWS * NBRICKS_PER_ROW;

    //create a breakout game
    //there are three attempts or the game is over
    public void run() {
        //three methods for creating and moving a paddle
        paddle = addPaddle();
        add(paddle);
        addMouseListeners();
        //methods of creating and moving the ball
        GOval ball = createBall();
        add(ball);
        //create a wall in which bricks will disappear when hit by a ball
        createWall();
        //start game on mouse click
        startNewGame(ball, howMuchBricksInWall);
    }

    //create a racket on the principle of an ordinary rectangle
    private GRect addPaddle() {
        GRect paddle = new GRect(getWidth() / 2 - PADDLE_WIDTH / 2, getHeight() - PADDLE_Y_OFFSET,
                PADDLE_WIDTH, PADDLE_HEIGHT);
        paddle.setFilled(true);
        paddle.setFillColor(Color.BLACK);
        return (paddle);
    }

    //add to the addMouseListeners method the method of moving the paddle with the mouse
    public void mouseMoved(MouseEvent me) {
        double paddleHeight = getHeight() - PADDLE_HEIGHT - PADDLE_Y_OFFSET;
        if (me.getX() <= PADDLE_WIDTH / 2.0) {
            paddle.setLocation(0, paddleHeight);
        } else
            paddle.setLocation(Math.min(me.getX() - paddle.getWidth()
                    / 2.0, getWidth() - PADDLE_WIDTH), paddleHeight);
    }

    //create a ball that is used in animation ballMovement method
    private GOval createBall() {
        GOval ball = new GOval(getWidth() / 2 - BALL_RADIUS / 2,
                getHeight() / 2 - BALL_RADIUS / 2, BALL_RADIUS * 2, BALL_RADIUS * 2);
        ball.setFilled(true);
        ball.setFillColor(Color.BLACK);
        return (ball);
    }

    //create a wall of bricks where every two levels of bricks change color
    private void createWall() {
        for (int i = 0; i < NBRICK_ROWS; i++) {
            double brickWidth = (getWidth() - (NBRICKS_PER_ROW - 1) * BRICK_SEP) / NBRICKS_PER_ROW;
            for (int j = 0; j < NBRICKS_PER_ROW; j++) {
                double x = ((j * (brickWidth + BRICK_SEP)) + ((getWidth() /
                        ((NBRICKS_PER_ROW * brickWidth) +
                                ((NBRICKS_PER_ROW - 1) * BRICK_SEP)) / 2.0)));
                double y = ((i * (BRICK_HEIGHT + BRICK_SEP)) + BRICK_Y_OFFSET);
                GRect brick = new GRect(x, y, brickWidth, BRICK_HEIGHT);
                brick.setFilled(true);
                //conditions under which bricks change color
                if (i <= 1) {
                    brick.setColor(Color.RED);
                } else if (i == 2 || i == 3) {
                    brick.setColor(Color.ORANGE);
                } else if (i == 4 || i == 5) {
                    brick.setColor(Color.YELLOW);
                } else if (i == 6 || i == 7) {
                    brick.setColor(Color.GREEN);
                } else {
                    brick.setColor(Color.CYAN);
                }
                add(brick);
            }
        }
    }

    //the start of a new game depending on the number
    //of attempts, the initial number of attempts NTURNS
    private void startNewGame(GOval ball, int howMuchBricks) {
        for (int i = 1; i <= NTURNS; i++) {
            beginNewTry(ball, howMuchBricks);
            if (howMuchBricks == 0) {
                break;
            }
        }
        if (howMuchBricks != 0) {
            ifYouLoser();
        }
    }

    //method to add game start on mouse click
    private void beginNewTry(GOval ball, int howMuchBricks) {
        waitForClick();
        ballMovement(ball, howMuchBricks);
    }

    //a method of animation that is added to the ball,
    //thanks to which it moves around the field and repels
    //obstacles in its path
    private void ballMovement(GOval ball, int howMuchBricks) {
        //random x direction
        RandomGenerator rgen = RandomGenerator.getInstance();
        double dx = rgen.nextDouble(1.0, 3.0);
        if (rgen.nextBoolean(0.5)) {
            dx = -dx;
        }
        double dy = FAST_AND_FURIOUS_Y;
        //cycle of conditions when colliding with objects or walls
        for (; !ballBelowFlor(ball); ) {
            //victory conditions
            if (howMuchBricks == 0) {
                ifYouWinner();
                break;
            }
            //collision conditions with ceiling or walls
            ball.move(dx, dy);
            if (ballBelowCeiling(ball)) {
                dy = -dy;
            }
            if (ballBelowRightWall(ball) || ballBelowLeftWall(ball)) {
                dx = -dx;
            }
            //collision conditions with paddle
            GObject collider = getCollidingObject(ball);
            if (collider == paddle) {
                dy = -dy;
                //collision conditions with brick
            } else if (collider != null) {
                dy = -dy;
                remove(collider);
                howMuchBricks -= 1;
            }
            pause(PAUSE_TIME);
        }
        ball.setLocation(getWidth() / 2 - BALL_RADIUS, getHeight() / 2 - BALL_RADIUS);
    }

    //checking the location of the ball
    //in case of false change the vector in the method above
    private boolean ballBelowFlor(GOval ball) {
        return ball.getY() + ball.getHeight() >= getHeight();
    }

    private boolean ballBelowCeiling(GOval ball) {
        return ball.getY() <= CELLING;
    }

    private boolean ballBelowRightWall(GOval ball) {
        return ball.getX() + ball.getWidth() >= getWidth();
    }

    private boolean ballBelowLeftWall(GOval ball) {
        return ball.getX() <= CELLING;
    }

    //a method that calculates the object by its four points,
    //if there is nothing, it returns zero, if there is, it returns the object
    private GObject getCollidingObject(GOval ball) {
        GObject object = null;
        if (getElementAt(ball.getX(), ball.getY()) != null) {
            object = getElementAt(ball.getX(), ball.getY());
        } else if (getElementAt(ball.getX() + BALL_RADIUS * 2.0, ball.getY()) != null) {
            object = getElementAt(ball.getX() + BALL_RADIUS * 2.0, ball.getY());
        } else if (getElementAt(ball.getX(), ball.getY() + BALL_RADIUS * 2.0) != null) {
            object = getElementAt(ball.getX(), ball.getY() + BALL_RADIUS * 2.0);
        } else if (getElementAt(ball.getX() + BALL_RADIUS * 2.0, ball.getY() + BALL_RADIUS * 2.0) != null) {
            object = getElementAt(ball.getX() + BALL_RADIUS * 2.0, ball.getY() + BALL_RADIUS * 2.0);
        }
        return object;
    }

    //a method that displays an inscription in case of a loss or a win
    private void resultWhenGameOver(String title) {
        GLabel label = new GLabel(title);
        label.setFont(new Font("Verdana-50", Font.BOLD, 50));
        label.setColor(Color.BLACK);
        add(label, (getWidth() - label.getWidth()) / 2.0, getHeight() / 2 - BALL_RADIUS * 2);
    }

    //method that is displayed when winning
    private void ifYouWinner() {
        resultWhenGameOver("YOU WIN!!! CONGRATULATIONS");
    }

    //method that is output on loss
    private void ifYouLoser() {
        resultWhenGameOver("YOY LOSE :(");
    }
}


