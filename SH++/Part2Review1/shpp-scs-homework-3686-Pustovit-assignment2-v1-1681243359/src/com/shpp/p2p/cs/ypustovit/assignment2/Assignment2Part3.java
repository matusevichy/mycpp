package com.shpp.p2p.cs.ypustovit.assignment2;

import acm.graphics.GOval;
import com.shpp.cs.a.graphics.WindowProgram;

import java.awt.*;

public class Assignment2Part3 extends WindowProgram {
    /* Draws two pawprints uses method drawPawprint,
     * which takes x and y coordinates as parameters.
     * These coordinates correct default position of each
     * paw element, that regulates by corresponding constants.
     * Also, I add method drawOval to reduce amount of code in
     * method drawPawprint.
     */

    /* Constants controlling the relative positions of the
     * three toes to the upper-left corner of the pawprint.
     *
     * (Yes, I know that actual pawprints have four toes.
     * Just pretend it's a cartoon animal. ^_^)
     */
    private static final double FIRST_TOE_OFFSET_X = 0;
    private static final double FIRST_TOE_OFFSET_Y = 20;
    private static final double SECOND_TOE_OFFSET_X = 30;
    private static final double SECOND_TOE_OFFSET_Y = 0;
    private static final double THIRD_TOE_OFFSET_X = 60;
    private static final double THIRD_TOE_OFFSET_Y = 20;

    /* The position of the heel relative to the upper-left
     * corner of the pawprint.
     */
    private static final double HEEL_OFFSET_X = 20;
    private static final double HEEL_OFFSET_Y = 40;

    /* Each toe is an oval with this width and height. */
    private static final double TOE_WIDTH = 20;
    private static final double TOE_HEIGHT = 30;

    /* The heel is an oval with this width and height. */
    private static final double HEEL_WIDTH = 40;
    private static final double HEEL_HEIGHT = 60;

    /* The default width and height of the window. These constants will tell Java to
     * create a window whose size is *approximately* given by these dimensions. You should
     * not directly use these constants in your program; instead, use getWidth() and
     * getHeight(), which return the *exact* width and height of the window.
     */
    public static final int APPLICATION_WIDTH = 100;
    public static final int APPLICATION_HEIGHT = 300;

    public void run() {
        drawPawprint(20, 20);
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
        drawOval(FIRST_TOE_OFFSET_X + x, FIRST_TOE_OFFSET_Y + y, TOE_WIDTH, TOE_HEIGHT, Color.BLACK);
        drawOval(SECOND_TOE_OFFSET_X + x, SECOND_TOE_OFFSET_Y + y, TOE_WIDTH, TOE_HEIGHT, Color.BLACK);
        drawOval(THIRD_TOE_OFFSET_X + x, THIRD_TOE_OFFSET_Y + y, TOE_WIDTH, TOE_HEIGHT, Color.BLACK);
        drawOval(HEEL_OFFSET_X + x, HEEL_OFFSET_Y + y, HEEL_WIDTH, HEEL_HEIGHT, Color.BLACK);
    }

    /**
     * Draws an oval with given x and y coordinate, width, height and color of the oval.
     * The coordinates specify the upper-left corner of the bounding box containing that oval.
     *
     * @param x      The x coordinate of the upper-left corner of the bounding box for the oval.
     * @param y      The y coordinate of the upper-left corner of the bounding box for the oval.
     * @param width  The width of the oval.
     * @param height The height of the oval.
     * @param color  The color of the oval.
     */
    private void drawOval(double x, double y, double width, double height, Color color) {
        GOval circle = new GOval(x, y, width, height);
        circle.setFilled(true);
        circle.setColor(color);
        add(circle);
    }

}
