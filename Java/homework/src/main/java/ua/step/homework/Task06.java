package ua.step.homework;

import java.util.regex.Matcher;
import java.util.regex.Pattern;

/**
 * Напишите метод, проверяющую правильность расстановки скобок в строке
 * введённой с клавиатуры. При правильной расстановке выполняются условия: 
 * • количество открывающих и закрывающих скобок равно. 
 * • внутри любой пары открывающая – соответствующая закрывающая скобка, скобки расставлены
 * правильно. В строке могут присутствовать скобки как круглые, так и квадратные
 * скобки (и др. символы). Каждой открывающей скобке соответствует закрывающая
 * того же типа (круглой – круглая, квадратной - квадратная).
 * Пример неправильной расстановки:
 * ( [ a) b]. Пример правильных входных данных (a[b](f[(g)(g)]))
 * Программа должна вывести результат в виде сообщения, примеры:
 *  • Правильная строка 
 *  • Ошибка отсутствие ( 
 *  • Ошибка отсутствие [
 * 
 */
public class Task06 {
	public static void main(String[] args) {
//	System.out.println(startAnalize("(a[b](f[(g)(g)])"));
		analizeString("a([b](f[(g)(g)]))");
	}

	private static void analizeString(String str){
		String result;
		if((result = startAnalize(str)) !=""){
			analizeResult(result);
		}
		else System.out.println("• Правильная строка");
	}

	private static String startAnalize(String str){
		String result="";
		String regular = "\\S*([\\(][^\\(\\[\\]\\)]*[\\)])\\S*";
		Pattern pattern = Pattern.compile(regular);
		Matcher matcher = pattern.matcher(str);
		if (matcher.find()) {
			str = str.replace(matcher.group(1),"");
			result = startAnalize(str);
		}
		else{
			String regular1 = "\\S*([\\[][^\\(\\[\\]\\)]*[\\]])\\S*";
			Pattern pattern1 = Pattern.compile(regular1);
			Matcher matcher1 = pattern1.matcher(str);
			if (matcher1.find()) {
				str = str.replace(matcher1.group(1),"");
				result = startAnalize(str);
			}
			else {
				result = str;
			}
		}
		return result;
	}

	private static void analizeResult(String result){
		String regular = "([\\[\\(\\)\\]])";
		Pattern pattern = Pattern.compile(regular);
		Matcher matcher = pattern.matcher(result);
		String matchResult="";
		while (matcher.find()) {
			matchResult = matcher.group();
			switch (matchResult){
				case "[":
					System.out.println("• Ошибка отсутствие ]");
					break;
				case "(":
					System.out.println("• Ошибка отсутствие )");
					break;
				case "]":
					System.out.println("• Ошибка отсутствие [");
					break;
				case ")":
					System.out.println("• Ошибка отсутствие (");
					break;

			}
		}
		if (matchResult == "") System.out.println("• Правильная строка");
	}
}
