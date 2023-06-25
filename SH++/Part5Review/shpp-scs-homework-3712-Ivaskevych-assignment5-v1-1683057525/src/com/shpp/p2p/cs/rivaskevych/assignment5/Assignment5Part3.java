package com.shpp.p2p.cs.rivaskevych.assignment5;

import com.shpp.cs.a.console.TextProgram;

import java.io.BufferedReader;
import java.io.FileReader;
import java.io.IOException;
import java.util.ArrayList;

public class Assignment5Part3 extends TextProgram {
    private static final String WORDS_FILE = "en-dictionary.txt";

    public void run() {
        /*Reads the file once using the method readWords().
         *Writes the obtained result to a variable words in the form ArrayList<String>.
         */
        ArrayList<String> words = readWords();

        /*A loop that asks for 3 letters and returns all words containing those three
         *letters in a given sequence
         */
        while (true) {
            String letters = readLine("Enter 3 letters: ").toLowerCase();
            printWords(words, letters);
        }
    }

    /**
     * Reads a .txt file with words
     *
     * @return ArrayList with all words included file
     */
    private ArrayList<String> readWords() {
        ArrayList<String> result = new ArrayList<String>();
        try {
            BufferedReader br = new BufferedReader(new FileReader(WORDS_FILE));

            String word;
            while ((word = br.readLine()) != null) {
                result.add(word);
            }

            br.close();

        } catch (IOException e) {
            println("Error: File 'en-dictionary.txt' not found!");
        }
        return result;
    }


    /**
     * Outputs to the console all words that contain the entered letters in the given sequence
     *
     * @param words ArrayList with all words included file.
     * @param letters String includes the letters entered by the user.
     */
    private void printWords(ArrayList<String> words, String letters) {
        for (String word : words) {
            int index1 = word.indexOf(letters.charAt(0));
            int index2 = word.indexOf(letters.charAt(1), index1 + 1);
            int index3 = word.indexOf(letters.charAt(2), index2 + 1);
            if (index1 != -1 && index2 != -1 && index3 != -1) {
                println(word);
            }
        }
    }
}
