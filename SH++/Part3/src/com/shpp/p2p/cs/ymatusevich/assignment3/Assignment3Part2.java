package com.shpp.p2p.cs.ymatusevich.assignment3;

import java.util.Scanner;

//This program calculate "Numbers-hailstones"
public class Assignment3Part2 {
    public static void main(String[] args) {
        int n = getUserNumber();
        startProcess(n);
    }

    /**
     * This method ask the number from the user for next calculate
     *
     * @return - the integer value for next calculate
     */
    private static int getUserNumber() {
        Scanner scanner = new Scanner(System.in);
        System.out.print("Enter the integer: ");
        //Check user input
        while (!scanner.hasNextInt()) {
            System.out.println("That's not a integer!");
            scanner.next();
        }
        return scanner.nextInt();
    }

    /**
     * This method start calculate in recursive until number not equiv 1 and show this process on console
     *
     * @param n - integer value for calculate
     */
    private static void startProcess(int n) {
        if (n <= 1) System.out.println("end.");
        else {
            int newN = 0;
            if (n % 2 == 0) {
                newN = n / 2;
                System.out.println(n + " is even so I take half: " + newN);
            } else {
                newN = n * 3 + 1;
                System.out.println(n + " is odd so I make 3n + 1: " + newN);
            }
            startProcess(newN);
        }
    }

}
