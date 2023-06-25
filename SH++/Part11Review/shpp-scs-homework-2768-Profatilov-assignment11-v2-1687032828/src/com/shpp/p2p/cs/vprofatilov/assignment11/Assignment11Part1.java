package com.shpp.p2p.cs.vprofatilov.assignment11;


import com.shpp.cs.a.console.TextProgram;

import java.util.*;


//input formula like (2+3)*(4-2) || (2+x)*(4-2) x=3
//or 90sin-45+3
//-(xsin) x=45


/**
 * In this code we have some rule!!!) <br>
 * <br>
 * 1.0)We input formula without using space 2+4)<br>
 * 1.2)If you are won't, you can use space but like ("2_+_4" -- _ = spase)<br>
 * <br>
 * 2.0)About work with "(" -- only like (2+3)*(4-2)<br>
 * my code <strong>does not support</strong> opening brackets after open -- "(2*(3+3)"<br>
 * <br>
 * 3.0)About sin, cos, tan, atan, sqrt, log2, log10 -- input number after math operation <br>
 * like sin90+cos360 or (sin90+x)+(-cos0) <br>
 * <br>
 * It is oll <strong>good luck</strong> !
 */
public class Assignment11Part1 extends TextProgram {


    /**
     * @param args 0 - formula, other it is letter and she`s value<br>
     *             HashMap<String, Double> variables - (if we have letter in formula) it is HashMap type [letter - value]
     */
    public static void main(String[] args) {
        if (Objects.equals(args[0], " ")) {
            System.out.println("Formula is empty ");
            System.exit(0);
        } else {

            ArrayList<String> interestingMathOperation = fillInterestingMathOperation();//sin, cos, tan, atan, log10, log2, sqrt


            System.out.println("Your formula is : " + args[0] + " ");
            HashMap<String, Double> variables = new HashMap<>();
            if (args.length > 1) {//we have letters only if we have args.length > 1
                System.out.print("With variables : ");
                for (int i = 1; i < args.length; i++) {
                    System.out.print(args[i] + " ");
                }
                System.out.println();
                variables = findValuesOfLetters(args, interestingMathOperation);
            }
            System.out.println("Result : " + calculate(findInterestingMathOperation(args[0], interestingMathOperation, variables), variables));

        }

    }


    /**
     * if formula have element interestingMathOperation <br>
     * calculate and add result
     *
     * @param arg                      formula
     * @param interestingMathOperation ArrayList with  sin, cos, tan, atan, log10, log2, sqrt
     * @param variables
     * @return
     */
    private static String findInterestingMathOperation(String arg, ArrayList<String> interestingMathOperation, HashMap<String, Double> variables) {
        LinkedList<String> formula;
        for (String s : interestingMathOperation) {
            if (arg.contains(s)) {
                int index = arg.indexOf(s);
                int startIndex = index;
                String mathOperation = arg.substring(index, index + s.length());
                arg = arg.substring(0, index) + arg.substring(index + s.length());
                formula = doingLinkedList(arg);
                String number = "";
                boolean check = true;

                while (check && startIndex < formula.size()) {
                    if (formula.get(startIndex).equals("(")) {
                        int i = startIndex;
                        String inBrackets = "";
                        while (check) {
                            if (formula.get(i).equals("(")) {
                                formula.remove(i);
                                continue;
                            } else if (formula.get(i).equals(")")) {
                                formula.remove(i);
                                check = false;
                                continue;
                            }
                            inBrackets += formula.get(i);
                            formula.remove(i);


                        }
                        inBrackets = findInterestingMathOperation(inBrackets, interestingMathOperation, variables);
                        number = calculate(inBrackets, variables);


                    } else if ((variables.get(formula.get(startIndex)) != null)) {
                        check = false;
                        number += (variables.get(formula.get(startIndex)));
                        formula.remove(startIndex);
                    } else if (checkNumberOrNo(formula.get(startIndex))) {
                        number += (formula.get(startIndex));
                        formula.remove(startIndex);
                        index++;
                    } else {
                        check = false;
                    }

                }


                double result = angleValue(mathOperation, Double.parseDouble(number.toString()));
                formula.add(startIndex, String.valueOf(result));
                arg = doingString(formula);
            }
        }
        return arg;
    }


