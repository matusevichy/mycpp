package com.shpp.p2p.cs.ymatusevich.assignment8;

import acm.graphics.GOval;
import com.shpp.cs.a.graphics.WindowProgram;

import java.awt.*;

//Model of ball, extends GOval
public class Ball extends GOval {
    //Ball diameter
    private double diameter;
    //Vertical moving speed
    private double vy = 3.0;
    //Current vertical speed if ball is bounce
    private double currentVy = vy;
    //Value of gravity if ball is bounce
    private double gravity = 0.05;
    //Ball moved to bottom or to top
    private boolean toBottom = true;

    public Ball(double v, double v1, double v2, double v3, Color color) {
        super(v, v1, v2, v3);
        diameter = v2;
        setFilled(true);
        setColor(color);
     }

    public double getDiameter() {
        return diameter;
    }

    public void setDiameter(double diameter) {
        this.diameter = diameter;
    }

    public double getVy() {
        return vy;
    }

    public void setVy(double vy) {
        this.vy = vy;
    }

    public boolean isToBottom() {
        return toBottom;
    }

    public void setToBottom(boolean toBottom) {
        this.toBottom = toBottom;
    }

    public double getCurrentVy() {
        return currentVy;
    }

    public void setCurrentVy(double currentVy) {
        this.currentVy = currentVy;
    }

    public double getGravity() {
        return gravity;
    }

    public void setGravity(double gravity) {
        this.gravity = gravity;
    }
}
