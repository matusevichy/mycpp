package com.shpp.p2p.cs.ymatusevich.assignment5;

import com.shpp.cs.a.console.TextProgram;

import java.io.BufferedReader;
import java.io.FileReader;
import java.io.IOException;
import java.util.ArrayList;

public class Assignment5Part3 extends TextProgram {
    //Name of the file with dictionary
    private final String DICTIONARY_FILE = "en-dictionary.txt";

    @Override
    public void run() {
        ArrayList<String> dict = getDictionary();
        while (true) {
            String chars = readLine("Enter three chars: ");
            if (chars.length() < 3) {
                println("Incorrect data!");
                continue;
            }
            findWords(chars, dict);
        }
    }

    /**
     * Looking for words with defined characters in the dictionary
     *
     * @param chars - user define characters
     * @param dict  - array of the words for looking words
     */
    private void findWords(String chars, ArrayList<String> dict) {
        chars = chars.toLowerCase();
        //checking all the words from dictionary in the loop
        for (String word : dict) {
            String wordLC = word.toLowerCase();
            int startIndex = 0;
            boolean isOk = true;
            //check that  all user-defined characters in the world are the correctly positioned
            for (int i = 0; i < chars.length(); i++) {
                int index = wordLC.indexOf(chars.charAt(i), startIndex);
                if (index == -1) {
                    isOk = false;
                    break;
                } else {
                    startIndex = index + 1;
                }
            }
            if (isOk) {
                println(word);
            }
        }
    }

    /**
     * Reading data from dictionary file
     *
     * @return array of the words
     */
    private ArrayList<String> getDictionary() {
        ArrayList<String> dict = new ArrayList<>();
        try {
            BufferedReader reader = new BufferedReader(new FileReader(DICTIONARY_FILE));
            String line;
            while ((line = reader.readLine()) != null) {
                dict.add(line);
            }
        } catch (IOException exception) {
            println(exception.getMessage());
        }
        return dict;
    }
}
