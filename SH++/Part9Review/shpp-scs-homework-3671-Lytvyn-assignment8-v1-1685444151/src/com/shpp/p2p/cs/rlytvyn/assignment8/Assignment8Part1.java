package com.shpp.p2p.cs.rlytvyn.assignment8;

import acm.graphics.*;
import com.shpp.cs.a.graphics.WindowProgram;

import java.util.Random;
import java.awt.*;
import java.awt.event.*;

public class Assignment8Part1 extends WindowProgram implements MouseListener, MouseMotionListener {
    /**
     * Width and height of application window in pixels
     */
    public static final int APPLICATION_WIDTH = 400;
    public static final int APPLICATION_HEIGHT = 600;
    // Number of seeds
    public static final int NUMBER_OF_SEEDS = 6;
    //squares size (seeds, water and air are shown as squares)
    public static final int SIZE_OF_SQUARES = 20;
    //Pause in ms
    public static final int PAUSE_LONG = 1000;
    //colors of squares
    private static final Color COLOR_OF_SEEDS = Color.BLACK;
    private static final Color COLOR_OF_WATER = Color.BLUE;
    private static final Color COLOR_OF_AIR = Color.WHITE;
    private static final Color COLOR_OF_PLANT = Color.GREEN;
    // The row length
    int rowLong;
    // The column  length
    int colLong;
    //make a field as array with squares
    GRect[][] matrixRects;
    //Coordinates of mouse if pressed
    int xMouse;
    int yMouse;

    public void run() {
        addMouseListeners();
        drawAir();
        addSeeds();
        addWater(xMouse, yMouse);
        moveAllDown();
    }

    //move all squares according task
    private void moveAllDown() {
        while (true) {
            for (int i = 0; i < rowLong; i++) {
                for (int j = colLong - 2; j >= 0; j--) {
                    //seeds fall to bottom
                    if (matrixRects[i][j].getColor() == COLOR_OF_SEEDS) {
                        matrixRects[i][j].setFilled(true);
                        matrixRects[i][j].setColor(COLOR_OF_AIR);
                        matrixRects[i][j].setFilled(true);
                        matrixRects[i][j + 1].setColor(COLOR_OF_SEEDS);
                    }
                    //if under water a plant present - add +1 green square
                    else if (matrixRects[i][j].getColor() == COLOR_OF_WATER
                            && matrixRects[i][j + 1].getColor() == COLOR_OF_PLANT) {
                        matrixRects[i][j].setFilled(true);
                        matrixRects[i][j].setColor(COLOR_OF_PLANT);
                    }
                    //if under water a seed present - repaint to green (it will be a plant)
                    else if (matrixRects[i][j].getColor() == COLOR_OF_WATER
                            && matrixRects[i][j + 1].getColor() == COLOR_OF_SEEDS
                    ) {
                        matrixRects[i][j].setFilled(true);
                        matrixRects[i][j].setColor(COLOR_OF_AIR);
                        matrixRects[i][j].setFilled(true);
                        matrixRects[i][j + 1].setColor(COLOR_OF_PLANT);
                    }
                    //water fall to bottom and disappears
                    else if (matrixRects[i][colLong - 1].getColor() == COLOR_OF_WATER) {
                        matrixRects[i][colLong - 1].setFilled(true);
                        matrixRects[i][colLong - 1].setColor(COLOR_OF_AIR);
                        matrixRects[i][colLong - 1].setFilled(true);
                        matrixRects[i][colLong - 1].setColor(COLOR_OF_AIR);
                    }
                    //water fall down
                    else if (matrixRects[i][j].getColor() == COLOR_OF_WATER) {
                        matrixRects[i][j].setFilled(true);
                        matrixRects[i][j].setColor(COLOR_OF_AIR);
                        matrixRects[i][j].setFilled(true);
                        matrixRects[i][j + 1].setColor(COLOR_OF_WATER);
                    }
                }
            }
            pause(PAUSE_LONG);
        }
    }

    //create random coordinates for seeds
    public static int generateRandomRow(int rowLong) {
        return new Random().nextInt(rowLong - 1);
    }

    public static int generateRandomCol(int colLong) {
        return new Random().nextInt(colLong - 1);
    }

    // ad water on coordinates from mouse with pressed button
    private void addWater(int xMouse, int yMouse) {
        matrixRects[xMouse][yMouse].setFilled(true);
        matrixRects[xMouse][yMouse].setColor(COLOR_OF_WATER);
    }

    // ad seeds on random coordinates
    private void addSeeds() {
        int x;
        int y;
        for (int i = 0; i < NUMBER_OF_SEEDS; i++) {
            x = generateRandomRow(rowLong);
            y = generateRandomCol(colLong);
            matrixRects[x][y].setFilled(true);
            matrixRects[x][y].setColor(COLOR_OF_SEEDS);
        }
    }

    //make field in arrey and fill it by air
    private void drawAir() {
        rowLong = getWidth() / SIZE_OF_SQUARES;
        colLong = getHeight() / SIZE_OF_SQUARES;
        matrixRects = new GRect[rowLong][colLong];
        int x;
        int y;
        for (int i = 0; i < rowLong; i++) {
            for (int j = 0; j < colLong; j++) {
                x = SIZE_OF_SQUARES * i;
                y = SIZE_OF_SQUARES * j;
                matrixRects[i][j] = new GRect(x, y, SIZE_OF_SQUARES, SIZE_OF_SQUARES);
                matrixRects[i][j].setFilled(true);
                matrixRects[i][j].setColor(COLOR_OF_AIR);
                add(matrixRects[i][j]);
            }
        }
    }

    // find coordinates of mouse, when button is pressed
    public void mousePressed(MouseEvent e) {
        xMouse = e.getX() / SIZE_OF_SQUARES;
        yMouse = e.getY() / SIZE_OF_SQUARES;

        if (inField(xMouse, yMouse)) {
            addWater(xMouse, yMouse);
        }
    }

    // check that coordinates are in field
    private boolean inField(int xMouse, int yMouse) {
        return xMouse >= 0 && xMouse < rowLong && yMouse >= 0 && yMouse < colLong;
    }
}