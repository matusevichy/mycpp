package com.shpp.p2p.cs.ymatusevich.assignment5;

import com.shpp.cs.a.console.TextProgram;

import java.util.ArrayList;
import java.util.Arrays;

public class Assignment5Part1 extends TextProgram {

    //Array of the vowel characters for checking syllables
    private static final ArrayList<Character> vowels = new ArrayList<Character>(Arrays.asList('a', 'e', 'i', 'o', 'u', 'y'));

    @Override
    public void run() {
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
        var count = 0;
        //Check all characters of the word in a loop
        for (int i = 0; i < word.length(); i++) {
            char ch = Character.toLowerCase(word.charAt(i));
            //if character is vowel and character not "e" on the end of the word
            if (vowels.contains(ch) && !((i == word.length() - 1) && (ch == 'e'))) {
                //if character is vowel on the beginning of the word does increment counter
                if (i == 0) {
                    count++;
                } else {
                    //if not two vowel characters one by one does increment counter
                    if (!vowels.contains(Character.toLowerCase(word.charAt(i - 1)))) {
                        count++;
                    }
                }
            }
        }
        return (count > 0) ? count : 1;
    }

}
