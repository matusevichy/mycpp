package com.shpp.p2p.cs.yekhlopeniuk.assignment7;

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
import java.awt.*;
import java.util.ArrayList;

public class NameSurferGraph extends GCanvas implements NameSurferConstants, ComponentListener {

    private double width, height;
    private double horizontalField, verticalField;
    private double horizontalStep, verticalStep;
    private final ArrayList<NameSurferEntry> existingEntries = new ArrayList<>(); //entries which were added
    private static final Color[] COLORS = new Color[] {
            new Color(229, 100, 110),
            new Color(255, 208, 100),
            new Color(149, 214, 164),
            new Color(139, 179, 234),
            new Color(214, 189, 239),
    };
    private int currentColor = 0;
    private GPoint labelPosition; //legend line position

    /**
     * Creates a new NameSurferGraph object that displays the data.
     */
    public NameSurferGraph() {
        setBackground(new Color(229, 229, 229));
        addComponentListener(this);
    }


    /**
     * Clears the list of name surfer entries stored inside this class.
     */
    public void clear() {
        removeAll();
        createGrid();
    }

    /**
     * Adds a new NameSurferEntry to the list of entries on the display.
     * Note that this method does not actually draw the graph, but
     * simply stores the entry; the graph is drawn by calling update.
     */
    public void addEntry(NameSurferEntry entry) {
        existingEntries.add(entry); //save current entry in array

        Color color = COLORS[currentColor % 5]; //change current graph color
        currentColor ++;

        //previous and current points to draw connecting lines
        double prevX = 0, prevY = 0;
        int prevRank = 0;
        double currentX, currentY;
        int currentRank;
        //create 12 dots for each decade
        for (int i = 0; i < NDECADES; i++) {
            currentRank = entry.getRank(i);
            currentX = horizontalField + horizontalStep * i;
            //currentY = height - verticalField - (height - 2 * verticalField) / 1000 * currentRank;
            currentY = verticalField + (height - 2 * verticalField) / 1000 * currentRank;

            //create dot only for name, which has ranks != 0
            if (currentRank > 0) {
                Dot dot = new Dot(new GPoint(currentX, currentY), currentRank, color);
                add(dot);
            }

            //draw line to join ranks, which are != 0
            if (prevRank > 0 && currentRank > 0) {
                GLine line = new GLine(prevX, prevY, currentX, currentY);
                line.setColor(color);
                add(line);
            }
            prevX = currentX;
            prevY = currentY;
            prevRank = currentRank;
        }

        //add legend line and change next line position
        addLabel(labelPosition, color, entry.getName());
        labelPosition.translate(0, verticalStep);
    }


    /**
     * Updates the display image by deleting all the graphical objects
     * from the canvas and then reassembling the display according to
     * the list of entries. Your application must call update after
     * calling either clear or addEntry; update is also called whenever
     * the size of the canvas changes.
     */
    public void update() {
        removeAll(); //clear screen
        countGridParameters(); //re-count parameters
        createGrid();
        currentColor = 0; //start from first color
        //draw existing graphs one more time
        ArrayList<NameSurferEntry> tempList = new ArrayList<>(existingEntries);
        existingEntries.clear();
        for (NameSurferEntry entry : tempList) {
            addEntry(entry);
        }
    }

    /**
     * Parameters to create the grid and graphs
     * Depends on window size
     */
    private void countGridParameters() {
        width = getWidth()*0.75; height = getHeight();
        horizontalStep = width / NDECADES; //12 decades
        verticalStep = height / (MAX_RANK/100.0 + 1); //11
        horizontalField = horizontalStep / 2;
        verticalField = verticalStep / 2;

        labelPosition = new GPoint(horizontalStep*13, verticalField);
    }

    /**
     * Background grid
     */
    private void createGrid() {
        for (int i = 0; i < NDECADES; i++) {
            int year = START_DECADE + i * 10;
            verticalLine(horizontalField + horizontalStep * i, Integer.toString(year));
        }
        for (int i = 0; i < 11; i++) {
            int rating = i * 100;
            horizontalLine(verticalField + verticalStep * i, Integer.toString(rating));
        }
    }

    /**
     * Create vertical line with label which represents decades
     * @param x - position
     * @param label = label text
     */
    private void verticalLine(double x, String label) {
        GLine line = new GLine(x, 0, x, height);
        line.setColor(Color.white);
        GLine line1 = new GLine(x + 1, 0, x + 1, height);
        line1.setColor(Color.white);
        add(line); add(line1);
        GLabel year = new GLabel(label);
        year.setFont("Verdana-12");
        year.setLocation(x, height - verticalField + 15);
        year.setColor(Color.black);
        add(year);
    }
    /**
     * Create vertical line with label which represents ranks
     * @param y - position
     * @param label = label text
     */
    private void horizontalLine(double y, String label) {
        GLine line = new GLine(0, y, width, y);
        line.setColor(Color.white);
        GLine line1 = new GLine(0, y+1, width, y+1);
        line1.setColor(Color.white);
        add(line); add(line1);
        GLabel rating = new GLabel(label);
        rating.setFont("Verdana-12");
        rating.setLocation(horizontalField - rating.getWidth() - 2, y);
        rating.setColor(Color.black);
        add(rating);
    }

    /**
     * Create label which represents line of graph legend
     * @param position
     * @param color
     * @param text
     */
    private void addLabel(GPoint position, Color color, String text) {
        GRect square = new GRect(position.getX(), position.getY(), 5, 5);
        square.setColor(color);
        square.setFillColor(color);
        square.setFilled(true);
        GLabel label = new GLabel(text, position.getX(), position.getY());
        label.move(10, label.getHeight()/2);
        label.setColor(Color.black);
        label.setFont("Verdana-14");
        add(label); add(square);
    }

    /* Implementation of the ComponentListener interface */
    public void componentHidden(ComponentEvent e) { }

    public void componentMoved(ComponentEvent e) { }

    public void componentResized(ComponentEvent e) {update();}

    public void componentShown(ComponentEvent e) { }

}
