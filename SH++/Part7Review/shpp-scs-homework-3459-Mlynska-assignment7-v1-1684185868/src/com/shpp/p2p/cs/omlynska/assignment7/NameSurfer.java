package com.shpp.p2p.cs.omlynska.assignment7;

/*
 * File: NameSurfer.java
 * ---------------------
 * When it is finished, this program will implement the viewer for
 * the baby-name database described in the assignment handout.
 */

import com.shpp.cs.a.simple.SimpleProgram;

import java.awt.event.*;
import javax.swing.*;

public class NameSurfer extends SimpleProgram implements NameSurferConstants {
    // variable for the input field
    private JTextField nameField;
    // variable for the button that clears the name graphs from the screen
    private JButton clearButton;
    // variable for the button that builds the name graph
    private JButton graphButton;
    // variable for creating the database of NameSurferEntries
    private NameSurferDataBase dataBase;
    // variable for creating the name graphs
    private NameSurferGraph graph;

    /**
     * This method has the responsibility for reading in the data base
     * and initializing the interactors at the top of the window.
     */
    public void init() {

        // adding interactors on the screen
        add(new JLabel("Name:"), NORTH);

        nameField = new JTextField(FIELD_SIZE);
        add(nameField, NORTH);
        nameField.setActionCommand("EnterPressed");
        nameField.addActionListener(this);

        graphButton = new JButton("Graph");
        add(graphButton, NORTH);
        graphButton.addActionListener(this);

        clearButton = new JButton("Clear");
        add(clearButton, NORTH);
        clearButton.addActionListener(this);

        addActionListeners();

        // adding the graph object with the grid and other elements on the screen
        graph = new NameSurferGraph();
        add(graph);

        // adding database which reads the file and stores the NameSurferEntries
        dataBase = new NameSurferDataBase(NAMES_DATA_FILE);
    }

    /**
     * This class is responsible for detecting when the buttons are
     * clicked, so you will have to define a method to respond to
     * button actions.
     */
    public void actionPerformed(ActionEvent e) {
        String cmd = e.getActionCommand();

        if (cmd.equals("EnterPressed")) {
            NameSurferEntry checkName = dataBase.findEntry(nameField.getText());
            if (checkName != null) {
                graph.addEntry(checkName);
            }
        } else if (e.getSource() == clearButton) {
            graph.clear();
        } else if (e.getSource() == graphButton) {
            NameSurferEntry checkName = dataBase.findEntry(nameField.getText());
            if (checkName != null) {
                graph.addEntry(checkName);
            }
        }

    }
}
