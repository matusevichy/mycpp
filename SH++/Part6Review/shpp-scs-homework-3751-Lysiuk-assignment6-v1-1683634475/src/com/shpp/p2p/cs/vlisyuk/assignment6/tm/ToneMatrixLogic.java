package com.shpp.p2p.cs.vlisyuk.assignment6.tm;

import com.shpp.p2p.cs.vlisyuk.assignment6.tm.ToneMatrixConstants;

public class ToneMatrixLogic {
    /**
     * Given the contents of the tone matrix, returns a string of notes that should be played
     * to represent that matrix.
     *
     * @param toneMatrix The contents of the tone matrix.
     * @param column     The column number that is currently being played.
     * @param samples    The sound samples associated with each row.
     * @return A sound sample corresponding to all notes currently being played.
     */

    public static double[] matrixToMusic(boolean[][] toneMatrix, int column, double[][] samples) {
        // This creates two variables numRows and numCols for the number of rows and columns in the toneMatrix, respectively.
        int numRows = toneMatrix.length;
        int numCols = toneMatrix[0].length;
        // Create an array result of size sampleSize() that stores volume values for each of sampleSize()
        // sound wave points.
        double[] result = new double[ToneMatrixConstants.sampleSize()];
        //Check if the current column is within the bounds of the matrix toneMatrix. If she is outside,
        // return an empty array result.
        if (column >= numCols) {
            return result;
        }
        // Loop through each row in the current column of the toneMatrix. If the current value
        // toneMatrix[row][column] is true, then sum the values from the samples array in the corresponding positions
        // with array result. The result values contain the sum of all sound samples that will be played for
        // current column.
        for (int row = 0; row < numRows; row++) {
            if (toneMatrix[row][column]) {
                for (int i = 0; i < samples[row].length; i++) {
                    result[i] += samples[row][i];
                }
            }
        }
        // Find the maximum absolute value in the result array. This is necessary in order to normalize the values
        // in the result array so that they remain between -1 and 1. First, we take the first element of the array
        // result and define its absolute value as max. Then, we iterate over the remaining elements of the result array,
        // compare their absolute value with the current maximum value max and, if the value is greater, then replace
        // max to this value.
        double max = Math.abs(result[0]);
        for (int i = 1; i < result.length; i++) {
            if (Math.abs(result[i]) > max) {
                max = Math.abs(result[i]);
            }
        }
        // If the maximum value in the result array is greater than 1, then we normalize by dividing each element of the array
        // to the maximum value. This ensures that the values in the result array will be between -1 and 1.
        if (max > 1.0) {
            for (int i = 0; i < result.length; i++) {
                result[i] /= max;
            }
        }
        // Return normalized array
        return result;
    }
}

