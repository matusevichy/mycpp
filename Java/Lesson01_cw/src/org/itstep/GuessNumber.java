package org.itstep;

import java.util.Random;
import java.util.Scanner;

import static java.lang.System.out;

public class GuessNumber {
    public static void main(String[] args) {
        Random random = new Random();
        int num = random.nextInt(100);
        out.println(num);
        int myNum=-1;
        Scanner scanner = new Scanner(System.in);
        while (myNum != num){
            out.println("Enter your number");
            myNum = scanner.nextInt();
            if (myNum < num){
                out.println("Your number is small");
            } else if (myNum > num) {
                out.println("Your number is big");
            }
            else if (myNum == num){
                out.println("You win!!!");
            }
        }
    }
}
