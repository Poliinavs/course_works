#include "stdafx.h"
#include <stack>
#include <queue>
using namespace std;

bool PolishNotation(int i, LT::LexTable& lextable, IT::IdTable& idtable)
{
	stack<LT::Entry> stack;		
	queue<LT::Entry> queue;		
	int countLex = 0;
	int posLex = i;
	int comma = 0;
	bool findFunc = false;
	for (i; lextable.table[i].lexema != LEX_SEMICOLON; i++, countLex++)
	{
		switch (lextable.table[i].lexema)
		{
		case LEX_ID:
		case LEX_FUNCTION:
		{
			if (idtable.table[lextable.table[i].idxTI].idtype == IT::F)
				findFunc = true;
			queue.push(lextable.table[i]);
			continue;
		}
		case LEX_LITERAL:
		{
			queue.push(lextable.table[i]);
			continue;
		}
		case LEX_LEFTHESIS:
		{
			lextable.table[i].priority = 0;
			stack.push(lextable.table[i]);
			continue;
		}
		case LEX_RIGHTHESIS:
		{
			lextable.table[i].priority = 0;
			if (findFunc)
			{
				/*if (comma == 0)
					comma++;*/
				comma++;
				LT::Entry func; func.idxTI = -1; func.lexema = '@'; func.sn = lextable.table[i].sn; func.amount = comma;
				lextable.table[i] = func;
				queue.push(lextable.table[i]);
				findFunc = false;
			}
			else {
				while (stack.top().lexema != LEX_LEFTHESIS
					)
				{
					queue.push(stack.top());
					stack.pop();
					if (stack.empty())
						return false;
				}
			}
			stack.pop();
			continue;
		}
		case LEX_PLUS: case LEX_MINUS: case LEX_STAR:
		case LEX_MOD: case LEX_DIRSLASH: 
		{
			if (lextable.table[i].lexema == LEX_PLUS || lextable.table[i].lexema == LEX_MINUS)
				lextable.table[i].priority = 2;
			if (lextable.table[i].lexema == LEX_STAR || lextable.table[i].lexema == LEX_MOD || lextable.table[i].lexema == LEX_DIRSLASH)
				lextable.table[i].priority = 3;

			if (lextable.table[i + 1].lexema == LEX_PLUS || lextable.table[i + 1].lexema == LEX_MINUS ||
				lextable.table[i + 1].lexema == LEX_STAR) {
				cout << "Два арифметических оператора не могут идти друг за другом!\n";
				return false;
			}
			while (!stack.empty() && lextable.table[i].priority <= stack.top().priority)// пока приоритет текущего оператора меньше или равен приоритету оператора в вершине стека
			{
				queue.push(stack.top());
				stack.pop();
			}
			stack.push(lextable.table[i]);
			continue;
		}
		case LEX_COMMA:
		{
			comma++;
			lextable.table[i].priority = 1;
		}
		}
	}
	while (!stack.empty())
	{
		if (stack.top().lexema == LEX_LEFTHESIS || stack.top().lexema == LEX_RIGHTHESIS)
			return false;
		queue.push(stack.top());
		stack.pop();
	}
	bool fr = true;

	LT::Entry temp;		temp.idxTI = -1;	temp.lexema = ' ';	temp.sn = lextable.table[posLex + countLex].sn;
	lextable.table[posLex + countLex] = temp;
	int count = 0;
	
	while (countLex != 0)
	{
		if (!queue.empty()) {

			lextable.table[posLex++] = queue.front();
			queue.pop();
		}
		else
		{
			temp.idxTI = -1;	temp.lexema = ' ';	temp.sn = lextable.table[posLex].sn;
			count++;
			if (fr) {
				temp.lexema = ';';
				fr = false;
			}
			lextable.table[posLex++] = temp;
		}

		countLex--;
	}
	if (fr) {
		temp.lexema = ';';
		lextable.table[posLex++] = temp;
	}

	for (int i = posLex - 1; i > -1; i--)// восстановление индексов первого вхождения в ТЛ у операторов из ТИ
	{
		if (( lextable.table[i].lexema == LEX_ID) && lextable.table[i].idxTI != TI_NULLIDX) {
			idtable.table[lextable.table[i].idxTI].idxfirstLE = i;
		}

	}
	int buff = count;
	for (int i = ++posLex; i < lextable.size; i++)
	{
		lextable.table[posLex-count] = lextable.table[i];
		count--;
	}
	lextable.size = lextable.size - buff;
	


	
	return true;
}

bool startPolishNotation(LT::LexTable& lextable, IT::IdTable& idtable)
{
	bool rc = false;
	for (int i = 0; i < lextable.size; i++)
	{
		if (lextable.table[i].lexema == '=' )
		{
			if (lextable.table[i + 1].lexema == LEX_LITERAL&& lextable.table[i + 2].lexema == LEX_SEMICOLON ) {
				continue;
			 }
			if (lextable.table[i + 1].lexema == '=' || lextable.table[i -1].lexema == '!' || lextable.table[i - 1].lexema == '<' || lextable.table[i - 1].lexema == '>') {
				i++;
				continue;
			}
			rc = PolishNotation(i + 1, lextable, idtable);
			if (!rc)
				return rc;
		}
	}
	return rc;
}



