package com.shpp.p2p.cs.vostapchuk.assignment2;

import acm.graphics.GOval;
import com.shpp.cs.a.graphics.WindowProgram;

import java.awt.*;
/* TODO:In this class the caterpillar was centered in the window or occupied its entire
 *    space. The color of the circle must differ from the color of the border of this circle.
 *     It should be possible to easily change the number of track segments.
 */

public class Assignment2Part6 extends WindowProgram {
    public static final int APPLICATION_WIDTH = 600;
    public static final int APPLICATION_HEIGHT = 150;
    private static final int NUM_SEGMENTS = 10; // Number of caterpillar segments
    private static final double DIAMETER = 50; //DIAMETER
    private static final double GAP = 20; // The distance between the ovals (circle)
    public static final Color OVAL_COLOR = new Color(0, 99, 0); // color circle
    private static final Color BORDER_COLOR = new Color(255, 0, 0); //color of borders

    public void run() {
        double x = 0; // Start coordination X
        double y = 40; // coordination Y in the center

        for (int i = 0; i < NUM_SEGMENTS; i++) {

            // The Y coordinate correction for the center of the second oval is 50% higher
            double evenUp = i % 2 == 0 ? 0 : -DIAMETER / 2.0;
            // Correction of the Y coordinate to align the height of the ovals
            GOval oval = new GOval(x, y + evenUp, DIAMETER, DIAMETER);
            oval.setFilled(true);
            oval.setFillColor(OVAL_COLOR);
            oval.setColor(BORDER_COLOR);
            add(oval);

            x += DIAMETER - GAP; // Оновлюємо координату X для наступного овалу з урахуванням накладання
        }
    }
}

