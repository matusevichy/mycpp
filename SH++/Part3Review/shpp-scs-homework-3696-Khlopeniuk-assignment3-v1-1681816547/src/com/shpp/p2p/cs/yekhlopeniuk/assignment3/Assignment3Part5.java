package com.shpp.p2p.cs.yekhlopeniuk.assignment3;

import acm.util.RandomGenerator;
import com.shpp.cs.a.console.TextProgram;

public class Assignment3Part5 extends TextProgram {
    //static to format text
    public static final String BLUE = "\u001B[34m";
    public static final String RESET = "\u001B[0m";
    public static final String GREEN = "\u001B[32m";
    public static final String RED = "\u001B[31m";
    RandomGenerator gen = RandomGenerator.getInstance(); //create random generator

    public void run() {
        /* make round of game until my gain become 20$ or more
        print every game number and result */

        int gain = 0; //how much money I win
        int gameNumber = 1; //count games quantity
        while (gain < 20) {
            print(BLUE + "Game " + gameNumber + ": " + RESET);
            gain += playRound();
            print("Your total is " + RED + gain + "$" + RESET);
            println();
            gameNumber ++;
        }
        println();
        //print result
        println("It took " + RED + gameNumber + RESET + " games and You win " + RED + gain + "$");
    }
    private int playRound() {
        /* one round of tрe game
        toss a coin until tail heads up */

        boolean coin = true; //at least one round should be played
        //true - eagle, toss one more time
        //false - tails, end of the game
        int moneyOnTable = 1; //the gain at current round
        print(GREEN + moneyOnTable + "$; " + RESET); //we begin from 1$
        while (coin) {
            coin = gen.nextBoolean(0.5); //toss a coin
            //eagle
            if (coin) {
                moneyOnTable *= 2;
                print("Eagle => " + GREEN + moneyOnTable + "$; " + RESET);
            }
            //tail
            else print("Tail => ");
        }
        return moneyOnTable;
    }
}
