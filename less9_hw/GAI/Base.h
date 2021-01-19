#pragma once
#include"List.h"

struct Auto
{
	char number[9];
	List* offencelist;
	Auto* owner, * left, * right;
};

class Base
{
	Auto* root;

public:
	Base();
	~Base();
	Auto* getRoot() { return root; }
	void Add();
	void Add(const char*, const char*, float);
	void Delete(const char*);
	Auto* Min(Auto*);
	void DeleteAll(Auto*);
	void Print(Auto*);
	Auto* Find(const char*, Auto*);
};

