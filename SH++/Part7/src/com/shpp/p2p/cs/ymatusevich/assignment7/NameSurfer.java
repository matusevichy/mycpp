package com.shpp.p2p.cs.ymatusevich.assignment7;

/*
 * File: NameSurfer.java
 * ---------------------
 * Main class of program. Presents user interface
 */

import com.shpp.cs.a.simple.SimpleProgram;

import javax.swing.*;
import java.awt.*;
import java.awt.event.ActionEvent;

public class NameSurfer extends SimpleProgram implements NameSurferConstants {

    private JTextField nameField;
    private NameSurferDataBase dataBase;
    private NameSurferGraph graph;
    /* Method: init() */

    /**
     * This method has the responsibility for reading in the data base
     * and initializing the interactors at the top of the window.
     */
    public void init() {
        //Create UI elements and add they on the window
        add(new JLabel("Name: "), NORTH);
        nameField = new JTextField();
        nameField.setActionCommand("Graph");
        nameField.addActionListener(this);
        add(nameField, NORTH);
        nameField.setPreferredSize(new Dimension(300, 0));
        var graphBtn = new JButton("Graph");
        add(graphBtn, NORTH);
        var clearBtn = new JButton("Clear");
        add(clearBtn, NORTH);

        //Get database use special class
        dataBase = new NameSurferDataBase(NAMES_DATA_FILE);

        //Create graph element and add on the window
        graph = new NameSurferGraph();
        add(graph);

        addActionListeners(this);
    }

    /* Method: actionPerformed(e) */

    /**
     * This class is responsible for detecting when the buttons are
     * clicked, so you will have to define a method to respond to
     * button actions.
     */
    public void actionPerformed(ActionEvent e) {
        if (e.getActionCommand().equals("Graph")) {
            var entry = dataBase.findEntry(nameField.getText());
            if (entry != null) {
                graph.addEntry(entry);
                graph.update();
            }
        } else if (e.getActionCommand().equals("Clear")) {
            graph.clear();
            graph.update();
        }
    }
}
