package com.shpp.p2p.cs.yekhlopeniuk.assignment3;

import acm.graphics.GOval;
import com.shpp.cs.a.graphics.WindowProgram;
import java.awt.*;

public class Assignment3Part6 extends WindowProgram {
    /* It works fine on fast computers
       It works correctly but not pretty on slow computers*/
    public static final int APPLICATION_SIZE = 400; //try more on fast computer
    public static final int EXECUTION_TIME = 5000; //5 seconds
    public static final boolean INFINITY_LOOP = false; //set false when checking and true when study this
    private static final int QUALITY = 360; //continuity of the line
    private static final double THICKNESS = 25;
    private static final double FREQUENCY_RATIO = 2.0; //play with this, try 3.0 and smthng < 1
    private double height, width;
    private double pause = 10; //change the speed of spin

    public void run() {
        //draw 360 frames
        setSize(APPLICATION_SIZE, APPLICATION_SIZE);
        setBackground(Color.BLACK);
        height = getHeight();
        width = getWidth();

        long startTime = System.currentTimeMillis(); //time of launch
        int remainingTime, frameTime;

        int frames = 0; //count frames
        //every frame is different by phase of oscillation along the X axis
        for (int phase = 0; phase < 360; phase++) {
            int executionTime = drawShape(phase); //time of drawing one frame in ms
            frames++;

            if (INFINITY_LOOP) {
                if (phase == 359) phase = 0; //make it endless
            }
            else {
                //how much time have we left to invest in 5 seconds
                remainingTime = EXECUTION_TIME - (int) (System.currentTimeMillis() - startTime);
                if (remainingTime < 0) break;

                //estimated time for every next frame
                frameTime = remainingTime / (360 - phase);
                if (executionTime == 0) pause = 1; //speed shouldn't be very fast
                else pause = pause * frameTime / executionTime; //correct the speed to invest in 5 seconds
            }
        }
        //print results
        print("Execution time: " + (System.currentTimeMillis() - startTime) + " ms; ");
        print("Frames: " + frames);
        exit();
    }
    private int drawShape(int phase) {
        //draw trajectory of point, which makes oscillation along the X and Y axes
        //frequency along the X is 1; frequency along the Y is FREQUENCY_RATIO
        //trajectory depends on phase of oscillation along the X axis
        //method returns the time of execution in ms

        long startTime = System.currentTimeMillis();
        //change color depending on the phase
        int red = (phase < 180) ? (int) (phase/180.0*255.0) : (int) ((-phase+360)/180.0*255.0);
        Color color = new Color(red, 64, 128);

        for (int i = 0; i < QUALITY; i++) {
            double angle = getAngle(i + phase);
            double x = width/2 * (1 + 0.9 * Math.sin(angle));
            angle = getAngle(i);
            double y = height/2 * (1 + 0.9 * Math.sin(angle * FREQUENCY_RATIO));
            drawCircle(x, y, color);
        }
        pause(pause); //controls the speed of drawing

        removeAll(); //clear screen
        long endTime = System.currentTimeMillis();
        return (int) (endTime - startTime);
    }
    private void drawCircle(double x, double y, Color color) {
        //draw circle by center in x, y
        GOval oval = new GOval(x - THICKNESS/2, y - THICKNESS/2, THICKNESS, THICKNESS);
        oval.setFilled(true);
        oval.setColor(color);
        add(oval);
    }
    private double getAngle(int angle) {
        //convent angle to radians
        return angle * 1.0 / QUALITY * 360 * 3.141592654 / 180.0;
    }
}
