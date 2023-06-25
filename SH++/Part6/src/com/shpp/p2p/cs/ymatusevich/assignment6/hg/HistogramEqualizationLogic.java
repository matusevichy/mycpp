package com.shpp.p2p.cs.ymatusevich.assignment6.hg;

import java.util.Arrays;

public class HistogramEqualizationLogic {
    private static final int MAX_LUMINANCE = 255;

    /**
     * Given the luminances of the pixels in an image, returns a histogram of the frequencies of
     * those luminances.
     * <p/>
     * You can assume that pixel luminances range from 0 to MAX_LUMINANCE, inclusive.
     *
     * @param luminances The luminances in the picture.
     * @return A histogram of those luminances.
     */
    public static int[] histogramFor(int[][] luminances) {
        int[] histogram = new int[MAX_LUMINANCE + 1];
        //Count the number of pixels for each luminance in the loops and store in a new array
        for (int row = 0; row < luminances.length; row++) {
            for (int col = 0; col < luminances[row].length; col++) {
                int luminance = luminances[row][col];
                //Increase the number of pixels for current pixel luminance
                histogram[luminance]++;
            }
        }
        return histogram;
    }

    /**
     * Given a histogram of the luminances in an image, returns an array of the cumulative
     * frequencies of that image.  Each entry of this array should be equal to the sum of all
     * the array entries up to and including its index in the input histogram array.
     * <p/>
     * For example, given the array [1, 2, 3, 4, 5], the result should be [1, 3, 6, 10, 15].
     *
     * @param histogram The input histogram.
     * @return The cumulative frequency array.
     */
    public static int[] cumulativeSumFor(int[] histogram) {
        int[] cumulativeHistogram = new int[MAX_LUMINANCE + 1];
        //Calculate cumulative histogram in loop
        for (int i = 0; i < histogram.length; i++) {
            if (i == 0) cumulativeHistogram[i] = histogram[i];
            else cumulativeHistogram[i] = histogram[i] + cumulativeHistogram[i - 1]; //sum all previous luminance
        }
        return cumulativeHistogram;
    }

    /**
     * Returns the total number of pixels in the given image.
     *
     * @param luminances A matrix of the luminances within an image.
     * @return The total number of pixels in that image.
     */
    public static int totalPixelsIn(int[][] luminances) {
        //Return calculated number of pixels (width * height)
        return luminances.length * luminances[0].length;
    }

    /**
     * Applies the histogram equalization algorithm to the given image, represented by a matrix
     * of its luminances.
     * <p/>
     * You are strongly encouraged to use the three methods you have implemented above in order to
     * implement this method.
     *
     * @param luminances The luminances of the input image.
     * @return The luminances of the image formed by applying histogram equalization.
     */
    public static int[][] equalize(int[][] luminances) {
        //Get histogram for image array
        var histogram = histogramFor(luminances);
        //Get cumulative histogram
        var cumulativeHistogram = cumulativeSumFor(histogram);
        //Get number of image pixels
        var totalPixels = totalPixelsIn(luminances);
        int rowsCount = luminances.length;
        int columnsCount = luminances[0].length;
        int[][] result = new int[rowsCount][columnsCount];

        //Changing luminance for each image pixel in the loops
        for (int row = 0; row < rowsCount; row++){
            for (int col = 0; col < columnsCount; col++){
                result[row][col] = MAX_LUMINANCE * cumulativeHistogram[luminances[row][col]] / totalPixels;
            }
        }
        return result;
    }
}
