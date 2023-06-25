package com.shpp.p2p.cs.dpavlov.assignment12;

/**
 * Class implements parsing picture and calculate number of Silhouettes
 * in picturePath of picture entered by input parameters of main method (args[])
 * Numbers of silhouettes is a very "subjective" parameter. In case we
 * can get two results. The main result is based on the fact that the
 * silhouettes should be similar to each other (both size and color).
 * Similarity parameters are in the interface ControlConstants.
 * Main result gets by method findSilhouettes() (in class SearchEngine)
 * Side result gets by method getAlternativeResult() (in class SearchEngine)
 *
 * If alpha chanel present in image, application set it to background by default
 */
public class Assignment12Part1 {
    public static void main(String[] args) {
        String path = setupPath(args);
        PictureParser psr = new PictureParser(path);
        if (psr.getPARSED_PICTURE() != null) {
            SearchEngine search = new SearchEngine(psr.getPARSED_PICTURE());
            System.out.println("Number of Silhouettes = " + search.findSilhouettes());
            if (search.getAlternativeResult() != 0)
                System.out.println("Alternative result = " + search.getAlternativeResult());
        }
    }

    /**
     * Method setup path to target image file.
     * If there are more than one argument method returns empty string and error message
     *
     * @return test.jpg if argument array is empty, or String entered by call
     */
    private static String setupPath(String[] args) {
        switch (args.length) {
            case 0 -> {
                return "test.jpg";
            }
            case 1 -> {
                return args[0];
            }
            default -> {
                System.err.println("Error!!! Too many arguments!");
                System.out.println("Please check entered data!");
                return "";
            }
        }
    }
}
