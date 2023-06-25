package com.shpp.p2p.cs.ymatusevich.assignment11;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.HashMap;
import java.util.Stack;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

/**
 * The program an advanced calculator for calculating arithmetic expressions with brackets and functions
 */
public class Assignment11Part1 {
    //Regular expression for arithmetic parsing expression string
    private static final String PARSER_EXPRESSION_PATTERN = "log10|log2|sqrt|atan|tan|cos|sin|" +
            "(?:(?<=^)[-])?\\d+[.,]?\\d*|(?:(?<=[\\^*\\/(])[-])?\\d+[.,]?\\d*|" +
            "(?:(?<=^)[-])?[A-Za-z]+|(?:(?<=[\\^*\\/])[-])?[A-Za-z]+|[+-^\\/*\\(\\)]";
    //Array with functions name
    private static final String[] FUNCTIONS = new String[]{"log10", "log2", "sqrt", "atan", "tan", "cos", "sin"};
    //Collection with operators and they priorities
    private static final HashMap<String, Integer> OPERATORS = new HashMap<>() {{
        put("+", 0);
        put("-", 0);
        put("*", 1);
        put("/", 1);
        put("^", 2);
    }};
    //Collection with operators, functions and methods for calculate they
    private static final HashMap<String, IAction> ACTIONS = new HashMap<>() {{
        put("+", (Double::sum));
        put("-", ((leftNumber, rightNumber) -> leftNumber - rightNumber));
        put("*", ((leftNumber, rightNumber) -> leftNumber * rightNumber));
        put("/", ((leftNumber, rightNumber) -> {
            Double v = leftNumber / rightNumber;
            if (v.isInfinite()) {
                System.out.println("Division by zero!");
            }
            return v;
        }));
        put("^", (Math::pow));
        put("log10", ((leftNumber, rightNumber) -> {
            Double v = Math.log10(leftNumber);
            if (v.isInfinite() || v.isNaN()) {
                System.out.println("Function log10 returned " + v);
            }
            return v;
        }));
        put("log2", ((leftNumber, rightNumber) -> {
            Double v = Math.log10(leftNumber) / Math.log10(2);
            if (v.isInfinite() || v.isNaN()) {
                System.out.println("Function log2 returned " + v);
            }
            return v;
        }));
        put("sqrt", ((leftNumber, rightNumber) -> {
            Double v = Math.sqrt(leftNumber);
            if (v.isInfinite() || v.isNaN()) {
                System.out.println("Function sqrt returned " + v);
            }
            return v;
        }));
        put("atan", ((leftNumber, rightNumber) -> {
            Double v = Math.atan(leftNumber);
            if (v.isInfinite() || v.isNaN()) {
                System.out.println("Function atan returned " + v);
            }
            return v;
        }));
        put("tan", ((leftNumber, rightNumber) -> {
            Double v = Math.tan(Math.toRadians(leftNumber));
            if (v.isInfinite() || v.isNaN()) {
                System.out.println("Function tan returned " + v);
            }
            return v;
        }));
        put("cos", ((leftNumber, rightNumber) -> {
            Double v = Math.cos(Math.toRadians(leftNumber));
            if (v.isInfinite() || v.isNaN()) {
                System.out.println("Function cos returned " + v);
            }
            return v;
        }));
        put("sin", ((leftNumber, rightNumber) -> {
            Double v = Math.sin(Math.toRadians(leftNumber));
            if (v.isInfinite() || v.isNaN()) {
                System.out.println("Function sin returned " + v);
            }
            return v;
        }));
    }};

    public static void main(String[] args) {
        //Set the expression
        if (args.length == 0) System.out.println("Not present an expression for calculating");
        else {
            var formula = args[0];
            var tree = makeTree(formula);
            //Set the array of the variables
            HashMap<String, Double> arguments = getVariablesMap(args);
            Double result = calculate(tree, arguments);
            System.out.println(result);
        }
    }

    /**
     * Gets all variables and they values from arguments
     * @param args array of arguments
     * @return collection of variables and they values
     */
    private static HashMap<String, Double> getVariablesMap(String[] args) {
        HashMap<String, Double> variables = new HashMap<>();
        for (int i = 1; i < args.length; i++) {
            //Parse argument to pair of variable and value
            var pair = args[i].split("=");
            String key = pair[0].trim();
            Double value = null;
            try {
                value = Double.parseDouble(pair[1].trim());
            } catch (Exception e) {
                System.out.println("Error! Value for variable \"" + key + "\" incorrect!");
            }
            variables.put(key, value);
        }
        return variables;
    }

    /**
     * Recursive calculates expression tree using array of the variables values
     *
     * @param tree      expressions tree
     * @param arguments array of the variables and they values
     * @return double result of the expression calculating
     */
    private static Double calculate(Node tree, HashMap arguments) {
        if (tree == null) return Double.NaN;
        Double result = 0.0;
        var value = tree.getValue();
        //If node of the tree is variable replace him on his value
        if (isVariable(value)) {
            Double data = (Double) arguments.get(value);
            if (data == null) {
                System.out.println("Argument for variable " + value + " is not present! Boom!!!");
                return Double.NaN;
            } else {
                result = data;
            }
        }
        //If node is operator or function recursive calculates expression using  ACTIONS collection
        if (isOperator(value) || isFunction(value)) {
            Double leftNumber = calculate(tree.getLeftNode(), arguments);
            Double rightNumber = calculate(tree.getRightNode(), arguments);
            result = ACTIONS.get(value).calculate(leftNumber, rightNumber);
            if (result.isInfinite() || result.isNaN()) {
                return result;
            }
        }
        //If node is number returns him
        if (isNumeric(value)) {
            result = Double.parseDouble(value);
        }
        return result;
    }

