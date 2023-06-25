package com.shpp.p2p.cs.ymatusevich.assignment3;

import acm.graphics.GRect;
import com.shpp.cs.a.graphics.WindowProgram;

import java.awt.*;

//This program draws the pyramid with the given parameters at the bottom of the window
public class Assignment3Part4 extends WindowProgram {
    //Bricks size
    private static final int BRICK_HEIGHT = 10;
    private static final int BRICK_WIDTH = 20;

    //The count of the bricks in the base of pyramid
    private static final int BRICKS_IN_BASE = 20;

    //Bricks color (fill and border)
    private static final Color BRICK_FILL_COLOR = Color.ORANGE;
    private static final Color BRICK_BORDER_COLOR = Color.BLACK;

    /* The default width and height of the window. These constants will tell Java to
     * create a window whose size is *approximately* given by these dimensions.
     */
    public static final int APPLICATION_WIDTH = 470;
    public static final int APPLICATION_HEIGHT = 320;

    @Override
    public void run() {
        resizeWindow();
        //Calculate drawing start point coordinates
        int x = (getWidth() - BRICK_WIDTH * BRICKS_IN_BASE) / 2;
        if (x < 0) x = 0;
        int y = getHeight() - BRICK_HEIGHT;
        buildPyramid(x, y, BRICKS_IN_BASE);
    }

    /**
     * Resizing the window to fit pyramid if the pyramid biggest the window
     */
    private void resizeWindow() {
        int pyramidHeight = BRICK_HEIGHT * BRICKS_IN_BASE;
        int pyramidWidth = BRICK_WIDTH * BRICKS_IN_BASE;
        System.out.println(pyramidWidth);
        if (getHeight() < pyramidHeight || getWidth() < pyramidWidth) setSize(pyramidWidth+20, pyramidHeight+40);
    }

    /**
     * Recursive drawing the lines of the pyramid with given parameters
     *
     * @param x           - integer value of the x coordinate of drawing start point
     * @param y           - integer value of the y coordinate of drawing start point
     * @param bricksCount - count of bricks in drawing line
     */
    private void buildPyramid(int x, int y, int bricksCount) {
        int currentX = x;
        for (int i = 0; i < bricksCount; i++) {
            drawBrick(currentX, y);
            currentX += BRICK_WIDTH;
        }
        if (bricksCount > 1) buildPyramid(x + BRICK_WIDTH / 2, y - BRICK_HEIGHT, bricksCount - 1);
    }

    /**
     * Drawing brick with given parameters
     *
     * @param x - integer value of the x coordinate of drawing start point
     * @param y - integer value of the y coordinate of drawing start point
     */
    private void drawBrick(int x, int y) {
        var rect = new GRect(x, y, BRICK_WIDTH, BRICK_HEIGHT);
        rect.setFillColor(BRICK_FILL_COLOR);
        rect.setFilled(true);
        rect.setColor(BRICK_BORDER_COLOR);
        add(rect);
    }
}
