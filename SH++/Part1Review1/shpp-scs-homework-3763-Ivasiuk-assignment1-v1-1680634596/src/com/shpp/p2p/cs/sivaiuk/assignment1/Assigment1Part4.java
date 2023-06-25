package com.shpp.p2p.cs.sivaiuk.assignment1;
import com.shpp.karel.KarelTheRobot;
public class Assigment1Part4 extends KarelTheRobot{

    public void run() throws Exception{
if(frontIsClear()&&leftIsClear()) {

    while (frontIsClear()) {
        fillTheRowWithBeepers1();
        moveToTheNextRow1();
        fillTheRowWithBeepers2();
        moveToTheNextRow2();
    }
    // Karel take the last beeper
    pickBeeper();
}
else{
    putBeeper();
}
        }
    private void fillTheRowWithBeepers1() throws Exception{
        putBeeper();
        while(frontIsClear()) {
            move();
            if(frontIsClear()) {
                move();
                putBeeper();
            }
        }
    }
    private void fillTheRowWithBeepers2() throws Exception {
        while (frontIsClear()) {
            putBeeper();
            if (frontIsClear())
                move();
            if(frontIsClear())
                move();

            }
    }

    private void moveToTheNextRow1() throws Exception {
        turnLeft();
        if (frontIsClear()) {
            move();
            turnLeft();
        }
    }
    private void moveToTheNextRow2() throws Exception {
     
        turnRight();
        if (frontIsClear()) {
            move();
            turnRight();
        }
    }
    private void turnRight() throws Exception{
        turnLeft();
        turnLeft();
        turnLeft();
    }
}
