#pragma once
#include<iostream>
#include<stdio.h>
#include<io.h>
#include<direct.h>

using namespace std;

enum
{
	CANCEL,
	REWRITE,
	SKIP,
	REWRITEFORALL
};

enum
{
	DELETE = 1,
	DELETEFORALL = 3
};

class App
{
	bool rewriteForAll = false;
	bool deleteForAll = false;
public:
	bool moveDir(char[], char[]);
	void copyFile(char[], char[]);
	int rewriteMenu(char[]);
	int deleteMenu(char[]);
};

