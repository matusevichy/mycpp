package com.shpp.p2p.cs.amykhailichenko.assignment6.arrays.hg;

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
        for (int i = 0; i < luminances.length; i++) {
            for (int y = 0; y < luminances[i].length; y++) {
                histogram[luminances[i][y]]++;
            }
        }
        return histogram; // 0 - 10 2 - 25
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
        int[] frequency = new int[histogram.length];
        frequency[0] = histogram[0];
        for (int i = 1; i < histogram.length; i++) {
            frequency[i] = frequency[i - 1] + histogram[i];
        }
        return frequency;
    }

    /**
     * Returns the total number of pixels in the given image.
     *
     * @param luminances A matrix of the luminances within an image.
     * @return The total number of pixels in that image.
     */
    public static int totalPixelsIn(int[][] luminances) {
        int x = 0;
        for (int i = 0; i < luminances.length; i++) {
            for (int y = 0; y < luminances[i].length; y++) {
                x++;
            }
        }
        return x;
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
        int[] cumulativeHistogram = cumulativeSumFor(histogramFor(luminances));
        int totalPixels = totalPixelsIn(luminances);
        int[][] newLuminance = new int[luminances.length][luminances[0].length];
        for (int i = 0; i < luminances.length; i++) {
            for (int y = 0; y < luminances[0].length; y++) {
                newLuminance[i][y] = (int) Math.round((double) MAX_LUMINANCE * cumulativeHistogram[luminances[i][y]] / totalPixels);
            }
        }
        return newLuminance;
    }
}
