package com.shpp.p2p.cs.ymatusevich.assignment4;

import acm.graphics.GObject;
import acm.graphics.GOval;
import acm.graphics.GPoint;
import acm.graphics.GRect;
import com.shpp.cs.a.graphics.WindowProgram;

import javax.swing.*;
import java.awt.*;
import java.awt.event.ComponentAdapter;
import java.awt.event.ComponentEvent;
import java.awt.event.MouseEvent;
import java.util.ArrayList;
import java.util.Random;

/**
 * Extend version of the Breakout game with sound effects for ball and bricks, visualisation number of attempts
 */
public class BreakoutExt extends WindowProgram {
    /**
     * Width and height of application window in pixels
     */
    public static final int APPLICATION_WIDTH = 800;
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
    private static final int NBRICK_ROWS = 10;

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

    /**
     * Offset of the top brick row from the top
     */
    private static final int BRICK_Y_OFFSET = 70;

    /**
     * Number of turns
     */
    private static final int NTURNS = 3;

    /**
     * Ball speed (pause in millisecond)
     */
    private static final int BALL_SPEED = 30;

    /**
     * Base colors for lines of the bricks
     */
    private static final Color[] BRICK_COLORS = new Color[]{Color.RED, Color.ORANGE, Color.YELLOW, Color.GREEN, Color.CYAN};

    /**
     * File names for audio samples
     */
    private static final String BALL_WAV = "ball-tap.wav";
    private static final String BRICK_WAV = "brick.wav";
    /**
     * Global variables for saving global objects - paddle, ball, array of the bricks, and bricks counter
     */
    private GRect paddle = null;
    private GOval ball = null;
    private GRect[][] bricks = null;
    private int bricksCount;

    /**
     * Global variable for saving audio clips for ball and brick
     */
    private double[] ballWav = null;

    private double[] brickWav = null;

    public void run() {
        startGame();
    }

    /**
     * Method creates all the global objects in the scene and starts a new game in a loop until
     * user has not destroyed all bricks or used all attempts
     */
    private void startGame() {
        this.setTitle("Breakout Game");
        removeAll();
        makePaddle();
        makeBricks();
        addComponentListener(new ComponentAdapter() {
            @Override
            public void componentResized(ComponentEvent e) {
                redrawWindow();
            }
        });
        addMouseListeners();
        ArrayList<GOval> gOvals = makeGOvals();
        int nTurns = NTURNS;
        while (nTurns != 0 && bricksCount != 0) {
            makeBall();
            waitForClick();
            if (!moveBall()) {
                nTurns--;
                remove(gOvals.get(gOvals.size() -1));
                gOvals.remove(gOvals.size()-1);
                remove(ball);
            }
        }
        endGame(nTurns);
    }

    /**
     * Makes array of ball for label with number of attempts
     * @return - array of GOval objects
     */
    private ArrayList<GOval> makeGOvals() {
        var array = new ArrayList<GOval>();
        for (int i = 0; i<NTURNS; i++){
            var gOval = new GOval(i * (BALL_RADIUS * 2 + 5), 0, BALL_RADIUS*2, BALL_RADIUS*2);
            gOval.setFilled(true);
            add(gOval);
            array.add(gOval);
        }
        return array;
    }

    /**
     * This method make analyze a count of the bricks and count of the turns left on end of game and
     * shown the result dialog box for user
     * @param nTurns - integer value of turns left
     */
    private void endGame(int nTurns) {
        String message = "";
        if (nTurns != 0 && bricksCount == 0) {
            message = "You win!!!";
            System.out.println("Win");
        } else {
            message = "You loss :(";
            System.out.println("Loss");
        }
        //Shown dialog box and got dialog result
        int n = JOptionPane.showConfirmDialog(
                this,
                message + "\nStart new game?",
                "End of this Game",
                JOptionPane.YES_NO_OPTION);
        if (n == 0) {
            removeAll();
            startGame();
        } else {
            exit();
        }
    }

