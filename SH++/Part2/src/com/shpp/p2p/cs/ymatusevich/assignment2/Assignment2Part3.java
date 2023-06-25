package com.shpp.p2p.cs.ymatusevich.assignment2;

import acm.graphics.GOval;
import com.shpp.cs.a.graphics.WindowProgram;

/**
 * Draw pawprint on canvas with given parameters
 */
public class Assignment2Part3 extends WindowProgram {
    /* Constants controlling the relative positions of the
     * three toes to the upper-left corner of the pawprint.
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
     * create a window whose size is *approximately* given by these dimensions.
     */
    public static final int APPLICATION_WIDTH = 300;
    public static final int APPLICATION_HEIGHT = 270;

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
        drawToe(x+FIRST_TOE_OFFSET_X, y+FIRST_TOE_OFFSET_Y);
        drawToe(x+SECOND_TOE_OFFSET_X, y+SECOND_TOE_OFFSET_Y);
        drawToe(x+THIRD_TOE_OFFSET_X, y+THIRD_TOE_OFFSET_Y);
        drawHeel(x+HEEL_OFFSET_X, y+HEEL_OFFSET_Y);
    }

    /**
     * Drawing toe in start point with coordinates x and y
     * @param x - double value to x coordinate of start point
     * @param y - double value to y coordinate of start point
     */
    private void drawToe(double x, double y){
        var toe = new GOval(x, y, TOE_WIDTH, TOE_HEIGHT);
        toe.setFilled(true);
        add(toe);
    }

    /**
     * Drawing heel in start point with coordinates x and y
     * @param x - double value to x coordinate of start point
     * @param y - double value to y coordinate of start point
     */
    private void drawHeel(double x, double y){
        var heel = new GOval(x, y, HEEL_WIDTH, HEEL_HEIGHT);
        heel.setFilled(true);
        add(heel);
    }

}
