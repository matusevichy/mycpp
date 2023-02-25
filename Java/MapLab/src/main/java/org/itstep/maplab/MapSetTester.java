package org.itstep.maplab;

import java.util.Arrays;
import java.util.HashMap;
import java.util.Scanner;
import java.util.TreeSet;


public class MapSetTester {
    public static void main(String[] args) {
        HashMap<String, TreeSet<String>> networkMap = new HashMap<>();
        Scanner scanner = new Scanner(System.in);
        while (true){
            System.out.println("Input tv network (or press Enter for cancel: ");
            String network = scanner.nextLine();
            if (network == "") break;
            System.out.println("Input tv show on " + network + ": ");
            String show = scanner.nextLine();
            if (networkMap.containsKey(network)){
                TreeSet<String> newSet = networkMap.get(network);
                newSet.add(show);
                networkMap.replace(network, newSet);
            }
            else{
                TreeSet<String> newSet = new TreeSet<>();
                newSet.add(show);
                networkMap.put(network, newSet);
            }
            System.out.println(networkMap.toString());
        }
        String[] networks = networkMap.keySet().toArray(new String[0]);
        Arrays.sort(networks);
        for (String network: networks) {
            System.out.print(network + ": ");
            System.out.println(networkMap.get(network).toString());
        }
    }
}
