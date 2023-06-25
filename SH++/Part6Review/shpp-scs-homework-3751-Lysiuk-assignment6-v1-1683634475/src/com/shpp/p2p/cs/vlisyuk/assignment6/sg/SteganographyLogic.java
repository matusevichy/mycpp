package com.shpp.p2p.cs.vlisyuk.assignment6.sg;

import acm.graphics.*;

public class SteganographyLogic {
    /**
     * Given a GImage containing a hidden message, finds the hidden message
     * contained within it and returns a boolean array containing that message.
     * <p/>
     * A message has been hidden in the input image as follows.  For each pixel
     * in the image, if that pixel has a red component that is an even number,
     * the message value at that pixel is false.  If the red component is an odd
     * number, the message value at that pixel is true.
     *
     * @param source The image containing the hidden message.
     * @return The hidden message, expressed as a boolean array.
     */
    public static boolean[][] findMessage(GImage source) {
        // Get the two-dimensional pixel array from the source image
        int[][] pixels = source.getPixelArray();
        // Create a new two-dimensional boolean array to store the message
        boolean[][] message = new boolean[pixels.length][pixels[0].length];
        // Loop through every pixel in the pixel array
        for (int row = 0; row < pixels.length; row++) {
            for (int col = 0; col < pixels[row].length; col++) {
                // Get the red component of the current pixel using the GImage.getRed() method
                int redComponent = GImage.getRed(pixels[row][col]);
                // If the red component is even, set the corresponding message value to false. Otherwise, set it to true.
                if (redComponent % 2 == 0) {
                    message[row][col] = false;
                } else {
                    message[row][col] = true;
                }
            }
        }
        // Return the two-dimensional boolean array containing the hidden message
        return message;
    }


    /**
     * Hides the given message inside the specified image.
     * <p/>
     * The image will be given to you as a GImage of some size, and the message will
     * be specified as a boolean array of pixels, where each white pixel is denoted
     * false and each black pixel is denoted true.
     * <p/>
     * The message should be hidden in the image by adjusting the red channel of all
     * the pixels in the original image.  For each pixel in the original image, you
     * should make the red channel an even number if the message color is white at
     * that position, and odd otherwise.
     * <p/>
     * You can assume that the dimensions of the message and the image are the same.
     * <p/>
     *
     * @param message The message to hide.
     * @param source  The source image.
     * @return A GImage whose pixels have the message hidden within it.
     */
    public static GImage hideMessage(boolean[][] message, GImage source) {

        // Convert image to array of ints
        int[][] pixels = source.getPixelArray();
        // Initialize an array with the same length
        int[][] newPixels = new int[pixels.length][pixels[0].length];

        // Copying values from one array to another
        for (int row = 0; row < pixels.length; row++) {
            for (int col = 0; col < pixels[row].length; col++) {

                // In this int we have a large number, not [255,11,23], [255,11,23], [255,11,23]
                int color = pixels[row][col];

                // Let's break it down into parts
                // Get the red, green, and blue components of the current pixel
                int red = GImage.getRed(color);
                int green = GImage.getGreen(color);
                int blue = GImage.getBlue(color);

                // Determine the new red value based on the message
                if (message[row][col]) {
                    // The message color is black, so make the red component odd
                    if (red % 2 == 0) {
                        red += 1;
                    }
                } else {
                    // The message color is white, so make the red component even
                    if (red % 2 == 1) {
                        red -= 1;
                    }
                }

                // Combine the new red, green, and blue components into a single pixel
                int newColor = GImage.createRGBPixel(red, green, blue);
                newPixels[row][col] = newColor;
            }
        }
        // Create a new GImage with the modified pixel array and return it
        return new GImage(newPixels);
    }
}
