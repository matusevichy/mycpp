package com.shpp.p2p.cs.ymatusevich.assignment1;

//Use extended class SuperKarelTheRobot with extend methods  turnAround(), moveToWall()
public class Assignment1Part3 extends SuperKarelTheRobot {
    @Override
    public void run() throws Exception {
        putBeeper();
        if (frontIsClear()){
            move();
            if (frontIsClear()){
                findCenter();
                clearStreet();
            }
        }
    }

    //Find center of the street by filling the street with beepers from the walls toward the center
    //As a result, there will be two beepers on the central corner
    //If world has even number of corner on width, center defined on one of two central corner
    private void findCenter() throws Exception {
        while (noBeepersPresent()) {
            moveToBeeper();
            putBeeper();
            move();
        }
        turnAround();
        move();
        putBeeper();
    }

    //Move Karel on corner before first beeper or to wall
    private void moveToBeeper() throws Exception {
        while (noBeepersPresent()) {
            move();
            if (frontIsBlocked() && noBeepersPresent()) {
                putBeeper();
            }
        }
        turnAround();
        move();
    }

    //Remove all unnecessary beepers on the street
    private void clearStreet() throws Exception {
        moveToWall();
        turnAround();
        while (frontIsClear()){
            pickBeeper();
            move();
        }
        pickBeeper();
        turnAround();
    }
}
