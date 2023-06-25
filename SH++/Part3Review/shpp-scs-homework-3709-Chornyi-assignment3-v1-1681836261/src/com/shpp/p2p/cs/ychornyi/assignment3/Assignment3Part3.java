package com.shpp.p2p.cs.ychornyi.assignment3;

import com.shpp.cs.a.console.TextProgram;

/**
 * add one variable what mean result make them 1 like the answer when degree equal 0
 */
public class Assignment3Part3 extends TextProgram {
    double result = 1;

    /**
     * add the variable base thats a number what we want to raise to a power
     * then read next number exponent which means to what power the base will be raised
     * then calculate with method raiseToPower and print the answer
     */
    public void run() {
        double base = readDouble("Enter the number you want to raise to a power: ");
        int power = readInt("Enter the degree: ");
        double answer = raiseToPower(base, power);
        println("The answer is : " + answer);
    }

    /**
     * if power bigger than 0 we from 1 to power value we multiply base by itself
     * if power smaller than 0 we do similar but power multiply by -1 and we multiply by 1 divide to base
     * and return our result, of course if power equal 0 we return 1
     */
        public double raiseToPower(double base, int power) {
            if (power > 0) {
                for (int i = 1; i <= power; i++) {
                    result *= base;
                }
            } else if (power < 0) {
                for (int i = 1; i <= (power*-1); i++) {
                    result *= 1/base;
                }
            }
            return result;
    }
}
