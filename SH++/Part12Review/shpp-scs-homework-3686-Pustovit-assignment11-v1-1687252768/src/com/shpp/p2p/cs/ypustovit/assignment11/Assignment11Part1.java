package com.shpp.p2p.cs.ypustovit.assignment11;

public class Assignment11Part1 {

    /**
     * Calculates given expressions.
     *
     * @param args First argument is the formula, others are variable, which are optional.
     */
    public static void main(String[] args) {

        Calculator calc = new Calculator();

        args = new String[3];
        args[0] = "(2+z)^-y+(1-(y+z*tan(-z)))*23-89+(z-y)";
        args[1] = "z=3";
        args[2] = "y=8.987";


        for (int i = 1; i < args.length; i++) {
            calc.parseVariables(args[i]);
        }
        System.out.println(calc.calculate(args[0], calc.getVariables()));


        args = new String[2];
        args[0] = "1+(2+3*(4+5-sin(45*cos(a))))/7";
        args[1] = "a=3";

        for (int i = 1; i < args.length; i++) {
            calc.parseVariables(args[i]);
        }
        System.out.println(calc.calculate(args[0], calc.getVariables()));

        args = new String[1];
        args[0] = "(1+3)*(2+2)";
        System.out.println(calc.calculate(args[0], calc.getVariables()));

    }


}