package com.shpp.p2p.cs.ymatusevich.assignment5;

import com.shpp.cs.a.console.TextProgram;

import java.io.BufferedReader;
import java.io.FileReader;
import java.io.IOException;
import java.util.ArrayList;

public class Assignment5Part4 extends TextProgram {
    @Override
    public void run() {
        var list = extractColumn("origins.csv", 1);
        //print result of parsing CSV
        if (list != null) {
            for (String cell : list) {
                println(cell);
            }
        } else println("File not found");
    }

    /**
     * Reads CSV file and takes a strings from defined column
     *
     * @param filename    - name of the CSV file
     * @param columnIndex - index of the column in CSV file
     * @return array of the strings from defined column
     */
    private ArrayList<String> extractColumn(String filename, int columnIndex) {
        ArrayList<String> list = new ArrayList<>();
        try {
            BufferedReader reader = new BufferedReader(new FileReader(filename));
            String line;
            //reads lines from the file in the loop and calls the parsing method
            while ((line = reader.readLine()) != null) {
                list.add(fieldsIn(line).get(columnIndex));
            }
            return list;
        } catch (IOException e) {
            return null;
        }
    }

    /**
     * Parses CSV string
     *
     * @param line - CSV string for parsing
     * @return - array of the strings from all columns in the string
     */
    private ArrayList<String> fieldsIn(String line) {
        ArrayList<String> list = new ArrayList<>();
        //parsing string on the predefined rules in the eternal loop
        while (line != "") {
            int indexQuot = line.indexOf("\"");
            int indexComa = line.indexOf(",");
            //if string doesn`t have coma and quote
            if ((indexQuot == -1) && (indexComa == -1)) {
                list.add(line);
                break;
            }
            //if between two commas not find quotes
            if ((indexComa != -1) && ((indexQuot == -1) || (indexComa < indexQuot))) {
                String str = line.substring(0, indexComa);
                line = line.substring(indexComa + 1);
                list.add(str);
            } else
                //if string has quote before next coma
                if ((indexQuot != -1) && ((indexQuot < indexComa) || indexComa == -1)) {
                    int indexNextQuot = indexQuot;
                    //looking end of the column in the eternal loop
                    while (true) {
                        indexNextQuot = line.indexOf("\"", indexNextQuot + 1);
                        //if found quote on the end of the string or after her not a quote
                        if (((indexNextQuot + 1) == line.length()) || (line.charAt(indexNextQuot + 1) != '\"')) {
                            //get string from this column, remove duplicate of quotes and add result to the array
                            String str = line.substring(indexQuot + 1, indexNextQuot);
                            str = str.replace("\"\"", "\"");
                            if (indexNextQuot + 1 != line.length()) indexNextQuot++;
                            line = line.substring(indexNextQuot + 1);
                            list.add(str);
                            break;
                        } else {
                            indexNextQuot++;
                        }
                    }
                }
        }
        return list;
    }
}
