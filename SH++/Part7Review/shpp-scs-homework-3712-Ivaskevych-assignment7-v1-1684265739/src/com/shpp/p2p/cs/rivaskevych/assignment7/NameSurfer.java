package com.shpp.p2p.cs.rivaskevych.assignment7;

/*
 * File: NameSurfer.java
 * ---------------------
 * When it is finished, this program will implements the viewer for
 * the baby-name database described in the assignment handout.
 */

import com.shpp.cs.a.simple.SimpleProgram;

import java.awt.event.*;
import javax.swing.*;

public class NameSurfer extends SimpleProgram implements NameSurferConstants {

    private JTextField textField = new JTextField(30);

    private NameSurferDataBase database;
    private NameSurferGraph graph;

    public NameSurfer() {
        database = new NameSurferDataBase(NAMES_DATA_FILE);
        graph = new NameSurferGraph();
        add(graph);
    }

    /**
     * This method has the responsibility for reading in the data base
     * and initializing the interactors at the top of the window.
     */
    public void init() {
        this.add(new JLabel("Name"), "North");
        this.add(this.textField, "North");
        this.add(new JButton("Graph"), "North");
        this.add(new JButton("Clear"), "North");
        this.textField.addKeyListener(new KeyListener() {

            @Override
            public void keyTyped(KeyEvent e) {

            }

            @Override
            public void keyPressed(KeyEvent e) {
                if (e.getKeyCode() == KeyEvent.VK_ENTER) {
                    graphButtonPressed(textField.getText());
                }
            }

            @Override
            public void keyReleased(KeyEvent e) {
            }
        });
        this.addActionListeners();
    }

    /**
     * This class is responsible for detecting when the buttons are
     * clicked, so you will have to define a method to respond to
     * button actions.
     */
    public void actionPerformed(ActionEvent e) {
        if (e.getActionCommand().equals("Graph")) {
            graphButtonPressed(this.textField.getText());
        } else if (e.getActionCommand().equals("Clear")) {
            clearButtonPressed();
        }
    }

    /**
     * This method performs an action when the graph key is pressed
     */
    public void graphButtonPressed(String name) {
        NameSurferEntry entry = database.findEntry(name);
        if (entry != null) {
            graph.addEntry(entry);
            graph.update();
        } else {
            System.out.println("Name not found: " + name);
        }
    }

    /**
     * This method performs an action when the clear key is pressed
     */
    public void clearButtonPressed() {
        this.textField.setText("");
        graph.clear();
        graph.update();
    }
}
