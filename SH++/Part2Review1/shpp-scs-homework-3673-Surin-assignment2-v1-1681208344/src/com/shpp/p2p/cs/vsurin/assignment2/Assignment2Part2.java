/**
 * File: Assignment2Part2.java
 * --------------------------------
 * This program draws a white rectangle in the center of the window
 * and four black circles at each corner of the window.
 */

package com.shpp.p2p.cs.vsurin.assignment2;

import acm.graphics.GOval;
import acm.graphics.GRect;
import com.shpp.cs.a.graphics.WindowProgram;

import java.awt.Color;

public class Assignment2Part2 extends WindowProgram {

    /* The width of the window */
    public static final int APPLICATION_WIDTH = 400;

    /* The height of the window */
    public static final int APPLICATION_HEIGHT = 300;

    /* The ratio of the circle size to the window size */
    public static final double CIRCLE_SIZE_RATIO = 3;

    /* The ratio of the rectangle width to the window width */
    public static final double RECTANGLE_WIDTH_RATIO = 1.4;

    /* The ratio of the rectangle height to the window height */
    public static final double RECTANGLE_HEIGHT_RATIO = 1.5;

    /* The color of the circles */
    public static final Color CIRCLE_COLOR = Color.BLACK;

    /* The color of the rectangle */
    public static final Color RECTANGLE_COLOR = Color.WHITE;

    /**
     * The entry point for the program. This method sets up the canvas and calls
     * the methods to draw the circles and rectangle.
     */
    public void run() {
        /* Calculate the x and y coordinates for the center of the window */
        double centerX = getWidth() / 2.0;
        double centerY = getHeight() / 2.0;

        /* Calculate the size of the circles */
        double minWindowSize = Math.min(getWidth(), getHeight());
        double circleSize = minWindowSize / CIRCLE_SIZE_RATIO;

        /* Calculate the size of the rectangle */
        double rectangleWidth = getWidth() / RECTANGLE_WIDTH_RATIO;
        double rectangleHeight = getHeight() / RECTANGLE_HEIGHT_RATIO;

        addCircle(0, 0, circleSize);
        addCircle(getWidth() - circleSize, 0, circleSize);
        addCircle(0, getHeight() - circleSize, circleSize);
        addCircle(getWidth() - circleSize, getHeight() - circleSize, circleSize);

        addRectangle(centerX - rectangleWidth / 2, centerY - rectangleHeight / 2, rectangleWidth, rectangleHeight);
    }

    /**
     * Adds a circle to the canvas at the specified coordinates and size.
     *
     * @param x          the x-coordinate of the circle
     * @param y          the y-coordinate of the circle
     * @param circleSize the size of the circle
     */
    private void addCircle(double x, double y, double circleSize) {
        drawCircle(x, y, circleSize, CIRCLE_COLOR);
    }

    /**
     * Draws a circle with the specified coordinates, size, and color.
     *
     * @param x          the x-coordinate of the circle
     * @param y          the y-coordinate of the circle
     * @param circleSize the size of the circle
     * @param color      the color of the circle
     */
    private void drawCircle(double x, double y, double circleSize, Color color) {
        GOval circle = new GOval(x, y, circleSize, circleSize);
        circle.setFilled(true);
        circle.setColor(color);
        add(circle);
    }

    /**
     * Adds a rectangle to the canvas at the specified coordinates, width, and height
     * with the given color.
     *
     * @param x      The x-coordinate of the upper left corner of the rectangle.
     * @param y      The y-coordinate of the upper left corner of the rectangle.
     * @param width  The width of the rectangle.
     * @param height The height of the rectangle.
     */
    private void addRectangle(double x, double y, double width, double height) {
        drawRectangle(x, y, width, height, RECTANGLE_COLOR);
    }

    /**
     * Adds a rectangle to the canvas at the specified coordinates, width, and height
     * with the specified color.
     *
     * @param x      The x-coordinate of the upper-left corner of the rectangle.
     * @param y      The y-coordinate of the upper-left corner of the rectangle.
     * @param width  The width of the rectangle.
     * @param height The height of the rectangle.
     * @param color  The color of the rectangle.
     */
    private void drawRectangle(double x, double y, double width, double height, Color color) {
        GRect rectangle = new GRect(x, y, width, height);
        rectangle.setFilled(true);
        rectangle.setColor(color);
        add(rectangle);
    }
}
