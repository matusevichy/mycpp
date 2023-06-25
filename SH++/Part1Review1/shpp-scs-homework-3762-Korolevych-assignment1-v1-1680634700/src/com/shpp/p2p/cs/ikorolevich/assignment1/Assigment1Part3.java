package com.shpp.p2p.cs.ikorolevich.assignment1;

import  com.shpp.karel.KarelTheRobot;

public class Assigment1Part3 extends  KarelTheRobot {
    /*
    Get ready you will now see the most difficult algorithm for solving this problem,
    it is the first that came to my mind. other easier algorithms I have already thought
    of as I wrote the code to redo it was too late
     */
    @Override
    public  void  run() throws  Exception{
        /*
        Our first check is to see if this world is not 1 cell, if it is, then we just put a beeper and finish the work
         */
        if(frontIsClear()||leftIsClear()) {
            /*
            Now get ready, we will place our beepers in a circle where it will stop
            (that is, there will be no place to put beepers) there is our center,
            our method below is responsible for this ,
            I will describe in more detail how it works in the method itself
             */
            putBeeperArroundMapAndStopAtMid();
            /*
             we go to our lower center beeper
             */
            moveToMidATSouthWall();
            /*
            we clear the line of beepers except for our middle one
             */
            cleanAllExceptMidBepper();
            /*
            turns the carrell to the top and steps forward so that it stands on the first beeper
             */
            while (notFacingNorth()) {
                turnLeft();
            }
            if (frontIsClear()) {
                move();
            }
            /*
            clears all other beepers
             */
            clearAllallOtherBeepers();
        }
        else {
            putBeeper();
        }

    }
    /*
    here he clears all the remaining beepers he goes straight
    to the wall collecting beepers if he reaches the wall he turns
    to the right if he goes straight and does not see a beeper under
     him he turns back and goes to the left and goes straight and so on until he clears this circle
     */
    private void clearAllallOtherBeepers()throws Exception {
        while (beepersPresent()){
            if(facingSouth()&&frontIsBlocked()){

            }
            else {
                pickBeeper();
            }
            if(frontIsClear()){
                move();
                if(noBeepersPresent()){
                    turnAround();
                    move();
                    turnLeft();
                    if(frontIsClear()){
                        move();
                    }
                }
            }
            else if(rightIsClear()){
                turnRight();
                move();
            }
        }
    }
    /*
        just clears all the beepers to the right and left of the center beeper
        on the line if we turned to the right then we return to the center beeper
        when we have cleared the right side if to the left then we just stop on the left in the corner
     */
    private void cleanAllExceptMidBepper() throws Exception {
        if(leftIsClear()){
            turnLeft();
            move();
           while (frontIsClear()){
               pickBeeper();
               move();
           }
           pickBeeper();
           turnAround();
           while (noBeepersPresent()){
               move();
           }
           turnLeft();
        }
        if(rightIsClear()){
            turnRight();
            move();
            while (frontIsClear()){
                pickBeeper();
                move();
            }
            pickBeeper();
        }
    }
    /*
    going down to our central beeper
     */
    private void moveToMidATSouthWall() throws Exception {
        while (notFacingSouth()){
            turnLeft();
        }
        while (frontIsClear()){
            move();
        }
    }
/*
we walk around our world and place beepers if he reaches the wall he turns right
,if he sees a beeper under him he goes back and turns left and so on until he places
the entire map in beepers where he stopped, the center is there
 */
    private void putBeeperArroundMapAndStopAtMid() throws Exception {
            while (noBeepersPresent()) {
                putBeeper();
                if (frontIsClear()) {
                    move();
                } else if (leftIsClear()) {
                    turnLeft();
                    move();
                }
                if (beepersPresent()) {
                    turnAround();
                    move();
                    turnRight();
                    if (frontIsClear()) {
                        move();
                    }
                }
            }

    }
    private void turnRight() throws Exception {
        turnLeft();
        turnLeft();
        turnLeft();
    }


    private void turnAround() throws Exception {
        turnLeft();
        turnLeft();
    }


}
