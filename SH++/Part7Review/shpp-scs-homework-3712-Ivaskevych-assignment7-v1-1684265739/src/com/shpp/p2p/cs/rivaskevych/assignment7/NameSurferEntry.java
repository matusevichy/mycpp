package com.shpp.p2p.cs.rivaskevych.assignment7;

/*
 * File: NameSurferEntry.java
 * --------------------------
 * This class represents a single entry in the database.  Each
 * NameSurferEntry contains a name and a list giving the popularity
 * of that name for each decade stretching back to 1900.
 */

public class NameSurferEntry implements NameSurferConstants {

    private String name;
    private int[] ranks;

    /**
     * Creates a new NameSurferEntry from a data line as it appears
     * in the data file.  Each line begins with the name, which is
     * followed by integers giving the rank of that name for each
     * decade.
     */
    public NameSurferEntry(String line) {
        String[] elements = line.split(" ");
        name = elements[0];
        ranks = new int[NDECADES];
        for (int i = 0; i < NDECADES; i++) {
            ranks[i] = Integer.parseInt(elements[i+1]);
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
        return ranks[decade];
    }

    /**
     * Returns a string that makes it easy to see the value of a
     * NameSurferEntry.
     */
    public String toString() {
        StringBuilder builder = new StringBuilder();
        builder.append(name).append(" [");
        for (int i = 0; i < NDECADES; i++) {
            if (i == NDECADES-1) {
                builder.append(ranks[i]).append("]");
            } else builder.append(ranks[i]).append(" ");
        }
        return builder.toString();
    }
}

