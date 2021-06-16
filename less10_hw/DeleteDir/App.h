#pragma once
#include<iostream>
#include<stdio.h>
#include<io.h>
#include<direct.h>

using namespace std;

enum
{
	CANCEL,
	DELETE,
	SKIP,
	DELETEFORALL
};

class App
{
	bool deleteForAll = false;
public:
	bool deleteDir(char[]);
	int deleteMenu(char[]);
};

