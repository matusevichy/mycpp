package com.shpp.p2p.cs.amolchanov.assignment3;

import com.shpp.cs.a.console.TextProgram;

public class Assignment3Part2 extends TextProgram {
    public void run() {
        printHailstones();
    }

    /**
     * ask the user for the correct number
     * perform the main function and print The end.
     */
    private void printHailstones() {
        int EnterNumber = 0;
        while (EnterNumber <= 1) {
            EnterNumber = readInt("Enter a number: ");
        }
        Hailstones(EnterNumber);
        println("The end.");
    }

    /**
     *The loop is executed until the set number reaches one
     * If n is even, divide it by 2
     * If n is odd, multiply by 3 and add 1
     * @param EnterNumber The number entered by the user
     */
    private void Hailstones(int EnterNumber) {
        while (EnterNumber != 1) {
            if (EnterNumber % 2 == 0) {
                println(EnterNumber + " is even so I take half: " + EnterNumber / 2);
                EnterNumber = EnterNumber / 2;
            } else {
                println(EnterNumber + " is odd so I make 3n + 1: " + (EnterNumber * 3 + 1));
                EnterNumber = EnterNumber * 3 + 1;
            }
        }
    }
}
