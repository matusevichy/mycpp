package com.shpp.p2p.cs.yekhlopeniuk.assignment3;

import com.shpp.cs.a.console.TextProgram;

public class Assignment3Part2 extends TextProgram {
    //static to format text
    public static final String BLUE = "\u001B[34m";
    public static final String RESET = "\u001B[0m";
    private int num;    //our number to make manipulations
                        //it's here, because all methods use it

    public void run() {
        //read number and make manipulations
        num = readInt("Введіть число: "); //red number from user
        while (num != 1) { //stop condition is number becomes 1
            //format and print result of current manipulation
            if (num%2 == 0) result("парне, значить потрібно поділити на 2, отримаємо ", num/2);
            else result("непарне, значить потрібно помножити на 3 и додати 1, отримаємо ", (num*3 + 1));
        }
    }
    private void result(String message, int numAfter) {
        //make manipulation and print message with result
        print(BLUE + num + " ");
        print(RESET + message);
        num = numAfter; //change number depending on the manipulation
        print(BLUE + num);
        println();
    }
}
