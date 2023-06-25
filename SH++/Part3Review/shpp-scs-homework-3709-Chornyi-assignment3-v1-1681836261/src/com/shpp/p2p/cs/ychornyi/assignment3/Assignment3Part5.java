package com.shpp.p2p.cs.ychornyi.assignment3;

import acm.util.RandomGenerator;
import com.shpp.cs.a.console.TextProgram;

/**
 * add two constant for head of our coin and how many we need to win for stop playing
 * and few variables for started player money, count of games played and how many we win
 */

public class Assignment3Part5 extends TextProgram {
    private static final int HEAD = 1;
    private static final int HOW_MANY_MONEY_WIN_WE_PLAY = 20;
    int playerMoney = 0;
    int gamesPlayed = 0;
    int earnedMoney;

    /**
     * until a win not enough we play a game then print the text with the count of how many games played
     */
    public void run() {
        while (playerMoney < HOW_MANY_MONEY_WIN_WE_PLAY) {
            playAGame();
        }
        System.out.println("It took " + gamesPlayed +  " games to earn $20");
    }

    /**
     * add variable for bet its 1 in start
     * then until we won how many we want we throw up the coin (use random generator)
     * until a head we double our money raise our gamePlayed count and throw up coin again
     * if throw tail we earned the money and raise our gamePlayed count
     */
    public void playAGame() {
        int bet = 1;
        while (true) {
            RandomGenerator random = RandomGenerator.getInstance();
            int coin = random.nextInt(2);
            if (coin == HEAD) {
                bet *= 2;
            } else {
                earnedMoney = bet;
                playerMoney += earnedMoney;
                gamesPlayed++;
                System.out.println("This game, you earned $" + earnedMoney);
                System.out.println("Your total is $" + playerMoney);
                break;
            }
        }
    }
}
