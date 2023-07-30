#include "stdafx.h"
#include<iomanip>
namespace LT
{
	LexTable Create(int size)
	{
		if (size > LT_MAXSIZE)
		{
			throw ERROR_THROW(200);
		}

		LexTable lextable;
		lextable.maxsize = size;
		lextable.size = 0;
		lextable.table = new Entry[size];
		return lextable;
	}

	void Add( // добавление лексемы в таблицу 
		LexTable& lextable, // таблица лексем
		Entry entry // лексема
	) {

		if (lextable.size >= lextable.maxsize)
		{
			throw ERROR_THROW(201);
		}
		lextable.table[lextable.size] = entry;
		lextable.size++;
	}

	

	Entry GetEntry( LexTable& lextable,int n) {
		if (n >= lextable.size || n < 0)
		{
			throw ERROR_THROW(202);
		}

		return lextable.table[n];

	}

	void Delete( LexTable& lextable ) {
		delete[] lextable.table;
		lextable.size = 0;
		lextable.maxsize = 0;
	}
	void showTable(LexTable lextable)		// вывод таблицы лексем
	{
		cout << "--------------------------Таблица лексем-----------------------" << endl;
		int stroke = 0;
		int From = 0;
		int To = 0;
		bool flag = false;
		cout << std::setfill('0') << std::setw(4) << std::right << stroke++ << " | ";

		char* arr = new char[TI_STR_MAXSIZE];
		for (int i = 0, j = 0; i < lextable.size; i++)
		{
			if (lextable.table[i].sn > lextable.table[i - 1].sn) {
				cout << std::setfill('0') << std::setw(4) << std::right << stroke++ << " | ";
			}
			if (lextable.table[i].lexema == LEX_SEMICOLON || lextable.table[i + 1].sn > lextable.table[i].sn)
			{
				arr[j] = lextable.table[i].lexema;
				flag = true;
			}
			else
				arr[j] = lextable.table[i].lexema;
			j++;
			if (flag) {
				arr[j] = '\0';
				cout << std::setw(20) << std::setfill(' ') << std::left << arr << " | " << setfill('0') << setw(3) << right << From << " - " << setfill('0') << setw(3) << right << To << endl;
				j = 0;
				From = To;
				flag = !flag;
			}
			To++;

		}
		cout << "---------------------------------------------------------------" << endl;
	}
	void WriteTable(LexTable lextable, Out::OUT out) {
		*out.stream << "\n--------------------------Таблица лексем-----------------------" << endl;
		int stroke = 0;
		int From = 0;
		int To = 0;
		bool flag = false;
		*out.stream << std::setfill('0') << std::setw(4) << std::right << stroke++ << " | ";
		char* arr = new char[TI_STR_MAXSIZE];
		for (int i = 0, j = 0; i < lextable.size; i++)
		{
			if (lextable.table[i].sn > lextable.table[i - 1].sn) {
				*out.stream << std::setfill('0') << std::setw(4) << std::right << stroke++ << " | ";
			}
			if (lextable.table[i].lexema == LEX_SEMICOLON || lextable.table[i + 1].sn > lextable.table[i].sn)
			{
				arr[j] = lextable.table[i].lexema;
				flag = true;
			}
			else
				arr[j] = lextable.table[i].lexema;
			j++;
			if (flag) {
				arr[j] = '\0';
				*out.stream << std::setw(20) << std::setfill(' ') << std::left << arr << " | " << setfill('0') << setw(3) << right << From << " - " << setfill('0') << setw(3) << right << To << endl;
				j = 0;
				From = To;
				flag = !flag;
			}
			To++;

		}
		*out.stream << "---------------------------------------------------------------" << endl;
	}

}