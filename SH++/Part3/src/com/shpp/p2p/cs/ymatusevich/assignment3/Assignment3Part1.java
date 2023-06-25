package com.shpp.p2p.cs.ymatusevich.assignment3;

import java.util.Arrays;
import java.util.Scanner;

//This program analyze user data of do exercise during the week and giving recommendations
public class Assignment3Part1 {

    private static final int COUNT_DAY_FOR_CARDIO = 5;
    private static final int COUNT_MINUTES_FOR_CARDIO = 30;
    private static final int COUNT_DAY_FOR_PRESSURE = 3;
    private static final int COUNT_MINUTES_FOR_PRESSURE = 40;

    public static void main(String[] args) {
        int[] timeOfDays = new int[7];
        getUserData(timeOfDays);
        printReport(timeOfDays);
    }

    /**
     * This method asking data from user of the count minutes on days of the week for doing exercise
     *
     * @param timeOfDays - array of the integer values for saving the count minutes on days of the week
     */
    private static void getUserData(int[] timeOfDays) {
        Scanner scanner = new Scanner(System.in);
        for (int i = 0; i < timeOfDays.length; i++) {
            System.out.print("How many minutes did you do on day " + (i + 1) + "? ");
            //Check user input
            while (!scanner.hasNextInt()) {
                System.out.println("That's not a number!");
                scanner.next();
            }
            timeOfDays[i] = scanner.nextInt();
        }
    }

    /**
     * This method analyzing user data and returning report and recommendation if еру user does less exercise than recommended
     *
     * @param timeOfDays - array of the integer values with the count minutes on days of the week
     */
    private static void printReport(int[] timeOfDays) {
        //Calculate the count of the days when user does exercise according to the recommendations
        var countDayOf30 = Arrays.stream(timeOfDays).filter(t -> t >= COUNT_MINUTES_FOR_CARDIO).count();
        var countDayOf40 = Arrays.stream(timeOfDays).filter(t -> t >= COUNT_MINUTES_FOR_PRESSURE).count();

        //Generate report
        var resultText = "Cardiovascular health:\n";
        resultText += (countDayOf30 < COUNT_DAY_FOR_CARDIO) ? "You needed to train hard for at least " +
                (COUNT_DAY_FOR_CARDIO - countDayOf30) + "\n" : "Great job! You've done enough exercise for cardiovascular health.\n";
        resultText += "Blood pressure:\n";
        resultText += (countDayOf40 < COUNT_DAY_FOR_PRESSURE) ? "You needed to train hard for at least " +
                (COUNT_DAY_FOR_PRESSURE - countDayOf40) + "\n" : "Great job! You've done enough exercise to keep a low blood pressure.\n";
        System.out.println(resultText);
    }
}
