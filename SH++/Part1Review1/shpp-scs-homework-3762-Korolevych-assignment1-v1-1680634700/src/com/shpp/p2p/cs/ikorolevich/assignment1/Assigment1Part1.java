package com.shpp.p2p.cs.ikorolevich.assignment1;

import  com.shpp.karel.KarelTheRobot;
public class Assigment1Part1 extends  KarelTheRobot {
    @Override
    public  void  run() throws  Exception{
        moveToNewspaper();
        pickBeeper();
        moveBack();
    }
    /*
      The karel returns to the starting position;
     */
    private void moveBack() throws Exception {
        turnAround();
        moveToWall();
        changeToRightRow();
        turnAround();
    }

    private void turnAround() throws Exception {
        turnLeft();
        turnLeft();
    }
    /*
    Karel goes to the newspaper
     */
    private void moveToNewspaper() throws Exception {
        changeToRightRow();
        beeperInRow();
    }
    /*
    Carrel goes to the first beeper on the line
     */
    private void beeperInRow() throws Exception {
        while (noBeepersPresent()){
            move();
        }
    }
    /*
    a method that makes the karel go forward until it meets a wall
     */
    private   void moveToWall() throws Exception {
        while (frontIsClear()){
            move();
        }
    }
    /*
    changes the Karel line to the right line
     */
    private void changeToRightRow() throws Exception {
        turnRight();
        move();
        turnLeft();
    }

    private void turnRight() throws Exception {
        turnLeft();
        turnLeft();
        turnLeft();
    }
}
