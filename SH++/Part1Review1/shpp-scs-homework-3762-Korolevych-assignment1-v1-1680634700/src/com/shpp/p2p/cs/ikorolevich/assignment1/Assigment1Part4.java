package com.shpp.p2p.cs.ikorolevich.assignment1;

import  com.shpp.karel.KarelTheRobot;
public class Assigment1Part4 extends  KarelTheRobot {
    @Override
    public  void  run() throws  Exception{
        /*
        three checks for the conditions if it is just a single line
        from top to bottom, if it is just a cell, and if it is a normal world
         */
        if(frontIsClear()) {
            while (frontIsClear()){
                /*
                arrange our beepers in two patterns place the beepers in the first pattern go back and go up
                place the second pattern, go back and go up
                 */
                putBeepersInRow1();
                turnAround();
                while (frontIsClear()){
                    move();
                }
                if(rightIsClear()) {
                    turnRight();
                    move();
                }
                    turnRight();
                    putBeepersInRow2();
                    turnAround();
                    while (frontIsClear()){
                        move();
                    }
                    if(rightIsClear()){
                        turnRight();
                        move();
                    }
                    turnRight();
                }
            }
        else if(leftIsClear()){
            turnLeft();
            putBeepersInRow1();
        }
        else {
            putBeeper();
        }
    }
    /*
    our second pattern takes a step and puts the beeper under it takes another step and so on until it reaches the wall
     */
    private void putBeepersInRow2() throws Exception {
        while (frontIsClear()) {
            move();
            putBeeper();
            if(frontIsClear()){
                move();
            }
        }
    }

    private void turnRight() throws Exception {
        turnLeft();
        turnLeft();
        turnLeft();
    }
    /*
    our 1st pattern puts the beeper under itself, takes a step, then takes another step, and so on until it meets the wall
     */
    private void putBeepersInRow1() throws Exception {
        while (frontIsClear()){
            putBeeper();
            move();
            if(frontIsClear()){
                move();
            }
        }
        turnAround();
        if(frontIsClear()){
            move();
        }
        if(beepersPresent()){
            turnAround();
            if(frontIsClear()){
                move();
            }
        }
        else {
            turnAround();
            if(frontIsClear()){
                move();
                putBeeper();
            }
        }
    }

    private void turnAround() throws Exception {
        turnLeft();
        turnLeft();
    }


}
