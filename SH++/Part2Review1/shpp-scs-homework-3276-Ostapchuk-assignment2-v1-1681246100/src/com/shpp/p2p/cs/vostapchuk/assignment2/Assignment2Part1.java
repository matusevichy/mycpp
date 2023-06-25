package com.shpp.p2p.cs.vostapchuk.assignment2;

import com.shpp.cs.a.console.TextProgram;

/*
 * TODO: Quadratic equation
 */
public class Assignment2Part1 extends TextProgram {
    public void run() {
        /*
         *Start program
         */
        println("Write numbers");

        double a, b, c;
        double x1, x2;

        a = readInt("a: ");
        b = readInt("b: ");
        c = readInt("c: ");
        /*
         *Search Discrimenant
         */
        double Discrimenant = b * b - 4 * a * c;

        if (Discrimenant == 0) {
            x1 = (-b) / (2 * a);
            System.out.printf("There is one root: " + x1);
        } else if (Discrimenant > 0) {
            x1 = (-b + Math.sqrt(Discrimenant)) / (2 * a);
            x2 = (-b - Math.sqrt(Discrimenant)) / (2 * a);
            System.out.printf("There are two roots: " + x1 + " and " + x2);
        } else {
            System.out.println("There are no real roots");
        }
    }
}

