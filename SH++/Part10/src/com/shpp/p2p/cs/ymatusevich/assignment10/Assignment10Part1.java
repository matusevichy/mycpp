package com.shpp.p2p.cs.ymatusevich.assignment10;

import java.util.HashMap;
import java.util.Map;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

/**
 * Calculator for calculating arithmetical expression. Program take minimum one argument - expression for calculating.
 * If the expression contain variable(s), they are passed in other arguments in format "variable=number"
 * Operators allowed for expression - -, +, /, *, ^
 */
public class Assignment10Part1 {
    //Patterns for parsing variable and value
    private final static String VARIABLE_PARSE_PATTERN = "([a-zA-Z]+)\\s*(=){1}\\s*([-]?\\d[.]?\\d*)";
    //Patterns for parsing high priority action (multiplication and division)
    private final static String HI_PRIORITY_PARSE_PATTERN = "((?:^[-])?\\d+[.]?\\d*)+\\s*([*/]){1}\\s*([-]?\\d+[.]?\\d*)";
    //Patterns for parsing low priority action (sum and difference)
    private final static String LOW_PRIORITY_PARSE_PATTERN = "((?:^[-])?\\d+[.]?\\d*)+\\s*([+-]){1}\\s*([-]?\\d+[.]?\\d*)";
    //Patterns for parsing exponentiation
    private final static String POW_PARSE_PATTERN = "((?:^[-])?\\d+[.]?\\d*)+\\s*([\\^]){1}\\s*([-]?\\d+[.]?\\d*)(?=[^\\^]|$)";
    //Structure for saving calculate results some expressions, for using they in other calculating
    private static final Map<String, Double> resultsMap = new HashMap<>();

    public static void main(String[] args) {
        if (args.length == 0) System.out.println("Not present an expression for calculating");
        else {
            String formula = prepareFormula(args);
            if (!formula.isEmpty()) {
                System.out.println(calculate(formula));
            } else {
                System.out.println("Wrong parameters. Calculation is not possible");
            }
        }
    }

    /**
     * Calculates expression
     * @param formula string with prepared expression for calculating
     * @return calculating result
     */
    private static Double calculate(String formula) {
        Double result;
        System.out.println(formula);
        String originalFormula = formula;
        if (resultsMap.containsKey(formula)) {
            result = resultsMap.get(formula);
        } else {
            //calculate exponentiation and put result to expression
            while (formula.contains("^")) {
                formula = calculateWithPattern(formula, POW_PARSE_PATTERN);
            }
            //calculate high priority action and put result to expression
            while (formula.matches(".+[*/].+")) {
                formula = calculateWithPattern(formula, HI_PRIORITY_PARSE_PATTERN);
            }
            //calculate low priority action and put result to expression
            while (formula.matches(".+[+-].+")) {
                formula = calculateWithPattern(formula, LOW_PRIORITY_PARSE_PATTERN);
            }
            result = Double.parseDouble(formula);
            //save expression and calculating result
            resultsMap.put(originalFormula, result);
        }
        return result;
    }

    /**
     * Calculates some action and put result to expression
     * @param formula string with expression for calculating
     * @param patternString regular expression for parsing some action
     * @return expression with calculated action
     */
    private static String calculateWithPattern(String formula, String patternString) {
        Pattern pattern = Pattern.compile(patternString);
        Matcher matcher = pattern.matcher(formula);
        double result = 0.0;
        if (matcher.find()) {
            if (resultsMap.containsKey(matcher.group(0))) {
                result = resultsMap.get(matcher.group(0));
            } else {
                switch (matcher.group(2)) {
                    case "*" -> result = Double.parseDouble(matcher.group(1)) * Double.parseDouble(matcher.group(3));
                    case "/" -> {
                        try {
                            result = Double.parseDouble(matcher.group(1)) / Double.parseDouble(matcher.group(3));
                        } catch (ArithmeticException e) {
                            return e.getMessage();
                        }
                        if (Double.isInfinite(result)) {
                            System.out.println("Division by zero!");
                            return "0";
                        }
                    }
                    case "+" -> result = Double.parseDouble(matcher.group(1)) + Double.parseDouble(matcher.group(3));
                    case "-" -> result = Double.parseDouble(matcher.group(1)) - Double.parseDouble(matcher.group(3));
                    case "^" ->
                            result = Math.pow(Double.parseDouble(matcher.group(1)), Double.parseDouble(matcher.group(3)));
                }
                //save expression and calculating result
                resultsMap.put(matcher.group(0), result);
            }
            formula = formula.replace(matcher.group(0), Double.toString(result));
        }
        return formula;
    }

    /**
     * Preparing arithmetic expression for calculating. Replacing all variables with values
     * @param args array of arguments (expression and variables with value)
     * @return prepared expression for calculate
     */
    private static String prepareFormula(String[] args) {
        String formula = args[0].replaceAll(" ", "");
        //Checks if expression contain variable(s)
        if (formula.matches(".*[a-zA-Z].*")) {
            //If arguments are exist
            if (args.length > 1) {
                Pattern pattern = Pattern.compile(VARIABLE_PARSE_PATTERN);
                for (int i = 1; i < args.length; i++) {
                    Matcher matcher = pattern.matcher(args[i]);
                    if (matcher.find()) {
                        //Replaces variable(s) with value(s)
                        formula = formula.replaceAll(matcher.group(1), matcher.group(3));
                    } else {
                        System.out.println("Argument " + i + " incorrect!");
                    }
                }
            } else {
                formula = "";
                System.out.println("Error! Expression has variables but parameters are absent for they!");
            }
        }
        if (formula.matches(".*[a-zA-Z].*")) {
            formula = "";
            System.out.println("Error! Expression has variables but not all parameters is set for they!");
        }
        return formula;
    }


}
