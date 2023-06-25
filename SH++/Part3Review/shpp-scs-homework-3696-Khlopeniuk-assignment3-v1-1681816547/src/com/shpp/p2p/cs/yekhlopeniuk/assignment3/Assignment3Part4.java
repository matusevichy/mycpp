package com.shpp.p2p.cs.yekhlopeniuk.assignment3;

import acm.graphics.GRect;
import acm.graphics.GOval;
import com.shpp.cs.a.graphics.WindowProgram;
import java.awt.*;

public class Assignment3Part4 extends WindowProgram {
    public static final int BRICK_HEIGHT = 7;
    public static final int BRICK_WIDTH = 25;
    public static final int BRICK_SEAM = 2; //distance between two bricks
    public static final int BRICKS_IN_BASE  = 20;
    public static final int APPLICATION_HEIGHT = (int) (BRICKS_IN_BASE * (BRICK_HEIGHT + BRICK_SEAM) * 2.0);
    public static final int APPLICATION_WIDTH = (int) (BRICKS_IN_BASE * (BRICK_WIDTH + BRICK_SEAM) * 1.25);

    public void run() {
        //draw pyramid
        setSize(APPLICATION_WIDTH, APPLICATION_HEIGHT); //I don't understand how it works
                                                        //it's impossible to set height I want
        int width = getWidth();

        double y = getHeight(); //bottom side of current brick
        double x = (width - (BRICK_WIDTH + BRICK_SEAM) * BRICKS_IN_BASE) / 2.0; //left side of current brick
        for (int i = BRICKS_IN_BASE; i > 0; i--) {
            x = (width - (BRICK_WIDTH + BRICK_SEAM) * i) / 2.0; //left side of left brick in this row

            for (int j = 0; j < i; j++) {
                drawBrick(x + (BRICK_WIDTH + BRICK_SEAM) * j, y); //draw bricks with different left side coordinates
            }
            y -= (BRICK_HEIGHT + BRICK_SEAM); //the y coordinate of bottom brick side at next raw
        }
        drawTotem(x, y - BRICK_WIDTH - BRICK_SEAM); //otherwise why do we need a pyramid?:)
    }
    private void drawBrick(double x, double y) {
        //draw brick by left bottom corner
        GRect brick = new GRect(x, y - BRICK_HEIGHT, BRICK_WIDTH, BRICK_HEIGHT);
        //use y - BRICK_HEIGHT to change bottom coordinate to upper coordinate
        brick.setFilled(true);
        brick.setColor(Color.BLACK);
        brick.setFillColor(Color.ORANGE);
        add(brick);
    }
    private void drawTotem(double x, double y) {
        //draw big red circle
        GOval totem = new GOval(x, y, BRICK_WIDTH, BRICK_WIDTH);
        totem.setFilled(true);
        totem.setColor(Color.BLACK);
        totem.setFillColor(Color.RED);
        add(totem);
    }
}
