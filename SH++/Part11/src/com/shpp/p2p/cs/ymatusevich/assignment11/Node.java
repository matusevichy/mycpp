package com.shpp.p2p.cs.ymatusevich.assignment11;

/**
 * Expressions tree class
 */
public class Node {
    //Node value
    private String value;
    //Left children
    private Node leftNode = null;
    //Right children
    private Node rightNode = null;

    //Constructor with one parameter
    public Node(String value) {
        this.value = value;
    }

    //Constructor with three parameters
    public Node(String value, Node leftNode, Node rightNode){
        this(value);
        this.leftNode = leftNode;
        this.rightNode = rightNode;
    }

    //Getters for all private fields
    public String getValue() {
        return value;
    }

    public Node getLeftNode() {
        return leftNode;
    }

    public Node getRightNode() {
        return rightNode;
    }
}
