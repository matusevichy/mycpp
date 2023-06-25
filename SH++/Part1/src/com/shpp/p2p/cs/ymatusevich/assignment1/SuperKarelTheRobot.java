package com.shpp.p2p.cs.ymatusevich.assignment1;

import com.shpp.karel.KarelTheRobot;

public class SuperKarelTheRobot extends KarelTheRobot {
    //Turn Karel to Right
    protected void turnRight() throws Exception {
        turnLeft();
        turnLeft();
        turnLeft();
    }

    //Turn Karel around
    protected void turnAround() throws Exception {
        turnLeft();
        turnLeft();
    }

    //Turn Karel to North
    protected void turnNorth() throws Exception {
        while (!facingNorth()){
            turnLeft();
        }
    }

    //Turn Karel to South
    protected void turnSouth() throws Exception {
        while (!facingSouth()){
            turnLeft();
        }
    }

    //Move Karel to the wall in a straight line
    protected void moveToWall() throws Exception {
        while(frontIsClear()){
            move();
        }
    }

}
