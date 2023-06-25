package com.shpp.p2p.cs.rivaskevych.assignment5;

import com.shpp.cs.a.console.TextProgram;

public class SyllableCounting extends TextProgram {
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
        word = word.toLowerCase();
        int numVowels = 0;
        String allVowels = "aeiouy";

        for (int i = 0; i < word.length(); i++) {
            char c = word.charAt(i);
            boolean isVowel = allVowels.contains("" + c);
            boolean prevIsVowel = i > 0 && allVowels.contains("" + word.charAt(i - 1));
            boolean lastCharIsE = i == word.length() - 1 && c == 'e';
            if (isVowel && !prevIsVowel && !lastCharIsE) {
                numVowels++;
            }
        }
        if(numVowels == 0) {
            return 1;
        } else return numVowels;
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




