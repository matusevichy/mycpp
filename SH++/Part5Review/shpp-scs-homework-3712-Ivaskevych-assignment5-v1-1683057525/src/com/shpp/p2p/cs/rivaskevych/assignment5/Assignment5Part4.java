package com.shpp.p2p.cs.rivaskevych.assignment5;

import com.shpp.cs.a.console.TextProgram;

import java.io.*;
import java.util.ArrayList;

public class Assignment5Part4 extends TextProgram {

    public void run() {

        ArrayList<String> array = extractColumn("test.csv", 2);
        println(array);

    }

    /**
     * Opens a CSV file with the name filename,
     * and returns in the form of an array all the
     * values that are in the columnIndex column
     *
     * @param filename A string containing a name of file.
     *                 The file can have any name, but must be in the "assets" folder,
     *                 which is in the root of the project
     * @param columnIndex The number of the data column from which we want to group
     * @return All the values that are in the columnIndex column in the form of an array
     *
     */
    private ArrayList<String> extractColumn(String filename, int columnIndex) {
        ArrayList<String> column = new ArrayList<>();
        try {
            String file = filename;
            BufferedReader br = new BufferedReader(new FileReader(file));
            String line;
            while ((line = br.readLine()) != null) {
                ArrayList<String> fields = fieldsIn(line);
                if (fields.size() > columnIndex) {
                    column.add(fields.get(columnIndex));
                }
            }
            br.close();
        } catch (IOException e) {
            println("Error: File is not found!");
            return null;
        }
        return column;
    }


    /**
     * Takes a string from a file and returns all fields of that string as array elements
     *
     * @param line The initial string of every line of the file.
     * @return An array with all fields of initial string like separate elements.
     */
    private ArrayList<String> fieldsIn(String line) {

        ArrayList<String> array = new ArrayList<>();
        boolean inQuotes = false;
        StringBuilder fieldBuilder = new StringBuilder();

        for (int i = 0; i < line.length(); i++) {
            char c = line.charAt(i);

            if (i == (line.length() - 1)) {
                if (c != '\"') {
                    fieldBuilder.append(c);
                }
                break;
            }

            boolean nextIsQuote = line.charAt(i + 1) == '\"';

            if (c == ',' && !inQuotes) {
                array.add(fieldBuilder.toString());
                fieldBuilder = new StringBuilder();
            } else if (c == '\"' && nextIsQuote) {
                fieldBuilder.append('\"');
                i += 1;
            } else if (c == '\"') {
                inQuotes = !inQuotes;
            } else {
                fieldBuilder.append(c);
            }
        }
        array.add(fieldBuilder.toString());
        return array;
    }
}
