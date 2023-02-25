package ua.step.homework;

import java.util.Arrays;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

/**
 * В массиве хранится n явно заданных текстовых строк.
 * <p>
 * Создать методы:
 * • Возвращает содержимое массива в виде строки через пробел (join)
 * • Возвращает содержимое массива в виде строки через заданный разделитель (перегруженный join)
 * • Сортирующий массив обратном порядке (без учёта регистра) от z до a (sortDesc);
 * • Сортирующий массив по количеству слов в строке (слова разделены пробелами) (sortByWordCount).
 *
 * Примечание: Не использовать методы строк и стандартную сортировку
 */
public class Task02 {
    public static void main(String[] args) {
        // TODO: Проверяйте методы здесь
    }

    /**
     * Соединяет массив строк в одну строку разделенную пробелом
     *
     * @param strings - массив строк
     * @return строка состоящая из элементов массив
     */
    public static String join(String[] strings) {
        String string = "";
        int n = strings.length;
        for (int i=0; i<n; i++){
            string+=strings[i]+((i<n-1)?" ":"");
        }
        return string;
    }

    /**
     * Соединяет массив строк в одну строку разделенную соединителем glue
     *
     * @param strings - массив строк
     * @param glue    - соединитель
     * @return строка состоящая из элементов массива
     */
    public static String join(String[] strings, String glue) {
        String string = "";
        int n = strings.length;
        for (int i=0; i<n; i++){
            string+=strings[i]+((i<n-1)?glue:"");
        }
        return string;
    }

    /**
     * Сортирует массив строк в порядке обратном алфавитному
     *
     * @param strings - массив строк для сортировки
     */
    public static void sortDesc(String[] strings) {
        int n=strings.length;
        for (int i=0; i<n; i++){
            for (int j=n-1; j>i;j--){
                if (compareStr(strings[j], strings[j-1]) > 0){
                    String tmp=strings[j-1];
                    strings[j-1]=strings[j];
                    strings[j]=tmp;
                }
            }
        }
    }
    private static int compareStr(String str1, String str2){
        final int n = str1.length();
        final int m = str2.length();
        int len = n;
        int result = 0;
        if (n>m){
            len = m;
            result = 1;
        }
        for (int i=0; i<len; i++){
            int tmp = Character.compare(str1.charAt(i), str2.charAt(i));
            if (tmp!=0) return tmp;
        }
        return result;
    }
    private static int getWorldCount(String str){
        final int n = str.length();
        String regex = "(\\w+)[ ,!.]";
        int result = 0;
        Pattern pattern = Pattern.compile(regex);
        Matcher matcher = pattern.matcher(str);
        while (matcher.find()){
            result++;
        }
        return result;
    }
    /**
     * Сортирует массив строк по количеству слов в строке
     *
     * @param strings - массив строк для сортировки
     */
    public static void sortByWordCount(String[] strings) {
        int n=strings.length;
        for (int i=0; i<n; i++){
            for (int j=n-1; j>i;j--){
                if (getWorldCount(strings[j]) < getWorldCount(strings[j-1])){
                    String tmp=strings[j-1];
                    strings[j-1]=strings[j];
                    strings[j]=tmp;
                }
            }
        }
    }
}
