package com.shpp.p2p.cs.rivaskevych.assignment5;

import com.shpp.cs.a.console.TextProgram;

public class AlgorismAlgorithms extends TextProgram {
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
     * Given two string representations of no negative integers, adds the
     * numbers represented by those strings and returns the result.
     *
     * @param n1 The first number.
     * @param n2 The second number.
     * @return A String representation of n1 + n2
     */
    private String addNumericStrings(String n1, String n2) {
        StringBuilder result = new StringBuilder();
        int carry = 0;
        int i = n1.length() - 1;
        int j = n2.length() - 1;
        while (i >= 0 || j >= 0 || carry > 0) {
            int digit1 = i >= 0 ? n1.charAt(i) - '0' : 0;
            int digit2 = j >= 0 ? n2.charAt(j) - '0' : 0;
            int sum = digit1 + digit2 + carry;
            result.append(sum % 10);
            carry = sum / 10;
            i--;
            j--;
        }
        return result.reverse().toString();
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
