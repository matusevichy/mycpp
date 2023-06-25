package com.shpp.p2p.cs.ymatusevich.assignment10;

public class Test {
    public static void main(String[] args) {
        System.out.println("Test 1");
        Assignment10Part1.main(new String[] {"-2+2"});
        System.out.println("Correctly result: 0");

        System.out.println("Test 2");
        Assignment10Part1.main(new String[] {"-2^2"});
        System.out.println("Correctly result: 4");

        System.out.println("Test 3");
        Assignment10Part1.main(new String[] {"2^-2"});
        System.out.println("Correctly result: 0.25");

        System.out.println("Test 4");
        Assignment10Part1.main(new String[] {"a + 1 + 2 *b + 5*a / c + 5.5 + 2^3 + 2^3 - 4/2.0^2.0", "a = 2", "b=5", "c=2.5"});
        System.out.println("Correctly result: 37.5");

        System.out.println("Test 5");
        Assignment10Part1.main(new String[] {"-2*2/5/5/5"});
        System.out.println("Correctly result: -0.032");

        System.out.println("Test 6");
        Assignment10Part1.main(new String[] {"-2*2/2^2"});
        System.out.println("Correctly result: -1");

        System.out.println("Test 7");
        Assignment10Part1.main(new String[] {"2*-2/2^2*h", "h=-5"});
        System.out.println("Correctly result: 5");

        System.out.println("Test 8");
        Assignment10Part1.main(new String[] {"2/a*b/c-3^h*2/6+0.1/b", "a=1.5", "b=-6", "c=-1", "h=-5"});
        System.out.println("Correctly result: 7.98196159122085");

        System.out.println("Test 9");
        Assignment10Part1.main(new String[] {"a^b^a", "a=3", "b=2"});
        System.out.println("Correctly result: 6561");

        System.out.println("Test 10");
        Assignment10Part1.main(new String[] {"a- -2", "a=-2", "b=2"});
        System.out.println("Correctly result: 0");

        System.out.println("Test 11");
        Assignment10Part1.main(new String[] {"3^2^4"});
        System.out.println("Correctly result: 43046721");

        System.out.println("Test 12");
        Assignment10Part1.main(new String[] {"-1+3^2^3-100*2/10^2 - 5/2"});
        System.out.println("Correctly result: 6555.5");

        System.out.println("Test 13");
        Assignment10Part1.main(new String[] {"2^5 + 4^3 - 2^-5 * 4^3"});
        System.out.println("Correctly result: 94");

        System.out.println("Test 13");
        Assignment10Part1.main(new String[] {"2+2^-0.34*53/3/5^3^2*2"});
        System.out.println("Correctly result: 94");

    }
}
