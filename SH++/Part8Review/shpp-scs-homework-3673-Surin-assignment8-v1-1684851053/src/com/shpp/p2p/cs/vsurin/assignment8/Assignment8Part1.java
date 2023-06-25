/*
 * File: Assignment8Part1.java
 * ---------------------
 * This program simulates bouncing balls that appear on the screen when the mouse button is pressed.
 * The size and color of the balls depend on how long the mouse button is held down.
 * The balls fall down due to gravity and bounce off the floor with an elastic collision.
 */

package com.shpp.p2p.cs.vsurin.assignment8;

import com.shpp.cs.a.graphics.WindowProgram;
import acm.graphics.GOval;

import java.awt.*;
import java.awt.event.MouseEvent;
import java.util.ArrayList;
import java.util.List;

public class Assignment8Part1 extends WindowProgram {
    /* The amount of time to pause between frames (48fps). */
    private static final double PAUSE_TIME = 1000.0 / 48;

    /* The initial horizontal velocity of the ball. */
    private static final double HORIZONTAL_VELOCITY = 1.0;

    /* Gravitational acceleration. */
    private static final double GRAVITY = 0.425;

    /* Elasticity. */
    private static final double ELASTICITY = 0.75;

    private List<GOval> balls;
    private List<Thread> ballThreads;
    private long mousePressTime;

    public void run() {
        balls = new ArrayList<>();
        ballThreads = new ArrayList<>();
        addMouseListeners();
    }

    /**
     * Called when the mouse button is pressed.
     * Creates a new ball at the mouse coordinates, adds it to the screen, and starts a new thread to make it fall.
     *
     * @param e The MouseEvent object containing information about the mouse event.
     */
    public void mousePressed(MouseEvent e) {
        // Record the time when the mouse button is pressed
        mousePressTime = System.currentTimeMillis();

        // Create a new ball at the mouse coordinates
        GOval ball = createBall(e.getX(), e.getY());

        // Add the ball to the list of balls and to the screen
        balls.add(ball);
        add(ball);
    }

    /**
     * Called when the mouse button is released.
     * Adjusts the size and color of the last added ball based on the duration the mouse button was held down.
     *
     * @param e The MouseEvent object containing information about the mouse event.
     */
    public void mouseReleased(MouseEvent e) {
        // Record the time when the mouse button is released
        long mouseReleaseTime = System.currentTimeMillis();

        // Calculate the duration the mouse button was held down
        long mouseHoldDuration = mouseReleaseTime - mousePressTime;

        // Calculate the size and color of the ball based on the hold duration
        double ballSize = calculateBallSize(mouseHoldDuration);
        Color ballColor = calculateBallColor(mouseHoldDuration);

        // Set the size and color of the last added ball
        balls.get(balls.size() - 1).setSize(ballSize, ballSize);
        balls.get(balls.size() - 1).setColor(ballColor);

        // Start a new thread to make the ball fall
        startBallThread(balls.get(balls.size() - 1));
    }

    /**
     * Creates a ball at the specified coordinates.
     *
     * @param x The x-coordinate of the ball.
     * @param y The y-coordinate of the ball.
     * @return A GOval object representing the ball.
     */
    private GOval createBall(double x, double y) {
        GOval ball = new GOval(x, y, 0, 0);
        ball.setFilled(true);
        return ball;
    }

    /**
     * Starts a new thread to continuously update the position of the ball.
     */
    private void startBallThread(GOval ball) {
        Thread thread = new Thread(new Runnable() {
            public void run() {
                double dy = 0;
                while (true) {
                    ball.move(HORIZONTAL_VELOCITY, dy);
                    dy += GRAVITY;

                    if (ballBelowFloor(ball) && dy > 0) {
                        dy *= -ELASTICITY;
                    }

                    pause(PAUSE_TIME);
                }
            }
        });
        ballThreads.add(thread);
        thread.start();
    }

    /**
     * Determines whether the ball has dropped below the floor level.
     *
     * @param ball The ball to test.
     * @return Whether it has fallen below the floor.
     */
    private boolean ballBelowFloor(GOval ball) {
        return ball.getY() + ball.getHeight() >= getHeight();
    }

    /**
     * Calculates the size of the ball based on the mouse hold duration.
     *
     * @param mouseHoldDuration The duration in milliseconds.
     * @return The size of the ball.
     */
    private double calculateBallSize(long mouseHoldDuration) {
        // Adjust these values according to your desired size range
        double minSize = 10.0;
        double maxSize = 100.0;

        // Calculate the size based on the duration
        double sizeRange = maxSize - minSize;
        double normalizedDuration = Math.min(mouseHoldDuration, 1000) / 1000.0; // Limit the duration to 1 second
        return minSize + (sizeRange * normalizedDuration);
    }

    /**
     * Calculates the color of the ball based on the mouse hold duration.
     *
     * @param mouseHoldDuration The duration in milliseconds.
     * @return The color of the ball.
     */
    private Color calculateBallColor(long mouseHoldDuration) {
        // Adjust these values according to your desired color range
        int minColor = 255; // White
        int maxColor = 0; // Black

        // Calculate the color based on the duration
        int colorRange = maxColor - minColor;
        double normalizedDuration = Math.min(mouseHoldDuration, 1000) / 1000.0; // Limit the duration to 1 second
        int colorValue = minColor + (int) (colorRange * normalizedDuration);
        return new Color(colorValue, colorValue, colorValue);
    }
}
