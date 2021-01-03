#include "list.h"

List::List()
{
	first = last = nullptr;
	count = 0;
}

List::~List()
{
//	Clear();
}

void List::addFirst(int val)
{
	Node* node = new Node;
	node->value = val;
	if (isEmpty())
	{
		first = last = node;
	}
	else
	{
		node->next = first;
		first = node;
	}
	count++;
}

void List::addLast(int val)
{
	Node* node = new Node;
	node->value = val;
	if (isEmpty())
	{
		first = last = node;
	}
	else
	{
		last->next = node;
		last = node;
	}
	count++;
}

void List::insertAt(int index, int val)
{
	Node* node = new Node;
	node->value = val;
	if (isEmpty())
	{
		first = last = node;
		count++;

	}
	else if (index >= count)
	{
		addLast(val);
	}
	else if (index <= 0)
	{
		addFirst(val);
	}
	else
	{
		Node* tmp = new Node;
		tmp = first;
		for (int i = 0; i < index-1; i++)
		{
			tmp = tmp->next;
		}
		node->next = tmp->next;
		tmp->next = node;
		count++;
	}
}

void List::removeFirst()
{
	if (!isEmpty())
	{
		Node* tmp = first->next;
		delete first;
		first = tmp;
		count--;
	}
}

void List::removeLast()
{
	if (!isEmpty())
	{
		Node* tmp = first;
		for (int i = 0; i < count-2; i++)
		{
			tmp = tmp->next;
		}
		delete tmp->next;
		last = tmp;
		last->next = nullptr;
		count--;
	}
}

void List::removeAt(int index)
{
	if (!isEmpty())
	{
		if (index<=0)
		{
			removeFirst();
		}
		else if (index>=count)
		{
			removeLast();
		}
		else
		{
			Node* tmp = first;
			for (int i = 0; i < index - 1; i++)
			{
				tmp = tmp->next;
			}
			Node* tmp1 = tmp->next->next;
			delete tmp->next;
			tmp->next = tmp1;
			count--;
		}
	}
}

int List::Find(int val)
{
	if (!isEmpty())
	{
		Node* tmp = first;
		for (int i = 0; i < count; i++)
		{
			if (tmp->value == val)
			{
				return i;
			}
			tmp = tmp->next;
		}
	}
	return NULL;
}

bool List::isEmpty()
{
	return count == 0;
}

void List::Clear()
{
	while (count!=0)
	{
		removeFirst();
	}
}

void List::Print()
{
	if (isEmpty())
	{
		cout << "List is empty...\n";
	}
	else
	{
		Node* tmp = first;
		for (int i = 0; i < count; i++)
		{
			cout << tmp->value << " ";
			tmp = tmp->next;
		}
		cout << endl;
	}
}
