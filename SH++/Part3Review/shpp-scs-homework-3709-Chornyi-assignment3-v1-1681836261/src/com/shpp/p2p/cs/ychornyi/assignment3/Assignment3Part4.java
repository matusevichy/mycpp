package com.shpp.p2p.cs.ychornyi.assignment3;

import acm.graphics.GRect;
import com.shpp.cs.a.graphics.WindowProgram;

import java.awt.*;

/**
 * added the constants as stated in the condition
 * for size of bricks and the number of the bricks in the base
 */
public class Assignment3Part4 extends WindowProgram {
    public static final int  BRICK_HEIGHT = 15;
    public static final int BRICK_WIDTH = 40;
    public static final int BRICKS_IN_BASE = 10;

    /**
     * create a pyramid with one brick less in next row
     */
      public void run() {
          createAPyramid();
          }

    /**
     * create like a matrix of our bricks with one brick less in a next row
     * and with a small offset
     */
    public void createAPyramid() {
          /* calculate pyramid width */
        int pyramidWidth = BRICKS_IN_BASE * BRICK_WIDTH;
        /* make count how many rows we need*/
        for (int i = 0; i < BRICKS_IN_BASE; i++) {
            /* calculate how many bricks in a row */
            int bricksInRow = BRICKS_IN_BASE - i;
            /* calculate a width of a row */
            int rowWidth = bricksInRow * BRICK_WIDTH;
            /* calculate a first x position of brick in a row */
            int rowX = (pyramidWidth - rowWidth) / 2;
            /* calculate a first y position of brick in a row */
            int rowY = getHeight() - (i + 1) * BRICK_HEIGHT;
            /* make a row with number of bricks what we calculate before */
            for (int j = 0; j < bricksInRow; j++) {
                /* position our pyramid in the bottom of the window and a half of width our window */
                GRect brick = new GRect(rowX + j * (BRICK_WIDTH) + getWidth()/2 - pyramidWidth / 2,
                        (rowY + BRICK_HEIGHT), BRICK_WIDTH, BRICK_HEIGHT);
                brick.setFilled(true);
                brick.setColor(Color.ORANGE);
                add(brick);
            }
        }
    }
}
