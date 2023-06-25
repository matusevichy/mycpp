package com.shpp.p2p.cs.sivaiuk.assignment1;
import com.shpp.karel.KarelTheRobot;

public class Assigment1Part3 extends KarelTheRobot {
    public void run() throws Exception {
        if(frontIsClear()) {
            //Put the first beeper
            putBeeper();
            move();

            moveToEndLineAndPutBeeper();
// Karel turn around and move on the next cell
            turnAround();
            move();

            while (noBeepersPresent()) {
                returnBackAndPutBeeperOnNextCell();
                move();
                if(noBeepersPresent()){
                    moveForwardAndPutBeeperOnTheNextCell();
                    move();
                }
            }
// Karel come back in centre
            turnAround();
            move();
            while(notFacingSouth())
                turnLeft();
            cleanAllWithoutCentralBeeper();

        }
        else{
            putBeeper();
        }
    }

        private void turnRight () throws Exception {
            turnLeft();
            turnLeft();
            turnLeft();
        }
        private void turnAround () throws Exception {
            turnLeft();
            turnLeft();
        }
        private void moveToEndLineAndPutBeeper () throws Exception {
            while (frontIsClear()) {
                if (noBeepersPresent())
                    move();
            }
            putBeeper();
        }

        private void returnBackAndPutBeeperOnNextCell () throws Exception {
            while (noBeepersPresent())
                move();
            turnAround();
            while (beepersPresent())
                move();
            putBeeper();
        }
        private void moveForwardAndPutBeeperOnTheNextCell () throws Exception {
            move();
            while (noBeepersPresent()) {
                move();
            }
            turnAround();
            while (beepersPresent()) {
                move();
            }
            putBeeper();
        }
       private void cleanAllWithoutCentralBeeper() throws Exception {
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
    }