    /**
     * make a string from a list
     *
     * @param formula LinkedList
     * @return String
     */
    private static String doingString(LinkedList<String> formula) {
        StringBuilder result = new StringBuilder();
        for (int i = 0; i < formula.size(); i++) {
            result.append(formula.get(i));
        }
        return result.toString();
    }


    /**
     * make a list from a string
     *
     * @param arg string
     * @return LinkedList
     */
    private static LinkedList<String> doingLinkedList(String arg) {
        LinkedList<String> formula = new LinkedList<>();
        for (char c : arg.toCharArray()) {
            formula.add(String.valueOf(c));
        }
        return formula;
    }

    /**
     * fill array list sin, cos, tan, atan, log10, log2, sqrt
     *
     * @return filing ArrayList
     */
    private static ArrayList<String> fillInterestingMathOperation() {
        ArrayList<String> interestingMathOperation = new ArrayList<>();
        interestingMathOperation.add("sin");
        interestingMathOperation.add("cos");
        interestingMathOperation.add("atan");
        interestingMathOperation.add("tan");
        interestingMathOperation.add("log10");
        interestingMathOperation.add("log2");
        interestingMathOperation.add("sqrt");
        return interestingMathOperation;
    }

    /**
     * find letters value<br>
     * with check for sin, cos,tan, atan, log2, log10
     *
     * @param args                     formula && letter-value
     * @param interestingMathOperation
     * @return
     */
    private static HashMap<String, Double> findValuesOfLetters(String[] args, ArrayList<String> interestingMathOperation) {
        HashMap<String, Double> variables = new HashMap<>();
        for (int i = 1; i < args.length; i++) {
            String letter;
            Double value;
            if (args[i].contains("(")) {
                String formula = args[i].substring(0,args[i].length());
                 value  = Double.parseDouble(calculate(formula,variables));
                 letter = args[i].substring(0, 1);
            }else {
                args[i] = findInterestingMathOperation(args[i], interestingMathOperation, variables);
                 letter = args[i].substring(0, 1);//letter (first)
                 value = Double.parseDouble(args[i].substring(2));// letters value,
                // 2 because letter= (what we want) that is only 2 object


            }
            variables.put(letter, value);
        }
        return variables;
    }


    /**
     * parse <strong>oll input</strong> string<br>
     *
     * @param arg    formula
     * @param values like [letter - value]
     * @return Linked list where we have all the numbers and signs separately<br>
     * in their order in formula
     */
    private static LinkedList<String> createToken(String arg, HashMap<String, Double> values) {
        LinkedList<String> tokens = new LinkedList<>();
        boolean one = false;
        String oneNumber = "";

        for (char c : arg.toCharArray()) {

            if (c == '(' || c == ')') {
                if (one) {
                    tokens.add(oneNumber);
                    oneNumber = "";
                    one = false;
                }
                tokens.add(String.valueOf(c));

            } else if (c == ' ' || c == ',') { //we have spase and ',' if we work with List (in brackets)
                //admission
            } else if (c == '.') {
                oneNumber += c;
                one = true;
            } else if (Character.isDigit(c)) {
                oneNumber += c;
                one = true;
            } else if (c == '+' || c == '*' || c == '-' || c == '/' || c == '^') {
                if (one) {
                    tokens.add(oneNumber);
                    oneNumber = "";
                    one = false;
                }
                tokens.add(Character.toString(c));

            } else if (Character.isLetter(c)) {
                if (one) {
                    tokens.add(oneNumber);
                    one = false;
                }
                if (values.get(Character.toString(c)) != null) {//if we have letter && and have value
                    tokens.add(values.get(Character.toString(c)).toString());  //if we have value change letter in formula on value
                } else {
                    System.out.println("Cant find value of latter");
                }
            }
        }
        if (one) {//last number
            tokens.add(oneNumber);
        }
        return tokens;
    }


