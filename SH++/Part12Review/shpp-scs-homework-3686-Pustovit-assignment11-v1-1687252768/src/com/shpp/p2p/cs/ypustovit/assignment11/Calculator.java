package com.shpp.p2p.cs.ypustovit.assignment11;

import java.util.*;
import java.util.List;

/**
 * This class realizes calculator logic with such opportunities:
 * add, subtract, multiply, divide, calculate functions (pow, sin, cos, tan, atan, log10, log2, sqrt).
 * Also, it can read brackets and prioritize actions.
 */
public class Calculator {

    /**
     * The place where the current formula is stored.
     * It is needed to check if it's the old one and not to parse it more than one time.
     */
    private String formula = "";

    /**
     * Parsed formula into tokens, without substituted values.
     */
    private ArrayList<String> clearParsedFormula;

    /**
     * Variables, that you can add as additional parameters.
     */
    private final HashMap<String, Double> variables = new HashMap<>();

    /**
     * Supported operators.
     */
    private static final List<Character> operators = Arrays.asList('(', ')', '^', '*', '/', '+', '-');

    /**
     * The main method which calculates your expression.
     *
     * @param formula   The formula.
     * @param variables Variables that are substituted (optional)
     * @return The result of calculations.
     */
    String calculate(String formula, HashMap<String, Double> variables) {
        ArrayList<String> parts = new ArrayList<>();
        // Checks if it's the same formula.
        if (!this.formula.equals(formula)) {
            this.formula = formula;
            parseFormula(formula);
        }

        try {
            parts = substituteTheValue();
        } catch (NumberFormatException e) {
            System.out.println("You may did a mistake in writing variables! Please try again!");
        }

        variables.clear();

        calculateExpressionsBetweenBrackets(parts);
        doMathematicalOperations(parts);

        if (parts.size() > 1) {
            return parts.toString();
        }

        return parts.get(0);

    }

    /**
     * Here for each operation I take left and right numbers from operator, parse it into double and
     * calculate the result. After that I replace that numbers and operator with this result.
     * All operations go in mathematical priority.
     *
     * @param parts The parsed formula with values or it's part.
     */
    void doMathematicalOperations(ArrayList<String> parts) {
        calculateFunctions(parts);
        multiplyAndDivide(parts);
        addAndSubtract(parts);
    }

    /**
     * Searches for the last open bracket and remember its index. Then searches for the first close bracket and
     * also remember its index. Then makes a subList of an expression between brackets and calculate it.
     * Then changes this expression to the answer in the original list.
     *
     * @param parts The parsed formula with values.
     */
    void calculateExpressionsBetweenBrackets(ArrayList<String> parts) {
        int indexOfTheOpenBracket = -1;
        int indexOfTheCloseBracket = -1;
        int counter = 0;
        for (int i = 0; i < parts.size(); i++) {
            if (parts.get(i).equals("(")) {
                counter++;
            } else if (parts.get(i).equals(")")) {
                indexOfTheOpenBracket = indexOfNthElement(parts,"(",counter);
                indexOfTheCloseBracket = parts.indexOf(")");
                break;
            }
        }

        if (indexOfTheOpenBracket >= 0) {
            ArrayList<String> res = new ArrayList<>(parts.subList(indexOfTheOpenBracket + 1, indexOfTheCloseBracket));
            int size = res.size();
            doMathematicalOperations(res);
            for (int i = 0; i < size + 2; i++) parts.remove(indexOfTheOpenBracket);
            parts.add(indexOfTheOpenBracket, String.valueOf(res.get(0)));

        }
        if (!parts.contains("(")) return;
        calculateExpressionsBetweenBrackets(parts);
    }

