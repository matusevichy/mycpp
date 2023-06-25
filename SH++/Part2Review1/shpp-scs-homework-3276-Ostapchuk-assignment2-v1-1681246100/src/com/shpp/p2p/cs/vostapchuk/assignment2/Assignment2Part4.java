package com.shpp.p2p.cs.vostapchuk.assignment2;

import acm.graphics.GLabel;
import acm.graphics.GRect;
import com.shpp.cs.a.graphics.WindowProgram;

import java.awt.*;


/* TODO: Tricolor flags and the name of the country in the lower right corner */

public class Assignment2Part4 extends WindowProgram {
    private static final Color STRIPE1_COLOR = new Color(0, 0, 0); // Color
    private static final Color STRIPE3_COLOR = new Color(255, 221, 0); // Color
    private static final Color STRIPE2_COLOR = new Color(239, 65, 53); // Color
    private static final int FLAG_WIDTH = 300; // WIDTH FLAG
    private static final int FLAG_HEIGHT = 200; // HEIGHT FLAG
    private static final String COUNTRY_NAME = "Belgium";//COUNTRY NAME

    public void run() {
        drawFlagOfBelgium();
    }

    private void drawFlagOfBelgium() {
        int windowWidth = getWidth();
        int windowHeight = getHeight();

        // We calculate the coordinates of the upper left corner of the flag for centering
        int flagX = (windowWidth - FLAG_WIDTH) / 2;
        int flagY = (windowHeight - FLAG_HEIGHT) / 2;

        // draw flaf
        GRect flag = new GRect(flagX, flagY, FLAG_WIDTH, FLAG_HEIGHT);
        flag.setFilled(true);
        add(flag);

        //Draw three stripes on the flag
        int stripeHeight = FLAG_HEIGHT / 3;
        GRect stripe1 = new GRect(flagX, flagY, FLAG_WIDTH, stripeHeight);
        GRect stripe2 = new GRect(flagX, flagY + stripeHeight, FLAG_WIDTH, stripeHeight);
        GRect stripe3 = new GRect(flagX, flagY + 2 * stripeHeight, FLAG_WIDTH, stripeHeight);

        stripe1.setFilled(true);
        stripe2.setFilled(true);
        stripe3.setFilled(true);

        stripe1.setFillColor(STRIPE1_COLOR);
        stripe2.setFillColor(STRIPE2_COLOR);
        stripe3.setFillColor(STRIPE3_COLOR);

        add(stripe1);
        add(stripe2);
        add(stripe3);


        // Add the inscription "Flag of ..." to the lower right corner of the window
        GLabel label = new GLabel("Flag of " + COUNTRY_NAME);
        label.setFont("SansSerif-14");
        label.setColor(Color.BLACK);
        double labelX = windowWidth - label.getWidth() - 5;
        double labelY = windowHeight - label.getAscent() - 5;
        add(label, labelX, labelY);
    }

}

