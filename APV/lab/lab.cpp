// lab.cpp : Этот файл содержит функцию "main". Здесь начинается и заканчивается выполнение программы.
//

#include "stdafx.h"

//-in:C:\instit\kurs2\kurs\APV\Debug\in.txt

using namespace std;
int _tmain(int argc, _TCHAR* argv[])
{
	setlocale(LC_ALL, "ru");

	Log::LOG log = Log::INITLOG;
	Out::OUT out = Out::INITOUT;
	Parm::PARM parm;

	try {
		parm = Parm::getparm(argc, argv);
		log = Log::getlog(parm.log);

		In::IN in = In::getin(parm.in);
	
		cout << "Всего символов:" << in.size << endl;
		cout << "Всего строк:" << in.lines + 1 << endl;
		cout << "Пропущено:" << in.ignor << endl;

		Log::WriteLog(log);
		Log::WriteParm(log, parm);
		Log::WriteIn(log, in);

		IT::IdTable idtable = IT::Create(in.size);
		LT::LexTable lextable = LT::Create(in.size);

		LexAnalize(in, lextable, idtable);

		MFST::Mfst mfst(lextable, GRB::getGreibach(), parm.pars);
		mfst.start(log);
		mfst.savededucation();
		mfst.printRules();

		startPolishNotation(lextable, idtable);

		bool sem_ok = Semantic::semanticsCheck(lextable, idtable);					// выполнить семантический анализ

		Gener::CodeGeneration(lextable, idtable);

		out = Out::getOut(parm.out);
		Out::WriteOutInd(out, idtable);
		Out::WriteOut(out, lextable);
		Out::Close(out);

		cout << "\nУспешное выполнение прошраммы!";
		Log::WriteLine(log, (char*)"Тест:", (char*)"без ошибок\n", "");

	}
	catch (Error::ERROR e)
	{
		Log::WriteError(log, e);
		Out::WriteError(out, e);
	}
}

  
	
