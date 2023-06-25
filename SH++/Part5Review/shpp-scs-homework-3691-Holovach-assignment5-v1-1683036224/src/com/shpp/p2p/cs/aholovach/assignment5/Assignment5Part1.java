package com.shpp.p2p.cs.aholovach.assignment5;

import com.shpp.cs.a.console.TextProgram;

/* TODO: Counting the number of syllables. */
public class Assignment5Part1 extends TextProgram {
    private final static String VOWELS = "aouieyAOUIEY";

    /**
     * Get counter of Syllables
     *
     * @param wordArray      Array of letters
     * @param counter        Counter of Syllable
     * @param previousLetter Default value of previous letter
     * @return Counter of syllables
     */
    private static int getCounterOfSyllables(char[] wordArray, int counter, char previousLetter) {
        // Check first letter of our word
        if (VOWELS.indexOf(wordArray[0]) != -1) {
            previousLetter = wordArray[0];
            counter++;
        }

        // Check all letters
        for (int i = 1; i < wordArray.length; i++) {
            /* If the current letter is a vowel and the previous letter is also a vowel,
             * then we increase the counter and the current letter becomes the previous one. */
            if ((VOWELS.indexOf(wordArray[i]) != -1) && VOWELS.indexOf(previousLetter) == -1) {
                previousLetter = wordArray[i];
                counter++;
            } else {
                previousLetter = wordArray[i];
            }
        }

        return counter;
    }

    @Override
    public void run() {
        /* Repeatedly prompt the user for a word and print out the estimated
         * number of syllables in that word.
         */
        startTest();
        while (true) {
            String word = readLine("Enter a single word: ");
            println("  Syllable count: " + syllablesInWord(word));
        }
    }

    /**
     * Given a word, estimates the number of syllables in that word according to the
     * heuristic specified in the handout.
     *
     * @param word A string containing a single word.
     * @return An estimate of the number of syllables in that word.
     */
    private int syllablesInWord(String word) {
        // Word to char array. Array of letters
        char[] wordArray = word.toCharArray();
        // Counter of Syllable
        int counterSyl = 0;
        // Default value of previous letter
        char previousLetter = ' ';

        counterSyl = getCounterOfSyllables(wordArray, counterSyl, previousLetter);

        /* If the last letter is 'e', then decrease the counter */
        return ((wordArray[word.length() - 1] == 'e') && (wordArray[word.length() - 2] != 'e') && (counterSyl != 1))
                ? counterSyl - 1 : counterSyl;
    }
    private void startTest() {
        check("Unity", 3);
        check("Unite", 2);
        check("Growth", 1);
        check("Possibilities", 5);
        check("Nimble", 1);
        check("Me", 1);
        check("Beautiful", 3);
        check("Manatee", 3);
    }

    private void check(String testCase, int expectedResult) {
        if (syllablesInWord(testCase) == expectedResult) {
            println("  Pass: " + testCase);
        } else {
            println("! FAIL: " + testCase);
        }
    }
}
