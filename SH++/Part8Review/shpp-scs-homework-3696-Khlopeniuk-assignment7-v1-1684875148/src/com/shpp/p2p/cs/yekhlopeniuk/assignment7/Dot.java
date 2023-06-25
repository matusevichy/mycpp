package com.shpp.p2p.cs.yekhlopeniuk.assignment7;
import acm.graphics.*;
import java.awt.*;
import java.awt.event.MouseEvent;
import java.awt.event.MouseListener;
import java.awt.event.MouseMotionListener;

/** This class represents the square - element of graph,
 * which represents rank of the name by decade,
 * with popup text with rank value
 * */
public class Dot extends GCompound implements MouseListener {
    public GPoint location;
    public GLabel label;

    public Dot(GPoint location, int value, Color color) {
        addMouseListener(this);
        this.location = new GPoint(location);

        //create popup label
        label = new GLabel(Integer.toString(value), location.getX(), location.getY());
        label.move(-label.getWidth()/2, -5);
        label.setFont("Verdana-14");

        //draw a dot
        GRect rect = new GRect(location.getX()-2, location.getY()-2, 5, 5);
        rect.setColor(color);
        rect.setFillColor(color);
        rect.setFilled(true);
        add(rect);
    }


    @Override
    public void mouseClicked(MouseEvent e) {}

    @Override
    public void mousePressed(MouseEvent e) {};

    @Override
    public void mouseReleased(MouseEvent e) {}

    @Override
    //show popup text
    public void mouseEntered(MouseEvent e) {
        add(label);
    }

    @Override
    //hide popup text
    public void mouseExited(MouseEvent e) {
        remove(label);
    }

}
