package com.shpp.p2p.cs.amykhailichenko.assignment6.arrays.tm;

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
        double[] result = new double[samples[0].length];
        double maxAmplitude = 1.0;

        for (int i = 0; i < samples.length; i++) {
            for (int y = 0; y < samples[0].length; y++) {
                if (toneMatrix[i][column]) {
                    result[y] += samples[i][y];
                }
            }
        }

        for (int i = 0; i < samples[0].length; i++) {
            if (Math.abs(result[i]) > maxAmplitude) {
                maxAmplitude = Math.abs(result[i]);
            }
        }

        if (maxAmplitude > 1.0) {
            for (int i = 0; i < samples[0].length; i++) {
                result[i] /= maxAmplitude;
            }
        }

        return result;
    }
}



