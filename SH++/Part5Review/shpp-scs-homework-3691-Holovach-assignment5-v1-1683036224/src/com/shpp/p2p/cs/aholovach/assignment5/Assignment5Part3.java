package com.shpp.p2p.cs.aholovach.assignment5;

import com.shpp.cs.a.console.TextProgram;

import java.io.BufferedReader;
import java.io.FileReader;
import java.io.IOException;
import java.util.ArrayList;
import java.util.Iterator;
import java.util.List;

/* TODO: Game with words. */
public class Assignment5Part3 extends TextProgram {
    /**
     * Read and write down all the words in the array.
     *
     * @return Array list of all English word.
     */
    private static List<String> readFile() {
        List<String> list = new ArrayList<>();

        try {
            // Read the file
            var reader = new BufferedReader(new FileReader("en-dictionary.txt"));
            String line;
            // While there are still words, write down their array
            while ((line = reader.readLine()) != null) {
                list.add(line);
            }
        } catch (IOException e) {
            e.printStackTrace();
        }

        return list;
    }

    @Override
    public void run() {
        // Read English words
        List<String> englishWords = readFile();

        while (true) {
            // Ask the user about word and delete all number
            char[] usersLetter = deleteNumbers(askUsersWord());
            // Find all words
            findWords(englishWords, usersLetter);
            // Indent
            println();
        }
    }

    /**
     * Searches for all correct words in an array.
     *
     * @param englishWords An array of all English words.
     * @param usersLetters A string that includes the user's letters.
     */
    private void findWords(List<String> englishWords, char[] usersLetters) {
        // An array that works faster than ordinary ones
        Iterator<String> iterator = englishWords.iterator();
        // Default values
        int index, counter = 0;

        // Read the English words array
        while (iterator.hasNext()) {
            String element = iterator.next(), temporaryElement = element;

            for (char letter : usersLetters) {
                /* If the letter is in the word,
                 * and they are arranged in order, then output the word */
                if (temporaryElement.indexOf(letter) != -1) {
                    index = temporaryElement.indexOf(letter);
                    temporaryElement = temporaryElement.substring(index + 1);
                    counter++;
                }
            }

            if (counter == usersLetters.length) {
                println(element);
            }

            counter = 0;
        }
    }

    /**
     * Delete all the numbers of a string.
     *
     * @param usersWord The string entered by the user.
     * @return An array user's letters.
     */
    private char[] deleteNumbers(String usersWord) {
        char[] usersLetter = new char[3];
        int index = 0;
        // If the element is a letter, then add to the array
        for (char letter : usersWord.toCharArray()) {
            if (Character.isLetter(letter)) {
                usersLetter[index++] = letter;
            }
        }

        return usersLetter;
    }

    /**
     * Ask the user for a word.
     *
     * @return A user's word.
     */
    private String askUsersWord() {
        // Prompt the user and change all letters to lower case
        String userWord = readLine("Write a car license plate: ").toLowerCase();

        // If the word is wrong, ask again
        while (!isWordRight(userWord)) {
            userWord = readLine("Write a car license plate: ").toLowerCase();
        }

        return userWord;
    }

    /**
     * Check the user's word.
     *
     * @param usersWord The string entered by the user.
     * @return True or false.
     */
    private Boolean isWordRight(String usersWord) {
        int counterLetters = 0, counterNumbers = 0;

        /* If the number of letters and numbers in the word is correct,
         * return true */
        for (char letter : usersWord.toCharArray()) {
            if (Character.isLetter(letter)) counterLetters++;
            else counterNumbers++;
        }

        return (counterNumbers == 4 && counterLetters == 3);
    }
}
