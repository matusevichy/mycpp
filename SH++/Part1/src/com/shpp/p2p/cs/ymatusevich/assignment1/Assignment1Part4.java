package com.shpp.p2p.cs.ymatusevich.assignment1;

//Use extended class SuperKarelTheRobot with extend method turnRight()
public class Assignment1Part4 extends SuperKarelTheRobot {
    @Override
    public void run() throws Exception {
        putBeeper();
        if (frontIsBlocked() && leftIsClear()){ //If world has one column
            turnLeft();
            fillColumn();
        }
        else{                                   //If world has more column
            while (frontIsClear()){
                fillLine();
            }
        }
    }

    //Fill line on chessboard
    private void fillLine() throws Exception {
        while (frontIsClear()){
            if (beepersPresent()){
                move();
            }
            else {
                move();
                putBeeper();
            }
        }
        moveToNextLine();
    }

    //Fill column on chessboard
    private void fillColumn() throws Exception {
        while (frontIsClear()){
            if (beepersPresent()){
                move();
            }
            else {
                move();
                putBeeper();
            }
        }
    }

    //Move Karel up to next line
    private void moveToNextLine() throws Exception {
        if(facingEast()){                   //If the line was filled left to right
            if (leftIsClear()){
                if (beepersPresent()){
                    turnLeft();
                    move();
                    turnLeft();
                }
                else {
                    turnLeft();
                    move();
                    putBeeper();
                    turnLeft();
                }
            }
        } else
        if(facingWest()) {                  //If the line was filled right to left
            if (rightIsClear()) {
                if (beepersPresent()) {
                    turnRight();
                    move();
                    turnRight();
                } else {
                    turnRight();
                    move();
                    putBeeper();
                    turnRight();
                }
            }
        }
    }
}
