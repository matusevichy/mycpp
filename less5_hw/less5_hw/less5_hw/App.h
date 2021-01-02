#pragma once
#include<iostream>
#include"Time.h"
#include"Matrix.h"

using namespace std;

class App
{
	enum { time = 1, matrix = 2 };
	enum {set1=1,set2,sum,diff,compare};
	enum {transpon1=3,transpon2,sum_m,prod_m,set_el,get_el};
public:
	void start();
	void main_menu();
	void time_menu();
	void matrix_menu();
	bool runapp(int);
	bool runtime();
	bool runmatrix();
};