    /**
     * calculate sin, cos or tng angle
     *
     * @param angle  sin, cos or tng
     * @param number angle
     * @return sin angle, cos angle, angle tng
     */
    private static Double angleValue(String angle, double number) {
        angle = angle.toLowerCase();
        if (angle.contains("cos")) {
            number = Math.toRadians(number);
            return Math.cos(number);
        } else if (angle.contains("sin")) {
            number = Math.toRadians(number);
            return Math.sin(number);
        } else if (angle.contains("atan")) {
            number = Math.toRadians(number);
            return Math.tan(number);
        } else if (angle.contains("tan")) {
            number = Math.toRadians(number);
            return Math.atan(number);
        } else if (angle.contains("log10")) {
            return Math.log10(number);
        } else if (angle.contains("log2")) {
            return Math.log(number);
        } else if (angle.contains("sqrt")) {
            return Math.sqrt(number);
        }
        return null;
    }

    /**
     * we work with brackets<br>
     *
     * @param formula   args[0]
     * @param variables HashMap like [x--40]
     * @return
     */
    private static String calculate(String formula, HashMap<String, Double> variables) {
        LinkedList<String> tokens = createToken(formula, variables);
        checkTwoMathSign(tokens);
        while (tokens.contains("(")) {
            LinkedList<String> inBrackets = new LinkedList<>(tokens);

            if (inBrackets.getFirst().equals("(") && inBrackets.getLast().equals(")")) {
                inBrackets.removeFirst();
                inBrackets.removeLast();

            }


            while (inBrackets.contains("(")) {
                int a = inBrackets.indexOf("(");
                for (int i = 0; i <= a; i++) {
                    inBrackets.remove(0);
                }


                int b = inBrackets.lastIndexOf(")");
                for (int i = b; i <= inBrackets.size() - 1; ) {
                    inBrackets.remove(b);
                }

            }

            findAndChangeResult(tokens, inBrackets);
        }


        checkTwoMathSign(tokens);
        сalculateEngine(tokens);
        return tokens.get(0);

    }

    /**
     * find and change result in basic formula<br>
     * using method calculateEngine
     *
     * @param formulaInLinkedList
     * @param inBrackets
     */
    private static void findAndChangeResult(LinkedList<String> formulaInLinkedList, LinkedList<String> inBrackets) {
        LinkedList<String> forCalculate = new LinkedList<>(inBrackets);
        String result = null;
        if (inBrackets.size() >= 3) {
            result = сalculateEngine(forCalculate);
        } else if (inBrackets.size() == 2) {
            result = inBrackets.get(0) + inBrackets.get(1);

        } else if (inBrackets.size() == 1) {
            result = inBrackets.get(0);
        }


        int i = 0;
        String forFindIndex = "";
        for (int g = 0; g < inBrackets.size(); g++) {
            forFindIndex += inBrackets.get(g);
        }


        for (int g = 0; g < formulaInLinkedList.size() - inBrackets.size(); g++) {
            String str = "";
            str += formulaInLinkedList.get(g);
            str += formulaInLinkedList.get(g + 1);
            str += formulaInLinkedList.get(g + 2);
            if (forFindIndex.contains(str)) {
                i = g;
                i--;
                g = formulaInLinkedList.size() - inBrackets.size() + 10; //for exit
            }
        }
        for (int t = 0; t < inBrackets.size() + 1; t++) {
            formulaInLinkedList.remove(i);
        }
        formulaInLinkedList.set(i, result);


    }


