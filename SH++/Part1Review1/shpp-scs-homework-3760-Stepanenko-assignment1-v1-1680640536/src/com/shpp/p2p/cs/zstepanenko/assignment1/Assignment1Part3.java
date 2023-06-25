package com.shpp.p2p.cs.zstepanenko.assignment1;

import com.shpp.karel.KarelTheRobot;

/**
 * Assignment1Part3 class extends KarelTheRobot class so that
 * Karel finds the centre of the Southern edge of his world.
 */
public class Assignment1Part3 extends KarelTheRobot {
    @Override

    /*
     * Let's think of Karel's world as a rectangle. To find the centre of the
     * Southern edge, we have to firstly find the centre of a rectangle itself, i.e.
     * to find a cell, where its diagonals cross. Then we drop a median to the Southern
     * edge and find its centre. After this, all we need is to remove unnecessary beepers.
     */

    public void run() throws Exception {
        buildADiagonale();
        turnRight();


        while (frontIsClear()) {
            move();
        }

        buildASemidiagonale();
        buildAMedian();
        removeOddBeepers();
        putBeeper();
    }

    /**
     * Precondition: Karel is in the Southwestern corner facing East;
     * Result: Karel has built a diagonal.
     */
    private void buildADiagonale() throws Exception {
        while (frontIsClear()) {
            putBeeper();
            turnLeft();
            move();
            turnRight();
            move();
        }

        putBeeper();
    }

    /**
     * Precondition: Karel is in the Northeastern corner facing North;
     * Result: Karel has built a semidiagonal.
     */
    private void buildASemidiagonale() throws Exception {
        turnRight();


        while (frontIsClear() && noBeepersPresent()) {
            putBeeper();
            turnRight();
            move();
            turnLeft();
            move();
        }

    }

    /**
     * Precondition: Karel is in the centre of his rectangular world;
     * Result: Karel has found the centre of the Southern edge.
     */
    private void buildAMedian() throws Exception {
        turnLeft();


        while (frontIsClear()) {
            move();
            putBeeper();
        }

    }

    /**
     * Precondition: Karel is in the centre of the Southern edge;
     * Result: Karel cleaned up his world from the odd beepers.
     */
    private void removeOddBeepers() throws Exception {
        turnRight();


        while (frontIsClear()) {
            move();
        }

        turnAround();


        while (frontIsClear()) {
            pickBeeper();
            turnLeft();
            move();
            turnRight();
            move();
        }

        pickBeeper();
        turnRight();


        while (frontIsClear()) {
            move();
        }

        turnRight();


        while (frontIsClear() && beepersPresent()) {
            pickBeeper();
            turnRight();
            move();
            turnLeft();
            move();
        }

        turnLeft();


        while (frontIsClear()) {
            move();
            pickBeeper();
        }

    }

    /**
     * Karel turns around.
     */
    private void turnAround() throws Exception {
        for (int i = 0; i < 2; i++) {
            turnLeft();
        }

    }

    /**
     * Karel turns right.
     */
    private void turnRight() throws Exception {
        for (int i = 0; i < 3; i++) {
            turnLeft();
        }

    }

}
