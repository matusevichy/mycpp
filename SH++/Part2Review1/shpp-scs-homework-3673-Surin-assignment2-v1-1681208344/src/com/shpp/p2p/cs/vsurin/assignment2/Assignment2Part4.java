/**
 * File: Assignment2Part4.java
 * ---------------------------
 * This program draws the flag of France.
 */

package com.shpp.p2p.cs.vsurin.assignment2;

import acm.graphics.GLabel;
import acm.graphics.GRect;
import com.shpp.cs.a.graphics.WindowProgram;

import java.awt.*;

public class Assignment2Part4 extends WindowProgram {
    /* Constants for the flag dimensions and colors */
    private static final double TRICOLOUR_WIDTH = 400;
    private static final double TRICOLOUR_HEIGHT = 250;
    private static final int FONT_SIZE = 20;
    private static final Color CARDINAL_RED = new Color(207, 8, 34);
    private static final Color CARDINAL_WHITE = new Color(255, 255, 255);
    private static final Color CARDINAL_BLUE = new Color(0, 33, 83);
    private static final int STRIPES_NUM = 3;
    private static final double STRIPE_MULTIPLIER = 1.5;
    /* Calculate the width of each stripe in the flag */
    private static final double STRIPES_GAP = TRICOLOUR_WIDTH / STRIPES_NUM;
    private static final double LABEL_OFFSET_X = 2;
    private static final double LABEL_OFFSET_Y = 2;


    public void run() {
        /* Calculate the x and y coordinates for the center of the window */
        double centerX = getWidth() / 2.0;
        double centerY = getHeight() / 2.0;

        addRectangle(centerX - STRIPES_GAP * STRIPE_MULTIPLIER, centerY - TRICOLOUR_HEIGHT / 2, STRIPES_GAP, TRICOLOUR_HEIGHT, CARDINAL_BLUE);
        addRectangle(centerX - STRIPES_GAP / 2, centerY - TRICOLOUR_HEIGHT / 2, STRIPES_GAP, TRICOLOUR_HEIGHT, CARDINAL_WHITE);
        addRectangle(centerX + STRIPES_GAP / 2, centerY - TRICOLOUR_HEIGHT / 2, STRIPES_GAP, TRICOLOUR_HEIGHT, CARDINAL_RED);
        addLabel("Flag of France", Color.BLACK);
    }

    /**
     * Adds a rectangle with the given dimensions and color to the canvas.
     *
     * @param x      The x coordinate of the upper-left corner of the rectangle.
     * @param y      The y coordinate of the upper-left corner of the rectangle.
     * @param width  The width of the rectangle.
     * @param height The height of the rectangle.
     * @param color  The color of the rectangle.
     */
    private void addRectangle(double x, double y, double width, double height, Color color) {
        GRect rect = new GRect(x, y, width, height);
        rect.setFilled(true);
        rect.setColor(color);
        add(rect);
    }

    /**
     * Adds a label with the given text and color to the lower right corner of the window.
     *
     * @param text  The text to display in the label.
     * @param color The color of the text.
     */
    private void addLabel(String text, Color color) {
        /* Create a new font with a plain style and size of 20 */
        Font font = new Font("Arial", Font.PLAIN, FONT_SIZE);
        GLabel label = new GLabel(text);
        label.setColor(color);
        label.setFont(font);

        /* Calculate the x and y coordinates of the label to position it in the lower right corner */
        double x = getWidth() - label.getWidth() - LABEL_OFFSET_X;
        double y = getHeight() - label.getHeight() + label.getHeight() - LABEL_OFFSET_Y;

        label.setLocation(x, y);
        add(label);
    }
}
