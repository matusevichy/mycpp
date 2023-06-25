package com.shpp.p2p.cs.ymatusevich.assignment1;

//Use extended class SuperKarelTheRobot with extend methods  turnSouth(), turnNorth(), moveToWall()
public class Assignment1Part2 extends SuperKarelTheRobot {
    @Override
    public void run() throws Exception {
        fillColumn();
        while(frontIsClear()){                    //Loop while Karel not on the end of the map
            move();
            move();
            move();
            move();
            fillColumn();
        }
    }

    //Fill the current column bottom-to-up
    private void fillColumn() throws Exception {
        turnNorth();
        putBeeperIfEmpty();
        while (frontIsClear()){
            move();
            putBeeperIfEmpty();
        }
        goBottomColumn();
    }

    //Move Karel to the bottom after filled the column
    private void goBottomColumn() throws Exception {
        turnSouth();
        moveToWall();
        turnLeft();
    }

    //Put beeper if current corner is empty
    private void putBeeperIfEmpty() throws Exception {
        if (noBeepersPresent()){
            putBeeper();
        }
    }
}
