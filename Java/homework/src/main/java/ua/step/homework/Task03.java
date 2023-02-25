package ua.step.homework;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.HashMap;
import java.util.Map;

/**
 * Палиндром — это последовательность символов, которая слева-направо и
 * справа-налево пишется одинаково. Например «АБА» или «АББ ББА». Дана
 * последовательность символов. Метод makePalindrome() должен преобразовать
 * строку удалив минимальное количество символов из строки,
 * чтобы получить палиндром.
 * Длина последовательности не больше 20 символов, вводится с клавиатуры.
 * <p>
 * Алгоритм решения данной задачи <a href='https://ru.wikibooks.org/wiki/%D0%A0%D0%B5%D0%BA%D1%83%D1%80%D1%81%D0%B8%D1%8F#%D0%97%D0%B0%D0%B4%D0%B0%D1%87%D0%B0_%C2%AB%D0%A1%D0%B4%D0%B5%D0%BB%D0%B0%D0%B9_%D0%BF%D0%B0%D0%BB%D0%B8%D0%BD%D0%B4%D1%80%D0%BE%D0%BC%C2%BB'>Задача «Сделай палиндром»</>
 */
public class Task03 {
    public static void main(String[] args) {
        String word = "1235421";
        String result = makePalindrome(word);
        System.out.println("result = " + result);
    }

    /**
     * Рекурсивный метод превращающий входную строку в палиндром
     * @param word - входная строка - не палиндром
     * @return палиндром
     */
    public static String makePalindrome(String word) {
        StringBuffer result = new StringBuffer();
        ArrayList<String> resultList = new ArrayList<String>();
        for (int i=0; i<word.length();i++){
            result=new StringBuffer();
            makePalindromeIteration(word, result, i);
            if(result.length() != 0) {
                resultList.add(result.toString());
            }
        }
        String longestString = null;
        for (String item:resultList){
            if (longestString == null || longestString.length()<item.length()){
                longestString = item;
            }
        }
        return longestString;
    }

    private static boolean makePalindromeIteration(String word, StringBuffer result, int index) {
        System.out.println(word);
        if (word.length()<=1){
            result.insert(result.length() / 2, word);
            return false;
        }
        for (int i=index;i<word.length();i++) {
            char startChar = word.charAt(i);
            int lastIndex = word.lastIndexOf(startChar);
            if (lastIndex > i) {
                result.insert(result.length() / 2, String.valueOf(startChar) + String.valueOf(startChar));
                if (!makePalindromeIteration(word.substring(i+1, lastIndex), result, 0)) break;
            } else if (lastIndex == i) {
                if (!makePalindromeIteration(word.substring(i+1), result, 0)) break;
            }
        }
        return false;
    }
}
