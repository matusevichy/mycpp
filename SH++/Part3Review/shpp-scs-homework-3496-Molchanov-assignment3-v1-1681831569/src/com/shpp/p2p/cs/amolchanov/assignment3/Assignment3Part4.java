package com.shpp.p2p.cs.amolchanov.assignment3;

import acm.graphics.GRect;
import com.shpp.cs.a.graphics.WindowProgram;

import java.awt.*;

public class Assignment3Part4 extends WindowProgram {
    public static final int BRICK_HEIGHT = 15;
    public static final int BRICK_WIDTH = 40;
    public static final int BRICKS_IN_BASE = 20;

    //calculate the full width of the pyramid
    public static final int PYRAMID_WIDTH = BRICK_WIDTH * BRICKS_IN_BASE + (BRICKS_IN_BASE - 1);

    public void run() {
        drawPyramid();

    }

    /**
     * we build the pyramid, first we calculate the starting position by x then by y
     * And so we build post after post
     */
    private void drawPyramid() {
        for (int row = 0; row < BRICKS_IN_BASE; row++) {
            double x = (getWidth() - PYRAMID_WIDTH) / 2.0 + row * BRICK_WIDTH / 2.0;
            double y = getHeight() - (row + 1) * BRICK_HEIGHT;
            for (int cols = 0; cols < BRICKS_IN_BASE - row; cols++) {
                add(createRectangle(x + cols * BRICK_WIDTH, y));
            }
        }
    }

    /**
     * create a brick and specify its width and height
     * @param x start position on x coordinate
     * @param y start position on y coordinate
     * @return brick, for which you need to specify the coordinates
     */
    private GRect createRectangle(double x, double y) {
        GRect rect = new GRect(x, y, BRICK_WIDTH, BRICK_HEIGHT);
        rect.setFillColor(Color.cyan);
        rect.setFilled(true);
        rect.setColor(Color.BLACK);
        return rect;
    }
}
