package com.shpp.p2p.cs.kserdiuk.assignment4;


import acm.graphics.*;
import acm.util.RandomGenerator;
import com.shpp.cs.a.graphics.WindowProgram;

import java.awt.*;
import java.awt.event.MouseEvent;

/**
 * The Breakout arcade game implementation
 */
public class Breakout extends WindowProgram {
    /**
     * Width and height of application window in pixels
     */
    public static final int APPLICATION_WIDTH = 400;
    public static final int APPLICATION_HEIGHT = 600;

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
     * Height of a brick
     */
    private static final int BRICK_HEIGHT = 8;

    /**
     * Radius of the ball in pixels
     */
    private static final int BALL_RADIUS = 10;

    private static final double START_SPEED = 3.0;

    /**
     * Offset of the top brick row from the top
     */
    private static final int BRICK_Y_OFFSET = 70;
    /**
     * Number of turns
     */
    private static final int NTURNS = 3;
    /**
     * Animation pause time between ball moves
     */
    private static final int PAUSE = 30;

    /* The method of run the Breakout program */
    @Override
    public void run() {
        playGame();
    }

    /* The method describes the main phases of the game and the conditions for its end */
    private void playGame() {

        addMouseListeners();
        /*bricks are made outside the loop because we need to start every next turn
        with the number and position of bricks from previous attempt.*/
        makeBrickWall();

        /* The play loop that depends on number of turns, amount of bricks remain and
          position of the ball relative to the bottom of the screen */
        for (int i = 0; i < NTURNS; i++) {
            makePaddle();

            requestForClick();

            makeBall();

            play();

            if (remainBricks == 0) { //case when all bricks are removed, game over and the user is win.
                removeAll(); // white screen
                youWinLabel();

            } else if (remainBricks > 0) { //case when the user lost a try, but he still has one or two turns to win
                remove(ball); // repaint ball and paddle with start position to the next turn
                remove(paddle);

            }
        }
        if (remainBricks > 0) { //case when turns is over, but one or more bricks are still on screen. User has lost.
            removeAll(); // white screen with win label
            gameOverLabel();
        }
    }

    /* The method that make a label with directions for user to click to  start the game*/
    private void requestForClick() {

        GLabel click = new GLabel("PLEASE CLICK");
        click.setFont("Cosmic-20");
        click.setColor(Color.BLACK);
        add(click, (getWidth() / 2 - click.getWidth() / 2), getHeight() - PADDLE_Y_OFFSET * 2 - click.getDescent());
        waitForClick();
        remove(click);

    }

    public GRect paddle;

    /*The method that creates a paddle and add it in the center of screen width. Paddle is located in the center of screen width
    and does not move vertically*/
    public void makePaddle() {
        paddle = new GRect(getWidth() / 2 - PADDLE_WIDTH / 2,
                getHeight() - PADDLE_Y_OFFSET - PADDLE_HEIGHT,
                PADDLE_WIDTH, PADDLE_HEIGHT);
        paddle.setColor(Color.BLACK);
        paddle.setFilled(true);
        paddle.setFillColor(Color.BLACK);
        add(paddle);
    }


     /* The method that move middle point of paddle using clicked mouse*/

    public void mouseDragged(MouseEvent e) {
        /* If the middle point of the paddle is between half paddle width of the screen begin
         and half a paddle width before the end of the screen,
         the x location of the paddle is set at where the mouse is minus half a paddle's width */
        if ((e.getX() < getWidth() - PADDLE_WIDTH / 2) && (e.getX() > PADDLE_WIDTH / 2)) {
            paddle.setLocation(e.getX() - PADDLE_WIDTH / 2, getHeight() - PADDLE_Y_OFFSET - PADDLE_HEIGHT);
        }
    }

    public GOval ball;

