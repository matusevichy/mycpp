package com.shpp.p2p.cs.vostapchuk.assignment2;

import acm.graphics.GOval;
import acm.graphics.GRect;
import com.shpp.cs.a.graphics.WindowProgram;

import java.awt.*;

/*
 * TODO:create a white rectangle that overlaps the four circles
 */
public class Assignment2Part2 extends WindowProgram {
    public static final int APPLICATION_WIDTH = 360;
    public static final int APPLICATION_HEIGHT = 300;
    private static final int DIAMETER = 200;

    public void run() {

        int radius = DIAMETER / 2;

        /*
         *  Create a four black circles
         */
        GOval circle1 = new GOval(getWidth() - 350, getHeight() - 265, DIAMETER, DIAMETER);
        GOval circle2 = new GOval(getWidth() + 200, getHeight() - 265, DIAMETER, DIAMETER);
        GOval circle3 = new GOval(getWidth() - 350, getHeight() + 100, DIAMETER, DIAMETER);
        GOval circle4 = new GOval(getWidth() + 200, getHeight() + 100, DIAMETER, DIAMETER);

        circle1.setFilled(true);
        circle2.setFilled(true);
        circle3.setFilled(true);
        circle4.setFilled(true);

        /*
         * Create a white rectangle
         */
        GRect rectangle = new GRect(getWidth() - 350 + radius, getHeight() - 265 + radius,
                getWidth() + DIAMETER, getHeight() + radius);
        rectangle.setFilled(true);
        rectangle.setColor(Color.WHITE);

        add(circle1);
        add(circle2);
        add(circle3);
        add(circle4);
        add(rectangle);
    }
}


