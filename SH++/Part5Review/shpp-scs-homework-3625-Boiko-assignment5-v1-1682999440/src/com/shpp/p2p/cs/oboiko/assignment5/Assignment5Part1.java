package com.shpp.p2p.cs.oboiko.assignment5;

import com.shpp.cs.a.console.TextProgram;

/** The Assignment5Part1 class given a word, estimates the number of syllables in that word according to the
 * heuristic specified in the handout.
 */
public class Assignment5Part1 extends TextProgram {
    public void run() {
        startTest();
        /* Repeatedly prompt the user for a word and print out the estimated
         * number of syllables in that word.
         */
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
        int syllableCount = 0; //Counter of syllable.

        for (int i = 0; i < word.length(); i++) {
            if (checkVowels(word.toLowerCase().charAt(i))) { //Check a letter and next letter by vowel.
                if (i != word.length() - 1) {
                    if (!checkVowels(word.toLowerCase().charAt(i + 1))) syllableCount++;
                } else {
                    syllableCount++;
                }
            }
        }

        return checkLastLetter(syllableCount, word);
    }

    /**
     * Checks the end of the word for "e" and if there are more than 1 syllables, it takes away one syllable.
     *
     * @param syllableCount - count of syllables.
     * @param word - test word.
     * @return checked count of syllables.
     */
    private int checkLastLetter(int syllableCount, String word) {
        if (syllableCount > 1 && word.charAt(word.length() - 1) == 'e'
                && !(checkVowels(word.toLowerCase().charAt(word.length() - 2))
                && checkVowels(word.toLowerCase().charAt(word.length() - 1)))) syllableCount--;
        return syllableCount;
    }

    /**
     * Checks if the letter is a vowel or not.
     *
     * @param letter - a letter.
     * @return true if the letter is a vowel and false if the letter is a consonant.
     */
    private boolean checkVowels(char letter) {
        char[] vowels = new char[] {'a', 'e', 'i', 'o', 'u', 'y'}; // Creates array vowel of letters.

        /* Checks a letter with each letters from array. */
        for (int i = 0; i < vowels.length; i++) { //Contains
            if (letter == vowels[i]) return true;
        }

        return false;
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