    /**
     * This method resize all left bricks relative to current size of the window
     */
    private void redrawWindow() {
        var brickWidth = getWidth() / (NBRICKS_PER_ROW) - BRICK_SEP;
        for (int i = 0; i < NBRICK_ROWS; i++)
            for (int j = 0; j < NBRICKS_PER_ROW; j++) {
                var x = BRICK_SEP + j * (brickWidth + BRICK_SEP);
                var y = BRICK_Y_OFFSET + i * (BRICK_HEIGHT + BRICK_SEP);
                if (bricks[i][j] != null) {
                    bricks[i][j].setLocation(x, y);
                    bricks[i][j].setSize(brickWidth, BRICK_HEIGHT);
                }
            }
        paddle.setLocation(paddle.getX(), getHeight() - PADDLE_Y_OFFSET - PADDLE_HEIGHT);
    }

    /**
     * This method makes an array of the bricks relative to a predefined count of rows and
     * count of the brick per row, and initialize global variable bricksCount of the count of bricks
     */
    private void makeBricks() {
        bricks = new GRect[NBRICK_ROWS][NBRICKS_PER_ROW];
        for (int i = 0; i < NBRICK_ROWS; i++) {
            Color brickColor;
            if ((i / 2) >= BRICK_COLORS.length) {
                brickColor = getRandomColor();
            } else {
                brickColor = BRICK_COLORS[i / 2];
            }
            for (int j = 0; j < NBRICKS_PER_ROW; j++) {
                bricks[i][j] = makeBrick(i, j, brickColor);
            }
        }
        bricksCount = NBRICK_ROWS * NBRICKS_PER_ROW;
    }

    /**
     * Create one brick with define color. Coordinates of created brick calculate from row and cell number
     * @param row - integer of a row number
     * @param cell - integer of a cell number
     * @param brickColor - color of brick
     * @return - created brick with defined parameter
     */
    private GRect makeBrick(int row, int cell, Color brickColor) {
        var brickWidth = getWidth() / (NBRICKS_PER_ROW) - BRICK_SEP;
        var x = BRICK_SEP + cell * (brickWidth + BRICK_SEP);
        var y = BRICK_Y_OFFSET + row * (BRICK_HEIGHT + BRICK_SEP);
        var brick = new GRect(x, y, brickWidth, BRICK_HEIGHT);
        brick.setFilled(true);
        brick.setFillColor(brickColor);
        add(brick);
        return brick;
    }

    /**
     * Makes and return random color
     * @return - Color value of the generated color
     */
    private Color getRandomColor() {
        var randomizer = new Random();
        return new Color(randomizer.nextFloat(), randomizer.nextFloat(), randomizer.nextFloat());
    }

