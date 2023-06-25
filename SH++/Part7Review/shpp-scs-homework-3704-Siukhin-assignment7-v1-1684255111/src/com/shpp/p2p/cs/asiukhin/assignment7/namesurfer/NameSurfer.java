package com.shpp.p2p.cs.asiukhin.assignment7.namesurfer;

/*
 * File: NameSurfer.java
 * ---------------------
 * When it is finished, this program will implement the viewer for
 * the baby-name database described in the assignment handout.
 */

import acm.program.*;
import com.shpp.cs.a.simple.SimpleProgram;

import java.awt.event.*;
import javax.swing.*;

public class NameSurfer extends SimpleProgram implements NameSurferConstants {

    private JTextField textField;
    private NameSurferDataBase ndb;
    private NameSurferGraph nsg;

	/* Method: init() */

    /**
     * This method has the responsibility for reading in the data base
     * and initializing the interactors at the top of the window.
     */
    public void init() {
        initInteractors();
        ndb = new NameSurferDataBase(PATH_OF_DATA_FILE);
        nsg = new NameSurferGraph();
        add(nsg);
    }

    /**
     * initialize the interactors at the top of the window.
     */
    private void initInteractors() {
        add(new JLabel("Name"),NORTH);

        textField = new JTextField(30);
        textField.setActionCommand("Graph");
        textField.addActionListener(this);
        add(textField, NORTH);

        add(new JButton("Graph"), NORTH);
        add(new JButton("Clear"), NORTH);
        add(new JButton("Delete"), NORTH);

        addActionListeners();
    }

	/* Method: actionPerformed(e) */

    /**
     * This class is responsible for detecting when the buttons are
     * clicked, so you will have to define a method to respond to
     * button actions.
     */
    public void actionPerformed(ActionEvent e) {
        // if some of top button is pressed
        if(e.getActionCommand().equals("Graph")) {
            // add name statistic to graph
            NameSurferEntry entry = ndb.findEntry(textField.getText());
            if(entry != null) {
                nsg.addEntry(entry);
            }
        } else if(e.getActionCommand().equals("Clear")) {
            // clear graph
            nsg.clear();
        } else if(e.getActionCommand().equals("Delete")) {
            // delete name statistic
            NameSurferEntry entry = ndb.findEntry(textField.getText());
            if(entry != null) {
                nsg.removeEntry(entry);
            }
        }
    }
}
