package com.shpp.p2p.cs.mrepencuk.assignment4;


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
    public static final int APPLICATION_WIDTH = 1100;
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

    private static final double PAUSE_TIME = 10;

    //===================================================================================

    private static final double ADDSPEED = 0.1;
    private static final double ELASTICiTY = 1;
    private static final double celling = 0;

    public void run() {
        //using the method to create a wall
        createWall();

        //add mouse control method
        addMouseListeners();
        //add racket
        addPaddle();

        //add a variable and assign the ball object to it
        GOval ball = createBall();
        add(ball);

        //add an animation method to the ball
        ballMovement(ball);


    }
    //with the help of a loop, we build rows and repeat them, so we build a grid of bricks
    private void createWall() {
        for (int i = 0; i < NBRICKS_PER_ROW; i++) {

            for (int a = 0; a < NBRICK_ROWS; a++) {
                brick(getWidth()/NBRICKS_PER_ROW * a, BRICK_HEIGHT * i );

            }
        }
    }
    //brick making method
    private GRect brick( double a, double b) {
        GRect brick = new GRect(a, b+BRICK_Y_OFFSET, getWidth()/NBRICKS_PER_ROW-BRICK_SEP,BRICK_HEIGHT -BRICK_SEP);
        brick.setFilled(true);
        brick.setColor(Color.black);
        add(brick);
        return (brick);
    }
    //use the AddMouseListeners() method to control the mouse
    private GObject selectPaddle;

    public void mousePressed(MouseEvent move) {
        selectPaddle = getElementAt(move.getX(), move.getY());
    }

    public void mouseDragged(MouseEvent move) {
        if (selectPaddle != null) {
            double newX = move.getX()- selectPaddle.getWidth()/2;
            double newY = getHeight() - PADDLE_Y_OFFSET;
            if (newX < 0){
                newX = 0;
            }   else if(newX > getWidth()-PADDLE_WIDTH){
                newX = getWidth()-PADDLE_WIDTH;
            }
            selectPaddle.setLocation(newX, newY);
        }
    }
    //create a racket
    private GRect addPaddle() {
        GRect paddle = new GRect(getWidth() / 2 - PADDLE_WIDTH / 2, getHeight() - PADDLE_Y_OFFSET,
                PADDLE_WIDTH, PADDLE_HEIGHT);
        paddle.setFilled(true);
        paddle.setFillColor(Color.BLACK);
        add(paddle);

        return (paddle);
    }
    //create a ball
    private GOval createBall() {
        GOval ball = new GOval(getWidth() / 2 - BALL_RADIUS / 2, getHeight() / 2 - BALL_RADIUS / 2, BALL_RADIUS, BALL_RADIUS);
        ball.setFilled(true);
        ball.setFillColor(Color.BLACK);
        return (ball);
    }
    //variables that we will use to move the ball
    GObject ballPosition1;
    GObject ballPosition2;
    GObject ballPosition3;
    GObject ballPosition4;
    double dx;
    double dy;
    //big ball stirring method
    private void ballMovement(GOval ball) {

        int howMuchBricks = NBRICK_ROWS * NBRICKS_PER_ROW;
        //ball random coordinate method
        RandomGenerator rgen = RandomGenerator.getInstance();
        dx = rgen.nextDouble(1.0, 3.0);
        if (rgen.nextBoolean(0.5))
            dx = -dx;
        dy = 4;
        int i =0;
        while (i<NTURNS) {
            ball.move(dx, dy);
            //conditions for losing
            //if the ball touches the floor, then the countdown will
            //be carried out, when the number specified in the constant
            //is reached, the game will end
            if (ballBelowFlor(ball) && dy > 0) {
                ball.setLocation(getWidth() / 2 - BALL_RADIUS / 2, getHeight() / 2 - BALL_RADIUS / 2);
                i++;
            }
            if (i == 3){
                loser();
                return;
            }
            //conditions in contact with walls and ceilings
            if (ballBelowCeiling(ball) && dy < 0) {

                dy *= -ELASTICiTY;
            }
            if (ballBelowRightWall(ball) && dx > 0) {
                dx *= -ELASTICiTY;
            }
            if (ballBelowLeftWall(ball) && dx < 0) {
                dx *= -ELASTICiTY;
            }
            //ball touch points
            ballPosition1 = getElementAt(ball.getX(), ball.getY());
            ballPosition2 = getElementAt(ball.getX() + BALL_RADIUS * 2, ball.getY());
            ballPosition3 = getElementAt(ball.getX(), ball.getY() + BALL_RADIUS * 2);
            ballPosition4 = getElementAt(ball.getX() + BALL_RADIUS * 2, ball.getY() + BALL_RADIUS * 2);
            //conditions and change in the trajectory of the ball in contact with the racket
            if (ballPosition4 == selectPaddle && ballBelowFlor1(ball)) {
                dy *= -ELASTICiTY;
            } else if (ballPosition3 == selectPaddle && ballBelowFlor1(ball)) {
                dy *= -ELASTICiTY;
            } else if (ballPosition2 == selectPaddle && ballBelowFlor1(ball)) {
                dy *= -ELASTICiTY;
            } else if (ballPosition1 == selectPaddle && ballBelowFlor1(ball)) {
                dy *= -ELASTICiTY;
            }
            //conditions and changes in the speed of the ball
            if (ballPosition1 != null && ballPosition1 != selectPaddle){
                howMuchBricks -= 1;
                remove(ballPosition1);
                dy *= -ELASTICiTY;
                if(dx >0){
                    dx +=ADDSPEED;
                } else if (dx < 0){
                    dx -=ADDSPEED;
                }
                if(dy >0){
                    dy +=ADDSPEED;
                } else if (dy < 0){
                    dy -=ADDSPEED;
                }
            } else if (ballPosition2 != null && ballPosition2 != selectPaddle){
                howMuchBricks -= 1;
                remove(ballPosition2);
                dy *= -ELASTICiTY;
                if(dx >0){
                    dx +=ADDSPEED;
                } else if (dx < 0){
                    dx -=ADDSPEED;
                }
                if(dy >0){
                    dy +=ADDSPEED;
                } else if (dy < 0){
                    dy -=ADDSPEED;
                }
            } else if (ballPosition3 != null && ballPosition3 != selectPaddle){
                howMuchBricks -= 1;
                remove(ballPosition3);
                dy *= -ELASTICiTY;
                if(dx >0){
                    dx +=ADDSPEED;
                } else if (dx < 0){
                    dx -=ADDSPEED;
                }
                if(dy >0){
                    dy +=ADDSPEED;
                } else if (dy < 0){
                    dy -=ADDSPEED;
                }
            } else if (ballPosition4 != null && ballPosition4 != selectPaddle){
                howMuchBricks -= 1;
                remove(ballPosition4);
                dy *= -ELASTICiTY;
                if(dx >0){
                    dx +=ADDSPEED;
                } else if (dx < 0){
                    dx -=ADDSPEED;
                }
                if(dy >0){
                    dy +=ADDSPEED;
                } else if (dy < 0){
                    dy -=ADDSPEED;
                }
            }

            //if all bricks are destroyed
            if(howMuchBricks < 0){
                winner();
                return;
            }

            pause(PAUSE_TIME);
        }
    }
    //checks for the position of the ball out of the field
    private boolean ballBelowFlor(GOval ball) {
        return ball.getY() + ball.getHeight() >= getHeight();
    }

    private boolean ballBelowFlor1(GOval ball) {
        return ball.getY() + ball.getHeight() >= getHeight() - 30;
    }

    private boolean ballBelowCeiling(GOval ball) {
        return ball.getY() <= celling;
    }

    private boolean ballBelowRightWall(GOval ball) {
        return ball.getX() + ball.getWidth() >= getWidth();
    }

    private boolean ballBelowLeftWall(GOval ball) {
        return ball.getX() <= celling;
    }
    //in case of victory
    private GLabel winner(){
        GLabel winner = new GLabel("YOU WIN!!! CONGRATULATIONS",0,getHeight()/2);
        winner.setFont("Verdana-50");
        add(winner);
        return(winner);
    }
    //in case of loss
    private GLabel loser(){
        GLabel lose = new GLabel("YOY LOSE :(",0,getHeight()/2);
        lose.setFont("Verdana-50");
        add(lose);
        return(lose);
    }



}


