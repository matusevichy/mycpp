package com.shpp.p2p.cs.zstepanenko.assignment1;

import com.shpp.karel.KarelTheRobot;

/* Assignment1Part2 class extends the basic KarelTheRobot class
 * so that Karel builds raws of stones (beepers) as a professional
 * stone mason. He is taught to omit the ceiling (walls of his world),
 * complete the raws with missing stones (beepers) and preserve
 * predefined intervals between the raws.
 * As soon as the number of stone columns is limited by the Eastern wall
 * of the world, Karel performs his duty cyclically until his right is clear.
 */
public class Assignment1Part2 extends KarelTheRobot {
    @Override
    public void run() throws Exception {
        turnLeft();
        while (rightIsClear()) {
            fillTheStonesToTheColumn();
            returnToTheBaseOfTheColumn();
            moveToTheNextColumn();
            fillTheStonesToTheColumn();
        }
    }

    private void fillTheStonesToTheColumn() throws Exception {
        if (facingEast()) {
            turnLeft();
        }
        while (frontIsClear()) {
            if (noBeepersPresent()) {
                putBeeper();
            }

            move();
        }
        if (noBeepersPresent()) {
            putBeeper();
        }
    }

    /* Precondition: Karel is in the Southwestern corner
     * of the world facing East;
     * Result: Karel fills in the first raw with beepers until
     * he is next to the Northern wall of the world.
     * First of all, to move in the direction of the raw Karel is about
     * to complete, he needs to face North. Consequently, the robot
     * turns left. After that Karel moves up (North) until the ceiling (Northern
     * wall). While moving, he checks each cell for beepers (aka stones)
     * and puts a beeper when a cell is empty.
     * In order to handle the edge cases this method is repeated at the end as well.
     */
    private void returnToTheBaseOfTheColumn() throws Exception {
        turnAround();
        while (frontIsClear()) {
            move();
        }
    }

    /* Precondition: Karel is at the top of the stone raw facing
     * Northern wall of the world;
     * Result: Karel is at the base of the column facing Southern wall
     * of the world.
     * It is said in the task that the length of stone raws is variable, but
     * all of them start at the same level. That is why, in order to have a possibility
     * to move to the next column, Karel has to return to the base, that is to face
     * the Southern wall of his world, where all columns commence.
     * For this purpose robot turns around and moves forward until he is next to the
     * Southern wall.
     */
    private void moveToTheNextColumn() throws Exception {
        turnLeft();
        for (int i = 0; i < 4; i++) {
            move();
        }
    }

    /* Precondition: Karel is at the base of a stone column facing South;
     * Result: Karel is at the base of the next column.
     * To move in the direction of the next raw the robot has to be facing East,
     * so he turns left.
     * As soon as the distance to the next column is predifined and equates to 3 cells,
     * Karel needs to make 4 steps to appear at its basement. It is also known that
     * intervals between columns are always constant. This empowers us to use
     * the "for"-cycle.
     */
    private void turnAround() throws Exception {
        turnLeft();
        turnLeft();
    }

    /* As soon as Karel cannot turn around by default, this method teaches
     * the robot to do this by performing two left turns.
     */
}