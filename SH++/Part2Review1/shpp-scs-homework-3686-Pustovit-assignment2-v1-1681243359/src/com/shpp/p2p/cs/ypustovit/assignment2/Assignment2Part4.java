package com.shpp.p2p.cs.ypustovit.assignment2;


import acm.graphics.GLabel;
import acm.graphics.GRect;
import com.shpp.cs.a.graphics.WindowProgram;

import java.awt.*;


public class Assignment2Part4 extends WindowProgram {

    //These constants are needed to regulate application width and height.
    public static final int APPLICATION_WIDTH = 600;
    public static final int APPLICATION_HEIGHT = 500;

    //These constants specify width and height of one strip of the tricolor flag.
    //So, actual size of flag must be multiplied by 3.
    private static final double STRIP_WIDTH = 100;
    private static final double STRIP_HEIGHT = 200;

    //These constants are needed to make some special colors, which is unavailable.
    private static final Color CARDINAL_RED = new Color(217, 28, 53);
    private static final Color GOLD = new Color(250, 217, 2);
    private static final Color DARK_BLUE = new Color(1, 3, 115);


    public void run() {
        //Draws center strip of the flag.
        drawRectangle(getWidth() / 2.0 - STRIP_WIDTH / 2.0,
                getHeight() / 2.0 - STRIP_HEIGHT / 2.0, STRIP_WIDTH, STRIP_HEIGHT, GOLD);
        //Draws left strip of the flag. Here 1.5 is reduction of - STRIP_WIDTH / 2.0 - STRIP_WIDTH.
        drawRectangle(getWidth() / 2.0 - 1.5 * STRIP_WIDTH,
                getHeight() / 2.0 - STRIP_HEIGHT / 2.0, STRIP_WIDTH, STRIP_HEIGHT, DARK_BLUE);
        //Draws right strip of the flag. + STRIP_WIDTH / 2.0 here also is reduction of
        // - STRIP_WIDTH / 2.0 + STRIP_WIDTH.
        drawRectangle(getWidth() / 2.0 + STRIP_WIDTH / 2.0,
                getHeight() / 2.0 - STRIP_HEIGHT / 2.0, STRIP_WIDTH, STRIP_HEIGHT, CARDINAL_RED);
        //Adds signature.
        addSignature("Flag of Chad", "Chiller-40");
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

    /**
     * Adds signature in the lower right corner with specified font and size.
     *
     * @param text        The text of the signature.
     * @param fontAndSize The font and size of the signature, written in one line separated by dash.
     *                    Example: "SomeFont-40"
     */
    private void addSignature(String text, String fontAndSize) {
        GLabel label = new GLabel(text);
        label.setFont(fontAndSize);
        label.setLocation(getWidth() - label.getWidth(), getHeight() - label.getDescent());
        add(label);
    }

}

