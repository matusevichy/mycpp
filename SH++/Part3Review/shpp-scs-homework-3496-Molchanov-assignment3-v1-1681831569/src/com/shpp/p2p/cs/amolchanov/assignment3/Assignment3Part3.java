package com.shpp.p2p.cs.amolchanov.assignment3;

import com.shpp.cs.a.console.TextProgram;

public class Assignment3Part3 extends TextProgram {
    public void run() {
        println(raiseToPower(-5, -3));
    }

    /**
     * method for exponentiation
     * @param base     the number to be raised to a power
     * @param exponent the degree to which we put the number
     * @return the answer is a number raised to a power
     */
    private double raiseToPower(double base, int exponent) {
        double x = 1;
        //If the degree is negative make it positive and divide the answer by 1
        int exponents = (exponent > 0) ? exponent : -exponent;
        for (int i = 0; i < exponents; i++) {
            x *= base;
        }
        if (exponent < 0) {
            x = 1 / x;
        }
        if (exponent == 0) {
            return 1;
        }
        return x;
    }
}
