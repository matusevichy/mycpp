package com.shpp.p2p.cs.aholovach.assignment5;

import com.shpp.cs.a.console.TextProgram;

/* TODO: Add strings. */

public class Assignment5Part2 extends TextProgram {
    /**
     * This method adds two strings as numbers.
     *
     * @param newNum   A default number.
     * @param addDigit Additional digit.
     * @param numUp    A larger number.
     * @param numDown  A smaller number.
     * @return Sum of two numbers.
     */
    private static StringBuilder addTwoNumbers(StringBuilder newNum, int addDigit, char[] numUp, char[] numDown) {
        int digit;

        for (int i = numUp.length - 1, j = numDown.length - 1; i >= 0; i--, j--) {
            // Converting a string into a number
            digit = (numUp[i] - '0') + ((j >= 0) ? numDown[j] - '0' : 0);

            /* if the number is less than 9, then just add,
             * and if it is more, then add a number */
            if (digit > 9) {
                newNum.append((digit + addDigit) % 10);
                addDigit = digit / 10;
            } else {
                newNum.append(digit + addDigit);
                addDigit = 0;
            }
        }

        // If there are no numbers, add a number.
        if (addDigit != 0) newNum.append(addDigit);

        return newNum;
    }

    @Override
    public void run() {
        startTest();
        /* Sit in a loop, reading numbers and adding them. */
        while (true) {
            String n1 = readLine("Enter first number: ");
            String n2 = readLine("Enter second number: ");
            println(n1 + " + " + n2 + " = " + addNumericStrings(n1, n2));
            println();
        }
    }

    /**
     * This method adds two strings as numbers.
     *
     * @param n1 A string containing the firs number.
     * @param n2 A string containing the second number.
     * @return Sum of two numbers.
     */
    private String addNumericStrings(String n1, String n2) {
        // Future value of the new number
        var newNumber = new StringBuilder();
        /* The additional digit that is added to the next digit
         * and the number itself that is added. */
        int additionalDigit = 0;
        // A larger number
        char[] numberUp = ((n1.length() >= n2.length()) ? n1 : n2).toCharArray();
        // A smaller number
        char[] numberDown = ((numberUp.length == n1.length()) ? n2 : n1).toCharArray();
        // Add two strings
        var number = addTwoNumbers(newNumber, additionalDigit, numberUp, numberDown);

        return number.reverse().toString();
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
