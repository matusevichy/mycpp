package com.shpp.p2p.cs.bsvitlikovskyi.assignment12;

import javax.imageio.ImageIO;
import java.awt.*;
import java.awt.image.BufferedImage;
import java.io.File;
import java.io.IOException;
import java.util.HashMap;
import java.util.Map;

/**
 * The program for searching for silhouettes in the image,
 * the algorithm for searching for silhouettes can be described as follows:
 * - the program reads the image file
 * - guided by the weight coefficients for each color component, we reduce the image to shades of gray
 * - taking into account the necessary search method (the BORDER_CONTROL switch), we find the background
 * on which the search for silhouettes will be carried out
 * - taking into account the heterogeneity of the background +- BACKGROUND_GRADATION we find the pixel that differs from the background
 * - run DFS to bypass possible silhouette pixels, follow the rule "all non-background pixels belong to the silhouette"
 * - count the pixels belonging to the silhouette
 * - when traversing the silhouette, we mark the pixels that were passed in the array of passed pixels to avoid duplication
 * - by the number of pixels belonging to the silhouette, taking into account the GARBAGE COEFFICIENT,
 * we conclude about the belonging of the object
 */

public class Assignment12Part1 {

    /* variable that sets the background search mechanism (the background on which we will search for silhouettes):
     * false - according to the majority of pixels, the absolute majority of pixels of a certain tone is the desired background
     * true - according to the prevailing tone in the borders of the image
     */
    private static final boolean BORDER_CONTROL = true;

    /* the coefficient that establishes the probable heterogeneity of the background
     * means all pixels defined as background +- BACKGROUND_GRADATION
     */
    private static final int BACKGROUND_GRADATION = 40;

    // the coefficient of classifying the object as garbage is set as a percentage of the image area
    private static final double GARBAGE_COEFFICIENT = 0.2;
    private static int[][] pixels;              // an array to store the pixel brightness of the input image
    private static boolean[][] visitedPixels;   // an array in which information about pixel reading will be stored
    private static int countPixels;             // variable used in calculating the size of the object


    public static void main(String[] args) throws IOException {
        // read the image
        String fileName = "test.jpg";      // the default filename if no argument is passed to the program
        if (args.length > 0) {
            fileName = args[0];            // the first argument received must contain the name of the file to work with
        }
        System.out.println("Open file  " + fileName + ".");
        try {
            // read the image into an array in gradations of gray indicating the brightness of each pixel
            pixels = readImage(fileName);

        } catch (Exception e) {
            System.out.println("I can't open the file " + fileName);
            System.exit(1);
        }

        // find the background of the image, two search options for most pixels or extreme image boundaries
        int backgroundColor = findBackground(pixels);

        int result = findSilhouettes(pixels, backgroundColor);      // searching for silhouettes in the processed image
        System.out.println("Found " + result + " silhouettes!");
    }

    /**
     * The method counts the number of silhouettes in the image, which is transmitted in the form of a luminance matrix
     * the search is based on an alternate search of pixels,
     * if they correspond to the brightness of the background +- BACKGROUND_GRADATION
     * we understand that the silhouette is absent here
     * if the brightness value does not correspond to the background, we understand that we entered a possible silhouette
     * after finding the first pixel of the probable silhouette, we start the recursive search in depth
     * the criterion for continuing the search is the mismatch of another pixel with the brightness of
     * the background +- BACKGROUND_GRADATION
     * if the pixel belongs to the silhouette, we mark it as part of the silhouette in the visitedPixels array
     * calculate the size of each silhouette, based on this value we draw a conclusion about belonging object
     * to garbage or silhouettes
     *
     * @param pixels          - an array with the pixel quality of the received image
     * @param backgroundColor - calculated probable background brightness
     * @return - the number of found silhouettes that meet the specified search conditions
     */
    private static int findSilhouettes(int[][] pixels, int backgroundColor) {
        int countSilhouettes = 0;                               // initialize the counter of silhouettes
        int width = pixels.length;
        int height = pixels[0].length;
        int garbageSize = (int) (width * height * GARBAGE_COEFFICIENT / 100);   //calculate the size of the garbage in pixels
        visitedPixels = new boolean[width][height];    // initialize an array with information about the visited pixels that probably belong to the silhouette

        for (int y = 0; y < height; y++) {
            for (int x = 0; x < width; x++) {
                if (!visitedPixels[x][y]) { // check whether the pixel is not listed in previously visited ones

                    /* if the brightness of the pixel +- BACKGROUND_GRADATION does not match the background,
                     * we conclude that it belongs to the silhouette  */
                    if (pixels[x][y] < (backgroundColor - BACKGROUND_GRADATION) || pixels[x][y] > (backgroundColor + BACKGROUND_GRADATION)) {
                        countPixels = 0;    // reset the pixel counter for the next silhouette

                        // start a recursive search in depth to bypass the entire silhouette
                        dfs(x, y, width, height, backgroundColor);

                        // if the size of the silhouette is larger than the garbage, we conclude that it is a silhouette
                        if (countPixels > garbageSize) {
                            System.out.println("SILHOUETTE SIZE: " + countPixels);
                            countSilhouettes++;
                        }
                    }
                }
            }
        }
        return countSilhouettes;
    }


