package com.shpp.p2p.cs.ymatusevich.assignment2;

import acm.graphics.GOval;
import acm.graphics.GRect;
import com.shpp.cs.a.graphics.WindowProgram;

import java.awt.*;
import java.awt.event.ComponentEvent;
import java.awt.event.ComponentListener;

/**
*The diameter of the circles calculate as 1/3 of the smaller side of the window (width or height)
*Size of the rectangle calculate from the window width and height using diameter of the circles
*ComponentListener added for redraw all elements (circles and rectangle) when window is resized (not in task)
*Received information from official site https://docs.oracle.com/javase/tutorial/uiswing/events/componentlistener.html
*/
public class Assignment2Part2 extends WindowProgram {

    /* The default width and height of the window. These constants will tell Java to
     * create a window whose size is *approximately* given by these dimensions.
     */
    public static final int APPLICATION_WIDTH = 300;
    public static final int APPLICATION_HEIGHT = 300;

    @Override
    public void run() {
        redraw();
        addComponentListener(new ComponentListener() {
            @Override
            public void componentResized(ComponentEvent e) {
                redraw();
            }

            @Override
            public void componentMoved(ComponentEvent e) {

            }

            @Override
            public void componentShown(ComponentEvent e) {

            }

            @Override
            public void componentHidden(ComponentEvent e) {

            }
        });
    }

    /**
    *Drawing the 4 black circles in the 4 corners of the window
    *@Params width, height - integer values of the current size of the window, diameter - integer value of the circle diameter
    */
    private void drawCircles(int width, int height, int diameter){
        var circle1 = new GOval(0, 0, diameter,diameter);
        circle1.setFillColor(Color.black);
        circle1.setFilled(true);
        add(circle1);
        var circle2 = new GOval(width-diameter, height-diameter, diameter,diameter);
        circle2.setFillColor(Color.black);
        circle2.setFilled(true);
        add(circle2);
        var circle3 = new GOval(width-diameter, 0, diameter,diameter);
        circle3.setFillColor(Color.black);
        circle3.setFilled(true);
        add(circle3);
        var circle4 = new GOval(0, height-diameter, diameter,diameter);
        circle4.setFillColor(Color.black);
        circle4.setFilled(true);
        add(circle4);
    }

    /**
    *Drawing the white rectangle between the centers of the circles
    *@Params width, height - integer values of the current size of the window, diameter - integer value of the circle diameter
    */

    private void drawRect(int width, int height, int diameter){
        var rectangle = new GRect(diameter/2, diameter/2, width-diameter, height-diameter);
        rectangle.setFilled(true);
        rectangle.setColor(Color.white);
        rectangle.setFillColor(Color.white);
        add(rectangle);
    }

    /**
    *Removing all element on the drawable canvas (if exists) and calling methods for drawing circles and  rectangle -
    *redraw all elements relative to the actual size of the window
    */
    private void redraw(){
        getGCanvas().removeAll();
        int width = getWidth();
        int height = getHeight();
        int diameter = width > height ? height/3 : width/3;
        drawCircles(width, height, diameter);
        drawRect(width, height, diameter);
    }
}
