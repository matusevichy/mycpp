package com.shpp.p2p.cs.ikorolevich.assignment1;

import  com.shpp.karel.KarelTheRobot;

public class Assigment1Part2 extends  KarelTheRobot {
    @Override
    public  void  run() throws  Exception{
        turnLeft();
        /*
        since the distance between the columns is specified in the condition,
        we simply move between them through the cycle and put beepers each time
        we return to the bottom and turn it to the left to check if the right is
         clear to know if it is already against the wall
         */
        while (rightIsClear()){
            moveToWall();
            turnAround();
            putBeeperInRow();
            turnLeft();
            moveToNextWall();
            turnLeft();
        }
        /*
        since the condition states that the last column is always near the wall
        and in the condition of the loop it will stop calling methods, we call the methods again
         */
        moveToWall();
        turnAround();
        putBeeperInRow();
    }

    /*
    just a method that goes to the next column also checks whether it can go
     */
    private void moveToNextWall() throws Exception {
        for(int i=0;i<4;i++){
            if(frontIsClear()){
                move();
            }
        }
    }

    private void turnAround() throws Exception {
        turnLeft();
        turnLeft();
    }
    /*
    fill our column with beepers
     */
    private void putBeeperInRow() throws Exception {
        while (frontIsClear()){
            if(noBeepersPresent()){
                putBeeper();
            }
            move();
        }
        if(noBeepersPresent()){
            putBeeper();
        }
    }

    private void moveToWall() throws Exception {
        while (frontIsClear()){
            move();
        }
    }


}
