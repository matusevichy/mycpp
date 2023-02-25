package ua.step.homework;

import java.sql.Array;
import java.util.Arrays;
import java.util.Scanner;

/**
 * Написать и методы работы с квадратными матрицами (матрицы
 * представить в виде двухмерных массивов). 
 * Должны присутствовать методы:
 * • создания единичной (диагональной) матрицы (метод createOne)
 * • создания нулевой матрицы (метод createNull)
 * • сложение матриц (метод sumMatrix)
 * • умножения матриц (метод productMatrix)
 * • умножение матрицы на скаляр (метод productMatrix)
 * • определение детерминанта матрицы (метод determinant)
 * • вывод матрицы на консоль (метод printMatrix)
 */
public class Task01 {

	public static void main(String[] args) {
		// TODO: Проверяйте методы здесь
		int[][] a = { {2,0,-1}, {0, -2, 2} };
		int[][] b = {{4, 1, 0}, {3, 2, 1}, {0, 1, 0} };
		printMatrix(b);
		System.out.println(determinant(b));

	}

	/**
	 * Создает единичную матрицу
	 * @param n - количество строк
	 * @param m - количество колонок
	 * @return единичную (диагональную) матрицу
	 */
	public static int[][] createOne (int n, int m) {
		int[][] array = new int[m][n];
		for (int i=0; i<m; i++){
			for (int j=0; j<n; j++){
				if (i==j){
					array[i][j] = 1;
				}
				else{
					array[i][j]=0;
				}
			}
		}
		System.out.println(Arrays.deepToString(array));
		return array;
	}

	/**
	 * Создает нулевую матрицу
	 * @param n - количество строк
	 * @param m - количество колонок
	 * @return нулевую матрицу
	 */
	public static int[][] createNull (int n, int m) {
		return new int[n][m];
	}

	/**
	 * Вычисляет сумму двух матриц
	 * @param one - первая матрица
	 * @param two - вторая матрица
	 * @return сумму двух матриц
	 */
	public static int[][] sumMatrix(int[][] one, int[][] two) {
		if (one.length != two.length){
			throw new RuntimeException("Arrays has difference length");
		}
		else
		{
			int[][] array = new int[one.length][];
			for (int i=0; i< one.length; i++){
				if (one[i].length != two[i].length){
					throw new RuntimeException("Arrays has difference length");
				}
				else
				{
					int count = one[i].length;
					array[i] = new int[count];
					for (int j=0; j<count; j++)
					{
						array[i][j]=one[i][j]+two[i][j];
					}
				}
			}
			return array;
		}
	}

	/**
	 * Вычисляет произведение двух матриц
	 * @param one - первая матрица
	 * @param two - вторая матрица
	 * @return произведение матриц
	 */
	public static int[][] productMatrix(int[][] one, int[][] two) {
		int row=one.length;
		int col=two[0].length;
		if (one[0].length != two.length){
			throw new RuntimeException("Arrays has difference length");
		}
		else
		{
			int[][] array = new int[row][col];
			for (int i=0; i<row; i++) {
				for (int j = 0; j < col; j++) {
					{
						int sum = 0;
						for (int k = 0; k < col; k++) {
							sum += one[i][k] * two[k][j];
						}
						array[i][j] = sum;
					}
				}
			}
			return array;
		}
	}

	/**
	 * Вычисляет произведение матрицы на скаляр
	 * @param matrix - матрица
	 * @param num - скаляр
	 * @return произведение матрицы на скаляр
	 */
	public static int[][] productMatrix(int[][] matrix, int num) {
		int row=matrix.length;
		int col=matrix.length;
		int[][] array = new int[row][col];
		for (int i=0; i<row; i++) {
			for (int j = 0; j < col; j++) {
				{
					array[i][j] = matrix[i][j] * num;
				}
			}
		}
		return array;
	}

	/**
	 * Вычисляет детерминант матрицы
	 * @param matrix - матрица
	 * @return детерминант матрицы
	 */
	public static int determinant(int[][] matrix) {
		int n=matrix.length;
		if (n != matrix[0].length){
			throw new RuntimeException("Incorrect input data! Non square matrix");
		}
		else{
			if (n==1) return matrix[0][0];
			else if (n==2) return matrix[0][0]*matrix[1][1] - matrix[0][1]*matrix[1][0];
			else{
				int d=0;
				for (int k=0; k<n; k++){
					int[][] newMatrix = new int[n-1][n-1];
					for (int i=1; i<n; i++){
						int tmp=0;
						for (int j=0; j<n; j++){
							if(j==k) continue;
							newMatrix[i-1][tmp]=matrix[i][j];
							tmp++;
						}
					}
					d+=Math.pow(-1,k+2)*matrix[0][k]*determinant(newMatrix);
				}
				return d;
			}
		}
	}

	/**
	 * Печатает матрицу в стандартный поток вывода
	 * @param matrix - матрица
	 */
	public static void printMatrix(int[][] matrix) {
		System.out.println(Arrays.deepToString(matrix));
	}
}
