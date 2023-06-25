package com.shpp.p2p.cs.ypustovit.assignment2;


import acm.graphics.GOval;
import com.shpp.cs.a.graphics.WindowProgram;

import java.awt.*;


public class Assignment2Part6 extends WindowProgram {

    //These constants are needed to regulate application width and height.
    public static final int APPLICATION_WIDTH = 700;
    public static final int APPLICATION_HEIGHT = 700;

    //Diameter of each body segment of the caterpillar.
    private static final double DIAMETER = 150;

    //Number of caterpillar body segments.
    private static final double BODY_SEGMENTS = 10;

    //Coordinates x and y that specify the upper-left corner of the bounding box containing
    // the first segment of the caterpillar.
    private static final double X_START_POINT = 125;
    private static final double Y_START_POINT = 275;

    public void run() {
        //Draws caterpillar with specified coordinates, number and size of body segments.
        for (int i = 0; i < BODY_SEGMENTS; i++) {
            //Draws one segment of the caterpillar.
            GOval c = new GOval(X_START_POINT + DIAMETER * i / 2,
                    //This condition is needed to draw even segments upper by a radius.
                    Y_START_POINT - ((i % 2 != 0) ? DIAMETER / 2 : 0), DIAMETER, DIAMETER);
            c.setFilled(true);
            c.setFillColor(Color.RED);
            c.setColor(Color.YELLOW);
            add(c);
        }
    }

}