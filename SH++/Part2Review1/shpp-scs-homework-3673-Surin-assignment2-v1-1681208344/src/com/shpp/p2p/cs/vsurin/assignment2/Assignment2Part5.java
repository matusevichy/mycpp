/**
 * File: Assignment2Part5.java
 * ---------------------------
 * This program draws a grid of rectangles in the center of the canvas.
 */

package com.shpp.p2p.cs.vsurin.assignment2;

import acm.graphics.GRect;
import com.shpp.cs.a.graphics.WindowProgram;

import java.awt.*;

public class Assignment2Part5 extends WindowProgram {
    /* The number of rows and columns in the grid, respectively. */
    private static final int NUM_ROWS = 7;
    private static final int NUM_COLS = 8;

    /* The width and height of each box. */
    private static final double BOX_SIZE = 40;

    /* The horizontal and vertical spacing between the boxes. */
    private static final double BOX_SPACING = 10;

    public void run() {
        /* Call the drawRectangleGrid method to draw the grid of rectangles */
        drawRectangleGrid(NUM_COLS, NUM_ROWS);
    }

    /**
     * Draws a grid of boxes with the specified number of rows and columns.
     *
     * @param cols The number of columns in the grid.
     * @param rows The number of rows in the grid.
     */
    private void drawRectangleGrid(int cols, int rows) {
        /* Calculate the center coordinates of the canvas */
        double centerX = getWidth() / 2.0;
        double centerY = getHeight() / 2.0;

        /* Calculate the total width and height of the grid */
        double gridWidth = cols * BOX_SIZE + (cols - 1) * BOX_SPACING;
        double gridHeight = rows * BOX_SIZE + (rows - 1) * BOX_SPACING;

        /* Calculate the starting x and y coordinates of the grid */
        double startX = centerX - gridWidth / 2.0;
        double startY = centerY - gridHeight / 2.0;

        /* Draw each row of boxes */
        for (int i = 0; i < rows; i++) {
            drawRow(i, cols, startX, startY);
        }
    }

    /**
     * Draws a single row of boxes in the grid.
     *
     * @param rowNumber The index of the row to draw.
     * @param cols The number of columns in the grid.
     * @param startX The x-coordinate of the upper-left corner of the row.
     * @param startY The y-coordinate of the upper-left corner of the row.
     */
    private void drawRow(int rowNumber, int cols, double startX, double startY) {
        /* Draw each box in the row */
        for (int i = 0; i < cols; i++) {
            drawBox(rowNumber, i, startX, startY);
        }
    }

    /**
     * Draws a single box in the grid.
     *
     * @param rowNumber The index of the row that the box belongs to.
     * @param colNumber The index of the column that the box belongs to.
     * @param startX The x-coordinate of the upper-left corner of the grid.
     * @param startY The y-coordinate of the upper-left corner of the grid.
     */
    private void drawBox(int rowNumber, int colNumber, double startX, double startY) {
        /* Calculate the x and y coordinates of the box */
        double x = startX + colNumber * (BOX_SIZE + BOX_SPACING);
        double y = startY + rowNumber * (BOX_SIZE + BOX_SPACING);

        /* Add the box to the canvas */
        addRectangle(x, y, BOX_SIZE, BOX_SIZE);
    }

    /**
     * Adds a rectangle to the canvas with the specified properties.
     *
     * @param x The x-coordinate of the upper-left corner of the rectangle.
     * @param y The y-coordinate of the upper-left corner of the rectangle.
     * @param width The width of the rectangle.
     * @param height The height of the rectangle.
     */
    private void addRectangle(double x, double y, double width, double height) {
        drawRectangle(x, y, width, height, Color.BLACK);
    }

    /**
     * Draws a rectangle with the specified properties.
     *
     * @param x The x-coordinate of the upper-left corner of the rectangle.
     * @param y The y-coordinate of the upper-left corner of the rectangle.
     * @param width The width of the rectangle.
     * @param height The height of the rectangle.
     * @param color The color to fill the rectangle with.
     */
    private void drawRectangle(double x, double y, double width, double height,	Color color) {
        GRect rect = new GRect(x, y, width, height);
        rect.setFilled(true);
        rect.setFillColor(color);
        rect.setColor(color);
        add(rect);
    }
}
