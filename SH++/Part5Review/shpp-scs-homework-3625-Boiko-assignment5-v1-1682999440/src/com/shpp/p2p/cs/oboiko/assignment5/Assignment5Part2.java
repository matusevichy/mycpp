package com.shpp.p2p.cs.oboiko.assignment5;

import com.shpp.cs.a.console.TextProgram;

/**
 * The Assignment5Part2 class reads two strings of numbers, sums the numbers in the strings,
 *      and displays the result on the screen.
 */
public class Assignment5Part2 extends TextProgram {
    public void run() {
        startTest();
        /* Sit in a loop, reading numbers and adding them. */
        while (true) {
            String n1 = readLine("Enter first number:  ");
            String n2 = readLine("Enter second number: ");
            println(n1 + " + " + n2 + " = " + addNumericStrings(n1, n2));
            println();
        }
    }

    /**
     * Given two string representations of nonnegative integers, adds the
     * numbers represented by those strings and returns the result.
     *
     * @param n1 The first number.
     * @param n2 The second number.
     * @return A String representation of n1 + n2
     */
    private String addNumericStrings(String n1, String n2) {
        String longNumber, shortNumber;

        /* Separates lines into longer and shorter. */
        if (n1.length() > n2.length()) {
            longNumber = n1;
            shortNumber = n2;
        } else {
            longNumber = n2;
            shortNumber = n1;
        }

        return summationNumbers(longNumber.replaceAll("\\D", ""),
                shortNumber.replaceAll("\\D", ""));
    }

    /**
     * Adds two strings of numbers and returns the answer.
     *
     * @param longNumber - a long number.
     * @param shortNumber - a short number.
     * @return sum of numbers.
     */
    private String summationNumbers(String longNumber, String shortNumber) {
        int temp, ost = 0;                                    // Auxiliary variables.
        StringBuilder result = new StringBuilder();
        int dif = longNumber.length() - shortNumber.length(); // Size difference between two strings.

        /* The number of loop iterations is taken from the longest string. */
        for (int i = longNumber.length() - 1; i >= 0; i--) {
            if (i >= dif) { // Checks the length of the smaller string.
                temp = (longNumber.charAt(i) - '0') + (shortNumber.charAt(i - dif) - '0');
            } else {
                temp = (longNumber.charAt(i) - '0');
            }

            /* Checks the number, if it is greater than 10, then displays a ten,
                    and the remainder lies in the result. */
            if (temp > 9) {
                result.insert(0, (temp % 10 + ost));
                ost = 1;
            } else {
                result.insert(0, ((temp + ost) % 10));

                if (temp + ost > 9) {
                    ost = 1;
                } else {
                    ost = 0;
                }
            }
        }

        /* If a ten remains after adding the numbers, then it is added to the beginning of the result string.*/
        if (ost == 1) result.insert(0, ost);

        return result.toString();
    }
    private void startTest(){
        check("123", "456", "579");
        check("137", "865", "1002");
        check("199", "1", "200");
        check("12345678910111213", "9876543210123", "12355555453321336");
        check("0", "0", "0");
        check("999999999999999", "999999999999999", "1999999999999998");
        check("111", "999999999999999", "1000000000000110");
    }

    private void check(String firstStr, String secondStr, String expectedResult) {
        if (addNumericStrings(firstStr, secondStr).equals(expectedResult)) {
            println("  Pass: " + firstStr + "+" + secondStr);
        } else {
            println("! FAIL: " + firstStr + "+" + secondStr);
        }
    }
}
