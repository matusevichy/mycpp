package com.shpp.p2p.cs.oboiko.assignment5;

import com.shpp.cs.a.console.TextProgram;
import java.io.BufferedReader;
import java.io.FileReader;
import java.io.IOException;
import java.util.ArrayList;

/**
 * The Assignment5Part4 class reads csv files and transfers the specified column to the list.
 */
public class Assignment5Part4 extends TextProgram {
    /** Path to the test CSV file. */
    private static final String PATH_CSV = "src/com/shpp/p2p/cs/oboiko/assignment5/assets/test.csv";

    @Override
    public void run() {
        ArrayList<String> arrayList = extractColumn(PATH_CSV, 2);
        if (arrayList != null) System.out.println(arrayList.toString());
    }

    /**
     * Reads the CVS files with data.
     *
     * @param filename - the path to the test CSV file.
     * @param columnIndex - the index of the column to be passed to the list.
     * @return a list with a column from a file.
     */
    private ArrayList<String> extractColumn(String filename, int columnIndex) {
        ArrayList<String> column = new ArrayList<>();
        String line;

        /* Reads all lines from a file.*/
        try (BufferedReader reader = new BufferedReader(new FileReader(filename))) {
            while ((line = reader.readLine()) != null) {
                column.add(fieldsIn(line).get(columnIndex));
            }
        } catch (IOException e) {
            return null;
        }

        return column;
    }

    /**
     * Reads a string and separates her by columns.
     *
     * @param line - a string from a file.
     * @return - a list with all columns from one line.
     */
    private ArrayList<String> fieldsIn(String line) {
        ArrayList<String> string = new ArrayList<>();

        /* Splits a line to columns through comma and put their to an array. */
        String[] array = line.replaceAll(", ", "::").split(",");

        /* Passes all array values to the sheet, removing extra quotes. */
        for (String w : array) {
            String temp = (w.contains("::")) ? w.substring(1, w.length() - 1) : w;
            string.add(temp.replaceAll("::", ", ").replaceAll("\"\"", "\""));
        }

        return string;
    }
}
