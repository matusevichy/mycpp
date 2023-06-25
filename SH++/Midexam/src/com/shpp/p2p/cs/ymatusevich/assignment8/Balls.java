package com.shpp.p2p.cs.ymatusevich.assignment8;

import com.shpp.cs.a.graphics.WindowProgram;

import java.awt.*;
import java.awt.event.MouseEvent;
import java.util.ArrayList;

import static java.lang.System.currentTimeMillis;

//The program allows you to create balls when you click the mouse button.
//The longer the press, the larger the ball and the darker the color
//Balls move to bottom and bounce
//The click on the ball reverse moving ball from bottom to top and bounce to
public class Balls extends WindowProgram {
    private final double MAX_BALL_SIZE = 255.0;
    //Local variable for saving time of the click on the mouse button
    long startTime;
    //Array of the created balls
    ArrayList<Ball> balls = new ArrayList<>();

    @Override
    public void run() {
        addMouseListeners();
        moveBalls();
    }

    public void mousePressed(MouseEvent event) {
        startTime = currentTimeMillis();
    }

    public void mouseReleased(MouseEvent event) {
        long time = currentTimeMillis() - startTime;
        if (time > 100) makeBall(time, event.getX(), event.getY());
    }

    public void mouseClicked(MouseEvent event) {
        //Get the object in the mouse clicked point
        var object = (Ball) getElementAt(event.getX(), event.getY());
        //If object exist set property for reverse move
        if (object != null && object.isToBottom()) {
            object.setToBottom(false);
            object.setVy(-object.getVy());
        }
    }

    /**
     * Makes new ball in the window and save to balls array
     * @param time - time of pressed mouse button for calculate ball size and color
     * @param x - x coordinate for drawing ball
     * @param y - y coordinate for drawing ball
     */
    private void makeBall(long time, double x, double y) {
        double diameter = (time / 10.0 < MAX_BALL_SIZE) ? time / 10 : MAX_BALL_SIZE;
        int colorVal = (int) (255/diameter * 10);
        Color color = new Color(colorVal, colorVal, colorVal, 255);
        var ball = new Ball(x, y, diameter, diameter, color);
        add(ball);
        balls.add(ball);
    }

    /**
     * Moves all balls in the loop
     */
    private void moveBalls() {
        while (true) {
            for (Ball ball : balls) {
                if (ball.isToBottom()) moveToBottom(ball);
                else moveToTop(ball);
            }
            pause(30);
        }
    }

    /**
     * Move ball from top to bottom
     * @param ball - ball for moving
     */
    private void moveToBottom(Ball ball) {
        //Ball on bottom of the window?
        boolean isOnBottom = (ball.getY() + ball.getDiameter()) >= getHeight();
        //If ball on bottom of the window reverse speed on the Y axis
        if (isOnBottom && ball.getVy() != 0) {
            ball.setVy(-ball.getVy());
            ball.setCurrentVy(ball.getVy());
        }
        //Moves ball
        if (ball.getVy() < 0 && ball.getCurrentVy() <= 0) {
            ball.setCurrentVy(ball.getCurrentVy() + ball.getGravity());
            ball.move(0, ball.getCurrentVy());
        } else if (ball.getVy() < 0 && ball.getCurrentVy() >= 0) {
            ball.setVy(-ball.getVy());
            ball.setCurrentVy(ball.getVy());
            ball.setGravity(ball.getGravity() * 2);
        } else if (!isOnBottom && !(ball.getGravity() >= ball.getVy())) ball.move(0, ball.getVy());
    }

    /**
     * Move ball from bottom to top if mouse clicked on ball
     * @param ball - ball for moving
     */

    private void moveToTop(Ball ball) {
        //Ball on top of the window?
        boolean isOnTop = ball.getY() <= 0;
        //If ball on top of the window reverse speed on the Y axis
        if (isOnTop && ball.getVy() != 0) {
            ball.setVy(-ball.getVy());
            ball.setCurrentVy(ball.getVy());
        }
        //Moves ball
        if (ball.getVy() > 0 && ball.getCurrentVy() >= 0) {
            ball.setCurrentVy(ball.getCurrentVy() - ball.getGravity());
            ball.move(0, ball.getCurrentVy());
        } else if (ball.getVy() > 0 && ball.getCurrentVy() <= 0) {
            ball.setVy(-ball.getVy());
            ball.setCurrentVy(ball.getVy());
            ball.setGravity(ball.getGravity() * 2);
        } else if (!isOnTop && !(ball.getGravity() >= Math.abs(ball.getVy()))) ball.move(0, ball.getVy());
    }

}
