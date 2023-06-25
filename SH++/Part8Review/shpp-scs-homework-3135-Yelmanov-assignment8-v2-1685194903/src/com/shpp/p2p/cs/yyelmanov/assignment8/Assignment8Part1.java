package com.shpp.p2p.cs.yyelmanov.assignment8;

import acm.graphics.GObject;
import acm.graphics.GOval;
import com.shpp.cs.a.graphics.WindowProgram;

import java.awt.*;
import java.awt.event.MouseEvent;
import java.util.ArrayList;

public class Assignment8Part1 extends WindowProgram {
    /**
     * For time smoothing
     */
    final int TIME_SMOOTHING = 7;
    /**
     * Maximum palette value
     */
    final int maxColorPalette = 255;
    /**
     * Animation time
     */
    final double PAUSE_TIME = 1000.0 / 33;
    /**
     * Ball acceleration
     */
    final double speedUp = 0.5;
    /**
     * Elasticity for a rebound
     */
    final double speedElasticity = 0.6;
    /**
     * Click start time
     */
    double startTime = 0;
    /**
     * Mouse click time
     */
    int differenceTime = 0;
    /**
     * Ball storage array
     */
    ArrayList<GOval> arrayBall = new ArrayList<GOval>();
    /**
     * Gravity for each ball
     */
    ArrayList<Double> arrayGravity = new ArrayList<Double>();
    /**
     * Was there a click on the ball. if yes-true;
     */
    ArrayList<Boolean> clickBall = new ArrayList<>();

    /**
     * check if there was a click on one of the balls,
     * if yes: then pass the value true to the specified cell of the array
     *
     * @param me the event to be processed
     */
    public void mouseClicked(MouseEvent me) {
        GObject clickObject = getElementAt(me.getX(), me.getY());
        for (int i = 0; i < arrayBall.size(); i++) {
            if (clickObject == arrayBall.get(i)) {
                clickBall.set(i, true);
            }
        }
    }

    /**
     * Record the time in startTime when you click on the mouse
     *
     * @param me the event to be processed
     */
    public void mousePressed(MouseEvent me) {
        startTime = System.currentTimeMillis();
    }

    /**
     * When you release the mouse key
     *
     * @param me the event to be processed
     */
    public void mouseReleased(MouseEvent me) {
        GObject clickObject = getElementAt(me.getX(), me.getY());
        if (clickObject == null) {
            //Click time
            differenceTime = (int) (System.currentTimeMillis() - startTime) / TIME_SMOOTHING;
            //color determination of the ball
            Color color = new Color(0, 0, 0);
            int nextPalette = maxColorPalette - differenceTime;
            if (nextPalette >= 0) {
                color = new Color(nextPalette, nextPalette, nextPalette);
            }
            //Ball Making
            GOval ball = new GOval(me.getX(), me.getY(), differenceTime, differenceTime);
            ball.setFilled(true);
            ball.setColor(color);
            add(ball);
            //Fill in the ball data arrays (object, whether a click was made, fall acceleration)
            arrayBall.add(ball);
            clickBall.add(false);
            arrayGravity.add(0.0);
        }

    }

    /**
     * Start a program to create and bounce balls
     */
    public void run() {
        addMouseListeners();
        moveBalls();
    }

    /**
     * implementation of the movement of balls that are in the array
     */
    private void moveBalls() {
        while (true) {
            for (int i = 0; i < arrayBall.size(); i++) {
                GObject ball = arrayBall.get(i);
                double dropGravity = clickBall.get(i) ? -speedUp : speedUp;
                double ELASTICITY = clickBall.get(i) ? speedElasticity : -speedElasticity;
                double dy = arrayGravity.get(i);
                //ball movement
                ball.move(0, dy);
                arrayGravity.set(i, dy + dropGravity);
                //bounce ball the bottom
                if (ballBellow(ball, dy)) {
                    arrayGravity.set(i, arrayGravity.get(i) * (ELASTICITY));
                }
                //Rebound from the ceiling
                if (ballUnderCeiling(ball, dy)) {
                    arrayGravity.set(i, arrayGravity.get(i) * (-ELASTICITY));
                }
            }
            pause(PAUSE_TIME);
        }
    }

    /**
     * @param ball chosen ball
     * @param dy   acceleration on y
     * @return true if the ball is above the ceiling and its acceleration is minus
     */
    private boolean ballUnderCeiling(GObject ball, double dy) {
        return ball.getY() <= 0 && dy < 0;
    }

    /**
     * @param ball chosen ball
     * @param dy   y bias speed
     * @return true if the ball is lower than the ticking window and its acceleration is positive
     */
    private boolean ballBellow(GObject ball, double dy) {
        return ball.getY() + ball.getHeight() >= getHeight() && dy > 0;
    }
}


