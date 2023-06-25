package com.shpp.p2p.cs.ychornyi.assignment3;

import com.shpp.cs.a.console.TextProgram;

/**
 * declared many constants for minutes per day, for minimum days,
 * and for answer when we check how training user.
 * Declared few variables to check how many day user training right,
 * how many days in the week they need training right,
 * and how many minutes user training per a day.
 */
public class Assignment3Part1 extends TextProgram {
    private static final int MIN_FOR_CARDIO = 30;
    private static final int MINIMUM_DAYS_FOR_CARDIO = 5;
    private static final int MIN_FOR_BLOOD_PRESSURE = 40;
    private static final int MINIMUM_DAYS_FOR_BLOOD_PRESSURE = 3;
    private static final String CARDIO_WARNING = "Cardiovascular health:\n" +
            " You needed to train hard for at least ";
    private static final String BLOOD_PRESSURE_WARNING = "Blood pressure:\n" +
            " You needed to train hard for at least ";
    private static final String MORE_DAYS_A_WEEK = " more day(s) a week!";
    private static final String CARDIO_COMPLIMENT = "Cardiovascular health:\n" +
            " Great job! You've done enough exercise for cardiovascular health.";
    private static final String BLOOD_PRESSURE_COMPLIMENT = "Blood pressure:\n" +
            " Great job! You've done enough exercise to keep a low blood pressure.";
    int moreDaysForCardio;
    int moreDaysForBloodPressure;
    int minutePerADay;
    int goodDaysForCardio;
    int goodDaysForBloodPressure;

    /**
     * read 7 times for every day in week how much time user spend for training.
     * After that give answer to user how many they need training more
     * or give a compliment what's they training enough.
     */
    public void run() {
        fillInTheTrainingDiary();
        checkTheUserTraining();
    }

    /**
     * enter the minute of training every day and calculate is there enough training for the week
     */
    public void fillInTheTrainingDiary() {
        for (int i = 1; i < 8; i++) {
            minutePerADay = readInt("How many minutes did you do on day " + i + "?");
            if (minutePerADay >= MIN_FOR_CARDIO) {
                goodDaysForCardio++;
            }
            if (minutePerADay >= MIN_FOR_BLOOD_PRESSURE) {
                goodDaysForBloodPressure++;
            }
        }
        moreDaysForCardio = MINIMUM_DAYS_FOR_CARDIO - goodDaysForCardio;
        moreDaysForBloodPressure = MINIMUM_DAYS_FOR_BLOOD_PRESSURE - goodDaysForBloodPressure;
    }

    /**
     * having data on how much user training each day give them the answer.
     */
    public void checkTheUserTraining() {
        if (goodDaysForCardio < MINIMUM_DAYS_FOR_CARDIO
                && goodDaysForBloodPressure < MINIMUM_DAYS_FOR_BLOOD_PRESSURE) {
            println(CARDIO_WARNING + moreDaysForCardio + MORE_DAYS_A_WEEK);
            println(BLOOD_PRESSURE_WARNING + moreDaysForBloodPressure + MORE_DAYS_A_WEEK);
        } else if (goodDaysForCardio < MINIMUM_DAYS_FOR_CARDIO
                && goodDaysForBloodPressure >= MINIMUM_DAYS_FOR_BLOOD_PRESSURE) {
            println(CARDIO_WARNING + moreDaysForCardio + MORE_DAYS_A_WEEK);
            println(BLOOD_PRESSURE_COMPLIMENT);
        } else if (goodDaysForCardio >= MINIMUM_DAYS_FOR_CARDIO
                && goodDaysForBloodPressure < MINIMUM_DAYS_FOR_BLOOD_PRESSURE) {
            println(CARDIO_COMPLIMENT);
            println(BLOOD_PRESSURE_WARNING + moreDaysForBloodPressure + MORE_DAYS_A_WEEK);
        } else {
            println(CARDIO_COMPLIMENT);
            println(BLOOD_PRESSURE_COMPLIMENT);
        }
    }
}
