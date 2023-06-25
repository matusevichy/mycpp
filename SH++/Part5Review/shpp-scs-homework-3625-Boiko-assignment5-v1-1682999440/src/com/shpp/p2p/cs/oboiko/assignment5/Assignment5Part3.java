package com.shpp.p2p.cs.oboiko.assignment5;

import com.shpp.cs.a.console.TextProgram;
import org.w3c.dom.ls.LSOutput;

import java.io.BufferedReader;
import java.io.FileReader;
import java.io.IOException;
import java.util.ArrayList;
import java.util.List;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

/**
 * The Assignment5Part3 class reads three letters from keyboard, it finds a word in the list
 * which contain entered letters and prints his on the screen.
 */
public class Assignment5Part3 extends TextProgram {
    private static final String DICTIONARY = "en-dictionary.txt";

    @Override
    public void run() {
        List<String> words = readAllWords(DICTIONARY);
        readWord(words);
    }

    /**
     * Reads a string from the keyboard and passes it for validation.
     *
     * @param words - list of words.
     */
    private void readWord(List<String> words) {
        String word;

        do {
            word = readLine("Enter three letters or \"q\" for exit: ")
                    .toLowerCase()
                    .replaceAll("[^A-Za-z]", "");

            boolean check = checkSizeWord(word);

            if (check)  {
                System.out.println(findWord(word, words));
                System.out.println("\n" + "------------------------" + "\n");
            }
        } while (!word.equals("q")); // Exit if enter character "q".
    }

    /**
     * Checks that the word was made of three letters.
     * If the word equal three letters so return true, else false.
     *
     * @param word - entered word.
     * @return boolean values correct the word or not.
     */
    private boolean checkSizeWord(String word) {
        if (word.length() != 3) {
            if (word.equals("q")) {
                System.out.println("Good-Bye.");
            } else if (word.length() > 3) {
                System.out.println("\u001B[31m" + "You entered more letters then three!\n" + "\u001B[0m");
            } else {
                System.out.println("\u001B[31m" + "You entered less letters then three!\n" + "\u001B[0m");
            }

            return false;
        } else {
            return true;
        }
    }

    /**
     * Finds in the list a word contain entered letters.
     *
     * @param word - entered word.
     * @param list - the list with words.
     * @return the word contain entered letters.
     */
    private String findWord(String word, List<String> list) {
        /* Regular expression with 3 letters entered. */
        String pattern = ".*[" + word.charAt(0) + "].*[" + word.charAt(1) + "].*[" + word.charAt(2) + "].*";

        for (String w : list) {
            if (Pattern.matches(pattern, w)) return w;
        }

        return "The word containing these letters - \"" + word + "\" not found!  Try again.";
    }

    /**
     * Records to the list words from the file.
     *
     * @param dictionary path to the file.
     * @return list with words.
     */
    private List<String> readAllWords(String dictionary) {
        List<String> cities = new ArrayList<>();

        try (BufferedReader reader = new BufferedReader(new FileReader(dictionary))) {
            String cityName;
            while ((cityName = reader.readLine()) != null ) {
                cities.add(cityName);
            }
        } catch (IOException e) {
            e.printStackTrace();
        }

        return cities;
    }
}
