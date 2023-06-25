package com.shpp.p2p.cs.amolchanov.assignment3;

import com.shpp.cs.a.console.TextProgram;

public class Assignment3Part1 extends TextProgram {
    //the time to devote to training
    private static final int CARDIO_MINUTES = 30;
    //the time to devote to training
    private static final int BLOOD_PRESSURE_MINUTES = 40;
    //Variable to record the days of cardiovascular health training
    private int cardio = 0;
    //a variable to record the days on which the workout to reduce blood pressure and cholesterol was performed
    private int bloodPressure = 0;

    public void run() {
        Aerobics();
        displayTheResult();
    }

    /**
     * ask the user how much time was spent on training and immediately put the value in the variable
     */
    private void Aerobics() {
        for (int i = 0; i < 7; i++) {
            int minutesSpent = readInt("How many minutes did you do on day " + (i + 1) + "? ");
            if (minutesSpent >= CARDIO_MINUTES) {
                cardio++;
            }
            if (minutesSpent >= BLOOD_PRESSURE_MINUTES) {
                bloodPressure++;
            }
        }
    }

    /**
     * output the training analysis
     */
    private void displayTheResult() {
        println("Cardiovascular health:");
        println(cardio >= 5 ? "  Great job! You've done enough exercise for cardiovascular health." : "  You needed to train hard for at least " + (5 - cardio) + " more day(s) a week!");
        println("Blood pressure:");
        println(bloodPressure >= 3 ? "  Great job! You've done enough exercise to keep a low blood pressure." : "You needed to train hard for at least " + (3 - bloodPressure) + " more day(s) a week!");
    }
}
