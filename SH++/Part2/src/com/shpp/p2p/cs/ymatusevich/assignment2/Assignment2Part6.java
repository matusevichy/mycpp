package com.shpp.p2p.cs.ymatusevich.assignment2;

import acm.graphics.GOval;
import com.shpp.cs.a.graphics.WindowProgram;

import java.awt.*;

//Program draws caterpillar on the canvas on the given parameters
public class Assignment2Part6 extends WindowProgram {
    //The x and y coordinates of start point for drawing
    private static final int START_X = 0;
    private static final int START_Y = 100;

    //The circles count and diameter in the drawn caterpillar, respectively
    private static final int CIRCLE_COUNT = 15;
    private static final int CIRCLE_DIAMETER = 70;

    //Offset of x and y coordinates for next circle
    private static final int CIRCLE_X_OFFSET = 35;
    private static final int CIRCLE_Y_OFFSET = 30;

    //Border and fill color for of circles
    private static final Color CIRCLE_FILL_COLOR = new Color(0,153,0);
    private static final Color CIRCLE_BORDER_COLOR = Color.red;

    /* The default width and height of the window. These constants will tell Java to
     * create a window whose size is *approximately* given by these dimensions.
     */
    public static final int APPLICATION_WIDTH = 600;
    public static final int APPLICATION_HEIGHT = 400;

    @Override
    public void run() {
        drawCaterpillar();
    }

    //Draws caterpillar`s given number of circles in loop
    private void drawCaterpillar(){
        int x = START_X;
        int y = START_Y;
        for (int i=0; i<CIRCLE_COUNT; i++){
            drawCircle(x, y);
            x += CIRCLE_X_OFFSET;
            y=((i % 2) != 0)? START_Y : y - CIRCLE_Y_OFFSET;
        }
    }

    /**
     * Draws circle on given colors in the x and y coordinates
     * @param x - integer value of start point x coordinate
     * @param y - integer value of start point y coordinate
     */
    private void drawCircle(int x, int y){
        var circle = new GOval(x,y,CIRCLE_DIAMETER, CIRCLE_DIAMETER);
        circle.setColor(CIRCLE_BORDER_COLOR);
        circle.setFilled(true);
        circle.setFillColor(CIRCLE_FILL_COLOR);
        add(circle);
    }
}