    /**
     * Starts the movement of the ball in the playing space,
     * at each step checks for collision with other objects or walls
     * @return - boolean result of game (true if all bricks is destroyed, false if ball get out
     */
    private boolean moveBall() {
        //initialize ball speed on x and y coordinates
        double vy = 3.0;
        var randomizer = new Random();
        double vx = randomizer.nextDouble(1.0, 3.0);
        if (randomizer.nextBoolean()) {
            vx = -vx;
        }
        //move ball in the loop
        while (true) {
            //check if ball get out
            if ((ball.getY() + BALL_RADIUS * 2) >= getHeight()) return false;
            var collapsedObj = getCollidingObject();
            //if the ball collided with the paddle or brick
            if (collapsedObj != null){
                    if (collapsedObj == paddle){
                        StdAudio.playInBackground(BALL_WAV);
                    }
                    if(isLeftTopCornerCollision(collapsedObj, vx, vy)){
                        vx = -Math.abs(vx);
                        vy = -Math.abs(vy);
                    } else
                    if (isRightTopCornerCollision(collapsedObj, vx, vy)){
                        vx = Math.abs(vx);
                        vy = -Math.abs(vy);
                    } else
                    if(isLeftBottomCornerCollision(collapsedObj, vx, vy)){
                        vx = -Math.abs(vx);
                        vy = Math.abs(vy);
                    } else
                    if (isRightBottomCornerCollision(collapsedObj, vx, vy)){
                        vx = Math.abs(vx);
                        vy = Math.abs(vy);
                    } else
                    if (isLeftCollision(collapsedObj, vx, vy)){
                        vx = - Math.abs(vx);
                    } else
                    if (isRightCollision(collapsedObj, vx, vy)){
                        vx = Math.abs(vx);
                    } else
                    if (isTopCollision(collapsedObj, vx, vy)){
                        if (((ball.getY() + ball.getHeight()) > collapsedObj.getY())){
                            ball.setLocation(ball.getX(), paddle.getY()-ball.getHeight() - 1);
                        }
                        vy = -Math.abs(vy);
                    } else
                    if (isBottomCollision(collapsedObj, vx, vy)){
                        vy = Math.abs(vy);
                    }
            }
            //if the ball collided with the top then invert the speed along the axis Y
            if (ball.getY() <= 0) {
                StdAudio.playInBackground(BALL_WAV);
                vy = -vy;
            }
            //if the ball collided with the brick - destroy brick and decrease counter of bricks
            if (collapsedObj != null && collapsedObj != paddle) {
                remove(collapsedObj);
                bricksCount--;
                StdAudio.playInBackground(BRICK_WAV);
                if (bricksCount == 0) {
                    return true;
                }
            }
            //if the ball collided with the wall, then invert the speed along the axis X
            if (((ball.getX() + ball.getWidth()) >= getWidth()) || (ball.getX() <= 0)) {
                StdAudio.playInBackground(BALL_WAV);
                vx = -vx;
            }
            ball.setLocation(ball.getX() + vx, ball.getY() + vy);
            pause(BALL_SPEED);
        }
    }

    /**
     * Checks ball collision with other objects in the game space
     * @return - GObject value of the collided object
     */
    private GObject getCollidingObject() {
        GObject obj = null;
        var pointArray = new GPoint[]{new GPoint(ball.getLocation()),
                new GPoint(ball.getX() - 1, ball.getY() + ball.getHeight() / 2),
                new GPoint(ball.getX(), ball.getY() + ball.getHeight()),
                new GPoint(ball.getX() + ball.getWidth(), ball.getY()),
                new GPoint(ball.getX() + ball.getWidth() + 1, ball.getY() + ball.getHeight() / 2),
                new GPoint(ball.getX() + ball.getWidth(), ball.getY() + ball.getHeight())};
        for (GPoint point : pointArray) {
            obj = getElementAt(point);
            if (obj != null) return obj;
        }
        return obj;
    }

    /**
     * Creates ball in the center of the game scene
     */
    private void makeBall() {
        int x = getWidth() / 2 - BALL_RADIUS;
        int y = BRICK_Y_OFFSET + (BRICK_HEIGHT + BRICK_SEP) * NBRICK_ROWS + BALL_RADIUS * 4;
        var ball = new GOval(x, y, BALL_RADIUS * 2, BALL_RADIUS * 2);
        ball.setFilled(true);
        add(ball);
        this.ball = ball;
    }

    /**
     * Creates paddle with predefine parameters
     */
    private void makePaddle() {
        int x = getWidth() / 2 - PADDLE_WIDTH / 2;
        int y = getHeight() - PADDLE_Y_OFFSET - PADDLE_HEIGHT;
        var paddle = new GRect(x, y, PADDLE_WIDTH, PADDLE_HEIGHT);
        paddle.setFilled(true);
        add(paddle);
        this.paddle = paddle;
    }

    /**
     * Moves the paddle if mouse moved
     * @param e the event to be processed
     */
    public void mouseMoved(MouseEvent e) {
        int x = e.getX() - PADDLE_WIDTH / 2;
        if (x < 0) x = 0;
        if (x > (getWidth() - PADDLE_WIDTH)) x = getWidth() - PADDLE_WIDTH - 1;
        paddle.setLocation(x, paddle.getY());
    }

