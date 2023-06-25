package com.shpp.p2p.cs.vostapchuk.assignment4;

import acm.graphics.GLabel;
import acm.graphics.GObject;
import acm.graphics.GOval;
import acm.graphics.GRect;
import acm.util.RandomGenerator;
import com.shpp.cs.a.graphics.WindowProgram;

import java.awt.*;
import java.awt.event.MouseEvent;

public class Assignment4Part1 extends WindowProgram {

    /**
     * Width and height of application window in pixels
     */
    public static final int APPLICATION_WIDTH = 400;
    public static final int APPLICATION_HEIGHT = 600;

    /**
     * Dimensions of game board (usually the same)
     */
    private static final int WIDTH = APPLICATION_WIDTH;
    private static final int HEIGHT = APPLICATION_HEIGHT;

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
    private static final int NBRICK_ROWS = 18;

    /**
     * Separation between bricks
     */
    private static final int BRICK_SEP = 4;

    /**
     * Width of a brick
     */
    private static final int BRICK_WIDTH = (WIDTH - (NBRICKS_PER_ROW - 1) * BRICK_SEP) / NBRICKS_PER_ROW;

    /**
     * Height of a brick
     */
    private static final int BRICK_HEIGHT = 8;

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

    /*Bricks counter label object*/
    GLabel bricksCounterLabel;

    /*Lives counter label object*/
    GLabel livesCounterLabel;

    /*Paddle object*/
    GRect paddle;

    /*Number of pixels(speed) ball moves on x-axis */
    private double vx;

    /* Number of pixels(speed) ball moves on y-axis */
    private double vy = 3;

    public void run() {
        addMouseListeners();
        tenRowsOfBricks();
        bricksCounter();
        livesCounter();
        createPaddleMakeItFlexible();
        createBallMakeItMove();
    }

    /**
     * A colored ceiling consisting of 10 rows has been created.
     * Each pair of rows has its own color and consists of 10 bricks.
     */
    private void tenRowsOfBricks() {
        // starting y-axis coordinate for the first row
        double yCoordinateRow = BRICK_Y_OFFSET;

        // create the row
        for (int i = 0; i < NBRICK_ROWS; i++) {
            // starting x-axis coordinate for the current row
            double xCoordinate = (getWidth() - BRICK_WIDTH * 10 - BRICK_SEP * 9) / 2;

            // fill the row with bricks
            for (int j = 0; j < NBRICKS_PER_ROW; j++) {
                // add brick to  with using parameters
                createBrick(xCoordinate, yCoordinateRow, i);

                // change x-axis for the next brick (move it to the right side)
                xCoordinate = xCoordinate + BRICK_WIDTH + BRICK_SEP;
            }

            // set the y-axis for the next row of bricks
            yCoordinateRow = yCoordinateRow + BRICK_HEIGHT + BRICK_SEP;
        }
    }

    /**
     * In the lower left corner, the user can see how many bricks are left before the end of the game.
     */
    private void bricksCounter() {
        int numberOfBricksToWinGame = NBRICKS_PER_ROW * NBRICK_ROWS;
        bricksCounterLabel = new GLabel("BRICKS TO WIN THIS GAME: " + numberOfBricksToWinGame);
        bricksCounterLabel.setFont("Helvetica-10");
        bricksCounterLabel.setLocation(0, getHeight() - bricksCounterLabel.getDescent());
        add(bricksCounterLabel);
    }

    /**
     * user can see how many attempts he/she has.
     */
    private void livesCounter() {
        livesCounterLabel = new GLabel("YOUR ATTEMPTS: " + NTURNS);
        livesCounterLabel.setFont("Helvetica-10");

        // label x-axis and y-axis
        double x = getWidth() - livesCounterLabel.getWidth();
        double y = getHeight() - livesCounterLabel.getDescent();

        livesCounterLabel.setLocation(x, y);
        add(livesCounterLabel);
    }

    /**
     * the program built a brick using coordinates and
     * set it color according to the task.
     */
    private void createBrick(double xCoordinate, double yCoordinateRow, int i) {
        // create a brick
        GRect rect = new GRect(xCoordinate, yCoordinateRow, BRICK_WIDTH, BRICK_HEIGHT);
        rect.setFilled(true);

        // set different colors for each row of bricks
        if (i == 0 || i == 1) {
            rect.setColor(Color.RED);
        }
        if (i == 2 || i == 3) {
            rect.setColor(Color.ORANGE);
        }
        if (i == 4 || i == 5) {
            rect.setColor(Color.YELLOW);
        }
        if (i == 6 || i == 7) {
            rect.setColor(Color.GREEN);
        }
        if (i == 8 || i == 9) {
            rect.setColor(Color.CYAN);
        }
        add(rect);
    }

    /** Create a paddle to play the game
     */
    private void createPaddleMakeItFlexible() {
        paddle = new GRect(0, getHeight() - PADDLE_Y_OFFSET, PADDLE_WIDTH, PADDLE_HEIGHT);
        paddle.setFilled(true);
        paddle.setColor(Color.BLACK);
        add(paddle);
    }

