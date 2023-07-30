#pragma once
#include"stdafx.h"
#include "LT.h"
#include "IT.h"
namespace Out {
	struct OUT { //протокол
		wchar_t logfile[PARM_MAX_SIZE]; //имя файла out
		std::ofstream* stream; //выходной поток протокола
	};

	static const OUT INITOUT{ L"", NULL };
	OUT getOut(wchar_t logfile[]);
	void WriteOutInd(OUT out, IT::IdTable& idtable);
	void WriteOut(OUT out, LT::LexTable& lextable);
	void WriteError(OUT out, Error::ERROR error);
	void Close(OUT out);
}