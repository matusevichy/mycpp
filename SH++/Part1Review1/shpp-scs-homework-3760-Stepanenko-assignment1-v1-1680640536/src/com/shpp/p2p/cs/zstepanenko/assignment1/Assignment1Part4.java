package com.shpp.p2p.cs.zstepanenko.assignment1;

import com.shpp.karel.KarelTheRobot;

/* Assignment1Part4 class extends the basic KarelTheRobot class
 * so that Karel fills in the checkerboard with chess (beepers).
 */
public class Assignment1Part4 extends KarelTheRobot {
    @Override
    public void run() throws Exception {
        turnLeft();
        while (rightIsClear()) {
            fillTheFirstRow();
            moveToTheNextRow();
            fillTheNextRow();
            moveToTheNextRow();
            turnLeft();
        }
    }

    /* Precondition: Karel is in the Southwestern corner of the world
     * facing East;
     * Result: The checkerboard is filled in with chess provided that
     * there is a chess figure (beeper) in its Southwestern corner.
     * For the convenience of perception, we asked Karel to turn left and face North.
     * To fill in the checkerboard, which parameters are limited by the
     * shape of the world, Karel has to repeat the cycle of actions until
     * he reaches the Eastern wall (in other words, while his right is clear).
     * First of all, Karel turns left and fills out the first row of chess.
     * Then he moves to the next row and fills it out, moves to the next row, turns left
     * and repeats the cycle until the Eastern wall is reached.
     */

    private void fillTheFirstRow() throws Exception {
        putBeeper();
        while (frontIsClear()) {
            move();
            putBeeper();
        }
        if (frontIsClear()) {
            move();
        }
        turnAround();
        while (frontIsClear()) {
            pickBeeper();
            move();
            if (frontIsClear()) {
                move();
            }
        }
    }

    /* Precondition: Karel is in the Southwestern corner facing East;
     * Result: Karel filled in the first row of chess providing that there
     * is a chess figure in the Southwestern corner.
     * Before implementing the method, Karel puts beeper in the
     * Southwestern corner (as soon as this action only needs to be performed once,
     * it is separated from the following cycle).
     * In order to put beepers in an appropriate order, Karel has to, firstly,
     * fill in the whole row with beepers, secondly, turn around and thirdly, extract
     * the odd beepers.
     * Taking into account that the first cell already contains the beeper and the front
     * is clear from the wall (the edge of the checkerboard), Karel has to consequently
     * perform a cycle of repeated actions, namely: move, put beeper and move again.
     * There appears an additional condition: the last move is only possible if the
     * front is clear.
     * When Karel reaches the edge of the checkerboard, he turns around and picks the
     * beeper he is standing at. Thus, he makes sure that after extracting the odd beepers,
     * the beeper he put first (the one in the Southwestern corner) remains at its place.
     * After this, Karel moves, picks another beeper and continues these actions until he
     * reaches the opposite edge of the checkerboard. Nevertheless, there also appears an
     * additional condition without performing which Karel is not able to continue his cycle
     * successfully: before making the last move, he has to check if the front is clear.
     */
    private void moveToTheNextRow() throws Exception {
        turnLeft();
        if (frontIsClear()) {
            move();
        }
    }
    /* Precondition: Karel is at the beginning of the first row, facing South;
     * Karel is at the beginning of the next row.
     * To implement this method Karel only has to turn left and make a single move.
     * Nonetheless, before making a move, he has to check if he is not facing the edge
     * of the checkerboard.
     */


    private void fillTheNextRow() throws Exception {
        turnLeft();
        while (frontIsClear()) {
            putBeeper();
            move();

        }
        turnAround();
        putBeeper();

        while (frontIsClear()) {
            move();
            pickBeeper();
            if (frontIsClear()) {
                move();
            }

        }

    }

    /* Precondition: Karel is at the beginning of the row facing East;
     * Result: Karel filled out the row.
     * Before performing the task, Karel has to turn left. The fulfillment
     * of all the next rows is very similar to that of the first one.
     * To begin with, Karel fills out the whole row with beepers, making sure
     * he takes into account edge cases (those were described in method "fillTheFirstRow").
     * At his way back, the robot performs the actions opposite to those he did
     * while moving back the first row. Thus, instead of picking the beeper,
     * he puts one to make sure this row will end up with the cell that doesn't
     * contain one. Then follows a series of repeated actions:
     * move, pick beeper, move. This one is opposite to the case of the first row,
     * where we had "pick beeper, move". Nevertheless, as in the first case, we still
     * have to handle the edge case of the action "move", which is done with the relevant
     * condition.
     */
    private void turnAround() throws Exception {
        turnLeft();
        turnLeft();
    }

    /* As soon as Karel was not programmed to turn around by default,
     * we teach him to do this by performing two consequent left turns.
     */
}