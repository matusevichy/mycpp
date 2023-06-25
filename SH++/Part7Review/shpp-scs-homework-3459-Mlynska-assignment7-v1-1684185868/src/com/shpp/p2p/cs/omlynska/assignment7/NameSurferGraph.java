package com.shpp.p2p.cs.omlynska.assignment7;

/*
 * File: NameSurferGraph.java
 * ---------------------------
 * This class represents the canvas on which the graph of
 * names is drawn. This class is responsible for updating
 * (redrawing) the graphs whenever the list of entries changes
 * or the window is resized.
 */

import acm.graphics.*;

import java.awt.*;
import java.awt.event.*;
import java.util.ArrayList;

public class NameSurferGraph extends GCanvas
        implements NameSurferConstants, ComponentListener {

    // Array for storing the colors of the displayed graphs of names
    private ArrayList<Color> colors = new ArrayList<>();
    // Array of entries that must be displayed on the screen
    private ArrayList<NameSurferEntry> graphList = new ArrayList<>();


    /**
     * Creates a new NameSurferGraph object that displays the data.
     */
    public NameSurferGraph() {
        addComponentListener(this);

        // adding colors to the colorsArray
        colors.add(Color.BLUE);
        colors.add(Color.RED);
        colors.add(Color.MAGENTA);
        colors.add(Color.BLACK);
    }


    /**
     * Clears the list of name surfer entries stored inside this class.
     */
    public void clear() {
        graphList.clear();
        update();
    }


    /* Method: addEntry(entry) */

    /**
     * Adds a new NameSurferEntry to the list of entries on the display.
     * Note that this method does not actually draw the graph, but
     * simply stores the entry; the graph is drawn by calling update.
     */
    public void addEntry(NameSurferEntry entry) {
        graphList.add(entry);
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
        removeAll();
        drawGrid();
        // adding all entries stored in the graphList array
        for (int i = 0; i < graphList.size(); i++) {
            NameSurferEntry entry = graphList.get(i);
            Color graphColor = colors.get(i % colors.size());
            drawNameGraph(entry, graphColor);
        }
    }

    /**
     * Draws the graph for the name surfer entry
     *
     * @param entry - NameSurferEntry to be displayed
     * @param color - the color of the graph's lines and label
     */
    private void drawNameGraph(NameSurferEntry entry, Color color) {
        // calculating the width between the grid lines according to the screen width
        int spaceWidth = getWidth() / NDECADES;
        // variables that calculates the location of the name rank on the grid
        int rank1RelativeValue = 0;
        int rank2RelativeValue = 0;
        // variables that calculate the Y coordinates of the rank name on the screen
        int y1Coordinate;
        int y2Coordinate;
        // String that contains the information to be displayed near the rank location on the grid
        String rankString;

        for (int i = 0; i < NDECADES - 1; i++) {
            rankString = String.valueOf(entry.getRank(i));
            int x1Coordinate = spaceWidth * i;
            int x2Coordinate = x1Coordinate + spaceWidth;
            if (entry.getRank(i) != 0) {
                rank1RelativeValue = (getHeight() - GRAPH_MARGIN_SIZE * 2) * entry.getRank(i) / MAX_RANK;
                y1Coordinate = GRAPH_MARGIN_SIZE + rank1RelativeValue;
            } else {
                y1Coordinate = getHeight() - GRAPH_MARGIN_SIZE;
                rankString = "*";
            }
            if (entry.getRank(i + 1) != 0) {
                rank2RelativeValue = (getHeight() - GRAPH_MARGIN_SIZE * 2) * entry.getRank(i + 1) / MAX_RANK;
                y2Coordinate = GRAPH_MARGIN_SIZE + rank2RelativeValue;
            } else {
                y2Coordinate = getHeight() - GRAPH_MARGIN_SIZE;
            }
            drawNameLabel(entry.getName() + " " + rankString, x1Coordinate, y1Coordinate, color);
            drawLine(x1Coordinate, y1Coordinate, x2Coordinate, y2Coordinate, color);
        }
        // drawing the name and rank for the edge case (the last decade)
        rankString = (entry.getRank(NDECADES - 1) != 0 ? String.valueOf(entry.getRank(NDECADES - 1)) : "*");
        int yLastName = (entry.getRank(NDECADES - 1) != 0 ? GRAPH_MARGIN_SIZE + (getHeight() - GRAPH_MARGIN_SIZE * 2) * entry.getRank(NDECADES - 1) / MAX_RANK : getHeight() - GRAPH_MARGIN_SIZE);
        drawNameLabel(entry.getName() + " " + rankString, spaceWidth * (NDECADES - 1), yLastName, color);
    }

    /**
     * Method for creating and drawing the Label for the Graph
     *
     * @param sign  - String that the label must contain
     * @param x     - The x-coordinate of the label origin
     * @param y     - The y-coordinate of the baseline for the label
     * @param color - The color of the label
     */
    private void drawNameLabel(String sign, int x, int y, Color color) {
        GLabel graphSign = new GLabel(sign);
        graphSign.setLocation(x, y);
        graphSign.setColor(color);
        add(graphSign);
    }

    /**
     * Draws the background grid on the screen
     */
    private void drawGrid() {
        // calculating the width between the lines that correspond to each decade
        int spaceWidth = getWidth() / NDECADES;

        drawLine(0, getHeight() - GRAPH_MARGIN_SIZE, getWidth(), getHeight() - GRAPH_MARGIN_SIZE, Color.BLACK);
        drawLine(0, GRAPH_MARGIN_SIZE, getWidth(), GRAPH_MARGIN_SIZE, Color.BLACK);

        for (int i = 0; i < NDECADES; i++) {
            int xCoordinate = spaceWidth * i;
            drawYearLabel(START_DECADE + i * YEARS_BETWEEN_DECADES, xCoordinate, getHeight() - GRAPH_MARGIN_SIZE / 10);
            drawLine(xCoordinate, 0, xCoordinate, getHeight(), Color.BLACK);
        }
    }

    /**
     * Draws the labels that represent years of each decade on the background grid
     *
     * @param year - The first year to be displayed on the grid
     * @param x    - The x-coordinate of the label origin
     * @param y    - The y-coordinate of the baseline for the label
     */
    private void drawYearLabel(int year, int x, int y) {
        String sign = String.valueOf(year);
        GLabel yearLabel = new GLabel(sign);
        yearLabel.setLocation(x, y);
        yearLabel.setFont(new Font("Arial", Font.PLAIN, GRAPH_MARGIN_SIZE - GRAPH_MARGIN_SIZE / YEAR_MARGIN));
        add(yearLabel);
    }

    /**
     * Draws the line as a part of graph canvas
     *
     * @param x1    - The x-coordinate of the start of the line
     * @param y1    - The y-coordinate of the start of the line
     * @param x2    - The x-coordinate of the end of the line
     * @param y2    - The y-coordinate of the end of the line
     * @param color - The color of the line
     */
    private void drawLine(int x1, int y1, int x2, int y2, Color color) {
        GLine line = new GLine(x1, y1, x2, y2);
        add(line);
        line.setColor(color);
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
