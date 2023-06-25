package com.shpp.p2p.cs.ypustovit.assignment2;


import acm.graphics.GRect;
import com.shpp.cs.a.graphics.WindowProgram;

import java.awt.*;


public class Assignment2Part5 extends WindowProgram {

    //These constants are needed to regulate application width and height.
    public static final int APPLICATION_WIDTH = 400;
    public static final int APPLICATION_HEIGHT = 400;

    /* The number of rows and columns in the grid, respectively. */
    private static final int NUM_ROWS = 6;
    private static final int NUM_COLS = 7;

    /* The width and height of each box. */
    private static final double BOX_SIZE = 40;

    /* The horizontal and vertical spacing between the boxes. */
    private static final double BOX_SPACING = 3;

    /*
     * Draws illusion with black boxes from left to right in the center,
     * specified with number of rows and columns, size of boxes and spacing
     * between them.
     */
    public void run() {
        //Calculates width and height of the box that contains illusion.
        double illusionWidth = BOX_SIZE * NUM_COLS + BOX_SPACING * (NUM_COLS - 1);
        double illusionHeight = BOX_SIZE * NUM_ROWS + BOX_SPACING * (NUM_ROWS - 1);
        //Calculates starting coordinates using previous variables.
        double xStart = getWidth() / 2.0 - illusionWidth / 2.0;
        double yStart = getHeight() / 2.0 - illusionHeight / 2.0;
        drawIllusion(xStart, yStart, NUM_ROWS, NUM_COLS);
    }


    /**
     * Draws a square with given x and y coordinate, size and color.
     * The coordinates specify the upper-left corner of the square.
     *
     * @param x     The x coordinate of the upper-left corner of the square.
     * @param y     The y coordinate of the upper-left corner of the square.
     * @param size  The width and height of the square.
     * @param color The color of the square.
     */
    private void drawSquare(double x, double y, double size, Color color) {
        GRect rect = new GRect(x, y, size, size);
        rect.setFilled(true);
        rect.setFillColor(color);
        rect.setColor(Color.WHITE);
        add(rect);
    }

    /**
     * Draws illusion with black boxes from left to right in the center.
     *
     * @param xStart  The x-coordinate of the upper left corner of the box containing the illusion.
     * @param yStart  The y-coordinate of the upper left corner of the box containing the illusion.
     * @param numRows The number of rows of the illusion.
     * @param numCols The number of columns of the illusion.
     */
    private void drawIllusion(double xStart, double yStart, int numRows, int numCols) {
        for (int i = 0; i < numRows; i++) {
            for (int j = 0; j < numCols; j++) {
                //Draws one square of the illusion.
                drawSquare(xStart + (BOX_SIZE + BOX_SPACING) * j,
                        yStart + (BOX_SIZE + BOX_SPACING) * i, BOX_SIZE, Color.BLACK);
            }
        }
    }

}
