/*
 * File: Assignment10Part1.java
 * ---------------------
 * This file contains a program that evaluates a mathematical expression
 * provided as a command-line argument, along with optional variable assignments.
 */

package com.shpp.p2p.cs.vsurin.assignment10;

import java.util.HashMap;

public class Assignment10Part1 {
    private static String formula; // Store the formula for subsequent processing

    /**
     * Check if the mathematical expression is provided as a command-line argument and evaluate it.
     *
     * @param args The command-line arguments passed to the program.
     */
    public static void main(String[] args) {
        if (args.length < 1) {
            System.out.println("Please enter a mathematical expression.");
            return;
        }

        formula = args[0];
        HashMap<String, Double> variables = new HashMap<>();

        // Process variable assignments
        for (int i = 1; i < args.length; i++) {
            String[] parts = args[i].split("=");
            String variable = parts[0].trim();
            double value = Double.parseDouble(parts[1]);
            variables.put(variable, value);
        }

        try {
            // Calculate the result of the formula
            double result = calculate(formula, variables);
            System.out.println("Result: " + result);
        } catch (Exception e) {
            System.out.println("Calculation error: " + e.getMessage());
        }
    }

    /**
     * Evaluates a mathematical formula along with variable assignments.
     *
     * @param formula   The mathematical formula to evaluate.
     * @param variables The map of variable assignments.
     * @return The result of the formula evaluation.
     * @throws Exception If there is an error in the formula or variable assignments.
     */
    public static double calculate(String formula, HashMap<String, Double> variables) throws Exception {
        // Remove whitespace from the formula
        formula = formula.replaceAll("\\s+", "");
        return evaluateExpression(formula, variables);
    }

    /**
     * Evaluates an expression recursively.
     *
     * @param expression The expression to evaluate.
     * @param variables  The map of variable assignments.
     * @return The result of the expression evaluation.
     * @throws Exception If there is an error in the expression or variable assignments.
     */
    private static double evaluateExpression(String expression, HashMap<String, Double> variables) throws Exception {
        int nextOperatorIndex = findNextOperatorIndex(expression);

        // Base case: If no operator is found, parse the operand
        if (nextOperatorIndex == -1) {
            return parseOperand(expression, variables);
        } else {
            char operator = expression.charAt(nextOperatorIndex);

            // Split the expression into left and right parts based on the operator
            String leftExpr = expression.substring(0, nextOperatorIndex);
            String rightExpr = expression.substring(nextOperatorIndex + 1);

            // Evaluate the left and right expressions recursively
            double leftValue = evaluateExpression(leftExpr, variables);
            double rightValue = evaluateExpression(rightExpr, variables);

            // Perform the corresponding operation based on the operator
            if (operator == '+') {
                return leftValue + rightValue;
            } else if (operator == '-') {
                return leftValue - rightValue;
            } else if (operator == '*') {
                return leftValue * rightValue;
            } else if (operator == '/') {
                if (rightValue == 0) {
                    throw new Exception("Division by zero");
                }
                return leftValue / rightValue;
            } else {
                return Math.pow(leftValue, rightValue);
            }
        }
    }

    /**
     * Finds the index of the next operator in the expression.
     *
     * @param expression The expression to search for operators.
     * @return The index of the next operator, or -1 if no operator is found.
     */
    private static int findNextOperatorIndex(String expression) {
        int nextPlusIndex = expression.indexOf('+');
        int nextMinusIndex = expression.indexOf('-', 1);
        int nextMultiplicationIndex = expression.indexOf('*');
        int nextDivisionIndex = expression.indexOf('/');
        int nextExponentIndex = expression.indexOf('^');

        // Find the smallest index among the operators
        int nextOperatorIndex = -1;

        if (nextPlusIndex != -1) {
            nextOperatorIndex = nextPlusIndex;
        }
        if (nextMinusIndex != -1 && (nextOperatorIndex == -1 || nextMinusIndex < nextOperatorIndex)) {
            nextOperatorIndex = nextMinusIndex;
        }
        if (nextMultiplicationIndex != -1 && (nextOperatorIndex == -1 || nextMultiplicationIndex < nextOperatorIndex)) {
            nextOperatorIndex = nextMultiplicationIndex;
        }
        if (nextDivisionIndex != -1 && (nextOperatorIndex == -1 || nextDivisionIndex < nextOperatorIndex)) {
            nextOperatorIndex = nextDivisionIndex;
        }
        if (nextExponentIndex != -1 && (nextOperatorIndex == -1 || nextExponentIndex < nextOperatorIndex)) {
            nextOperatorIndex = nextExponentIndex;
        }

        return nextOperatorIndex;
    }

    /**
     * Parses an operand from the expression.
     *
     * @param expression The expression containing the operand.
     * @param variables  The map of variable assignments.
     * @return The parsed operand value.
     * @throws Exception If there is an error in the operand or variable assignments.
     */
    private static double parseOperand(String expression, HashMap<String, Double> variables) throws Exception {
        if (expression.startsWith("-")) {
            if (expression.length() == 1) {
                throw new Exception("Invalid expression: " + expression);
            } else {
                return -parseOperand(expression.substring(1), variables);
            }
        } else if (Character.isDigit(expression.charAt(0)) || expression.charAt(0) == '.') {
            return Double.parseDouble(expression.replace(',', '.'));
        } else {
            if (variables.containsKey(expression)) {
                return variables.get(expression);
            } else {
                throw new Exception("Unknown variable: " + expression);
            }
        }
    }

    /**
     * Gets the stored formula.
     *
     * @return The stored formula.
     */
    public static String getFormula() {
        return formula;
    }
}
