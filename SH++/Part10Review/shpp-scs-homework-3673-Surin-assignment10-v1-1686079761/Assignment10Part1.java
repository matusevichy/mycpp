/*
 * File: Assignment10Part1.java
 * ---------------------
 * This file contains a program that evaluates a mathematical expression
 * provided as a command-line argument, along with optional variable assignments.
 */

package com.shpp.p2p.cs.vsurin.assignment10;

import java.util.HashMap;

public class Assignment10Part1 {
    /**
     * Check if the mathematical expression is provided as a command-line argument and evaluate it.
     *
     * @param args The command-line arguments passed to the program.
     */
    public static void main(String[] args) {
        // Check if the mathematical expression is provided as a command-line argument
        if (args.length < 1) {
            System.out.println("Потрібно ввести математичний вираз.");
            return;
        }

        String formula = args[0]; // Get the mathematical expression from the first argument
        HashMap<String, Double> variables = new HashMap<>(); // Create a map to store variable assignments

        // Process variable assignments from command-line arguments
        for (int i = 1; i < args.length; i++) {
            String[] parts = args[i].split("="); // Split each argument into variable and value parts
            String variable = parts[0].trim(); // Get the variable name
            double value = Double.parseDouble(parts[1]); // Get the variable value
            variables.put(variable, value); // Store the variable assignment in the map
        }

        try {
            // Call the calculate method to evaluate the formula with the provided variables
            double result = calculate(formula, variables);
            System.out.println("Результат: " + result);
        } catch (Exception e) {
            System.out.println("Помилка обчислення: " + e.getMessage());
        }
    }

    /**
     * Evaluate the given mathematical formula using the provided variables.
     *
     * @param formula   The mathematical formula to evaluate.
     * @param variables The map of variable assignments.
     * @return The result of the evaluation.
     * @throws Exception If there is an error in the evaluation.
     */
    public static double calculate(String formula, HashMap<String, Double> variables) throws Exception {
        formula = formula.replaceAll("\\s+", ""); // Remove all whitespace characters from the formula
        System.out.println(formula);
        return evaluateExpression(formula, variables); // Evaluate the expression recursively
    }

    /**
     * Evaluate the given expression recursively, considering parentheses, operators, and operands.
     *
     * @param expression The expression to evaluate.
     * @param variables  The map of variable assignments.
     * @return The result of the evaluation.
     * @throws Exception If there is an error in the evaluation.
     */
    private static double evaluateExpression(String expression, HashMap<String, Double> variables) throws Exception {
        // Split the expression into operators and operands
        char[] operators = {'+', '-', '*', '/', '^'};
        for (char operator : operators) {
            int index = findOperatorIndex(expression, operator);
            if (index != -1) {
                String leftExpr = expression.substring(0, index);
                String rightExpr = expression.substring(index + 1);

                double leftValue = evaluateExpression(leftExpr, variables);
                double rightValue = evaluateExpression(rightExpr, variables);
                System.out.println(leftValue + " " + operator  + " " + rightValue);
                return applyOperator(leftValue, rightValue, operator);
            }
        }

        // The expression is a single operand (either a number or a variable)
        if (Character.isDigit(expression.charAt(0))) {
            // The operand is a number
            return Double.parseDouble(expression);
        } else {
            // The operand is a variable
            if (variables.containsKey(expression)) {
                return variables.get(expression);
            } else {
                throw new Exception("Невідома змінна: " + expression);
            }
        }
    }

    /**
     * Find the index of the first occurrence of the operator in the expression, considering operator precedence.
     *
     * @param expression The expression to search in.
     * @param operator   The operator to find.
     * @return The index of the operator in the expression, or -1 if not found.
     */
    private static int findOperatorIndex(String expression, char operator) {
        // Find the index of the first occurrence of the operator in the expression (considering operator precedence)
        int index = -1;

        for (int i = 0; i < expression.length(); i++) {
            char c = expression.charAt(i);
            if (c == operator || c == '^') {
                index = i;
                break;
            }
        }

        if (index != -1 && operator == '-' && index > 0 && expression.charAt(index - 1) == '^') {
            // Ignore the minus sign before an exponent (a unique case for negative exponents)
            return findOperatorIndex(expression.substring(index + 1), operator) + index + 1;
        }

        return index;
    }

    /**
     * Apply the given operator to the left and right operands and return the result.
     *
     * @param leftValue  The left operand.
     * @param rightValue The right operand.
     * @param operator   The operator to apply.
     * @return The result of the operation.
     * @throws Exception If there is an error in applying the operator.
     */
    private static double applyOperator(double leftValue, double rightValue, char operator) throws Exception {
        // Apply the operator to the left and right operands
        switch (operator) {
            case '+':
                return leftValue + rightValue;
            case '-':
                return leftValue - rightValue;
            case '*':
                return leftValue * rightValue;
            case '/':
                if (rightValue == 0) {
                    throw new Exception("Ділення на нуль");
                }
                return leftValue / rightValue;
            case '^':
                return Math.pow(leftValue, rightValue);
            default:
                throw new Exception("Невідомий оператор: " + operator);
        }
    }
}
