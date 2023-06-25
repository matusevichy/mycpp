package com.shpp.p2p.cs.yekhlopeniuk.assignment3;

import com.shpp.cs.a.console.TextProgram;

public class Assignment3Part3 extends TextProgram {

    public void run() {
        //read base, exponent and print result
        double base = readDouble("Enter the base (any number): ");
        int exponent = readInt("Enter the exponent (integer positive or negative): ");
        println(base + "^" + exponent + " is " + raiseToPower(base, exponent));
    }
    private double raiseToPower(double base, int exponent) {
        //raise base into exponent
        if (exponent == 0) return 1; //everything in 0 is 1
        int module = exponent;
        if (exponent < 0) module *= -1; //we cannot use Math, so I need to do this
        double result = base;
        for (int i = 1; i < module; i++) result = result*base; //counting result

        if (exponent < 0) result = 1/result; //counting result if exponent is <0
        return result;
    }
}
