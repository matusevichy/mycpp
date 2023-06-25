package com.shpp.p2p.cs.ymatusevich.assignment5;

import com.shpp.cs.a.console.TextProgram;

public class Assignment5Part2 extends TextProgram {
    public void run() {
        /* Sit in a loop, reading numbers and adding them. */
        while (true) {
            String n1 = readLine("Enter first number:  ");
            String n2 = readLine("Enter second number: ");
            if (n1.length() == 0 || n2.length() == 0){
                println("First and second number is required!");
                continue;
            }
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
        String result = "";
        int length = Math.max(n1.length(), n2.length());
        return sumStr(n1, n2, 0, result);
    }

    /**
     * Recursive adding numbers from strings
     * @param n1 - first string of the numbers
     * @param n2 - second string of the numbers
     * @param i - 0 if suma of previous numbers < 10 or 1 if > 10
     * @param result - suma of all previous numbers for recursive adding
     * @return current suma of numbers
     */
    private String sumStr(String n1, String n2, int i, String result) {
        int n1Length = n1.length();
        int n2Length = n2.length();
        //checking if one of two strings not empty
        if (n1Length > 0 || n2Length > 0){
            //takes last characters from strings and convert to integers
            int num1 = (n1Length > 0)? n1.charAt(n1Length - 1) - '0' : 0;
            int num2 = (n2Length > 0)? n2.charAt(n2Length - 1) - '0' : 0;
            //adding numbers from strings and a shifted number
            int sum = num1 + num2 + i;
            if (sum >= 10){
                sum = sum - 10;
                i = 1;
            }
            else {
                i = 0;
            }
            result = (char)(sum + '0') + result;
            if (n1Length > 0) n1 = n1.substring(0, n1Length -1);
            if (n2Length > 0) n2 = n2.substring(0, n2Length -1);
            //Get result from next step of recursive
            result = sumStr(n1, n2, i, result);
        }
        else if (i > 0) result = (char)(i + '0') + result;
        return result;
    }


}
