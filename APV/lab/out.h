#pragma once
#include"stdafx.h"
#include "LT.h"
#include "IT.h"
namespace Out {
	struct OUT { //��������
		wchar_t logfile[PARM_MAX_SIZE]; //��� ����� out
		std::ofstream* stream; //�������� ����� ���������
	};

	static const OUT INITOUT{ L"", NULL };
	OUT getOut(wchar_t logfile[]);
	void WriteOutInd(OUT out, IT::IdTable& idtable);
	void WriteOut(OUT out, LT::LexTable& lextable);
	void WriteError(OUT out, Error::ERROR error);
	void Close(OUT out);
}