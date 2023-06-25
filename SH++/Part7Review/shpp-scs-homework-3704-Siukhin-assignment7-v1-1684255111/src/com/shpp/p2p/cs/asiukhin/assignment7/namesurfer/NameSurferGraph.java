package com.shpp.p2p.cs.asiukhin.assignment7.namesurfer;

/*
 * File: NameSurferGraph.java
 * ---------------------------
 * This class represents the canvas on which the graph of
 * names is drawn. This class is responsible for updating
 * (redrawing) the graphs whenever the list of entries changes
 * or the window is resized.
 */

import acm.graphics.*;

import java.awt.event.*;
import java.util.*;
import java.awt.*;

public class NameSurferGraph extends GCanvas implements NameSurferConstants, ComponentListener {

    private double width;
    private double height;
    private double columnWidth;

    private final Set<NameSurferEntry> entries;

    /**
     * Creates a new NameSurferGraph object that displays the data.
     */
    public NameSurferGraph() {
        entries = new LinkedHashSet<>();
        addComponentListener(this);
        update();
    }


    /**
     * Clears the list of name surfer entries stored inside this class.
     */
    public void clear() {
        entries.clear();
        update();
    }


    /* Method: addEntry(entry) */

    /**
     * Adds a new NameSurferEntry to the list of entries on the display.
     * Note that this method does not actually draw the graph, but
     * simply stores the entry; the graph is drawn by calling update.
     */
    public void addEntry(NameSurferEntry entry) {
        entries.add(entry);
        update();
    }

    /**
     * Removes NameSurferEntry to the list of entries on the display
     */
    public void removeEntry(NameSurferEntry entry) {
        entries.remove(entry);
        update();
    }


    /**
     * Updates the display image by deleting all the graphical objects
     * from the canvas and then reassembling the display according to
     * the list of entries. Your application must call update after
     * calling either clear or addEntry; update is also called whenever
     * the size of the canvas changes.
     */
    public void update() {
        width = getWidth();
        height = getHeight();
        columnWidth = width / NDECADES;
        removeAll();
        drawDecades();
        drawMesh();
        drawLineStatistics();
    }

    /**
     * Draws decades at the bottom
     */
    private void drawDecades() {
        double yLabel = height - GRAPH_LABEL_PADDING;
        for (int i = 0; i < NDECADES; i++) {
            double xLabel = GRAPH_LABEL_PADDING + i * columnWidth;
            add(new GLabel(String.valueOf(START_DECADE + (i * 10)), xLabel, yLabel));
        }
    }

    /**
     * Draws chart mesh. vertical and horizontal lines
     */
    private void drawMesh() {
        //vertical
        for (int i = 0; i < NDECADES; i++) {
            double xVertical = i * columnWidth;
            add(new GLine(xVertical, 0, xVertical, height));
        }

        //bottom and top horizontal lines
        add(new GLine(0, GRAPH_MARGIN_SIZE, width, GRAPH_MARGIN_SIZE));
        add(new GLine(0, height - GRAPH_MARGIN_SIZE, width, height - GRAPH_MARGIN_SIZE));
    }

    /**
     * Draws entities on chart
     */
    private void drawLineStatistics() {
        Color[] colors = new Color[]{Color.BLUE, Color.RED, Color.MAGENTA, Color.BLACK};
        int colorIterator = 0;

        // calc ratio for correct value placement
        double yBottom = height - GRAPH_MARGIN_SIZE;
        double rankRatio = (yBottom - GRAPH_MARGIN_SIZE) / MAX_RANK;

        for (NameSurferEntry nse : entries) {

            for (int i = 0; i < NDECADES; i++) {

                // get x1 y1 cords for label and line
                double x1 = columnWidth * i;
                double y1 = nse.getRank(i) * rankRatio;

                // fix y1 if zero
                if(y1 == 0) {
                    y1 = yBottom;
                } else {
                    y1 += GRAPH_MARGIN_SIZE;
                }

                //add label for name
                String rank = (nse.getRank(i) == 0) ? "*": String.valueOf(nse.getRank(i));
                GLabel label = new GLabel(nse.getName() + rank,x1,y1);
                label.setColor(colors[colorIterator]);
                add(label);

                // make line if we did not reach the last decade
                if(i + 1 < NDECADES){
                    // get x2 y2 for line
                    double x2 = x1 + columnWidth;
                    double y2 = nse.getRank(i + 1) * rankRatio;

                    // fix y2
                    if(y2 == 0) {
                        y2 = yBottom;
                    } else {
                        y2 += GRAPH_MARGIN_SIZE;
                    }

                    // draw line
                    GLine line = new GLine(x1, y1, x2, y2);
                    line.setColor(colors[colorIterator]);
                    add(line);
                }
            }

            // change color
            colorIterator++;
            if(colorIterator == colors.length) {
                colorIterator = 0;
            }
        }
    }


    /* Implementation of the ComponentListener interface */
    public void componentHidden(ComponentEvent e) {
    }

    public void componentMoved(ComponentEvent e) {
    }

    public void componentResized(ComponentEvent e) {
        update();
    }

    public void componentShown(ComponentEvent e) {
    }
}
