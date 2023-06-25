package com.shpp.p2p.cs.dpavlov.assignment12;

import javax.imageio.ImageIO;
import java.awt.image.BufferedImage;
import java.io.File;
import java.io.IOException;

/**
 * Class parse image to Array of pixels and set statuses for all of them.
 */
public class PictureParser implements ControlConstants {
    private final MyPixel[][] PARSED_PICTURE;

    /**
     * Class constructor
     */

    public PictureParser(String path) {
        this.PARSED_PICTURE = parsePicture(path);
        if (PARSED_PICTURE != null)
            setFrontAndBackLabels(setLuminanceSeparator());
    }

    /**
     * Method read Image from file and create two-dimensional array of pixels
     *
     * @param path: Path to target file
     * @return Array if file present, null if file not found
     */
    private MyPixel[][] parsePicture(String path) {
        try {
            BufferedImage current = ImageIO.read(new File(path));
            MyPixel[][] result = new MyPixel[current.getWidth()][current.getHeight()];
            for (int i = 0; i < result.length; i++)
                for (int j = 0; j < result[0].length; j++)
                    result[i][j] = new MyPixel(current.getRGB(i, j));
            return result;
        } catch (IOException e) {
            System.err.println("\nError while reading file");
            System.err.println("File " + path + " not found or busy!");
            System.out.println("Please enter correct data! ");
            return null;
        }
    }

    /**
     * method calculate value of luminance separator based on average luminance value
     */
    private int setLuminanceSeparator() {
        int[] luminanceHistogram = createLuminanceHistogram();
        int averageLuminance = calculateAverageLuminance(luminanceHistogram);
        return (int) (averageLuminance * LUMINANCE_SEPARATOR_COEFFICIENT);
    }

    private int[] createLuminanceHistogram() {
        int[] result = new int[MAX_LUMINANCE + 1];
        for (MyPixel[] rows : PARSED_PICTURE)
            for (MyPixel cell : rows)
                if (cell.getStatus() != STATUS_LIST.ALPHA)
                    result[cell.getLUMINANCE()]++;
        return result;
    }

    private int calculateAverageLuminance(int[] luminanceHistogram) {
        long sum = 0;
        int count = 0;
        for (int i = 0; i < luminanceHistogram.length; i++) {
            sum = sum + (long) i * luminanceHistogram[i];
            count += luminanceHistogram[i];
        }
        return (int) (sum / count);
    }

    /**
     * Method setup type of layers for picture (foreground and background
     */
    private void setFrontAndBackLabels(int luminanceSeparator) {
        for (MyPixel[] row : PARSED_PICTURE)
            for (MyPixel cell : row) {
                if (cell.getStatus() == STATUS_LIST.ALPHA) continue;
                if (cell.getLUMINANCE() < luminanceSeparator)
                    cell.setStatus(STATUS_LIST.BACKGROUND_LAYER);
                else
                    cell.setStatus(STATUS_LIST.FOREGROUND_LAYER);
            }
    }

    /** Getters section */
    public MyPixel[][] getPARSED_PICTURE() {
        return PARSED_PICTURE;
    }
}
