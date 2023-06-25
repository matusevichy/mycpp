package com.shpp.p2p.cs.amolchanov.assignment3;

import com.shpp.cs.a.console.TextProgram;


public class Assignment3Part5 extends TextProgram {
    private static final int MONEY_TO_WIN = 20;

    public void run() {
        casinoGame();
    }

    /**
     * the cycle is executed until the lucky guy has more than the necessary amount of money
     */
    private void casinoGame() {
        int sweaty = 1;
        //amount of money lucky
        int lucky = 0;
        //game counter
        int turn = 0;
        while (lucky < MONEY_TO_WIN) {
            //flip of a coin 1 heads 0 tails
            int tossCoin = (int) (Math.random() * 2);
            // The sweaty eagle adds exactly the same amount to the amount on the table.
            if (tossCoin == 0) {

                sweaty += sweaty;
            }
            //tails, everything on the table goes to the lucky one.
            if (tossCoin == 1) {
                println("This game, you earned $" + sweaty);
                lucky += sweaty;
                println("Your total is $" + lucky);
                //sweaty starts over with $1
                sweaty = 1;
            }
            //record each iteration
            turn++;
        }
        //output how many games it took to win
        println("It took " + turn + " games to earn $" + MONEY_TO_WIN);
    }
}