    /**
     * Searches for a function in the list and calculate it. Then changes it to the result in the input list.
     * Recurs it until no-one function left.
     *
     * @param parts The parsed formula with values or it's part.
     */
    void calculateFunctions(ArrayList<String> parts) {
        int index = -1;
        double res = 0;
        label:
        for (String s : parts) {
            switch (s) {
                case "^":
                    index = parts.indexOf("^");
                    try {
                        res = Math.pow(Double.parseDouble(parts.get(index - 1)), Double.parseDouble(parts.get(index + 1)));
                    } catch (NumberFormatException e) {
                        System.out.println("An error occurred while raising a number to a power! " +
                                "Please check your expression and try again!");
                    }
                    break label;
                case "sin":
                    index = parts.indexOf("sin");
                    try {
                        res = Math.sin(Double.parseDouble(parts.get(index + 1)));
                    } catch (NumberFormatException e) {
                        System.out.println("An error occurred while calculating sin of a number! " +
                                "Please check your expression and try again!");
                    }
                    break label;
                case "cos":
                    index = parts.indexOf("cos");
                    try {
                        res = Math.cos(Double.parseDouble(parts.get(index + 1)));
                    } catch (NumberFormatException e) {
                        System.out.println("An error occurred while calculating cos of a number! " +
                                "Please check your expression and try again!");
                    }
                    break label;
                case "tan":
                    index = parts.indexOf("tan");
                    try {
                        res = Math.tan(Double.parseDouble(parts.get(index + 1)));
                    } catch (NumberFormatException e) {
                        System.out.println("An error occurred while calculating tan of a number! " +
                                "Please check your expression and try again!");
                    }
                    break label;
                case "atan":
                    index = parts.indexOf("atan");
                    try {
                        res = Math.atan(Double.parseDouble(parts.get(index + 1)));
                    } catch (NumberFormatException e) {
                        System.out.println("An error occurred while calculating atan of a number! " +
                                "Please check your expression and try again!");
                    }
                    break label;
                case "log10":
                    index = parts.indexOf("log10");
                    try {
                        res = Math.log10(Double.parseDouble(parts.get(index + 1)));
                    } catch (NumberFormatException e) {
                        System.out.println("An error occurred while calculating log10 of a number! " +
                                "Please check your expression and try again!");
                    }
                    break label;
                case "log2":
                    index = parts.indexOf("log2");
                    try {
                        res = Math.log(Double.parseDouble(parts.get(index + 1))) / Math.log(2);
                    } catch (NumberFormatException e) {
                        System.out.println("An error occurred while calculating log2 of a number! " +
                                "Please check your expression and try again!");
                    }
                    break label;
                case "sqrt":
                    index = parts.indexOf("sqrt");
                    try {
                        res = Math.sqrt(Double.parseDouble(parts.get(index + 1)));
                    } catch (NumberFormatException e) {
                        System.out.println("An error occurred while calculating sqrt of a number! " +
                                "Please check your expression and try again!");
                    }
                    break label;
            }
        }
        if ((index >= 0) && (parts.get(index).equals("^"))) {
            for (int i = 0; i < 3; i++) parts.remove(index - 1);
            parts.add(index - 1, String.valueOf(res));
        } else if (index >= 0) {
            for (int i = 0; i < 2; i++) parts.remove(index);
            parts.add(index, String.valueOf(res));
        }
        if (!parts.contains("^")) return;
        calculateFunctions(parts);
    }

    /**
     * Run through expression and multiply or divide all numbers between which he finds operators * or /.
     *
     * @param parts The parsed formula with values or it's part.
     */
    void multiplyAndDivide(ArrayList<String> parts) {
        int index = -1;
        double res = 0;
        for (String s : parts) {
            if (s.equals("*")) {
                index = parts.indexOf("*");
                try {
                    res = Double.parseDouble(parts.get(index - 1)) * Double.parseDouble(parts.get(index + 1));
                } catch (NumberFormatException e) {
                    System.out.println("An error occurred while multiplying two numbers! " +
                            "Please check your expression and try again!");
                }
                break;
            } else if (s.equals("/")) {
                index = parts.indexOf("/");
                try {
                    res = Double.parseDouble(parts.get(index - 1)) / Double.parseDouble(parts.get(index + 1));
                } catch (NumberFormatException e) {
                    System.out.println("An error occurred while dividing two numbers! " +
                            "Please check your expression and try again!");
                }
                break;
            }
        }
        if (index >= 0) {
            for (int i = 0; i < 3; i++) parts.remove(index - 1);
            parts.add(index - 1, String.valueOf(res));
        }
        if (!parts.contains("*") && !parts.contains("/")) return;
        multiplyAndDivide(parts);
    }

