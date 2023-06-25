package com.shpp.p2p.cs.ymatusevich.assignment1;

//Use extended class SuperKarelTheRobot with extend methods  turnRight(), turnAround(), moveToWall()
public class Assignment1Part1 extends SuperKarelTheRobot {
    @Override
    public void run() throws Exception {
        goToNewsPaper();
        getNewspaper();
        goToStart();
    }

    //Go to the newspaper.
    private void goToNewsPaper() throws Exception {
        while (noBeepersPresent()){                 // Move Karel in a loop until the newspaper is found
            if(leftIsClear())
            {
                turnLeft();
            } else
                if (frontIsBlocked()) {
                turnRight();
            }
            move();
        }
    }

    //Get newspaper to bag
    private void getNewspaper() throws Exception {
        pickBeeper();
    }

    //Go to the start point
    private void goToStart() throws Exception {
        turnAround();
        moveToWall();
        turnRight();
        moveToWall();
        turnRight();
    }

}
