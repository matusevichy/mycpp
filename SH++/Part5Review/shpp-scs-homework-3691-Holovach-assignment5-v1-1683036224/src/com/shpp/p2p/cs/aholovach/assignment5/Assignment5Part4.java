package com.shpp.p2p.cs.aholovach.assignment5;

import com.shpp.cs.a.console.TextProgram;

import java.io.BufferedReader;
import java.io.FileReader;
import java.io.IOException;
import java.util.ArrayList;
import java.util.List;

/* TODO: CSV parsing. */

public class Assignment5Part4 extends TextProgram {
    public void run() {
        println(extractColumn("test.csv", 2));
    }

    /**
     * Parse the CSV file and return the column we requested.
     *
     * @param filename    The name of the file that we will parse.
     * @param columnIndex The index of line we need to take.
     * @return An array of all word in line.
     */
    private ArrayList<String> extractColumn(String filename, int columnIndex) {
        var resultArray = new ArrayList<String>();

        try {
            // Read the file
            BufferedReader reader = new BufferedReader(new FileReader(filename));
            String line;

            // Check each line and return array
            while ((line = reader.readLine()) != null) {
                // Add word to array
                resultArray.add(splitLine(line, columnIndex));
            }

        } catch (IOException e) {
            // If file not found return null
            return null;
        }

        return resultArray;
    }

    /**
     * Parse the lines and return it.
     *
     * @param line        A string that will be changed.
     * @param columnIndex The index of which word we need to take.
     * @return A right string.
     */
    private String splitLine(String line, int columnIndex) {
        // String that will be added to the array
        var newString = new StringBuilder();
        // Array of all words separated by commas
        var list = new ArrayList<String>();
        // Array of line
        char[] arrayLine = line.toCharArray();
        // Result
        String resultString;

        int counter = 0;
        /* If there are no quotation marks in the line,
         * just separate them with commas */
        if (line.indexOf('"') != -1) {
            // If there is, do another logic
            resultString = getResultString(columnIndex, newString, list, arrayLine, counter);
        } else {
            resultString = line.split(",")[columnIndex];
        }

        // Return the correct column
        return resultString;
    }

    /**
     * A string with quotation marks
     *
     * @param colIndex The index of which column we need to take.
     * @param newStr   A Default string.
     * @param list     List of our new string.
     * @param arrLine  Array list of all word in line.
     * @param count    Counter question marks.
     * @return A right string.
     */
    private String getResultString(int colIndex, StringBuilder newStr, List<String> list, char[] arrLine, int count) {
        // Array iteration
        for (char c : arrLine) {
            // If this is the end of the line, then return the array
            if (c == ',' && (count % 2 == 0)) {
                list.add(newStr.toString());
                newStr = new StringBuilder();
                count = 0;
            } else {
                //if there are quotes, the counter is plus one
                if (c == '"') count++;

                newStr.append(c);
            }
        }

        list.add(newStr.toString());

        //if there are quotation marks, then call the method that erases the extra quotation marks
        return (list.get(colIndex).indexOf('"') != -1) ? cleanInvertedCommas(list.get(colIndex)) : list.get(colIndex);
    }

    /**
     * Return String without question mark
     */
    private String cleanInvertedCommas(String s) {
        // String's array
        char[] stringArray = s.toCharArray();
        // Default string
        var newString = new StringBuilder();

        // Condition for removing quotation marks
        for (int i = 0; i < stringArray.length; i++) {
            if ((i != 0) && (i != stringArray.length - 1)
                    && (stringArray[i] != '"' || !Character.isLetter(stringArray[i + 1]))
                    && (stringArray[i] != '"' || !Character.isLetter(stringArray[i - 1]))) {
                newString.append(stringArray[i]);
            }
        }
        // Return new string without question mark.
        return newString.toString();
    }
}
