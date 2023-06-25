package com.shpp.p2p.cs.vostapchuk.assignment2;

import acm.graphics.GRect;
import com.shpp.cs.a.graphics.WindowProgram;

import java.awt.*;

/* TODO:This class draw a matrix of black boxes separated by "streets".*/

public class Assignment2Part5 extends WindowProgram {
    // Set the size of the window
    public static final int APPLICATION_WIDTH = 340;
    public static final int APPLICATION_HEIGHT = 350;
    /* The number of rows and columns in the grid, respectively. */
    private static final int NUM_ROWS = 5;
    private static final int NUM_COLS = 6;

    /* The width and height of each box. */
    private static final int BOX_SIZE = 40;
    /* The horizontal and vertical spacing between the boxes. */
    private static final int BOX_SPACING = 10;

    private void matrixSquarte() {
        // Calculate the total width and height of the matrix
        int totalWidth = NUM_COLS * (BOX_SIZE + BOX_SPACING);
        int totalHeight = NUM_ROWS * (BOX_SIZE + BOX_SPACING);

        // Calculate the horizontal and vertical spacing for the "streets"
        int horizontalSpacing = (getWidth() - totalWidth) / 2;
        int verticalSpacing = (getHeight() - totalHeight) / 2;

        // Draw the boxes and streets
        for (int row = 0; row < NUM_ROWS; row++) {
            for (int col = 0; col < NUM_COLS; col++) {
                int x = horizontalSpacing + col * (BOX_SIZE + BOX_SPACING);
                int y = verticalSpacing + row * (BOX_SIZE + BOX_SPACING);
                //Draw the boxes
                GRect square = new GRect(x, y, BOX_SIZE, BOX_SIZE);
                square.setFilled(true);
                square.setFillColor(Color.BLACK);
                add(square);
            }
        }
    }

    public void run() {
        matrixSquarte();
    }
}
