#include "Base.h"

Base::Base()
{
	root = nullptr;
}

Base::~Base()
{
	if (root)
	{
		delete root;
	}
}

void Base::Add()
{
	Auto* newauto, * position, * parent;
	char tmpnum[9];
	int leftright;
	cout << "Enter the number of the car:\n";
	gets_s(tmpnum,9);
	if (newauto=Find(tmpnum,root))
	{
		newauto->offencelist->Add();
	}
	else
	{
		newauto = new Auto;
		strcpy_s(newauto->number, tmpnum);
		newauto->offencelist = new List;
		newauto->offencelist->Add();
		newauto->left = nullptr;
		newauto->right = nullptr;
		if (!root)
		{
			root = newauto;
		}
		else
		{
			position = root;
			while (position)
			{
				parent = position;
				if ((leftright=strcmp(newauto->number, position->number)) < 0)
				{
					position = position->left;
				}
				else
				{
					position = position->right;
				}
				newauto->owner = position;
				if (leftright < 0)
				{
					position->left = newauto;
				}
				else
				{
					position->right = newauto;
				}
			}
		}
	}
}

void Base::Add(const char* num, const char* name, float sum)
{
	Auto* newauto, * position, * parent=NULL;
	int leftright;
	if (newauto = Find(num, root))
	{
		newauto->offencelist->Add(name,sum);
	}
	else
	{
		newauto = new Auto;
		strcpy_s(newauto->number, num);
		newauto->offencelist = new List;
		newauto->offencelist->Add(name,sum);
		newauto->left = nullptr;
		newauto->right = nullptr;
		if (!root)
		{
			root = newauto;
		}
		else
		{
			position = root;
			while (position)
			{
				parent = position;
				if ((leftright = strcmp(newauto->number, position->number)) < 0)
				{
					position = position->left;
				}
				else
				{
					position = position->right;
				}
			}
				newauto->owner = parent;
				if (leftright < 0)
				{
					parent->left = newauto;
				}
				else
				{
					parent->right = newauto;
				}			
		}
	}
}

void Base::Delete(const char* num)
{
	Auto* tmp;
	tmp = Find(num, root);
	if (tmp)
	{
		if (!tmp->left && !tmp->right)
		{
			if (tmp == root)
			{
				delete root;
				root = nullptr;
			}
			else if (strcmp(tmp->number, tmp->owner->number) < 0)
			{
				tmp->owner->left = nullptr;
			}
			else
			{
				tmp->owner->right = nullptr;
			}
			delete tmp;
		}
		else if (!tmp->left && tmp->right)
		{
			if (strcmp(tmp->number, tmp->owner->number) < 0)
			{
				tmp->owner->left = tmp->right;
			}
			else
			{
				tmp->owner->right = tmp->right;
			}
			delete tmp;
		}
		else if (tmp->left && !tmp->right)
		{
			if (strcmp(tmp->number, tmp->owner->number) < 0)
			{
				tmp->owner->left = tmp->left;
			}
			else
			{
				tmp->owner->right = tmp->left;
			}
			delete tmp;
		}
		else
		{
			Auto* min = Min(tmp->right);
			if (min->right && min->owner!=tmp)
			{
				min->owner->left = min->right;
				min->right = tmp->right;
			}
			min->left = tmp->left;
			min->owner = tmp->owner;
			if (tmp != root)
			{
				if (strcmp(tmp->number, tmp->owner->number) < 0)
				{
					tmp->owner->left = min;
				}
				else
				{
					tmp->owner->right = min;
				}
			}
			else
			{
				min->owner = nullptr;
				root = min;
			}
			delete tmp;
		}
	}
}

Auto* Base::Min(Auto* el)
{
	Auto* position = el, * tmp = position;
	while (position)
	{
		tmp = position;
		position = position->left;
	}
	return tmp;
}

void Base::DeleteAll(Auto* el)
{
	Auto* position = el;
	if (position!=root)
	{
		if (strcmp(position->number, position->owner->number) < 0)
		{
			position->owner->left = nullptr;
		}
		else
		{
			position->owner->right = nullptr;
		}

	}
 		if (position->left)
		{
			DeleteAll(position->left);
		}
		if (position->right)
		{
			DeleteAll(position->right);
		}
		if (position == root)
		{
			delete position;
			root = nullptr;
		}
		else
		{
			delete position;
		}
}

void Base::Print(Auto* el)
{
	if (el)
	{
		Auto* position;
		position = el;
		if (position->left)
		{
			Print(position->left);
		}
		cout << position->number << endl;
		cout << "Offence(s):\n";
		position->offencelist->Print();
		cout << endl;
		if (position->right)
		{
			Print(position->right);
		}
	}
}

void Base::Print(const char* num)
{
	Auto* tmp = Find(num, root);
	cout << tmp->number << endl;
	cout << "Offence(s):\n";
	tmp->offencelist->Print();
	cout << endl;
}

void Base::Print(const char* min, const char* max, Auto* el)
{
	if (el)
	{
		Auto* position;
		position = el;
		if (position->left)
		{
			Print(min, max, position->left);
		}
		if (strcmp(min, position->number) <= 0 && strcmp(position->number, max) <= 0)
		{
			cout << position->number << endl;
			cout << "Offence(s):\n";
			position->offencelist->Print();
			cout << endl;
		}
		if (position->right)
		{
			Print(min, max, position->right);
		}
	}
}

Auto* Base::Find(const char* number, Auto* el)
{
	if (el)
	{
		if (strcmp(number, el->number) == 0)
		{
			return el;
		}
		else if (strcmp(number, el->number) < 0)
		{
			Find(number, el->left);
		}
		else
		{
			Find(number, el->right);
		}
	}
	else
	{
		return nullptr;
	}
}

