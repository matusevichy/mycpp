package com.shpp.p2p.cs.ymatusevich.assignment2;

import acm.graphics.GRect;
import com.shpp.cs.a.graphics.WindowProgram;

import java.awt.*;

/**
 * Drawing matrix with black boxes on center of canvas
 */
public class Assignment2Part5 extends WindowProgram {
    /* The number of rows and columns in the grid, respectively. */
    private static final int NUM_ROWS = 5;
    private static final int NUM_COLS = 6;

    /* The width and height of each box. */
    private static final double BOX_SIZE = 40;

    /* The horizontal and vertical spacing between the boxes. */
    private static final double BOX_SPACING = 10;

    /* The default width and height of the window. These constants will tell Java to
     * create a window whose size is *approximately* given by these dimensions.
     */
    public static final int APPLICATION_WIDTH = 450;
    public static final int APPLICATION_HEIGHT = 350;

    @Override
    public void run() {
        //Define start point coordinates (x and y) for drawing matrix using current window size
        int x = (int)(getWidth() - ((BOX_SIZE * NUM_COLS)+((NUM_COLS -1)*BOX_SPACING)))/2;
        int y = (int)(getHeight() - ((BOX_SIZE * NUM_ROWS)+((NUM_ROWS -1)*BOX_SPACING)))/2;
        drawMatrix(x,y);
    }

    /**
     * Drawing matrix with boxes in start point with coordinates x and y
     * @param x - integer value to x coordinate of start point
     * @param y - integer value to y coordinate of start point
     */
    private void drawMatrix(int x, int y){
        int currentY = y;
        for (int i=0; i<NUM_ROWS; i++){
            int currentX = x;
            for (int j=0; j<NUM_COLS; j++){
                drawBox(currentX,currentY);
                currentX+=BOX_SIZE+BOX_SPACING;
            }
            currentY+=BOX_SIZE+BOX_SPACING;
        }
    }

    /**
     * Drawing black box in start point with coordinates x and y
     * @param x - integer value to x coordinate of start point
     * @param y - integer value to y coordinate of start point
     */
    private void drawBox(int x, int y){
        var box = new GRect(x, y, BOX_SIZE, BOX_SIZE);
        box.setFilled(true);
        box.setFillColor(Color.black);
        add(box);
    }
}