    /*The method that create the ball and add it on the screen center */
    private void makeBall() {
        ball = new GOval(getWidth() / 2 - BALL_RADIUS,
                getHeight() / 2 - BALL_RADIUS,
                BALL_RADIUS * 2, BALL_RADIUS * 2);
        ball.setColor(Color.BLACK);
        ball.setFilled(true);
        ball.setFillColor(Color.BLACK);
        add(ball);
    }

    /*The method that create the brick wall with colored rows, width-centered */
    private void makeBrickWall() {
        double brickWidth = (getWidth() - (NBRICKS_PER_ROW) * BRICK_SEP) / NBRICKS_PER_ROW; // width of one single brick
        double brickX = getWidth() / 2 - (brickWidth * NBRICKS_PER_ROW) / 2 - BRICK_SEP * (NBRICKS_PER_ROW - 1) / 2; //first brick x coord.
        double brickY = BRICK_Y_OFFSET; // the space between upper wall and first row

        for (int i = 0; i < NBRICK_ROWS; i++) { //loop that create bricks column

            for (int j = 0; j < NBRICKS_PER_ROW; j++) { //loop that create bricks row
                GRect brick = new GRect(brickX, brickY, brickWidth, BRICK_HEIGHT);
                brick.setFilled(true);
                if (i < 2) {
                    brick.setColor(Color.RED);
                    brick.setFillColor(Color.RED);
                } else if (i < 4) {
                    brick.setColor(Color.ORANGE);
                    brick.setFillColor(Color.ORANGE);
                } else if (i < 6) {
                    brick.setColor(Color.YELLOW);
                    brick.setFillColor(Color.YELLOW);
                } else if (i < 8) {
                    brick.setColor(Color.GREEN);
                    brick.setFillColor(Color.GREEN);
                } else if (i < 10) {
                    brick.setColor(Color.CYAN);
                    brick.setFillColor(Color.CYAN);
                } else {
                    brick.setColor(Color.BLUE);
                    brick.setFillColor(Color.BLUE);
                }
                add(brick);

                brickX = brickX + (brickWidth + BRICK_SEP);

            }
            brickX = brickX - (NBRICKS_PER_ROW) * brickWidth - (NBRICKS_PER_ROW) * BRICK_SEP;
            brickY = brickY + (BRICK_HEIGHT + BRICK_SEP);
        }
    }

    /*The parameter of bricks number, that are left after collision with the ball*/
    private int remainBricks = NBRICK_ROWS * NBRICKS_PER_ROW;

    /* The ball velocity - offset x and y*/
    private double vx, vy;

    /*The method that generate ball velocity - x offset for ball and realize the animation*/
    private void play() {
        RandomGenerator rgen = RandomGenerator.getInstance();
        vx = rgen.nextDouble(1.0, 3.0);
        if (rgen.nextBoolean(0.5))
            vx = -vx; // according to random generator choice the X offset changes direction to the opposite
        vy = START_SPEED; // Y offset is unchanged

        while (remainBricks != 0 && ball.getY() + 2 * BALL_RADIUS < getHeight()) { // condition while the ball move and
                                                                                    // single turn continuous
            moveBall();
            checkCollider();
            pause(PAUSE);
        }
    }

    /*The method that show the rules of contact with the walls (screen edges)*/
    private void moveBall() {

        ball.move(vx, vy); //function of ball move with velocity

        if (ball.getX() + 2 * BALL_RADIUS >= getWidth()) { //bounce of right wall
            vx = -vx;
        } else if (ball.getX() <= 0) { //bounce of left wall
            vx = -vx;
        } else if (ball.getY() <= 0) { //bounce of upper wall
            vy = -vy;
        }

    }

    /*The method that identify the collider and relative to the type of collider give the ball directions to move (if its paddle
     or remove the brick */
    private void checkCollider() {
        GObject collider = getCollidingObject();
        if (collider != null) {
            if (collider == paddle) {
                vy = -vy;
            } else {
                remove(collider);
                vy = -vy;
                remainBricks = remainBricks - 1; //brick counter decreases by one after each collision with ball.
            }
        }
    }

