package com.shpp.p2p.cs.ymatusevich.assignment3;

import java.util.Random;

//Casino with one simple coin toss game
public class Assignment3Part5 {
    public static void main(String[] args) {
        startGame();
    }

    /**
     * Start new game with a total of $0. Game continue until the total amount is more than $20
     */
    private static void startGame(){
        int total=0;
        int count=0;
        //Loop of the current game
        while(total < 20){
            var prize = startRound();
            total += prize;
            System.out.println("This game, you earned $" + prize);
            System.out.println("Your total is $" + total);
            count++;
        }
        System.out.println("It took " + count + " games to earn $20");
    }

    /**
     * Start new round in game. Round continue until the toss coin return tails (randomizer return false).
     * @return - integer value of the round prize
     */
    private static int startRound() {
       int prize = 1;
       var randomizer = new Random();
       //Loop of the current round
       while (randomizer.nextBoolean()){
           prize *= 2;
        }
       return prize;
    }
}
