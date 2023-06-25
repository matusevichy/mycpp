package com.shpp.p2p.cs.vlisyuk.assignment6.hg;

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
        // Initialize the histogram to all zeroes
        for (int i = 0; i <= MAX_LUMINANCE; i++) {
            histogram[i] = 0;
        }

        // Iterate through the luminance values and increment the histogram
        for (int[] row : luminances) {
            for (int luminance : row) {
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
        int[] cumulativeSum = new int[histogram.length];

        cumulativeSum[0] = histogram[0];
        for (int i = 1; i < histogram.length; i++) {
            cumulativeSum[i] = cumulativeSum[i - 1] + histogram[i];
        }
        return cumulativeSum;
    }

    /**
     * Returns the total number of pixels in the given image.
     *
     * @param luminances A matrix of the luminances within an image.
     * @return The total number of pixels in that image.
     */
    public static int totalPixelsIn(int[][] luminances) {
        int numRows = luminances.length;
        int numCols = luminances[0].length;
        return numRows * numCols;
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
        // Get the histogram and the cumulative sum
        int[] histogram = histogramFor(luminances);
        int[] cumulativeSum = cumulativeSumFor(histogram);

        // Get the total number of pixels and create a new brightness matrix
        int totalPixels = totalPixelsIn(luminances);
        int[][] equalized = new int[luminances.length][luminances[0].length];

        // Apply the histogram equalization algorithm to each pixel in the image
        for (int row = 0; row < luminances.length; row++) {
            for (int col = 0; col < luminances[row].length; col++) {
                int currentLuminance = luminances[row][col];
                int equalizedLuminance = (cumulativeSum[currentLuminance] * MAX_LUMINANCE) / totalPixels;
                equalized[row][col] = equalizedLuminance;
            }
        }
        // Return the matrix of equalized brightnesses
        return equalized;
    }
}
