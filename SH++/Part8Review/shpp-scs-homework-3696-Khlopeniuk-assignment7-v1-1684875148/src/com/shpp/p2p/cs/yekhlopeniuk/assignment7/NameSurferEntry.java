package com.shpp.p2p.cs.yekhlopeniuk.assignment7;

/*
 * File: NameSurferEntry.java
 * --------------------------
 * This class represents a single entry in the database.  Each
 * NameSurferEntry contains a name and a list giving the popularity
 * of that name for each decade stretching back to 1900.
 */

import java.util.*;

public class NameSurferEntry implements NameSurferConstants {

	public String name; //the main field = name of the entry
    public ArrayList<Integer> ranks = new ArrayList<>(); //12 ranks by decade

    /**
     * Creates a new NameSurferEntry from a data line as it appears
     * in the data file.  Each line begins with the name, which is
     * followed by integers giving the rank of that name for each
     * decade.
     */
    public NameSurferEntry(String line) {
        //split the line by space
        String[] values = line.split(" ");
        for (String s : values) {
            try {
                int rank = Integer.parseInt(s);
                ranks.add(rank);
            } catch (NumberFormatException e) {
                name = s;
                //it works only if database has no errors. But it works:)
            }
        }
    }

    /**
     * Returns the name associated with this entry.
     */
    public String getName() {
        return name;
    }


    /**
     * Returns the rank associated with an entry for a particular
     * decade.  The decade value is an integer indicating how many
     * decades have passed since the first year in the database,
     * which is given by the constant START_DECADE.  If a name does
     * not appear in a decade, the rank value is 0.
     */
    public int getRank(int decade) {
        return ranks.get(decade);
    }


    /**
     * Returns a string that makes it easy to see the value of a
     * NameSurferEntry.
     */
    public String toString() {
        String string = "";
        string += "[";
        string += name;
        for (int i : ranks) {
            string += " ";
            string += i;
        }
        string += "]";

        return string;
    }
}

