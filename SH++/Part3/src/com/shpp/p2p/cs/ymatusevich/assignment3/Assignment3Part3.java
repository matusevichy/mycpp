package com.shpp.p2p.cs.ymatusevich.assignment3;

import java.util.Scanner;

//This program raise a number to a power
public class Assignment3Part3 {
    public static void main(String[] args) {
        startProc();
    }

    /**
     * Method get user data (base and exponent), run calculate and show getting result in console
     */
    private static void startProc() {
        double base;
        int exponent;
        Scanner scanner = new Scanner(System.in);
        System.out.print("Enter the base (double value): ");
        //Check user input
        while (!scanner.hasNextDouble()) {
            System.out.println("That`s not a double!");
            scanner.next();
        }
        base = scanner.nextDouble();
        System.out.print("Enter the exponent (integer value): ");
        //Check user input
        while (!scanner.hasNextInt()) {
            System.out.println("That`s not a integer!");
            scanner.next();
        }
        exponent = scanner.nextInt();
        System.out.println(raiseToPower(base, exponent));
    }

    /**
     * Method raise a base to an exponent
     *
     * @param base     - the double value of number for raising
     * @param exponent - the integer value for exponent
     * @return - double value result of raising to a power
     */
    private static double raiseToPower(double base, int exponent) {
        if (exponent == 0) return 1;
        double result = 1.0;
        for (int i = 0; i < ((exponent > 0) ? exponent : -1 * exponent); i++) {
            result *= base;
        }
        if (exponent < 0) result = 1.0 / result;
        return result;
    }
}
