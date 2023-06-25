package com.shpp.p2p.cs.amolchanov.assignment3;

import acm.graphics.*;
import acm.program.*;
import acm.util.*;
import com.shpp.cs.a.graphics.WindowProgram;

import java.awt.*;


public class Assignment3Part6 extends WindowProgram {
    //ball size
    private static final int CIRCLE_SIZE = 50;
    //current balls
    private GOval ball;
    private GOval ball2;
    private GOval ball3;
    private GOval ball4;
    private GOval ball5;
    //delta for each ball
    private double dx = 9;
    private double dy = 5;
    private double dx2 = 7;
    private double dy2 = 6;
    private double dx3 = 6;
    private double dy3 = 8;
    private double dx4 = 8;
    private double dy4 = 8;
    private double dx5 = 4;
    private double dy5 = 9;
    private RandomGenerator rgen = new RandomGenerator();
    // frames per second
    public static final double FPS = 1000.0 / 60;

    public void run() {
        //scatter the balls on the screen
        drawBall();
        drawBall2();
        drawBall3();
        drawBall4();
        drawBall5();
        //making the balls move
        moveBalls();
    }

    private void moveBalls() {
        long start = System.currentTimeMillis();
        while (System.currentTimeMillis() - start < 5000) {
            ballmovement();
            colorChange();
            //All balls are measured if they touch the wall, they change direction
            if (ball.getY() >= getHeight() - CIRCLE_SIZE || ball.getY() <= 0) {
                dy = -dy;
            }
            if (ball.getX() >= getWidth() - CIRCLE_SIZE || ball.getX() <= 0) {
                dx = -dx;
            }
            if (ball2.getY() >= getHeight() - CIRCLE_SIZE || ball2.getY() <= 0) {
                dy2 = -dy2;
            }
            if (ball2.getX() >= getWidth() - CIRCLE_SIZE || ball2.getX() <= 0) {
                dx2 = -dx2;
            }
            if (ball3.getY() >= getHeight() - CIRCLE_SIZE || ball3.getY() <= 0) {
                dy3 = -dy3;
            }
            if (ball3.getX() >= getWidth() - CIRCLE_SIZE || ball3.getX() <= 0) {
                dx3 = -dx3;
            }
            if (ball4.getY() >= getHeight() - CIRCLE_SIZE || ball4.getY() <= 0) {
                dy4 = -dy4;
            }
            if (ball4.getX() >= getWidth() - CIRCLE_SIZE || ball4.getX() <= 0) {
                dx4 = -dx4;
            }
            if (ball5.getY() >= getHeight() - CIRCLE_SIZE || ball5.getY() <= 0) {
                dy5 = -dy5;
            }
            if (ball5.getX() >= getWidth() - CIRCLE_SIZE || ball5.getX() <= 0) {
                dx5 = -dx5;
            }

            pause(FPS);
        }
    }

    /**
     * move the balls at a given speed
     */
    private void ballmovement() {
        ball.move(dx, dy);
        ball2.move(dx2, dy2);
        ball3.move(dx3, dy3);
        ball4.move(dx4, dy4);
        ball5.move(dx5, dy5);
    }

    /**
     * make the balls change color to random
     */
    private void colorChange() {
        ball.setColor(rgen.nextColor());
        ball2.setColor(rgen.nextColor());
        ball3.setColor(rgen.nextColor());
        ball4.setColor(rgen.nextColor());
        ball5.setColor(rgen.nextColor());
    }

    /**
     * Creating the first ball
     */
    private void drawBall() {
        double x = (getWidth() / 2.0 - CIRCLE_SIZE);
        double y = (getHeight() / 2.0 - CIRCLE_SIZE);
        ball = new GOval(x, y, CIRCLE_SIZE, CIRCLE_SIZE);
        ball.setFilled(true);
        add(ball);
    }

    /**
     * Create the second ball
     */
    private void drawBall2() {
        double x = (getWidth() / 2.0 - CIRCLE_SIZE * 2);
        double y = (getHeight() / 2.0 - CIRCLE_SIZE * 2);
        ball2 = new GOval(x, y, CIRCLE_SIZE, CIRCLE_SIZE);
        ball2.setFilled(true);
        add(ball2);
    }

    /**
     * Create the third ball
     */
    private void drawBall3() {
        double x = (getWidth() / 2.0 - CIRCLE_SIZE * 3);
        double y = (getHeight() / 2.0 - CIRCLE_SIZE * 3);
        ball3 = new GOval(x, y, CIRCLE_SIZE, CIRCLE_SIZE);
        ball3.setFilled(true);
        add(ball3);
    }

    /**
     * creating the fourth ball
     */
    private void drawBall4() {
        double x = (getWidth() / 2.0 - CIRCLE_SIZE * 4);
        double y = (getHeight() / 2.0 - CIRCLE_SIZE * 4);
        ball4 = new GOval(x, y, CIRCLE_SIZE, CIRCLE_SIZE);
        ball4.setFilled(true);
        add(ball4);
    }

    /**
     * Creating the fifth ball
     */
    private void drawBall5() {
        double x = (getWidth() / 2.0 - CIRCLE_SIZE * 5);
        double y = (getHeight() / 2.0 - CIRCLE_SIZE * 4);
        ball5 = new GOval(x, y, CIRCLE_SIZE, CIRCLE_SIZE);
        ball5.setFilled(true);
        add(ball5);
    }


}