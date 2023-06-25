package com.shpp.p2p.cs.sivaiuk.assignment1;
import com.shpp.karel.KarelTheRobot;

public class Assigment1Part1 extends KarelTheRobot {
    @Override
    public void run() throws Exception {
moveToNewspaper();
pickBeeper();
returnBack();
    }
    private void turnRight() throws Exception{
        turnLeft();
        turnLeft();
        turnLeft();
    }
    private void turnAround() throws Exception{
        turnLeft();
        turnLeft();
    }
    private void moveToNewspaper() throws Exception{
        turnRight();
        move();
        turnLeft();
        while(noBeepersPresent())
            move();
    }
    private void returnBack() throws Exception{
        turnAround();
        while(frontIsClear())
            move();
        moveToRightCell();
    }
    private void moveToRightCell() throws Exception{
        turnRight();
        move();
        turnRight();
    }

}