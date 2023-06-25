/**
 * File: Assignment2Part3.java
 * --------------------------------
 * This class represents a program that draws a pawprint using ovals. It extends the
 * WindowProgram class and contains the run method as the entry point for the program.
 */

package com.shpp.p2p.cs.vsurin.assignment2;

import acm.graphics.GOval;
import com.shpp.cs.a.graphics.WindowProgram;

import java.awt.*;

public class Assignment2Part3 extends WindowProgram {
    /**
     * Constants controlling the relative positions of the
     * three toes to the upper-left corner of the pawprint.
     */
    private static final double FIRST_TOE_OFFSET_X = 0;
    private static final double FIRST_TOE_OFFSET_Y = 20;
    private static final double SECOND_TOE_OFFSET_X = 30;
    private static final double SECOND_TOE_OFFSET_Y = 0;
    private static final double THIRD_TOE_OFFSET_X = 60;
    private static final double THIRD_TOE_OFFSET_Y = 20;

    /**
     * The position of the heel relative to the upper-left
     * corner of the pawprint.
     */
    private static final double HEEL_OFFSET_X = 20;
    private static final double HEEL_OFFSET_Y = 40;

    /**
     * Each toe is an oval with this width and height.
     */
    private static final double TOE_WIDTH = 20;
    private static final double TOE_HEIGHT = 30;

    /**
     * The heel is an oval with this width and height.
     */
    private static final double HEEL_WIDTH = 40;
    private static final double HEEL_HEIGHT = 60;

    /**
     * The default width and height of the window.
     */
    public static final int APPLICATION_WIDTH = 270;
    public static final int APPLICATION_HEIGHT = 220;

    public void run() {
        drawPawprint(HEEL_OFFSET_X, HEEL_OFFSET_Y);
        drawPawprint(180, 70);
    }

    /**
     * Draws a pawprint. The parameters should specify the upper-left corner of the
     * bounding box containing that pawprint.
     *
     * @param x The x coordinate of the upper-left corner of the bounding box for the pawprint.
     * @param y The y coordinate of the upper-left corner of the bounding box for the pawprint.
     */
    private void drawPawprint(double x, double y) {
        addCircle(x + HEEL_WIDTH / 2, y + HEEL_HEIGHT / 2, HEEL_WIDTH, HEEL_HEIGHT);
        addCircle(FIRST_TOE_OFFSET_X + x, (FIRST_TOE_OFFSET_Y + y) - TOE_HEIGHT / 2, TOE_WIDTH, TOE_HEIGHT);
        addCircle(SECOND_TOE_OFFSET_X + x, (SECOND_TOE_OFFSET_Y + y) - TOE_HEIGHT / 2, TOE_WIDTH, TOE_HEIGHT);
        addCircle(THIRD_TOE_OFFSET_X + x, (THIRD_TOE_OFFSET_Y + y) - TOE_HEIGHT / 2, TOE_WIDTH, TOE_HEIGHT);
    }

    private void addCircle(double x, double y, double width, double height) {
        drawCircle(x, y, width, height, Color.BLACK);
    }

    /**
     * Draws a circle with the indicated properties.
     *
     * @param x The x coordinate of the upper-left corner of the rectangle.
     * @param y The y coordinate of the upper-left corner of the rectangle.
     * @param width The width of the rectangle.
     * @param height The height of the rectangle.
     * @param color The color to use for the rectangle.
     */
    private void drawCircle(double x, double y, double width, double height, Color color) {
        GOval rect = new GOval(x, y, width, height);
        rect.setFilled(true);
        rect.setColor(color);
        add(rect);
    }
}
