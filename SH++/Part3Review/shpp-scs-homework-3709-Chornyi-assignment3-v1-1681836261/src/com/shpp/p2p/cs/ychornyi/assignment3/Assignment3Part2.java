package com.shpp.p2p.cs.ychornyi.assignment3;

import com.shpp.cs.a.console.TextProgram;

/**
 * doesn't add a constant, just announced three variables for entered number
 * and strings whats we change whole program.
 */
public class Assignment3Part2 extends TextProgram {
 int enteredNumber;
 String forOddNumber;
 String forEvenNumber;

    /**
     * read one number and then make a magick with them
     * until it becomes a 1.
     */
    public void run() {
        enteredNumber = readInt("Enter a number: ");
        doTheMathForTheEnteredNumber();
    }

    /**
     * until entered number not a 1 we change them,
     * if number even we divide 2
     * if odd we multiply 3 and add 1
     */
    public void doTheMathForTheEnteredNumber() {
        while (enteredNumber != 1) {
            if (enteredNumber % 2 == 0) {
                forEvenNumber = enteredNumber + " is even so I take half: ";
                enteredNumber = enteredNumber / 2;
                println(forEvenNumber + enteredNumber);
            } if (enteredNumber == 1) {
                break;
            }
            if (enteredNumber % 2 != 0) {
                forOddNumber = enteredNumber + " is odd so I make 3n + 1: ";
                enteredNumber = (3 * enteredNumber) + 1;
                println(forOddNumber + enteredNumber);
            }
        }
    }
}
