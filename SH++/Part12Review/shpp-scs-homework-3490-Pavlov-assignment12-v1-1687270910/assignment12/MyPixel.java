package com.shpp.p2p.cs.dpavlov.assignment12;

/**
 * Class created to encapsulate all methods and parameters of Image pixel
 */
public class MyPixel implements ControlConstants {
    // Current pixel luminance (gray scale)
    private final int LUMINANCE;
    //Current status of pixel
    private STATUS_LIST status;

    /**
     * Class constructor calculate Gray scaled luminance and set ALPHA CHANEL status if present
     */
    public MyPixel(int argb) {
        // extraction Alpha, Red,Green,Blue components from ARGB integer value
        int aComponent = (argb >> 24) & 0xff;
        int rComponent = (argb >> 16) & 0xff;
        int gComponent = (argb >> 8) & 0xff;
        int bComponent = (argb) & 0xff;
        //calculating luminance
        this.LUMINANCE = (int) (0.3 * rComponent + 0.59 * gComponent + 0.11 * bComponent + 0.5);
        if (aComponent < MAX_LUMINANCE) this.status = STATUS_LIST.ALPHA;
    }

    /** Setters and getters section */
    public int getLUMINANCE() {
        return LUMINANCE;
    }

    public STATUS_LIST getStatus() {
        return status;
    }

    public void setStatus(STATUS_LIST status) {
        this.status = status;
    }
}
