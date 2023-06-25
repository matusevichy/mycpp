package com.shpp.p2p.cs.ypustovit.assignment2;

import com.shpp.cs.a.console.TextProgram;

import static java.lang.Math.pow;
import static java.lang.Math.sqrt;

public class Assignment2Part1 extends TextProgram {
    public void run() {
        //Here user enters coefficients a, b and c.
        double a = readDouble("Please enter coefficient a: ");
        double b = readDouble("Please enter coefficient b: ");
        double c = readDouble("Please enter coefficient c: ");
        //Edge cases when one or more coefficients equals to 0.
        if ((a == 0) || (b == 0) || (c == 0)) {
            if(((a == 0) && (b == 0) && (c == 0))||((a == 0) && (b == 0))){
                println("The equation with these coefficients is not exist. Please try again.");
            }else if (((b == 0) && (c == 0)) || ((a == 0) && (c == 0))) {
                println("There is one root: 0");
            } else if (c == 0) {
                double x1 = 0;
                double x2 = -b / a;
                println("There are two roots: " + x1 + " and " + x2);
            } else if ((b == 0) && (-c / a < 0)) {
                println("There are no real roots.");
            } else if ((b == 0) && (-c / a > 0)) {
                double x1 = sqrt(-c / a);
                double x2 = -sqrt(-c / a);
                println("There are two roots: " + x1 + " and " + x2);
            } else if (a == 0) {
                double x0 = -c / b;
                println("There is one root: " + x0);
            }
        } else {
            //Here uses method calculateDeterminant and checks how many roots quadratic equation have.
            double det = calculateDeterminant(a, b, c);
            if (det > 0) {
                double x1 = (-b - sqrt(det)) / 2 * a;
                double x2 = (-b + sqrt(det)) / 2 * a;
                println("There are two roots: " + x1 + " and " + x2);
            } else if (det == 0) {
                double x0 = -b / 2 * a;
                println("There is one root: " + x0);
            } else {
                println("There are no real roots.");
            }
        }
    }

    /**
     * This method calculates determinant of a quadratic equation.
     * a^2 * x + bx + c = 0
     * It takes coefficients a, b and c as parameters.
     */
    private double calculateDeterminant(double a, double b, double c) {
        return pow(b, 2) - 4 * a * c;
    }

}
