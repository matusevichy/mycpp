package com.shpp.p2p.cs.yyelmanov.assignment8;

import acm.graphics.GOval;
import com.shpp.cs.a.graphics.WindowProgram;
import java.awt.*;
import java.awt.event.MouseEvent;
import java.util.ArrayList;

public class Assignment8Part1 extends WindowProgram {
    double startTime = 0;
    int differenceTime = 0;
    int maxColorPalitre = 255;
    ArrayList<GOval> masiveBall = new ArrayList<GOval>();
    ArrayList<Double> masiveGravity= new ArrayList<Double>();

    public void mouseClicked(MouseEvent me) {

    }

    public void mousePressed(MouseEvent me) {

        startTime = System.currentTimeMillis();
    }

    public void mouseReleased(MouseEvent me) {
        differenceTime = (int) (System.currentTimeMillis() - startTime) / 7;
        Color color;
        if (maxColorPalitre - differenceTime * 2 >= 0) {
            color = new Color(maxColorPalitre - differenceTime * 2, maxColorPalitre - differenceTime * 2, maxColorPalitre - differenceTime * 2);
        } else {
            color = new Color(0, 0, 0);
        }
        GOval ball = new GOval(me.getX(), me.getY(), differenceTime, differenceTime);
        ball.setFilled(true);
        ball.setColor(color);
        masiveBall.add(ball);
        masiveGravity.add(0.0);
        add(ball);


    }

    public void run() {
        addMouseListeners();
        moveBalls();
    }
    private void moveBalls() {
        while (true) {
            for (int i =0;i<masiveBall.size();i++) {
                double dy=masiveGravity.get(i);
                masiveBall.get(i).move(0, dy);
                masiveGravity.set(i,dy+0.3);
                if(masiveBall.get(i).getY()+masiveBall.get(i).getHeight()>=getHeight()&&dy>0){
                    double q =masiveGravity.get(i)*(-0.4);
                    masiveGravity.set(i,q);
                }
            }
            pause(1000.0 / 33);
        }
    }
}


