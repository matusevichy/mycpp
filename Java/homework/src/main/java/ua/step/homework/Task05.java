

package ua.step.homework;

import java.util.Scanner;

/**
 * Королю нужно убить дракона, но в его казне мало средств
 * для покупки армии. Нужно создать программу, используя
 * методы, которая поможет рассчитать минимальное ко-
 * личество копейщиков, которое необходимо, чтобы убить
 * дракона. C клавиатуры вводятся данные:
 * - здоровья дракона;
 * - атаки дракона;
 * - здоровье одного копейщика;
 * - атака одного копейщика.
 * Защита, меткость и т. п. не учитывать. Копейщики наносят
 * удар первыми (общий нанесенный урон – это сумма атак
 * всех живых копейщиков). Если атака дракона превышает
 * значение жизни копейщика (например, у копейщика жиз-
 * ни – 10, а атака – 15), то умирает несколько копейщиков, а
 * оставшийся урон идет одному из копейщиков.
 *
 * Например, жизнь дракона – 500, атака – 55, жизнь одно-
 * го копейщика – 10, атака –10, а количество копейщиков при
 * данных условиях – 20.
 * Лог боя для данного примера должен выглядеть так:
 *
 * Итерация 15
 * Копейщики атакуют (урон 200) – у дракона осталось 300 жизней
 * Дракон атакует – осталось 15 копейщиков, один из которых ранен
 * (осталось 5 жизней)
 * Копейщики атакуют – у дракона осталось 150 жизней
 * Дракон атакует – осталось 9 копейщиков
 * Копейщики атакуют – у дракона осталось 60 жизней
 * Дракон атакует – осталось 4 копейщика, один из которых ранен
 * (осталось 5 жизней)
 * Копейщики атакуют – у дракона осталось 20 жизней
 * Дракон атакует и побеждает
 */
public class Task05 {
	static int dragonHealth;
	static int dragonDamage;
	static int spearmanHealth;
	static int spearmanDamage;

	public static void main(String[] args) {
		Scanner scanner = new Scanner(System.in);
		System.out.println("Здоровье дракона");
		dragonHealth = scanner.nextInt();
		System.out.println("Атака дракона");
		dragonDamage = scanner.nextInt();
		System.out.println("Здоровье копейщика");
		spearmanHealth = scanner.nextInt();
		System.out.println("Атака копейщика");
		spearmanDamage = scanner.nextInt();
//		System.out.println(startBattle(dragonHealth, 256*spearmanHealth, 256));
		System.out.println(findMinSpearmanCount(0,dragonHealth/spearmanDamage/2, dragonHealth/spearmanDamage, 1));
	}

	private static int findMinSpearmanCount(int min, int max, int count, int iteration){
		int minSpearmanCount=0;
		System.out.println(String.format("Итерация %d", iteration));
		if (startBattle(dragonHealth, count*spearmanHealth, count)){
			if (count != min){
				minSpearmanCount = findMinSpearmanCount(min, count, min+(count-min)/2, iteration+1);
			}
			else return count;
		}
		else{
			if((max-min) != 1) minSpearmanCount = findMinSpearmanCount(count, max, count + (max-count)/2, iteration+1);
			else return max;
		}
		return minSpearmanCount;
	}
	private static boolean startBattle (int dragonHealth, int spearmansHeals, int spearmanCount)
	{
		int spearmansDamage = spearmanCount * spearmanDamage;
		dragonHealth = dragonHealth - spearmansDamage;
		if (dragonHealth > 0){
			System.out.println(String.format(" * Копейщики атакуют (урон %d) – у дракона осталось %d жизней", spearmansDamage, dragonHealth));
			spearmansHeals=spearmansHeals-dragonDamage;
			if (spearmansHeals > 0){
				spearmanCount = (int)Math.ceil((double)spearmansHeals/spearmanHealth);
				System.out.println(String.format(" * Дракон атакует – осталось %d копейщиков", spearmanCount));
				int spearmansFullHealth = spearmanCount*spearmanHealth;
				int diffHealth = spearmansFullHealth-spearmansHeals;
				if(diffHealth > 0){
					System.out.println(String.format(" * один из которых ранен (осталось %d жизней)", spearmansHeals-(spearmanCount-1)*spearmanHealth));
				}
				return startBattle(dragonHealth, spearmansHeals, spearmanCount);
			}
			else{
				System.out.println("Дракон атакует и побеждает");
				return false;
			}
		}
		else{
			System.out.println(String.format(" * Копейщики атакуют (урон %d) и побеждают", spearmansDamage));
			return true;
		}
	}


}

