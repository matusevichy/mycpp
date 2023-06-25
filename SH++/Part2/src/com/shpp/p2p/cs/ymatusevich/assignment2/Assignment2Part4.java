package com.shpp.p2p.cs.ymatusevich.assignment2;

import acm.graphics.GLabel;
import acm.graphics.GRect;
import com.shpp.cs.a.graphics.WindowProgram;

import java.awt.*;

/**
 * Universal program for drawing flag of the country with a different number of color on center of the canvas
 */
public class Assignment2Part4 extends WindowProgram {

    //The default width and height of the flag
    public static final int FLAG_WIDTH = 200;
    public static final int FLAG_HEIGHT = 150;

    /* The default width and height of the window. These constants will tell Java to
     * create a window whose size is *approximately* given by these dimensions.
     */
    public static final int APPLICATION_WIDTH = 300;
    public static final int APPLICATION_HEIGHT = 300;

    /**
     * Enumerated type declaration to determine the orientation of the color on the flag (horizontal or vertical)
     */
    private enum Orientation {
        HORIZONTAL,
        VERTICAL
    }

    @Override
    public void run() {
//        drawFlag("Germany", Orientation.HORIZONTAL, new Color[] {Color.black, Color.red, Color.yellow});
        drawFlag("Ukraine", Orientation.HORIZONTAL, new Color[] {Color.blue, Color.yellow});
//        drawFlag("Belgium", Orientation.VERTICAL, new Color[]{new Color(2555, 255,255, 0), Color.yellow, Color.red});
    }

    /**
     * Drawing flag on the canvas using different parameters
     * @param countryName - String value to the name of the country for display in label
     * @param colorOrientation - enum Orientation value to orientation of the color on the flag
     * @param colors - array of Color in order left-to-right for vertical color orientation or top-to-bottom for horizontal color orientation
     */
    private void drawFlag(String countryName, Orientation colorOrientation, Color[] colors){
        //Define offsets for colored rectangle based on the number of colors and flag size
        var offsetX = colorOrientation == Orientation.HORIZONTAL? 0: FLAG_WIDTH/colors.length;
        var offsetY = colorOrientation == Orientation.HORIZONTAL? FLAG_HEIGHT/colors.length: 0;

        //Define size of colored rectangle based on the number of colors and flag size
        var widthRect = colorOrientation == Orientation.HORIZONTAL? FLAG_WIDTH: FLAG_WIDTH/colors.length;
        var heightRect = colorOrientation == Orientation.HORIZONTAL? FLAG_HEIGHT/colors.length: FLAG_HEIGHT;

        //Define start point coordinates for flag drawing
        int x = (getWidth()-FLAG_WIDTH)/2;
        int y = (getHeight()-FLAG_HEIGHT)/2;

        //Drawing colored rectangles in loop
        for (Color color: colors) {
            drawRect(x, y, widthRect, heightRect, color);
            x+=offsetX;
            y+=offsetY;
        }
        drawLabel(countryName);
    }

    /**
     * Drawing colored rectangle on the canvas using different parameters
     * @param x - integer value to x coordinate for start point
     * @param y - integer value to y coordinate for start point
     * @param width - integer value to width rectangle
     * @param height - integer value to height rectangle
     * @param color - Color value to fill in rectangle
     */
    private void drawRect(int x, int y, int width, int height, Color color){
        var rect = new GRect(x, y, width, height);
        rect.setColor(color);
        rect.setFilled(true);
        rect.setFillColor(color);
        add(rect);
    }

    /**
     * Drawing label with country name in bottom-right corner of window
     * For define font size using FontMetrics https://docs.oracle.com/javase/tutorial/2d/text/measuringtext.html
     * @param countryName - String value to country name
     */
    private void drawLabel(String countryName){
        var text = "Flag of " +countryName;
        var label = new GLabel(text, 0, 0);
        Font font = new Font("Dialog", Font.BOLD, 12);
        label.setFont(font);
        var fontMetrics = getFontMetrics(font);
        var textWidth = fontMetrics.stringWidth(text);
        label.setLocation(getWidth()-textWidth, getHeight()-fontMetrics.getDescent());
        add(label);
    }
}
