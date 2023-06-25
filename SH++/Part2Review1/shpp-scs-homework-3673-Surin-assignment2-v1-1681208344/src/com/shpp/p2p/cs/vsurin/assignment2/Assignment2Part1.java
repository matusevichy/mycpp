/**
 * File: Assignment2Part1.java
 * --------------------------------
 * This program calculates the roots of a quadratic equation using the quadratic formula. The user is prompted
 * to enter values for a, b, and c, and the program calculates the roots and displays them to the user.
 */

package com.shpp.p2p.cs.vsurin.assignment2;

import com.shpp.cs.a.console.TextProgram;

public class Assignment2Part1 extends TextProgram {
    public void run() {
        // Read in values for a, b, and c from the user
        double a = readInt("Please enter a:");
        double b = readInt("Please enter b:");
        double c = readInt("Please enter c:");

        // Calculate the discriminant
        double delta = b * b - 4 * a * c;

        // Check whether there are any real roots
        if (delta < 0) {
            // If the discriminant is negative, there are no real roots
            println("There are no real roots");
        } else if (delta == 0) {
            // If the discriminant is zero, there is one real root
            double root = -b / (2 * a);
            println("There is one root: " + root);
        } else {
            // If the discriminant is positive, there are two real roots
            double root1 = (-b + Math.sqrt(delta)) / (2 * a);
            double root2 = (-b - Math.sqrt(delta)) / (2 * a);
            println("There are two roots: " + root1 + " and " + root2);
        }
    }
}
