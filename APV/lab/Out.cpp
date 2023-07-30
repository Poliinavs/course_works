#include"stdafx.h"
#include"out.h"
#include<iostream>
#include<fstream>
#include<iomanip>
#pragma warning(disable : 4996)

using namespace std;

namespace Out
{
	OUT getOut(wchar_t outfile[])
	{
		OUT out;
		out.stream = new ofstream;
		out.stream->open(outfile);
		if (out.stream->fail())
			throw ERROR_THROW(112);
		wcscpy_s(out.logfile, outfile);
		return out;
	}
	
	void WriteOutInd(OUT out, IT::IdTable& idtable)
	{
		*out.stream << "\n--------------------------Таблица индентифекаторов-----------------------" << endl;
			*out.stream << std::setfill('-') << std::setw(87) << '-' << std::endl;
	*out.stream << "   №" << " | " << "Идентификатор" << " | " << "Тип данных" << " | " << "Тип идентификатора" << " | " << "Индекс в ТЛ" << " | " << "Значение    " << std::endl;
	*out.stream << std::setw(87) << '-' << std::endl;
	*out.stream << endl;
	for (int i = 0, j = 0; i < idtable.size; i++, j++)
	{
		*out.stream << std::setfill('0') << std::setw(4) << std::right << j << " | ";
		*out.stream << std::setfill(' ') << std::setw(13) << std::left << idtable.table[i].id << " | ";
		switch (idtable.table[i].iddatatype)
		{
		case 1: *out.stream << std::setw(10) << std::left;
			*out.stream << "integer" << " | "; break;
		case 2: *out.stream << std::setw(10) << std::left;
			*out.stream << "string" << " | "; break;
		case 3: *out.stream << std::setw(10) << std::left;
			*out.stream << "bool" << " | "; break;
		default: *out.stream << std::setw(10) << std::left << "unknown" << " | "; break;
		}
		switch (idtable.table[i].idtype)
		{
		case 1: *out.stream << std::setw(18) << std::left << "переменная" << " | "; break;
		case 2: *out.stream << std::setw(18) << std::left << "функция" << " | "; break;
		case 3: *out.stream << std::setw(18) << std::left << "параметр" << " | "; break;
		case 4: *out.stream << std::setw(18) << std::left << "литерал" << " | "; break;
		default: *out.stream << std::setw(18) << std::left << "unknown" << " | "; break;
		}
		*out.stream << std::setw(11) << std::left << idtable.table[i].idxfirstLE << " | ";
		if (idtable.table[i].iddatatype == 1 && idtable.table[i].idtype != IT::F)
			*out.stream << std::setw(18) << std::left << idtable.table[i].value.vint;
		else if (idtable.table[i].iddatatype == 2 && idtable.table[i].idtype != IT::F) {
			if (idtable.table[i].value.vstr->str[0] != '\'')
				*out.stream << "\"" << idtable.table[i].value.vstr->str << "\"";
			else
				*out.stream << idtable.table[i].value.vstr->str;
		}
		else if (idtable.table[i].iddatatype == 3 && idtable.table[i].idtype != IT::F) {
			if(idtable.table[i].value.vbool==1)
			*out.stream << std::setw(18) << std::left << "true";
			else 
				*out.stream << std::setw(18) << std::left << "false";
		}
			
		else
			*out.stream << "-";
		*out.stream << std::endl;
	}
	*out.stream << std::setfill('-') << std::setw(87) << '-' << std::endl;
	}
	void WriteOut(OUT out, LT::LexTable& lextable)
	{
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
	void WriteError(OUT out, Error::ERROR error)
	{
		if (out.stream)
		{
			*out.stream << "\nОшибка " << error.id
				<< ": " << error.message
				<< "\nСтрока " << error.inext.line
				<< " позиция " << error.inext.col << endl;
			Close(out);
		}
	}
	void Close(OUT out)
	{
		out.stream->close();
		delete out.stream;
	}
}