    /**
     * Run through expression and add or subtract all numbers between which he finds operators + or -.
     *
     * @param parts The parsed formula with values or it's part.
     */
    void addAndSubtract(ArrayList<String> parts) {
        int index = -1;
        double res = 0;
        for (String s : parts) {
            if (s.equals("+")) {
                index = parts.indexOf("+");
                try {
                    res = Double.parseDouble(parts.get(index - 1)) + Double.parseDouble(parts.get(index + 1));
                } catch (NumberFormatException e) {
                    System.out.println("An error occurred while adding two numbers! " +
                            "Please check your expression and try again!");
                }
                break;
            } else if (s.equals("-")) {
                index = parts.indexOf("-");
                try {
                    res = Double.parseDouble(parts.get(index - 1)) - Double.parseDouble(parts.get(index + 1));
                } catch (NumberFormatException e) {
                    System.out.println("An error occurred while subtracting two numbers! " +
                            "Please check your expression and try again!");
                }
                break;
            }
        }
        if (index >= 0) {
            for (int i = 0; i < 3; i++) parts.remove(index - 1);
            parts.add(index - 1, String.valueOf(res));
        }
        if (!parts.contains("+") && !parts.contains("-")) return;
        addAndSubtract(parts);
    }

    /**
     * Parse formula in principle separate digits and operators, except negative numbers.
     *
     * @param formula The actual formula.
     */
    void parseFormula(String formula) {
        formula = formula.replaceAll(" ", "");
        clearParsedFormula = new ArrayList<>();
        int index = 0;
        // For edge case, when two minuses go in a row, for example 2-x-3
        boolean firstMinus = true;
        for (int i = 0; i < formula.length(); i++) {
            char ch = formula.charAt(i);
            char nextCh;
            try {
                nextCh = formula.charAt(i + 1);
            } catch (StringIndexOutOfBoundsException e) {
                nextCh = ' ';
            }

            for (char c : operators) {
                if (ch == c) {
                    // If first number is negative.
                    if ((i == 0) && (ch == '-')) {
                        firstMinus = false;
                        continue;
                    }

                    if (!firstMinus) {
                        clearParsedFormula.add(formula.substring(index, formula.indexOf(ch, index + 1)));
                        index = formula.indexOf(ch, index + 1) + 1;
                        firstMinus = true;
                    } else {
                        clearParsedFormula.add(formula.substring(index, formula.indexOf(ch, index)));
                        index = formula.indexOf(ch, index) + 1;
                    }
                    clearParsedFormula.add(String.valueOf(ch));
                    // For negative numbers
                    if (nextCh == '-') {
                        firstMinus = false;
                        i++;
                    }
                }
            }
        }
        clearParsedFormula.add(formula.substring(index));
        clearParsedFormula.removeIf(s -> s.equals(""));
    }

    /**
     * Parse variables into a HashMap<String, Double>, where key is the name of the variable.
     *
     * @param variable String with name and value of the variable. For example "a=2"
     */
    void parseVariables(String variable) {
        variable = variable.replaceAll(" ", "");
        int index = variable.indexOf("=");
        String k = variable.substring(0, index);
        Double v = Double.parseDouble(variable.substring(index + 1));
        this.variables.put(k, v);
    }

    /**
     * Substitutes values of the variables into the formula.
     */
    ArrayList<String> substituteTheValue() {
        Set<String> keys = variables.keySet();
        ArrayList<String> formulaWithValues = new ArrayList<>(clearParsedFormula);
        for (String s : formulaWithValues) {
            for (String k : keys) {
                if (s.equals(k)) {
                    formulaWithValues.set(formulaWithValues.indexOf(s), String.valueOf(variables.get(k)));
                } else if (s.equals("-" + k)) {
                    if (String.valueOf(variables.get(k)).startsWith("-")) {
                        formulaWithValues.set(formulaWithValues.indexOf(s),
                                String.valueOf(variables.get(k)).substring(1));
                    } else {
                        formulaWithValues.set(formulaWithValues.indexOf(s), "-" + variables.get(k));
                    }

                }
            }
        }
        return formulaWithValues;
    }

    /**
     *  Finds element in ArrayList with specified sequence number.
     *
     * @param arrayList ArrayList where we search for the needed element on specific position.
     * @param el The needed element.
     * @param sequenceNumber The sequence number of the element.
     * @return Index of the needed element on specific position.
     */
    public int indexOfNthElement(ArrayList<String> arrayList, String el, int sequenceNumber) {
        int index = -1;
        int counter = 0;
        for (int i = 0; i < arrayList.size(); i++) {
            if (arrayList.get(i).equals(el)) {
                counter++;
            }
            if (sequenceNumber == counter) {
                index = i;
                break;
            }
        }

        return index;
    }

    // getters
    HashMap<String, Double> getVariables() {
        return variables;
    }

    ArrayList<String> getClearParsedFormula() {
        return clearParsedFormula;
    }

    String getFormula() {
        return formula;
    }
}