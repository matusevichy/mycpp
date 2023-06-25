package com.shpp.p2p.cs.ymatusevich.assignment7;

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

public class NameSurferGraph extends GCanvas
        implements NameSurferConstants, ComponentListener {
    //Array of the user selected entries
    private Set<NameSurferEntry> entries;

    /**
     * Creates a new NameSurferGraph object that displays the data.
     */
    public NameSurferGraph() {
        entries = new HashSet<>();
        addComponentListener(this);
    }


    /**
     * Clears the list of name surfer entries stored inside this class.
     */
    public void clear() {
        entries.clear();
    }


    /* Method: addEntry(entry) */

    /**
     * Adds a new NameSurferEntry to the list of entries on the display.
     * Note that this method does not actually draw the graph, but
     * simply stores the entry; the graph is drawn by calling update.
     */
    public void addEntry(NameSurferEntry entry) {
        entries.add(entry);
    }


    /**
     * Updates the display image by deleting all the graphical objects
     * from the canvas and then reassembling the display according to
     * the list of entries. Your application must call update after
     * calling either clear or addEntry; update is also called whenever
     * the size of the canvas changes.
     */
    public void update() {
        removeAll();
        createVerticalLines();
        createHorizontalLines();
        createCharts();
    }

    /**
     * Draws the graphs for the user selected entries
     */
    private void createCharts() {
        //define coordinates for draw graphs relatively size of the window
        var axisYZeroPoint = GRAPH_MARGIN_SIZE;
        var axisYLength = getHeight() - GRAPH_MARGIN_SIZE - axisYZeroPoint;
        var scaleY = (double) axisYLength / MAX_RANK;
        int offSetX = this.getWidth() / 12;
        int colorIndex = 0;

        //Draw graphs for selected entries in the loop
        for (NameSurferEntry entry : entries) {
            var name = entry.getName();
            var rank = entry.getRank(0);

            //Set point coordinates for first decade and draw label
            var startLineX = 0;
            var startLineY = (rank > 0) ? (axisYZeroPoint + scaleY * rank) : axisYZeroPoint + axisYLength;
            createLabel(name, rank, startLineX, startLineY, colorIndex);

            //Set point coordinates for other decades, draw lines and labels in the loop
            for (int i = 1; i < NDECADES; i++) {
                rank = entry.getRank(i);
                var endLineX = i * offSetX;
                var endLineY = (rank > 0) ? (axisYZeroPoint + scaleY * rank) : axisYZeroPoint + axisYLength;
                var line = new GLine(startLineX, startLineY, endLineX, endLineY);
                line.setColor(LINE_COLORS[colorIndex]);
                add(line);
                startLineX = endLineX;
                startLineY = endLineY;
                createLabel(name, rank, startLineX, startLineY, colorIndex);
            }

            //Set color for the next graph
            colorIndex = (colorIndex < LINE_COLORS.length - 1)? colorIndex + 1: 0;
        }
    }

    /**
     * Draws label for the point on the graph
     * @param name - string value name of baby
     * @param rank - rank of name
     * @param startLineX - x coordinate of the drawing point
     * @param startLineY - x coordinate of the drawing point
     * @param colorIndex - index of the drawing color in the LINE_COLORS array
     */
    private void createLabel(String name, int rank, int startLineX, double startLineY, int colorIndex) {
        var text = name + " " + ((rank > 0) ? Integer.toString(rank) : "*");
        var label = new GLabel(text, startLineX, startLineY);
        label.setColor(LINE_COLORS[colorIndex]);
        add(label);
    }

    /**
     * Draws horizontal lines on the chart for 0 and 1000 ranks
     */
    private void createHorizontalLines() {
        add(new GLine(0, GRAPH_MARGIN_SIZE, getWidth(), GRAPH_MARGIN_SIZE));
        add(new GLine(0, getHeight() - GRAPH_MARGIN_SIZE, getWidth(), getHeight() - GRAPH_MARGIN_SIZE));
    }

    /**
     * Draws vertical lines on the chart for 12 decades
     */
    private void createVerticalLines() {
        int offSetX = this.getWidth() / 12;
        for (int i = 0; i < NDECADES; i++) {
            var year = START_DECADE + i * 10;
            var x = i * offSetX;
            add(new GLine(x, 0, x, getHeight()));
            var label = new GLabel(Integer.toString(year), x, getHeight());
            label.setFont(LABEL_FONT);
            add(label);
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
