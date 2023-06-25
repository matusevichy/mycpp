package com.shpp.p2p.cs.asiukhin.assignment7.namesurfer;

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
import java.io.File;
import java.io.FileReader;
import java.io.IOException;
import java.util.HashMap;

public class NameSurferDataBase implements NameSurferConstants {
    // hash map that stores rankings key is name and value is NameSurferEntry entity
    private final HashMap<String,NameSurferEntry> entries;

	/* Constructor: NameSurferDataBase(filename) */

    /**
     * Creates a new NameSurferDataBase and initializes it using the
     * data in the specified file.  The constructor throws an error
     * exception if the requested file does not exist or if an error
     * occurs as the file is being read.
     */
    public NameSurferDataBase(String filename) {
        entries = initData(filename);
    }

    /**
     * Fills up the hash map by values taken from data file
     */
    private HashMap<String,NameSurferEntry> initData(String filename) {
        HashMap<String,NameSurferEntry> lines = new HashMap<>();
        String line;

        System.out.println(new File(filename));

        try(BufferedReader br = new BufferedReader(new FileReader(filename))) {

            while ((line = br.readLine()) != null){
                NameSurferEntry nse = new NameSurferEntry(line);
                lines.put(nse.getName().toLowerCase(),nse);
            }

        }catch (IOException e){
            System.out.println("File not found!");
        }

        return lines;
    }
	
	/* Method: findEntry(name) */

    /**
     * Returns the NameSurferEntry associated with this name, if one
     * exists.  If the name does not appear in the database, this
     * method returns null.
     */
    public NameSurferEntry findEntry(String name) {
        return entries.get(name.toLowerCase());
    }
}

