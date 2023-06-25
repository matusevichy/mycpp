package com.shpp.p2p.cs.ymatusevich.assignment3;

import acm.graphics.GRect;
import com.shpp.cs.a.graphics.WindowProgram;

import java.awt.*;
import java.util.Arrays;

import static java.lang.System.currentTimeMillis;

//Program makes the custom animation with a duration of 5 seconds.
//In the animation a given number of colored rectangles fall down with different speeds
public class Assignment3Part6 extends WindowProgram {
    //Size and count of rectangles
    private final int RECT_COUNT = 10;
    private final int RECT_WIDTH = 30;
    private final int RECT_HEIGHT = 10;
    //Fill color of rectangles
    private final Color RECT_COLOR = Color.RED;

    @Override
    public void run() {
        waitForClick();
        startAnimation();
    }

    /**
     * This method create and start animation. Duration calculated as the difference between
     * currentTimeMillis() on start animation and currentTimeMillis() on current loop step.
     * Pause between the animation steps - 100ms.
     */
    private void startAnimation() {
        long startTime = currentTimeMillis();
        int deltaTime = 0;
        var rects = createObjects();
        Arrays.stream(rects).forEach(r -> add(r));
        //Animation loop
        while (deltaTime <= 5000) {
            deltaTime = (int) (currentTimeMillis() - startTime);
            moveRects(rects);
            pause(100);
        }
    }

    /**
     * Moving all rectangles to down on random value
     *
     * @param rects - array of rectangles for moving
     */
    private void moveRects(GRect[] rects) {
        Arrays.stream(rects).forEach(r -> r.move(0, Math.random() * 10));
    }

    /**
     * This method generate given count of the colored rectangles in random coordinates for next adding to animation
     * @return - array of rectangles GRect
     */
    private GRect[] createObjects() {
        GRect[] array = new GRect[RECT_COUNT];
        for (int i = 0; i < RECT_COUNT; i++) {
            var rect = new GRect(Math.random() * getWidth(), 0, RECT_WIDTH, RECT_HEIGHT);
            rect.setFilled(true);
            rect.setFillColor(RECT_COLOR);
            array[i] = rect;
        }
        return array;
    }

}
