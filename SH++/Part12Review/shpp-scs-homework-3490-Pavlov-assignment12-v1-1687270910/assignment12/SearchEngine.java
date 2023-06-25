package com.shpp.p2p.cs.dpavlov.assignment12;

import java.util.ArrayList;

/**
 * Class search and calculate silhouettes of picture
 */
public class SearchEngine implements ControlConstants {
    // parsed image
    private final MyPixel[][] PARSED_PICTURE;
    private final int WIDTH;
    private final int HEIGHT;
    private final boolean[][] VISITS;
    private int counter;
    private final ArrayList<Integer> FOREGROUND_LIST = new ArrayList<>();
    private final ArrayList<Integer> BACKGROUND_LIST = new ArrayList<>();
    private int alternativeResult;

    /**
     * Class constructor.
     */
    public SearchEngine(MyPixel[][] parsedPicture) {
        this.PARSED_PICTURE = parsedPicture;
        this.WIDTH = this.PARSED_PICTURE.length;
        this.HEIGHT = this.PARSED_PICTURE[0].length;
        this.VISITS = new boolean[WIDTH][HEIGHT];
    }

    /**
     * Main math metod of silhouettes calculation
     */
    public int findSilhouettes() {
        for (int i = 0; i < WIDTH; i++)
            for (int j = 0; j < HEIGHT; j++)
                if (!VISITS[i][j]) {
                    VISITS[i][j] = true;
                    STATUS_LIST currentStatus = PARSED_PICTURE[i][j].getStatus();
                    counter = 0;
                    switch (currentStatus) {
                        case FOREGROUND_LAYER -> {
                            DFS(i, j);
                            FOREGROUND_LIST.add(counter);
                        }
                        case BACKGROUND_LAYER -> {
                            DFS(i, j);
                            BACKGROUND_LIST.add(counter);
                        }
                    } //switch
                }
        garbageCollector(BACKGROUND_LIST);
        garbageCollector(FOREGROUND_LIST);
        int result = Math.max(BACKGROUND_LIST.size(), FOREGROUND_LIST.size());
        this.alternativeResult = Math.min(BACKGROUND_LIST.size(), FOREGROUND_LIST.size());
        this.alternativeResult = result != this.alternativeResult ? this.alternativeResult : 0;
        return result;
    }

    /**
     * Deep search recursive method
     */
    private void DFS(int i, int j) {
        VISITS[i][j] = true;
        counter++;
        for (int[] direction : DIRECTIONS) {
            int newx = i + direction[0];
            int newy = j + direction[1];
            if ((newx >= 0 && newx < WIDTH) && (newy >= 0 && newy < HEIGHT) && !VISITS[newx][newy])
                if (PARSED_PICTURE[i][j].getStatus() == PARSED_PICTURE[newx][newy].getStatus())
                    DFS(newx, newy);
        }
    }

    /**
     * Garbage collector
     * Method works is two turns
     * In first turn collect smallest garbage
     * In first turn collect medium garbage
     * @param list: List of found objects while searching
     */
    private void garbageCollector(ArrayList<Integer> list) {
        // small garbage collector
        if (list.size() == 0) return;
        int maxValue = list.get(0);
        for (Integer current : list)
            if (current > maxValue) maxValue = current;
        double garbageSeparatorValue = maxValue * ABSOLUTE_GARBAGE_COLLECTOR_COEFFICIENT;
        for (int i = 0; i < list.size(); i++)
            if (list.get(i) < garbageSeparatorValue) {
                list.remove(i);
                i--;
            }
        // medium garbage collector
        int lowSizeGarbageBorder = 0;
        for (Integer element : list)
            lowSizeGarbageBorder += element;
        lowSizeGarbageBorder = (int) (lowSizeGarbageBorder / list.size() * RELATIVE_GARBAGE_COLLECTOR_COEFFICIENT);
        for (int i = 0; i < list.size(); i++) {
            if (list.get(i) < lowSizeGarbageBorder) {
                list.remove(i);
                i--;
            }
        }
    }

    /** Getter of result of alternative layer*/
    public int getAlternativeResult() {
        return alternativeResult;
    }
}