    /**
     * Recursive depth-first search function for image traversal
     * at each recursion and pixel matching, the countPixel pixel counter is increased by 1.
     * the conditions for exiting the recursion are going beyond the image,
     * or hitting the tone color +- BACKGROUND_GRADATION
     */
    private static void dfs(int x, int y, int width, int height, int backgroundColor) {

        // checking for going beyond the possible limits of the image
        if (x < 0 || x >= width || y < 0 || y >= height) {
            return;
        }

        // Check pixel visit and silhouette membership
        if (visitedPixels[x][y] || (pixels[x][y] <= (backgroundColor + BACKGROUND_GRADATION)
                && pixels[x][y] > backgroundColor - BACKGROUND_GRADATION)) {
            return;
        }

        // Mark a pixel as visited
        visitedPixels[x][y] = true;

        // count the number of pixels belonging to the silhouette
        countPixels++;

        // Call recursively for neighboring pixels
        dfs(x, y - 1, width, height, backgroundColor); // upper neighbor
        dfs(x + 1, y, width, height, backgroundColor); // left neighbor
        dfs(x - 1, y, width, height, backgroundColor); // right neighbor
        dfs(x, y + 1, width, height, backgroundColor); // lower neighbor
    }

    /**
     * A method for finding the probable background of the received image
     * has two background search options that are selected by the BORDER_CONTROL variable
     * false - according to the majority of pixels, the absolute majority of pixels of a certain tone
     * is the desired background
     * true - according to the prevailing tone in the borders of the image
     *
     * @param pixels - array of brightness pixels of the received image
     * @return - the brightness of the probable background
     */
    private static int findBackground(int[][] pixels) {
        HashMap<Integer, Integer> frequencyMap = new HashMap<>();   //a map for recording the luminance of all pixels

        int width = pixels.length;
        int height = pixels[0].length;

        //  go through all the pixels of the image
        for (int y = 0; y < height; y++) {
            for (int x = 0; x < width; x++) {
                frequencyMap.put(pixels[x][y], (frequencyMap.getOrDefault(pixels[x][y], 0) + 1));
            }
        }
        int mostFrequentColor = findMaxFrequentNumberInMap(frequencyMap);   // tone that occurs most often
        frequencyMap.clear();

        // look at all the pixels that form the borders of the image
        for (int y = 0; y < height; y++) {
            frequencyMap.put(pixels[0][y], (frequencyMap.getOrDefault(pixels[0][y], 0) + 1));
            frequencyMap.put(pixels[width - 1][y], (frequencyMap.getOrDefault(pixels[width - 1][y], 0) + 1));
        }

        for (int x = 0; x < width; x++) {
            frequencyMap.put(pixels[x][0], (frequencyMap.getOrDefault(pixels[x][0], 0) + 1));
            frequencyMap.put(pixels[x][height - 1], (frequencyMap.getOrDefault(pixels[x][height - 1], 0) + 1));
        }
        int borderColor = findMaxFrequentNumberInMap(frequencyMap);     // tone that is most often found on the border

        System.out.println("In the picture converted to gray tones, " + mostFrequentColor + " color is most often found.");
        System.out.println("According to the border pixels of the image, the most likely background color is " + borderColor + ".");
        String method1 = "The user sets the search for the background in such a way that " +
                "the pixels of the same brightness that prevail determine the background!";
        String method2 = "The user has specified background search -" +
                " the pixels that are most often found on the border of the image determine the background ";
        System.out.println(BORDER_CONTROL ? method2 : method1);

        return (BORDER_CONTROL) ? borderColor : mostFrequentColor;
    }

    /**
     * The method of finding the key by the most frequently used value in HashMap
     *
     * @param frequencyMap - HashMap as a value for each key is the frequency of finding brightness in the image (image boundaries)
     * @return - the key to which the largest value corresponds
     */
    private static int findMaxFrequentNumberInMap(HashMap<Integer, Integer> frequencyMap) {
        int maxFrequency = 0;
        int mostFrequentNumber = 0;
        for (Map.Entry<Integer, Integer> entry : frequencyMap.entrySet()) {
            int frequency = entry.getValue();
            if (frequency > maxFrequency) {
                maxFrequency = frequency;
                mostFrequentNumber = entry.getKey();
            }
        }
        return mostFrequentNumber;
    }


    /**
     * read the image into an array of pixels,
     * according to the weighting coefficients we determine the brightness - color in grayscale
     *
     * @param pathFile - the path to the file being processed
     * @return a two-dimensional array of the size of the received image with the brightness values of the corresponding pixel
     * @throws IOException file reading errors
     */
    private static int[][] readImage(String pathFile) throws IOException {

        BufferedImage image = ImageIO.read(new File(pathFile));

        /* By applying these weights to the value of each color and calculating their sum, we get
         * the brightness of the pixel in grayscale. Standard weights for each color (red, green, blue) according to the
         * RGB (Red-Green-Blue) color model are given in the ITU-R BT.709 standard
         */
        double redWeight = 0.299;
        double greenWeight = 0.587;
        double blueWeight = 0.114;

        // Get the width and height of the image
        int width = image.getWidth();
        int height = image.getHeight();

        int[][] pixels = new int[width][height];

        System.out.println("Image width - " + width + "; height - " + height + ".");

        for (int y = 0; y < height; y++) {
            for (int x = 0; x < width; x++) {
                Color color = new Color(image.getRGB(x, y), true);

                // determine the brightness value of each pixel, taking into account the weight coefficients of each component
                int gray = (int) (color.getRed() * redWeight +
                        color.getGreen() * greenWeight + color.getBlue() * blueWeight);

                // if a pixel has absolute transparency, we consider it as bright as possible
                if (color.getAlpha() == 0) {
                    gray = 255;
                }
                //  write the value of the pixel brightness in the array
                pixels[x][y] = gray;
            }
        }
        return pixels;
    }
}