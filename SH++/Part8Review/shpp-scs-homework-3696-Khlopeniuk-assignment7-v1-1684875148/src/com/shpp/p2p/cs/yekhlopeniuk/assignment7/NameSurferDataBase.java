package com.shpp.p2p.cs.yekhlopeniuk.assignment7;

/*
 * File: NameSurferDataBase.java
 * -----------------------------
 * This class keeps track of the complete database of names.
 * The constructor reads in the database from a file, and
 * the only public method makes it possible to look up a
 * name and get back the corresponding NameSurferEntry.
 * Names are matched independent of case, so that "Eric"
 * and "ERIC" are the same names.
 */

import java.io.BufferedReader;
import java.io.FileReader;
import java.io.IOException;
import java.util.ArrayList;

public class NameSurferDataBase implements NameSurferConstants {

    private final static String pathToDir = "\\src\\com\\shpp\\p2p\\cs\\yekhlopeniuk\\assignment7\\";
    public ArrayList<NameSurferEntry> dataBase = new ArrayList<>();

	/* Constructor: NameSurferDataBase(
	filename) */

    /**
     * Creates a new NameSurferDataBase and initializes it using the
     * data in the specified file.  The constructor throws an error
     * exception if the requested file does not exist or if an error
     * occurs as the file is being read.
     */
    public NameSurferDataBase(String filename) {
        //System.out.println(pathToDir + filename);
        /* Open and read the file, and get data values from it*/
        try {
            String dir = System.getProperty("user.dir"); //current directory
            BufferedReader br = new BufferedReader(new FileReader(filename));
            while (true) {
                String line = br.readLine();
                if (line == null) break;
                //create database entry from current line
                NameSurferEntry entry = new NameSurferEntry(line);
                //add entry to database
                dataBase.add(entry);
            }
            br.close();

        } catch (IOException e) {
            System.out.println("Something went wrong with database:(");
        }

    }

    /**
     * Returns the NameSurferEntry associated with this name, if one
     * exists.  If the name does not appear in the database, this
     * method returns null.
     */
    public NameSurferEntry findEntry(String name) {
        for (NameSurferEntry entry : dataBase) {
            if (entry.name.equals(name)) {
                return entry;
            }
        }
        return null; //there is no name in database
    }
}