    /**
     * Makes an expressions tree from string
     *
     * @param formula string of arithmetic expression
     * @return root node of the tree
     */
    private static Node makeTree(String formula) {
        var parseResult = parse(formula);
        if (parseResult.size() == 0) {
            System.out.println("Wrong formula!");
            return null;
        }
        var rpn = makeRPN(parseResult);
        if (rpn == null) return null;
        //Parse RPN string to collection
        ArrayList<String> strings = new ArrayList<>(Arrays.stream(rpn.split(" ")).toList());
        Stack<Node> stack = new Stack<>();
        //Build expressions tree in loop
        for (String str : strings) {
            //If element is number push to the stack
            if (isNumeric(str) || isVariable(str)) stack.push(new Node(str));
            //If element is operator get two elements from the stack, create new node with children elements
            // and push to the stack
            if (isOperator(str)) {
                Node rightNode = stack.pop();
                Node leftNode = stack.pop();
                stack.push(new Node(str, leftNode, rightNode));
            }
            //If element is function get element from the stack, create new node with one child element
            // and push to the stack
            if (isFunction(str)) {
                stack.push(new Node(str, stack.pop(), null));
            }
        }
        //return root node of the tree
        return stack.pop();
    }

    /**
     * Parses formula string to collection using regular expression in PARSER_EXPRESSION_PATTERN
     *
     * @param formula string of arithmetic expression
     * @return collection with all expression elements
     */
    private static ArrayList<String> parse(String formula) {
        ArrayList<String> result = new ArrayList<>();
        Pattern pattern = Pattern.compile(PARSER_EXPRESSION_PATTERN);
        Matcher matcher = pattern.matcher(formula);
        while (matcher.find()) {
            result.add(matcher.group(0));
        }
        return result;
    }

    /**
     * Converts expression to Reverse Polish notation (RPN) for next calculating
     * https://uk.wikipedia.org/wiki/%D0%9F%D0%BE%D0%BB%D1%8C%D1%81%D1%8C%D0%BA%D0%B8%D0%B9_%D1%96%D0%BD%D0%B2%D0%B5%D1%80%D1%81%D0%BD%D0%B8%D0%B9_%D0%B7%D0%B0%D0%BF%D0%B8%D1%81
     *
     * @param formula collection with expression elements
     * @return string of expression in RPN
     */
    private static String makeRPN(ArrayList<String> formula) {
        StringBuilder outString = new StringBuilder();
        Stack<String> stack = new Stack<>();
        //Save all expression element as RPN in the loop0
        for (String str : formula) {
            //If element is number put him to result string
            if (isNumeric(str) || isVariable(str)) {
                outString.append(str + " ");
            }
            //If element is function or opened bracket put him to stack
            else if (isFunction(str) || str.equals("(")) {
                stack.push(str);
            }
            //If element is a close bracket then get all the elements up to the open bracket from stack
            //and put they to result string
            else if (str.equals(")")) {
                while (true) {
                    if (stack.empty()) {
                        System.out.println("Error! Mismatched brackets!");
                        return null;
                    }
                    String element = stack.pop();
                    if (element.equals("(")) break;
                    else outString.append(element + " ");
                }
            }
            //If element is an operator
            else if (isOperator(str)) {
                if (!stack.empty() && (isOperator(stack.peek()) || isFunction(stack.peek()))) {
                    //While on top of the stack a function or an operator with priority >= current priority
                    //put element to result string, else put element to stack
                    while (true) {
                        if (stack.isEmpty()) {
                            stack.push(str);
                            break;
                        }
                        String top = stack.peek();
                        int topPriority = (isFunction(top) || top.equals("(")) ? -1 : OPERATORS.get(top);
                        int currentPriority = OPERATORS.get(str);
                        if (str.equals(top) && str.equals("^")) {
                            stack.push(str);
                            break;
                        } else if (isFunction(top) || topPriority >= currentPriority) {
                            outString.append(stack.pop() + " ");
                        } else {
                            stack.push(str);
                            break;
                        }
                    }
                } else stack.push(str);
            } else {
                System.out.println("Error in formula! Incorrect data \"" + str + "\"!");
                return null;
            }
        }
        outString = stackToString(stack, outString);
        return outString.toString();
    }

    /**
     * Checks if string is variable
     *
     * @param str string for checking
     * @return true if str is variable or false
     */
    private static boolean isVariable(String str) {
        return !isNumeric(str) && !isFunction(str) && str.matches("[a-zA-Z]+");
    }

    /**
     * Gets all elements from stack and puts they to string
     *
     * @param stack     stack with elements
     * @param outString string for saving elements
     * @return result string with all elements from stack
     */
    private static StringBuilder stackToString(Stack<String> stack, StringBuilder outString) {
        while (!stack.empty()) {
            outString.append(stack.pop() + " ");
        }
        return outString;
    }

    /**
     * Checks if string is operator using collection OPERATORS
     *
     * @param str string for checking
     * @return true if str is operator or false
     */
    private static boolean isOperator(String str) {
        return OPERATORS.containsKey(str);
    }

    /**
     * Checks if string is function using collection FUNCTIONS
     *
     * @param str string for checking
     * @return true if str is function or false
     */
    private static boolean isFunction(String str) {
        return Arrays.stream(FUNCTIONS).toList().contains(str);
    }

    /**
     * Checks if string is number
     *
     * @param str string for checking
     * @return true if str is number or false
     */
    private static boolean isNumeric(String str) {
        if (str == null || str.isEmpty()) return false;
        try {
            double number = Double.parseDouble(str);
        } catch (NumberFormatException e) {
            return false;
        }
        return true;
    }


}