    /** paddle can follow users` mouse. Mouse x-axis coordinate always
     * at the center of the paddle
     */
    public void mouseMoved(MouseEvent paddleMove) {
        // find center(x-axis) of the paddle
        double mouseCenterOfThePaddle = PADDLE_WIDTH / 2;

        // minimum x-axis coordinate for paddle
        double xAxisLimits = getWidth() - mouseCenterOfThePaddle;
        // minimum y-axis coordinate for paddle
        double yAxisLimits = mouseCenterOfThePaddle;

        // set limitations for paddle to prevent it from going outside the app window
        if (paddleMove.getX() <= xAxisLimits && paddleMove.getX() >= yAxisLimits) {
            paddle.setLocation(paddleMove.getX() - mouseCenterOfThePaddle, getHeight() - PADDLE_Y_OFFSET);
        }
    }

    /** ADD a ball. The ball is animated.
     */
    private void createBallMakeItMove() {
        // create regular black ball
        GOval ball = createBall();

        // make it animated
        animateBall(ball);
    }

    /** Create Ball
     */
    private GOval createBall() {
        //ball height and width
        double ovalWidthHeight = BALL_RADIUS * 2;

        // create oval and add it to html
        GOval oval = new GOval(getWidth() / 2 - BALL_RADIUS, getHeight() / 2 - BALL_RADIUS, ovalWidthHeight, ovalWidthHeight);
        oval.setFilled(true);
        oval.setColor(Color.BLACK);
        add(oval);
        return oval;
    }

    /** the ball is animated, it bounces from each wall.
     */
    private void animateBall(GOval ball) {
        // click on mouse to start the game
        waitForClick();

        // origin quantity of bricks user has to break to win the game
        int numberOfBricksToWinGame = NBRICKS_PER_ROW * NBRICK_ROWS;

        // the number of lives a user has to finish the game
        int numberAttemptsUserHas = NTURNS;

        // set speed(number of pixels) ball moves on x-axis. It is a random
        // value  between -3 and 3. It could be positive or negative.
        RandomGenerator rgen = RandomGenerator.getInstance();
        vx = rgen.nextDouble(1.0, 3.0);
        if (rgen.nextBoolean(0.5)) {
            vx = -vx;
        }

        while (numberAttemptsUserHas != 0) {
            // ball met something
            GObject collider = getCollidingObject(ball);
            if (collider == paddle) {
                vy = vy * (-1);
            }

            //collider != null && collider != paddle
            if (collider != null && collider != paddle && collider != bricksCounterLabel
                    && collider != livesCounterLabel) {
                vy = vy * (-1);
                remove(collider);
                numberOfBricksToWinGame--;
                displayQuantityLeft(numberOfBricksToWinGame);
            }

            // bounce left border
            if (ball.getX() < 0) {
                vx = vx * (-1);
            }

            // bounce right border
            if (ball.getX() > getWidth() - BALL_RADIUS * 2) {
                vx = vx * (-1);
            }

            // bounce top border
            if (ball.getY() < 0) {
                vy = vy * (-1);
            }

            // user missed one of his/her lives
            if (ball.getY() > getHeight() - BALL_RADIUS * 2) {
                numberAttemptsUserHas--;

                //countered decreased, when user missed one of his lives
                displayAttemptsUserHas(numberAttemptsUserHas);

                // set starting position of the ball
                ball.setLocation(getWidth() / 2 - BALL_RADIUS, getHeight() / 2 - BALL_RADIUS);
                if (numberAttemptsUserHas != 0) {
                    waitForClick();
                }
                continue;
            }

            ball.move(vx, vy);
            pause(30);
        }

        finalResult(numberAttemptsUserHas);
    }

    /** The paddle hits the ball.
     */
    private GObject getCollidingObject(GOval ball) {
        // ball diameter
        double ballDiameter = BALL_RADIUS * 2;

        if (getElementAt(ball.getX(), ball.getY()) != null) {
            return getElementAt(ball.getX(), ball.getY());
        }
        if (getElementAt(ball.getX() + ballDiameter, ball.getY()) != null) {
            return getElementAt(ball.getX() + ballDiameter, ball.getY());
        }
        if (getElementAt(ball.getX(), ball.getY() + ballDiameter) != null) {
            return getElementAt(ball.getX(), ball.getY() + ballDiameter);
        }
        if (getElementAt(ball.getX() + ballDiameter, ball.getY() + ballDiameter) != null) {
            return getElementAt(ball.getX() + ballDiameter, ball.getY() + ballDiameter);
        }
        return null;
    }

    /**Text value of the bricksCounterLabel when changed ball met brick (decreased).
     */
    private void displayQuantityLeft(int quantityOfBricksLeft) {
        bricksCounterLabel.setLabel("BRICKS TO WIN THIS GAME: " + quantityOfBricksLeft);
    }

    /** counter decreased, when user missed one of his lives
     */
    private void displayAttemptsUserHas(int numberAttemptsUserHas) {
        livesCounterLabel.setLabel("YOUR ATTEMPTS: " + numberAttemptsUserHas);
    }

    /*game is over and  user can see his/her result.*/

    private void finalResult(int numberAttemptsUserHas) {
        removeAll();
        GLabel label = new GLabel("");
        label.setFont("Helvetica-24");

        // user lost
        if (numberAttemptsUserHas == 0) {
            label.setLabel("SORRY, YOU LOST...");
        }
        // user won
        if (numberAttemptsUserHas != 0) {
            label.setLabel("CONGRATULATIONS, YOU WON!!");
        }

        // get x-axis, y-axis to center final message
        double x = (getWidth() - label.getWidth()) / 2;
        double y = (getHeight() - label.getHeight()) / 2;

        label.setLocation(x, y);
        add(label);
    }
}