    /**
     * for working with formula like : 4+(-4) && -4+5
     *
     * @param tokens formula in LinkedList were we change oll letter on value
     */
    private static void checkTwoMathSign(LinkedList<String> tokens) {
        if (tokens.size() > 1) {
            if (checkMathAngle(tokens.get(0)) && !tokens.get(1).equals("(")) {
                String number = tokens.get(0) + tokens.get(1);
                tokens.pollFirst();
                tokens.pollFirst();
                tokens.add(0, number);
            }
            for (int i = 1; i < tokens.size() - 1; i++) {
                String number = tokens.get(i + 1);
                boolean check = checkNumberOrNo(number);
                if (check) {
                    if (checkMathAngle(tokens.get(i))) {
                        if (tokens.get(i - 1).equals("+") || tokens.get(i - 1).equals("-")) {
                            number = tokens.get(i) + number;
                            tokens.remove(i);
                            tokens.remove(i);
                            tokens.add(i, number);
                        }
                    }
                }

            }
        }

    }

    /**
     * check method`s name
     *
     * @param number String were we can have enething
     * @return true if number || false if not number
     */
    private static boolean checkNumberOrNo(String number) {

        try {
            Double.parseDouble(number);
            return true;
        } catch (NumberFormatException e) {
            return false;
        }
    }

    /**
     * for check formula like (-3)
     *
     * @param tokensInBrackets
     * @return true if we have + or - || false if no
     */
    private static boolean checkMathAngle(String tokensInBrackets) {
        if (tokensInBrackets.equals("+") || tokensInBrackets.equals("-")) {
            return true;
        } else {
            return false;
        }

    }


    /**
     * while we don`t have only one number <br>
     * find -, +, /, *, ^ and doing math operation
     *
     * @param tokens -- Linked list where we have all the numbers and signs separately<br>
     *               in their order in formula
     * @return result after oll math operation
     */
    private static String сalculateEngine(LinkedList<String> tokens) {
        while (tokens.size() != 1) {

            if (tokens.contains("^")) {
                int index = tokens.indexOf("^");
                double resultNumber = Math.pow(findA(tokens, index), findB(tokens, index));
                changeValue(tokens, index, resultNumber);
            } else if (tokens.contains("/")) {
                int index = tokens.indexOf("/");
                double resultNumber = findA(tokens, index) / findB(tokens, index);
                changeValue(tokens, index, resultNumber);
            } else if (tokens.contains("*")) {
                int index = tokens.indexOf("*");
                double result = findA(tokens, index) * findB(tokens, index);
                changeValue(tokens, index, result);
            } else if (tokens.contains("-")) {
                int index = tokens.indexOf("-");
                double result = findA(tokens, index) - findB(tokens, index);
                changeValue(tokens, index, result);
            } else if (tokens.contains("+")) {
                int index = tokens.indexOf("+");
                double result = findA(tokens, index) + findB(tokens, index);
                changeValue(tokens, index, result);
            }
        }
        return tokens.get(0);
    }


    /**
     * find number after math sign
     *
     * @param tokens LinkedList with formula
     * @param index  of math sign
     * @return
     */
    private static double findB(LinkedList<String> tokens, int index) {
        return Double.parseDouble(tokens.get(index + 1));
    }


    /**
     * find number before math sign
     *
     * @param tokens LinkedList with formula
     * @param index  math sign
     * @return
     */
    private static double findA(LinkedList<String> tokens, int index) {
        return Double.parseDouble(tokens.get(index - 1));
    }

    /**
     * Delete two number and sign<br>
     * add result of mathematical operation
     *
     * @param tokens       LinkedList
     * @param index        sign index
     * @param resultNumber number what we have after a mathematical operation
     * @return changed LinkedList
     */
    private static LinkedList<String> changeValue(LinkedList<String> tokens, int index, double resultNumber) {
        tokens.remove(index - 1);
        tokens.remove(index - 1);
        tokens.remove(index - 1);
        tokens.add(index - 1, String.valueOf(resultNumber));
        return tokens;
    }


}
