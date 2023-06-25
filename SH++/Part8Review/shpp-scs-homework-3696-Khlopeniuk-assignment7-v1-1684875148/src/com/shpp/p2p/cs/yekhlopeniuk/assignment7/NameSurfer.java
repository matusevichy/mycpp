package com.shpp.p2p.cs.yekhlopeniuk.assignment7;

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

	private JButton buildGraph, clearScreen;
    private JTextField name;
    private NameSurferDataBase dataBase;
    private NameSurferGraph graph;


    /**
     * This method has the responsibility for reading in the database
     * and initializing the interactors at the top of the window.
     */
    public void init() {
        dataBase = new NameSurferDataBase(NAMES_DATA_FILE); //create database from file

        graph = new NameSurferGraph(); add(graph); //create main field

        //text field to enter the name
        add(new JLabel("Name: "), NORTH);
        name = new JTextField(NAME_LENGTH);  add(name, NORTH);
        name.addActionListener(this);
        //name.setActionCommand("EnterPressed");

        //buttons to build graph and clear screen
        buildGraph = new JButton("Graph"); add(buildGraph, NORTH);
        //buildGraph.setActionCommand("BuildGraph");

        clearScreen = new JButton("Clear"); add(clearScreen, NORTH);
        //clearScreen.setActionCommand("ClearField");

        addActionListeners();
    }

    /**
     * This class is responsible for detecting when the buttons are
     * clicked, so you will have to define a method to respond to
     * button actions.
     */
    public void actionPerformed(ActionEvent event) {
        //build graph
        if (event.getSource() == buildGraph || event.getSource() == name) {
            String currentName = name.getText();
            //check for empty field
            if (!currentName.equals("")) {
                //set text field to normal view
                currentName  = currentName.toLowerCase();
                currentName = currentName.substring(0, 1).toUpperCase() + currentName.substring(1);
                NameSurferEntry entry = dataBase.findEntry(currentName);
                name.setText(""); //clear the text field
                //check if name exists
                if (entry != null) {
                    print("Graph: "); println(currentName);
                    println(entry.toString());
                    graph.addEntry(entry);
                }
                else {
                    name.setText("");
                    println("Very strange name...");
                }
            }
        //remove all graphs
        } else if (event.getSource() == clearScreen){
            println("Clear Screen");
            graph.clear();
        } else println("***");
    }
}
