package com.shpp.p2p.cs.ypustovit.assignment2;

import acm.graphics.GOval;
import acm.graphics.GRect;
import com.shpp.cs.a.graphics.WindowProgram;

import java.awt.*;

public class Assignment2Part2 extends WindowProgram {

    //These constants are needed to regulate application width and height.
    public static final int APPLICATION_WIDTH = 300;
    public static final int APPLICATION_HEIGHT = 200;

    public void run() {
        double diameter;
        //Depending on application width and height calculates diameters of the circles.
        //This is needed for cases when APPLICATION_WIDTH != APPLICATION_HEIGHT
        if (getHeight() > getWidth()) {
            diameter = getWidth() / 3.0;
        } else {
            diameter = getHeight() / 3.0;
        }
        //Calculates rectangle width and height.
        double rectWidth = getWidth() - diameter;
        double rectHeight = getHeight() - diameter;
        //Draws circle in the upper left corner.
        drawCircle(0, 0, diameter, Color.BLACK);
        //Draws circle in the upper right corner.
        drawCircle(getWidth() - diameter, 0, diameter, Color.BLACK);
        //Draws circle in the lower left corner.
        drawCircle(0, getHeight() - diameter, diameter, Color.BLACK);
        //Draws circle in the lower right corner.
        drawCircle(getWidth() - diameter, getHeight() - diameter, diameter, Color.BLACK);
        //Draws rectangle in the middle of the application.
        drawRectangle(getWidth() / 2.0 - rectWidth / 2.0, getHeight() / 2.0 - rectHeight / 2.0,
                rectWidth, rectHeight, Color.WHITE);

    }

    /**
     * Draws a circle with given x and y coordinate, diameter and color.
     * The coordinates specify the upper-left corner of the bounding box containing that circle.
     *
     * @param x        The x coordinate of the upper-left corner of the bounding box for the circle.
     * @param y        The y coordinate of the upper-left corner of the bounding box for the circle.
     * @param diameter The diameter of the circle.
     * @param color    The color of the circle.
     */
    private void drawCircle(double x, double y, double diameter, Color color) {
        GOval circle = new GOval(x, y, diameter, diameter);
        circle.setFilled(true);
        circle.setColor(color);
        add(circle);
    }

    /**
     * Draws a rectangle with given x and y coordinate, width, height and color.
     * The coordinates specify the upper-left corner of the rectangle.
     *
     * @param x      The x coordinate of the upper-left corner of the rectangle.
     * @param y      The y coordinate of the upper-left corner of the rectangle.
     * @param width  The width of the rectangle.
     * @param height The height of the rectangle.
     * @param color  The color of the rectangle.
     */
    private void drawRectangle(double x, double y, double width, double height, Color color) {
        GRect rect = new GRect(x, y, width, height);
        rect.setFilled(true);
        rect.setColor(color);
        add(rect);
    }

}
