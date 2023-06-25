package com.shpp.p2p.cs.achuchko.assignment6.hg;

import acm.graphics.GImage;

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
        int[] array = new int[256];
        /**Сounting the histogram of the original image*/
        for (int row = 0; row < luminances.length; row++) {
            for (int col = 0; col < luminances[row].length; col++) {
                int rgb = luminances[row][col];
                int temp = array[rgb];
                array[rgb] = ++temp;
            }
        }

        return array;
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
        int[] array = new int[histogram.length];
        int count = 0;
        /**
         * Calculate the cumulative histogram
         * */
        for (int i = 0; i < histogram.length; i++) {
            array[i] = (histogram[i] + array[count]);

            if (i < 1) {
                continue;
            }
            count++;
        }

        return array;
    }

    /**
     * Returns the total number of pixels in the given image.
     *
     * @param luminances A matrix of the luminances within an image.
     * @return The total number of pixels in that image.
     */

    public static int totalPixelsIn(int[][] luminances) {
        /**Count the total number of pixels in an image*/
        GImage image = new GImage(luminances);
        int width = (int) image.getWidth();
        int height = (int) image.getHeight();

        return width * height;
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

        /**We get the necessary data from the method*/
        int[] histogram = histogramFor(luminances);
        int[] cumulative = cumulativeSumFor(histogram);
        int totalPixels = totalPixelsIn(luminances);

        /** Declaring a new array for storing mandible images*/
        int[][] newLuminance = new int[luminances.length][luminances[0].length];
        /**
         * Replace each luminance in the original image using the above formula
         * (newLuminance = MAX_LUMINANCE * cumulativeHistogram[L] / totalPixels)
         * */
        for (int row = 0; row < luminances.length; row++) {
            for (int col = 0; col < luminances[row].length; col++) {
                int l = luminances[row][col];
                newLuminance[row][col] = MAX_LUMINANCE * cumulative[l] / totalPixels;
            }
        }

        return newLuminance;
    }
}
