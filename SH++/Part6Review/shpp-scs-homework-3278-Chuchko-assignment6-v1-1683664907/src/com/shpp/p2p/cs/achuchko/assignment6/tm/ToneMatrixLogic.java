package com.shpp.p2p.cs.achuchko.assignment6.tm;

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
        double[] array = new double[ToneMatrixConstants.sampleSize()];

        for (int row = 0; row < toneMatrix.length; row++) {
            if (toneMatrix[row][column] == true) {
                array = compositionOfSoundWaves(array, samples[row]);
            }
        }

        result = soundWaveNormalization(array);

        return result;
    }


    /**
     * Method for adding tone
     */
    public static double[] compositionOfSoundWaves(double[] oldArray, double[] newArray) {
        double[] array = new double[oldArray.length];

        for (int i = 0; i < oldArray.length; i++) {
            array[i] = oldArray[i] + newArray[i];
        }
        return array;
    }

    /**
     * Method for normalize the sound wave for the range
     */
    public static double[] soundWaveNormalization(double[] array) {
        double[] normalizedArray = new double[array.length];
        /**
         * Finding the largest number in an array modulo
         * */
        double max = Math.abs(array[0]);
        int largestElementIndex = 0;
        for (int i = 1; i < array.length; i++) {
            if (Math.abs(array[i]) > max) {
                max = Math.abs(array[i]);
                largestElementIndex = i;
            }
        }

        /** In the event that there is a value in the wave greater than 1 taken in absolute value,
         *  then we normalize the wave
         *  */
        if (max > 1) {
            double largestNumber = array[largestElementIndex];
            for (int i = 0; i < array.length; i++) {
                normalizedArray[i] = array[i] / largestNumber;
            }
        } else {
            normalizedArray = array;
        }

        return normalizedArray;
    }
}
