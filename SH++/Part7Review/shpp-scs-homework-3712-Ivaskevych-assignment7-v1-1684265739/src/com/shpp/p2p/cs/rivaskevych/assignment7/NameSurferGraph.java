package com.shpp.p2p.cs.rivaskevych.assignment7;

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

public class NameSurferGraph extends GCanvas
        implements NameSurferConstants, ComponentListener {
    ArrayList<NameSurferEntry> surferEntryList = new ArrayList<NameSurferEntry>();

    /**
     * Creates a new NameSurferGraph object that displays the data.
     */
    public NameSurferGraph() {
        addComponentListener(this);
    }


    /**
     * Clears the list of name surfer entries stored inside this class.
     */
    public void clear() {
        surferEntryList.clear();
    }


    /**
     * Adds a new NameSurferEntry to the list of entries on the display.
     * Note that this method does not actually draw the graph, but
     * simply stores the entry; the graph is drawn by calling update.
     */
    public void addEntry(NameSurferEntry entry) {
        surferEntryList.add(entry);
    }


    /**
     * Updates the display image by deleting all the graphical objects
     * from the canvas and then reassembling the display according to
     * the list of entries. Your application must call update after
     * calling either clear or addEntry; update is also called whenever
     * the size of the canvas changes.
     */
    public void update() {
        this.removeAll();
        int decadeWidth = getWidth() / NDECADES;
        drawingTable(decadeWidth);
        drawingGraph(decadeWidth);
    }

    /**
     * This method draws a start table on GCanvas
     */
    public void drawingTable(int width) {
        for (int i = 0; i < NDECADES; i++) {
            GLine verticalLine = new GLine(i * width, 0, i * width, getHeight());
            GLabel label = new GLabel(Integer.toString(START_DECADE + i * 10), i * width, getHeight());
            Font f = new Font("SansSerif", Font.BOLD, 16);
            label.setFont(f);
            add(label);
            add(verticalLine);
        }
        double y = getHeight() - GRAPH_MARGIN_SIZE;
        GLine horisontalLine1 = new GLine(0, GRAPH_MARGIN_SIZE, getWidth(), GRAPH_MARGIN_SIZE);
        GLine horisontalLine2 = new GLine(0, y, getWidth(), y);
        add(horisontalLine1);
        add(horisontalLine2);
    }

    /**
     * This method draws a graph on GCanvas depend on our surferEntryList contain
     */
    public void drawingGraph(int width) {
        Color[] colors = {Color.BLUE, Color.RED, Color.MAGENTA, Color.BLACK};
        Font labelFont = new Font("Dialog", Font.BOLD, 11);
        double scalePoint = ((getHeight() - (GRAPH_MARGIN_SIZE * 2.0)) / MAX_RANK);
        for (NameSurferEntry el : surferEntryList) {
            int indexColor = surferEntryList.indexOf(el) % colors.length;
            for (int i = 0; i < NDECADES - 1; i++) {
                double x1 = i * width;
                double x2 = (i + 1) * width;
                double y1 = el.getRank(i) == 0
                        ? getHeight() - GRAPH_MARGIN_SIZE
                        : scalePoint * el.getRank(i) + GRAPH_MARGIN_SIZE;
                double y2 = el.getRank(i + 1) == 0
                        ? getHeight() - GRAPH_MARGIN_SIZE
                        : scalePoint * el.getRank(i + 1) + GRAPH_MARGIN_SIZE;
                GLine line = new GLine(x1, y1, x2, y2);
                line.setColor(colors[indexColor]);
                GLabel label = el.getRank(i) == 0
                        ? new GLabel(el.getName() + '*', x1, y1)
                        : new GLabel(el.getName() + el.getRank(i), x1, y1);
                label.setColor(colors[indexColor]);
                label.setFont(labelFont);
                if (i == 10) {
                    GLabel lastLabel = el.getRank(i+1) == 0
                            ? new GLabel(el.getName() + '*', x2, y2)
                            : new GLabel(el.getName() + el.getRank(i + 1), x2, y2);
                    lastLabel.setColor(colors[indexColor]);
                    lastLabel.setFont(labelFont);
                    add(lastLabel);
                }
                add(line);
                add(label);
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