    /**
     * Check if ball collided with left side of object
     * @param obj - collided object for checking
     * @param vx - speed along of X axis
     * @param vy - speed along of Y axis
     * @return = true if ball collided with left side of object, or false if not
     */
    private boolean isLeftCollision(GObject obj, double vx, double vy){
        return (ball.getX() + ball.getWidth() - Math.abs(vx) <= obj.getX());
    }

    /**
     * Check if ball collided with right side of object
     * @param obj - collided object for checking
     * @param vx - speed along of X axis
     * @param vy - speed along of Y axis
     * @return = true if ball collided with right side of object, or false if not
     */
    private boolean isRightCollision(GObject obj, double vx, double vy){
        return (ball.getX() >= (obj.getX() + obj.getWidth() - Math.abs(vx)));
    }

    /**
     * Check if ball collided with left top corner of object
     * @param obj - collided object for checking
     * @param vx - speed along of X axis
     * @param vy - speed along of Y axis
     * @return = true if ball collided with left top corner of object, or false if not
     */
    private boolean isLeftTopCornerCollision(GObject obj, double vx, double vy){
        return (vx > 0 && vy > 0 && ((ball.getX() + ball.getWidth()/2) <= obj.getX()) && !isLeftCollision(obj, vx, vy));
    }

    /**
     * Check if ball collided with right top corner of object
     * @param obj - collided object for checking
     * @param vx - speed along of X axis
     * @param vy - speed along of Y axis
     * @return = true if ball collided with right top corner of object, or false if not
     */
    private boolean isRightTopCornerCollision(GObject obj, double vx, double vy){
        return (vx < 0 && vy > 0 && ((ball.getX()) >= (obj.getX() + obj.getWidth() - ball.getWidth()/2)) && !isRightCollision(obj, vx, vy));
    }

    /**
     * Check if ball collided with top side of object
     * @param obj - collided object for checking
     * @param vx - speed along of X axis
     * @param vy - speed along of Y axis
     * @return = true if ball collided with top side of object, or false if not
     */
    private boolean isTopCollision(GObject obj, double vx, double vy){
        return (vy > 0 && !isLeftTopCornerCollision(obj, vx, vy) && !isRightTopCornerCollision(obj, vx, vy));
    }

    /**
     * Check if ball collided with left bottom corner of object
     * @param obj - collided object for checking
     * @param vx - speed along of X axis
     * @param vy - speed along of Y axis
     * @return = true if ball collided with left bottom corner of object, or false if not
     */
    private boolean isLeftBottomCornerCollision(GObject obj, double vx, double vy){
        return (vx > 0 && vy < 0 && ((ball.getX() + ball.getWidth()/2) <= obj.getX()) && !isLeftCollision(obj, vx, vy));
    }

    /**
     * Check if ball collided with right bottom corner of object
     * @param obj - collided object for checking
     * @param vx - speed along of X axis
     * @param vy - speed along of Y axis
     * @return = true if ball collided with right bottom corner of object, or false if not
     */
    private boolean isRightBottomCornerCollision(GObject obj, double vx, double vy){
        return (vx < 0 && vy < 0 && ((ball.getX()) >= (obj.getX() + obj.getWidth() - ball.getWidth()/2)) && !isRightCollision(obj, vx, vy));
    }

    /**
     * Check if ball collided with bottom side of object
     * @param obj - collided object for checking
     * @param vx - speed along of X axis
     * @param vy - speed along of Y axis
     * @return = true if ball collided with bottom side of object, or false if not
     */
    private boolean isBottomCollision(GObject obj, double vx, double vy){
        return (vy < 0 && !isLeftTopCornerCollision(obj, vx, vy) && !isRightTopCornerCollision(obj, vx, vy));
    }
}