package com.shpp.p2p.cs.sivaiuk.assignment1;
import com.shpp.karel.KarelTheRobot;
public class Assigment1Part2 extends KarelTheRobot{
   public void run() throws Exception{
       while(frontIsClear()) {
           putsBeepersOnColumnAndComeBack();
           moveToTheNextColum();
       }
       // Karel puts beepers on the last column
       putsBeepersOnColumnAndComeBack();
   }
    private void moveToEndOfColumnAndPutBeepers() throws Exception{
        turnLeft();
       while(frontIsClear()) {
           if (noBeepersPresent())
               putBeeper();
           move();
       }
       if(noBeepersPresent())
       putBeeper();
    }
    private void turnRight() throws Exception{
       turnLeft();
       turnLeft();
       turnLeft();
    }
    private void moveToTheWall() throws Exception{
        while(frontIsClear())
            move();
    }
    private void moveToTheNextColum() throws Exception{
       for(int i=0;i<4;i++){
          if(frontIsClear())
              move();
       }
    }
    private void turnAround() throws Exception{
       turnLeft();
       turnLeft();
    }
    // Karel returns to where he come from
    private void returnBack() throws Exception{
       turnAround();
       moveToTheWall();
       turnLeft();
    }
    private void putsBeepersOnColumnAndComeBack() throws Exception{
        moveToEndOfColumnAndPutBeepers();
        returnBack();
    }

}
