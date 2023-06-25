package com.shpp.p2p.cs.ymatusevich.assignment2;

import java.util.Scanner;

/**
 * Compute are roots of the quadratic equation using discriminant
 */
public class Assignment2Part1 {
    public static void main(String[] args) {
        double a,b,c,d;
        //Get data from user
        Scanner scanner = new Scanner(System.in);
        System.out.print("Please enter a: ");
        a = scanner.nextDouble();
        System.out.print("Please enter b: ");
        b = scanner.nextDouble();
        System.out.print("Please enter c: ");
        c = scanner.nextDouble();

        d = computeDiscriminant(a, b, c);
        if (d < 0){
            System.out.println("There are no real roots");
        }
        else {
            double[] roots = computeRoots(a, b, d);
            if (d == 0) {
                System.out.println("There is one root: " + roots[0]);
            } else {
                System.out.println("There are two roots: " + roots[0] + " and " + roots[1]);
            }
        }
    }

    /**Return calculated discriminant of a quadratic equation
    *@Params a,b,c - are double values of a equation for compute discriminant
    *@Result - the double value of the computed discriminant
    */
    private static double computeDiscriminant(double a, double b, double c){
        return Math.pow(b, 2) - 4 * a * c;
    }

    /**
    *Return array of the calculated roots of a quadratic equation
    *@Params a,b - are double values of a equation;
    *@Param d -  the double value to discriminant of a quadratic equation
    *Result - the array of a double values with roots of a quadratic equation
    */
    private static double[] computeRoots(double a, double b, double d){
        double[] roots = new double[2];
        roots[0] = (-b + Math.sqrt(d)) / (2 * a);
        roots[1] = (-b - Math.sqrt(d)) / (2 * a);
        return roots;
    }
}
