package com.shpp.p2p.cs.ymatusevich.assignment6.tm;

import java.util.Arrays;

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
        double[] result = new double[ToneMatrixConstants.sampleSize()];
        for (int row = 0; row < toneMatrix.length; row++){
            //If cell is true sum the sounds and store to result array
            if (toneMatrix[row][column]){
                for (int i = 0; i < result.length; i++){
                    result[i] += samples[row][i];
                }
            }
        }
        result = normalizeArray(result);
        return result;
    }

    /**
     * Normalizes array to range (-1.0 ; 1.0)
     * @param sample Array of double fo normalizing
     * @return normalized array
     */
    private static double[] normalizeArray(double[] sample) {
        double[] result = new double[sample.length];
        //Get maximal sound intensity
        double maxVal = Arrays.stream(sample).max().getAsDouble();
        double minVal = Arrays.stream(sample).min().getAsDouble();
        double max = Math.abs(maxVal) > Math.abs(minVal)? maxVal : minVal;
        //Normalizes the intensity of each element of the array relative to the maximum intensity
        for (int i = 0; i < sample.length; i++){
            result[i] = sample[i] == 0? 0 : sample[i] / max;
        }
        return result;
    }
}
