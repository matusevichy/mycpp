package com.shpp.p2p.cs.ymatusevich.assignment12;

import acm.graphics.GImage;
import com.shpp.cs.a.console.TextProgram;

import java.awt.*;
import java.util.ArrayList;
import java.util.Collections;

/**
 * Program calculates count of big objects on the picture
 * To prevent an error StackOverFlow on big pictures need to add "-Xss64m" to VM option in the
 * "Edit configuration" dialog.
 */
public class Assignment12Part1 extends TextProgram {

    //Set difference between fon and silhouette colors
    private static final Double COLOR_DIFFERENCE = 100000.0;

    //Set difference between big and small objects
    private static final Double SIZE_DIFFERENCE = 2.0;

    //Array of the shifts for recursive pixels checking
    private static final int[] SHIFTS = new int[]{-1, 0, 1};

    public static void main(String[] args) {
        String fileName = args.length == 0 ? "test.jpg" : args[0];
        try {
            var image = new GImage(fileName);
            System.out.println(findSilhouettes(image));
        } catch (Exception e) {
            System.out.println(e.getMessage());
        }
    }

    /**
     * Checks all pixels of image in the two loops, find all objects on the picture, save pixels count of each object
     * to the array.
     *
     * @param image original image for analise
     * @return count of the big objects
     */
    private static long findSilhouettes(GImage image) {
        var pixelsArray = image.getPixelArray();
        var backgroundColor = new Color(pixelsArray[0][0]);

        //Array of the all founded objects
        ArrayList<Integer> silhouettes = new ArrayList<>();
        for (int i = 0; i < pixelsArray.length; i++)
            for (int j = 0; j < pixelsArray[0].length; j++) {
                var color = new Color(pixelsArray[i][j]);
                if (getColorsDistance(color, backgroundColor) >= COLOR_DIFFERENCE) {
                    //Save founded object pixel count to array
                    silhouettes.add(getSilhouette(pixelsArray, i, j, backgroundColor, 0));
                }
            }
        return getCountBigSilhouettes(silhouettes);
    }

    /**
     * Calculates count of the pixels in some object recursively
     *
     * @param pixelsArray     array of the image pixels
     * @param row             row of the being checked pixel
     * @param col             column of the being checked pixel
     * @param backgroundColor color of the background
     * @param pixelsCount     count of pixels in current object
     * @return count of pixels in current object
     */
    private static Integer getSilhouette(int[][] pixelsArray, int row, int col, Color backgroundColor, int pixelsCount) {
        if (getColorsDistance(new Color(pixelsArray[row][col]), backgroundColor) >= COLOR_DIFFERENCE) {
            //If pixel not background increasing pixel count
            pixelsCount++;
            //Mark current pixel as background
            pixelsArray[row][col] = backgroundColor.getRGB();

            //Recursively check neighboring pixels
            for (int i = 0; i < SHIFTS.length; i++) {
                for (int j = 0; j < SHIFTS.length; j++) {
                    var nextRow = row + SHIFTS[i];
                    var nextCol = col + SHIFTS[j];
                    if (nextRow < 0 || nextRow > pixelsArray.length - 1 || nextCol < 0 || nextCol > pixelsArray[0].length - 1)
                        continue;
                    else {
                        pixelsCount = getSilhouette(pixelsArray, nextRow, nextCol, backgroundColor, pixelsCount);
                    }
                }
            }
        }

        return pixelsCount;
    }

    /**
     * Calculates difference between two colors
     * @param c1 first color
     * @param c2 second color
     * @return size of the difference
     */
    private static double getColorsDistance(Color c1, Color c2) {
        return Math.pow((c1.getRed() - c2.getRed()), 2) +
                Math.pow((c1.getGreen() - c2.getGreen()), 2) +
                Math.pow((c1.getBlue() - c2.getBlue()), 2);
    }

    /**
     * Calculates count of the biggest objects using constant SIZE_DIFFERENCE
     * @param silhouettes array of the all founded objects
     * @return count of the biggest objects
     */
    private static long getCountBigSilhouettes(ArrayList<Integer> silhouettes) {
        var biggest = Collections.max(silhouettes);
        var count = silhouettes.stream().filter(s -> s >= biggest / SIZE_DIFFERENCE).count();

        return count;
    }
}
