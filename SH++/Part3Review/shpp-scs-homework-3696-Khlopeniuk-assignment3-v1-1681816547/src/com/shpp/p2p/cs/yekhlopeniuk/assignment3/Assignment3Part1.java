package com.shpp.p2p.cs.yekhlopeniuk.assignment3;

import com.shpp.cs.a.console.TextProgram;

public class Assignment3Part1 extends TextProgram {
    //static to format text
    public static final String BLUE = "\u001B[34m";
    public static final String RESET = "\u001B[0m";
    private int cvExercises = 0; //exercises 30 and more minutes long - cardio vascular
    private int bpExercises = 0; //exercises 40 and more minutes long - blood pressure

    public void run() {
        //ask for time and show results
        for(int i = 1; i < 8; i++) askExercise(i);
        showResult("Cardiovascular health", 5, cvExercises);
        showResult("Blood pressure", 3, bpExercises);
    }
    private void askExercise(int i) {
        /*ask about exercise and define if it is
        enough for CV and BP */
        double duration = 0;
        //I'm not sure that ex cannot be 0 minutes long but let it be as i wrote
        while ((duration == 0) || (duration < 0)) duration = readInt("How many minutes did you do on day " + i + "? ");
        if (duration >= 30) {
            cvExercises++; //It's good exercise for cv
            if (duration >=40) {
                bpExercises++;  //It's good exercise for bp
            }
        }
    }
    private void showResult(String health, int normative, int exercises) {
        //get result for each type of activity
        println(BLUE + health + ":" + RESET); //name of activity
        health = Character.toLowerCase(health.charAt(0)) + health.substring(1); //text formatting
        String answer =
                //compare quantity of exercise with normative
                (exercises >= normative) ?
                        "Great job! You've done enough exercise for " + health + "." :
                        "You needed to train hard for at least " + (normative - exercises) + " more day(s) a week!";
        println("   " + answer);
    }
}
