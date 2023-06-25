/**
 * File: Assignment2Part6.java
 * ---------------------------
 * Draws a caterpillar of circles in alternating order.
 */

package com.shpp.p2p.cs.vsurin.assignment2;

import acm.graphics.GOval;
import com.shpp.cs.a.graphics.WindowProgram;

import java.awt.*;

public class Assignment2Part6 extends WindowProgram {

    /* Constants for the number of circles, diameter, spacing, and colors */
    private static final double NUM_CIRCLES = 10;
    private static final double CIRCLE_DIAMETER = 150;
    private static final double CIRCLE_SPACING = CIRCLE_DIAMETER / 10;
    private static final Color CIRCLE_COLOR = new Color(0, 178, 0);
    private static final Color BORDER_COLOR = new Color(178, 15, 11);

    public void run() {
        double circleWidth = CIRCLE_DIAMETER;
        double circleHeight = CIRCLE_DIAMETER;

        /* Calculate the y coordinate for the center of the window */
        double centerY = getHeight() / 2.0;

        /* Iterate through the number of circles and draw them */
        for (int i = 0; i < NUM_CIRCLES; i++) {
            double spacing = i % 2 == 0 ? CIRCLE_SPACING : -CIRCLE_SPACING;
            addCircle(circleWidth / 2 * i, centerY - circleHeight / 2 + spacing, circleWidth, circleHeight);
        }
    }

    /**
     * Adds a circle to the window with the given properties.
     *
     * @param x The x coordinate of the upper-left corner of the circle.
     * @param y The y coordinate of the upper-left corner of the circle.
     * @param width The width of the circle.
     * @param height The height of the circle.
     */
    private void addCircle(double x, double y, double width, double height) {
        drawCircle(x, y, width, height, CIRCLE_COLOR, BORDER_COLOR);
    }

    /**
     * Draws a circle with the indicated properties.
     *
     * @param x The x coordinate of the upper-left corner of the circle.
     * @param y The y coordinate of the upper-left corner of the circle.
     * @param width The width of the circle.
     * @param height The height of the circle.
     * @param color The fill color of the circle.
     * @param border The border color of the circle.
     */
    private void drawCircle(double x, double y, double width, double height, Color color, Color border) {
        GOval circle = new GOval(x, y, width, height);
        circle.setFilled(true);
        circle.setFillColor(color);
        circle.setColor(border);
        add(circle);
    }
}