    /*The method that finds the collider by four points in the ball corners
    and 8 points near the center between sides of square containing a ball.
    if the collider has fined (not null), returns object in this point */
    private GObject getCollidingObject() {
        if (getElementAt(ball.getX(), ball.getY()) != null) { //left upper corner point
            return getElementAt(ball.getX(), ball.getY());

        } else if (getElementAt(ball.getX() + 2 * BALL_RADIUS, ball.getY()) != null) { //right upper corner point
            return getElementAt(ball.getX() + 2 * BALL_RADIUS, ball.getY());

        } else if (getElementAt(ball.getX() + 2 * BALL_RADIUS, ball.getY() + 2 * BALL_RADIUS) != null) { //right lower corner point
            return getElementAt(ball.getX() + 2 * BALL_RADIUS, ball.getY() + 2 * BALL_RADIUS);

        } else if (getElementAt(ball.getX(), ball.getY() + 2 * BALL_RADIUS) != null) { //left lower corner point
            return getElementAt(ball.getX(), ball.getY() + 2 * BALL_RADIUS);

        /* Two points near center on upper edge of square*/
        } else if (getElementAt(ball.getX() + BALL_RADIUS - 2, ball.getY()) != null ){
            return getElementAt(ball.getX() + BALL_RADIUS - 2, ball.getY());
        } else if (getElementAt(ball.getX() + BALL_RADIUS + 2, ball.getY()) != null ){
            return getElementAt(ball.getX() + BALL_RADIUS + 2, ball.getY());
        /*Two points near center on lower edge of square*/
        } else if (getElementAt(ball.getX(), ball.getY() + 2 * BALL_RADIUS - 2) != null ){
            return getElementAt(ball.getX(), ball.getY() + 2 * BALL_RADIUS - 2);
        } else if (getElementAt(ball.getX(), ball.getY() + 2 * BALL_RADIUS + 2) != null ){
            return getElementAt(ball.getX(), ball.getY() + 2 * BALL_RADIUS + 2);
        /*Two points near center on left edge of square*/
        } else if (getElementAt(ball.getX(), ball.getY() + BALL_RADIUS - 2) != null ){
            return getElementAt(ball.getX(), ball.getY() + BALL_RADIUS - 2);
        } else if (getElementAt(ball.getX(), ball.getY() + BALL_RADIUS + 2) != null ){
            return getElementAt(ball.getX(), ball.getY() + BALL_RADIUS + 2);
        /*Two points near center on right edge of square*/
        } else if (getElementAt(ball.getX() + 2 * BALL_RADIUS, ball.getY() + BALL_RADIUS - 2) != null ){
            return getElementAt(ball.getX() + 2 * BALL_RADIUS, ball.getY() + BALL_RADIUS - 2);
        } else if (getElementAt(ball.getX() + 2 * BALL_RADIUS, ball.getY() + BALL_RADIUS - 2) != null ){
            return getElementAt(ball.getX() + 2 * BALL_RADIUS, ball.getY() + BALL_RADIUS - 2);
        /*if no element founds*/
        } else {
            return null;
        }
    }

    /*The method that creates the label "Game over" and add it on screen*/
    private void gameOverLabel() {
        GLabel gameOver = new GLabel("GAME OVER :(");
        gameOver.setFont("Cosmic-40");
        gameOver.setColor(Color.BLACK);
        add(gameOver, (getWidth() / 2 - gameOver.getWidth() / 2), getHeight() / 2 - gameOver.getDescent());
    }

    /*The method that creates the label "You win" and add it on screen*/
    private void youWinLabel() {
        GLabel youWin = new GLabel("YOU WIN :)");
        youWin.setFont("Cosmic-40");
        youWin.setColor(Color.BLACK);
        add(youWin, (getWidth() / 2 - youWin.getWidth() / 2), getHeight() / 2 - youWin.getDescent());

    }

}