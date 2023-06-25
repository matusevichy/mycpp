package com.shpp.p2p.cs.ymatusevich.assignment6.sg;

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
        //Get pixel array of source image
        var pixelArray = source.getPixelArray();
        boolean[][] result = new boolean[pixelArray.length][];

        //Check the red color value of all pixels in two loops and save result in array
        for (int row = 0; row < pixelArray.length; row++) {
            result[row] = new boolean[pixelArray[row].length];
            for (int col = 0; col < pixelArray[row].length; col++) {
                var red = GImage.getRed(pixelArray[row][col]);

                //if pixel`s red color value is even, put "false" into the result, otherwise put "true" into the result
                result[row][col] = (red % 2 == 0) ? false : true;
            }
        }
        return result;
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
        //Get pixel array of source image
        var pixelArray = source.getPixelArray();

        //Check the red color value of all pixels and value from message in two loops, and change red value
        for (int row = 0; row < pixelArray.length; row++) {
            for (int col = 0; col < pixelArray[row].length; col++) {
                var red = GImage.getRed(pixelArray[row][col]);
                var green = GImage.getGreen(pixelArray[row][col]);
                var blue = GImage.getBlue(pixelArray[row][col]);
                if (message[row][col] && ((red % 2) == 0)) red++;
                if (!message[row][col] && ((red % 2) != 0)) red--;
                pixelArray[row][col] = GImage.createRGBPixel(red, green, blue);
            }
        }
        return new GImage(pixelArray);
    }
}
