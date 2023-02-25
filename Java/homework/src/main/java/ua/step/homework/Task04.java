package ua.step.homework;

import java.util.*;

/**
 * Эту задачу можно встретить и под названием «Золотая гора» — нужно спуститься с горы
 * и собрать как можно больше золота.
 *
 * Ниже показан пример треугольника из чисел.
 * <pre>
 *       7
 *      3 8
 *     8 1 0
 *    2 7 4 4
 *   4 5 2 6 5
 * </pre>
 * Написать программу, которая позволит:
 * - выводить значения треугольника на консоль в таком виде как на рисунке;
 * - вычислять наибольшую с умму чисел, через которые проходит путь, начинающийся на вершине и
 * заканчивающийся где-то на основании.
 *
 * 1. Каждый шаг может идти диагонально вниз-направо или диагонально вниз-налево.
 * 2. Количество строк в треугольнике >1, но <100.
 * 3. Числа в треугольнике все целые от 0 до 99 включительно (генерируются случайным образом).
 *
 * В примере, описанном выше, это путь 7, 3, 8, 7, 5, дающий максимальную сумму 30.
 *
 * Программа должна выводить на экран треугольник и путь, который даст максимальный результат. Для текущего
 * примера он будет такой – влево, влево, вправо, влево.
 *
 * Алгоритм решения данной задачи: <a href='https://ru.wikibooks.org/wiki/%D0%A0%D0%B5%D0%BA%D1%83%D1%80%D1%81%D0%B8%D1%8F#%D0%97%D0%B0%D0%B4%D0%B0%D1%87%D0%B0_%D0%BE_%D0%B7%D0%BE%D0%BB%D0%BE%D1%82%D0%BE%D0%B9_%D0%B3%D0%BE%D1%80%D0%B5'>Задача о золотой горе</a>
 */
public class Task04 {

	public static void main(String[] args) {
		// TODO: Здесь будет ваш код
		Random random = new Random();
		int height = random.nextInt(100)+1;
		int[][] mountain = createMountain(height);
		Map<Integer, ArrayList<String>> allPath = new HashMap<>();
		System.out.println(Arrays.deepToString(mountain));
		showMountain(mountain);
		getPath(mountain,0,new ArrayList<String>(), "", allPath, 0, 1);
		int max = Collections.max(allPath.keySet());
		String path = allPath.get(max).toString();
		System.out.println(max);
		System.out.println(path);
	}

	private static int[][] createMountain(int height){
		int[][] mountain = new int[height][];
		Random random = new Random();
		for (int i=0; i<height; i++){
			mountain[i] = new int[i+1];
			int j=0;
			do{
				int number = random.nextInt(100);
				mountain[i][j] = number;
				j++;
			}while(j<=i);
		}
		return mountain;
	}

	private static void showMountain(int[][] mountain){
		int height = mountain.length;
		for (int i=0; i<height; i++){
			char[] emptyStr = new char[height-i];
			Arrays.fill(emptyStr,' ');
			System.out.print(emptyStr);
			int j=0;
			do{
				System.out.print((mountain[i][j]<10)?mountain[i][j]+ "  ":mountain[i][j] + " ");
				j++;
			}while(j<=i);
			System.out.println();
		}
	}

	private static void getPath(int[][] mountain, int sum, ArrayList<String> path, String dest, Map<Integer, ArrayList<String>> allPath, int index, int step){
		int i=0;
		sum+=mountain[step-1][index];
		if(dest !="") path.add(dest);
		if (step< mountain.length) {
			do {
				getPath(mountain, sum, new ArrayList<String>(path),(i == 0) ? "left" : "right" ,allPath, (i == 0) ? index : index + 1, step + 1);
				i++;
			} while (i <= 1);
		}
		else{
			allPath.put(sum, path);
		}
	}
}
