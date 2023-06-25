package com.shpp.p2p.cs.zstepanenko.assignment1;

import com.shpp.karel.KarelTheRobot;

/* Assignment1Part1 class extends the basic KarelTheRobot class
 * so that Karel leaves a maze (house), reaches the beeper (newspaper),
 * collects it and returns to the initial position.
 */
public class Assignment1Part1 extends KarelTheRobot {
    @Override
    public void run() throws Exception {
        setOutForNewspaper();
        collectNewspaper();
        returnToTheInitialPoint();
    }

    private void setOutForNewspaper() throws Exception {
        turnRight();
        move();
        turnLeft();

        while (noBeepersPresent()) {
            move();
        }
    }

    /*
     * Precondition: Karel is in the initial point facing North;
     * Result: Karel reaches the beeper.
     * The method "setOutForNewspaper" causes Karel
     * to change his initial position so that he can
     * pick up a beeper.
     * In order to perform the task he turns right and moves one cell forward
     * to be standing in front of the maze's exit (a so called "door").
     * Karel is in front of the door but he doesn't look North anymore.
     * In order to start moving in the right direction he needs to turn left.
     * Finally, Karel can go sraight to the exit until he encounters a "newspaper".
     * For this purpose the cycle "while" is appropriate as it makes Karel
     * move cell by cell until he finds the beeper.
     */
    private void collectNewspaper() throws Exception {
        if (beepersPresent()) {
            pickBeeper();
        }
    }

    /*
     * The condition "if beepersPresent" helps us check if there
     * is any beeper before Karel picks it.
     * The method "сollectNewspaper" causes Karel
     * to pick up the beeper.
     */
    private void returnToTheInitialPoint() throws Exception {
        turnAround();

        while (frontIsClear()) {
            move();
        }

        turnRight();
        move();
        turnRight();
    }

    /*
     * Precondition: Karel picked up the beeper and is facing North;
     * Result: Karel is in the initial position.
     * When Karel has already put a beeper into his bag, he needs to return
     * to the start. As soon as he is facing North, he must turn around to face
     * South, go back to the maze until he reaches the wall, turn right and make
     * the last move.
     * Nevertheless, in my opinion, this task is accomplished to the full extent,
     * if we make Karel turn around and face North as at the beginning of his adventure.
     * So, he turns around.
     */
    private void turnRight() throws Exception {
        turnLeft();
        turnLeft();
        turnLeft();
    }

    /*
     * As soon as there is no command "turnRight" in Karel language,
     * we can make the robot turn in this direction by performing three consequent
     * turns left.
     */

    private void turnAround() throws Exception {
        turnLeft();
        turnLeft();
    }
    /* As soon as this command isn't available, we can make
     * Karel turn around by making him perform two turns left.
     */

}