package com.shpp.p2p.cs.dpavlov.assignment12;

/**
 * Interface implement control constants used in program
 */
public interface ControlConstants {
    // Pixel Statuses while program running
    enum STATUS_LIST {ALPHA, BACKGROUND_LAYER, FOREGROUND_LAYER}
    // Maximal luminance of pixel
    int MAX_LUMINANCE = 255;
    // Constant regulate value of luminance, to separate background and foreground layers
    // Used after calculate average luminance in parser.
    double LUMINANCE_SEPARATOR_COEFFICIENT = 0.7;
    // Setting offset directions coordinates while silhouettes size processing
    // {1,0} - east pixel {0,1} -south pixel ...
    int[][] DIRECTIONS = {{1,0},{0,1},{-1,0},{0,-1}};
    // Constant set absolute garbage size (based on maximal size of silhouette
    // Example: if maximum size of silhouette is 1500 pixels all elements sized
    // less than 1500*0.02 = 30 pixels automatically mark as garbage
    double ABSOLUTE_GARBAGE_COLLECTOR_COEFFICIENT = 0.02;
    // Constant set Relative garbage size (based an average size of silhouette
    // after collecting small garbage)
    // Example. Sizes of silhouettes 500 400 100 600. Average size 400.
    // All element sized less than 400*0.3 = 120 marks as garbage
    double RELATIVE_GARBAGE_COLLECTOR_COEFFICIENT = 0.3;

}
