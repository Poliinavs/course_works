
#include  "Generator.h"

#include "stdafx.h"
#include <stack>
using namespace std;

namespace Gener
{
	bool condition = false;
	int conditOmount = 0;
	bool needCont = false;

	string itoS(int x) {
		char p[1000];
		_itoa(x, p, 10);
		return string(p);
	}

string CallFunction(LT::LexTable& lextable, IT::IdTable& idtable, int g)
{
	string str;
	stack<IT::Entry> temp;
	IT::Entry e = ITENTRY(g);
	stack<LT::Entry> stack;
	 
	for (int j = g+1; LEXEMA(j) != LEX_SEMICOLON; j++)
	{
		if (LEXEMA(j) == LEX_ID || LEXEMA(j) == LEX_LITERAL ) 
			temp.push(ITENTRY(j));
	}
	FST::FST fstLENGHT(ITENTRY(g).id, LENGHT);
	

	while (!temp.empty())
	{
		if (temp.top().idtype == IT::IDTYPE::L && temp.top().iddatatype == IT::IDDATATYPE::STR) {
			if (execute(fstLENGHT))  // mov edi,offset L0
				str = str + "mov edi,offset " + temp.top().id + "\n";
			else
			str = str + "push offset " + temp.top().id + "\n";
			
		}
		else str = str + "push " + temp.top().id + "\n";
		temp.pop();
	}
	
	str = str + "call " + string(e.id) + IN_CODE_ENDL;

	return str;
}

string createEqual(LT::LexTable& lextable, IT::IdTable& idtable, int i)
{
	string str;
	IT::Entry e1 = ITENTRY(i-1); // левый операнд

	switch (e1.iddatatype)
	{
	case IT::IDDATATYPE::INT:
	case IT::IDDATATYPE::BOOL:
	{
		bool first = true;
	 for (int j = i + 1; LEXEMA(j) != LEX_SEMICOLON; j++)
		{
			switch (LEXEMA(j))
			{
			case LEX_LITERAL:
			case LEX_ID:
			case LEX_FUNCTION:
			{
				if (ITENTRY(j).idtype == IT::IDTYPE::F) // если в выражении вызов функции
				{
					str = str + CallFunction(lextable, idtable, j); 
					str = str + "push eax\n"; 
					while (LEXEMA(j) != '@') j++; 
					break;
				}
				else str = str + "push " + ITENTRY(j).id + "\n";
				break;
			}
			
			case LEX_PLUS:
				str = str + "pop ebx\npop eax\nadd eax, ebx\npush eax\n"; break;
			case LEX_MINUS:
				str = str + "pop ebx\npop eax\nsub eax, ebx\npush eax\n"; break;
			case LEX_STAR:
				str = str + "pop ebx\npop eax\nimul eax, ebx\npush eax\n"; break;
			case LEX_DIRSLASH:
				str = str + DEL + ITENTRY(j - 1).id + "\njz error\n" + "pop ebx\npop eax\ncdq\nidiv ebx\npush eax\n"; break;
			case LEX_MOD:
				str = str + "pop ebx \nmov edx, 0 \npop eax \nidiv ebx \npush edx \nmov eax, edx\n"; break;
			}
		} 

		str = str + "\npop ebx\nmov " + e1.id + ", ebx\n";
		break;
	}
	case IT::IDDATATYPE::STR:
	{
		char lex = LEXEMA(i + 1);
		IT::Entry e2 = ITENTRY(i + 1);
		if (e2.idtype == IT::IDTYPE::F ) 
		{
			str = str + CallFunction(lextable, idtable, i+1);
			str = str + "push eax\n";
			str = str + "\npop ebx\nmov " + e1.id + ", ebx\n";
			break;
		}
	
		else if (lex == LEX_LITERAL)
			str = str + "mov " + e1.id + ", offset " + e2.id;
		else// идентификатор (переменная)
			str = str + "mov ecx, " + e2.id + "\nmov " + e1.id + ", ecx";
	}
	}

	return str;
}

string createFunction(LT::LexTable& lextable, IT::IdTable& idtable, int i, string funcname)
{
	string str;
	IT::Entry e = ITENTRY(i + 1);
	IT::IDDATATYPE type = e.iddatatype;

	str = SEPSTR(funcname) + string(e.id) + string(" PROC,\n\t");
	int j = i + 3;// первый параметр после (
	while (LEXEMA(j) != LEX_RIGHTHESIS) // пока параметры не кончатся
	{
		if (LEXEMA(j) == LEX_ID)// параметр
			str = str + string(ITENTRY(j).id) + (ITENTRY(j).iddatatype == IT::IDDATATYPE::INT ? " : sdword, " : " : dword, ");
		j++;
	}

	str += "\n; ---------------------\npush ebx\npush edx\n; -------------------------------";

	return str;
}

string createReturn(LT::LexTable& lextable, IT::IdTable& idtable, int i, string funcname)
{
	string str = "; ------------------\npop edx\npop ebx\n; -------------------------------\n";
	if (LEXEMA(i + 1) != LEX_SEMICOLON)
		str = str + "mov eax, " + string(ITENTRY(i + 1).id) + "\n";
	str += "ret\n";
	str += funcname + " ENDP" + SEPSTREMP;
	return str;
}

string transit;
string createCondition(LT::LexTable& lextable, IT::IdTable& idtable,int i)
{
	string str;
	string leftt_str, right_str;
	
	IT::Entry rgt;
	IT::Entry lft = ITENTRY(i + 2); // левый операнд
	if (ITENTRY(i + 2).iddatatype == IT::BOOL) {
		
		str = str + "mov edx, " + lft.id + "\ncmp edx, 1 " + "\n";
		str = str + "\n" + "jz" + " right" + itoS(conditOmount);
		str = str + "\n" + "jnz" + " wrong" + itoS(conditOmount);
		return str;
	}
	if (lextable.table[i+4].idxTI != LT_TI_NULLIDX) // правый операнд для ><
	 rgt = ITENTRY(i + 4);
	else
		rgt = ITENTRY(i + 5); // правый операнд для >= <=
	
	str = str + "mov edx, " + lft.id + "\ncmp edx, " + rgt.id + "\n";

	switch (LEXEMA(i + 3))
	{
	case LEX_MORE: {
		right_str = "jg"; leftt_str = "jl"; break;
		if (LEXEMA(i + 4) == '=')
		{
			right_str = "jge"; leftt_str = "jle"; break;
		}
	} 
	case LEX_LESS: {
		right_str = "jl"; leftt_str = "jg"; break;
		if(LEXEMA(i + 4)=='=')
		{
			right_str = "jle"; leftt_str = "jge"; break;
		}	
	} 
	case LEX_EQUALS: right_str = "jz"; leftt_str = "jnz"; break;
	case LEX_NOTEQUALS: right_str = "jnz"; leftt_str = "jz"; break;
	}
	str = str + "\n" + right_str + " right" + itoS(conditOmount);
	if (LEXEMA(i) == LEX_WHILE)
	{
	
		transit = str;
	}
	str = str + "\n" + leftt_str + " wrong" + itoS(conditOmount);
	
	return str;
}

	vector <string> createDataConst(IT::IdTable& idtable)	
	{
		vector <string> v;
		v.push_back(BEGIN);
		v.push_back(EXTERN);

		vector <string> cnct; 
		cnct.push_back(CONST);
		vector <string> data; ;
		data.push_back(DATA);

		for (int i = 0; i < idtable.size; i++)// const, data
		{
			IT::Entry e = idtable.table[i];
			string str = "\t\t" + string(e.id);

			if (idtable.table[i].idtype == IT::IDTYPE::L)// литерал - в .const
			{
				switch (e.iddatatype)
				{
				case IT::IDDATATYPE::STR: str = str + " byte '" + string(idtable.table[i].value.vstr->str) + "', 0"; break;
				case IT::IDDATATYPE::INT: str = str + " sdword " + itoS(e.value.vint); break;
				case IT::IDDATATYPE::BOOL: str = str + " sdword " + itoS(e.value.vbool); break;
				}
				cnct.push_back(str);
			}
			else if (idtable.table[i].idtype == IT::IDTYPE::V)// переменная - в .data
			{
				switch (e.iddatatype)
				{
				case IT::IDDATATYPE::INT: str = str + " sdword 0"; break;
				case IT::IDDATATYPE::STR: str = str + " dword ?"; break;
				case IT::IDDATATYPE::BOOL: str = str + " sdword 0"; break;
				}
				data.push_back(str);
			}
		}

		v.insert(v.end(), cnct.begin(), cnct.end());// заполнение в вектор
		v.insert(v.end(), data.begin(), data.end());
		v.push_back(CODE);
		v.push_back(FUNC_LENGHT);
		return v;
	}

	void CodeGeneration(LT::LexTable& lextable, IT::IdTable& idtable)
	{
		vector <string> v = createDataConst(idtable);
		ofstream ofile("..\\astmbler\\asm.asm");
		string funcname;// имя текущей функции
		string str;
		bool main=false;
		int amount_cond = 0;
		stack<string> cond_wrong;
		bool whle = false;

		for (int i = 0; i < lextable.size; i++)
		{
			switch (LEXEMA(i))
			{
			case LEX_MAIN:
			{
				str = str + SEPSTR("MAIN") + "main PROC";
				main = true;
				break;
			}
			case LEX_FUNCTION:// вызов функции и передача параметров 
			{
				if (lextable.table[i].idxTI == -1) {
					funcname = ITENTRY(i + 1).id; /////// lextable.table[i].idxTI==-1
					str = createFunction(lextable, idtable, i, funcname);
				}
				else {
					str = CallFunction(lextable, idtable, i);
				}
				break;
				
			}
			case LEX_RETURN:
			{
				//if(LEXEMA(i + 1) != LEX_LITERAL)
				if(!main)
				str = createReturn(lextable, idtable, i, funcname);
				break;
			}
			case LEX_ID:// вызов функции 
			{
				if (LEXEMA(i + 1) == LEX_LEFTHESIS && LEXEMA(i - 1) != LEX_FUNCTION)
					str = CallFunction(lextable, idtable, i);
				break;
			}
			case LEX_RIGHTBRACE: {
				if (condition|| amount_cond !=0) {
					str = str + "\nmov eax, 1 ";
					str = str + "\njz osn" +itoS(conditOmount);
					if(LEXEMA(i+1)==LEX_ELSE)
					needCont = true;
					else {
						
						//if (whle) {
						//	//str = "\n" + transit + "\n"+ "wrong" + itoS(conditOmount) + ":";;
						//	str =  + cond_wrong.top() + ":";
						//	whle = false;
						//	amount_cond--;
						//	cond_wrong.pop();
						//
						//}
						//else {
							//str = "wrong" + itoS(conditOmount) + ":";
							amount_cond--;
							str = cond_wrong.top() + ":";
							cond_wrong.pop();
						//}
						
						
					}
				}
				else {
					if(needCont){
						str = str + "\nosn" + itoS(conditOmount) + ":";
						needCont=false;
					}
					
				}
				condition = false;
				break;
			}
			case LEX_WHILE:
			{
				conditOmount++;
				transit = "";
				str = createCondition(lextable, idtable, i);
				//cond_wrong.push("\n" + transit + "\n" +"wqqqqqqqqqqrong" + itoS(conditOmount));
				condition = true;
				whle = true;
				break;
			}
			case LEX_CONDITION: 
			{
				conditOmount++;
				str = createCondition(lextable, idtable, i);
				condition = true;
				break;
			}
			case LEX_LEFTBRACE:
			{
				if (condition) {
					
					if (whle) {
						cond_wrong.push("\n" + transit + "\n" + "wrong" + itoS(conditOmount));
						whle = false;
					}
					else {
						cond_wrong.push("wrong" + itoS(conditOmount));
					}
					
					str = str + "\nright" + itoS(conditOmount) + ":";
					amount_cond++;
				}
				break;
			}
			case LEX_ELSE: {
				//str = str + "\nwrong" + itoS(conditOmount) + ":";
				amount_cond--;
				str = cond_wrong.top() + ":";
				cond_wrong.pop();
				break;
			}
			case '=':
			{
				if (LEXEMA(i + 1) != '=' && LEXEMA(i - 1) != '=' && LEXEMA(i - 1) != '<' && LEXEMA(i - 1) != '>' && LEXEMA(i - 1) != '!') {
					str = createEqual(lextable, idtable, i);
					while (LEXEMA(++i) != LEX_SEMICOLON);
				}
				break;
			}
			case LEX_NEWLINE:
			{
				str = str + "push offset newline\ncall outstr\n";
				break;
			}
			case LEX_PRINT:
			{
				IT::Entry e = ITENTRY(i + 1);
				switch (e.iddatatype)
				{
				case IT::IDDATATYPE::INT:
				case IT::IDDATATYPE::BOOL:
					str = str + "\npush " + e.id + "\ncall outnum\n";
					break;
				case IT::IDDATATYPE::STR:
					if (e.idtype == IT::IDTYPE::L) str = str + "\npush offset " + e.id + "\ncall outstr\n";
					else str = str + "\npush " + e.id + "\ncall outstr\n";
					break;
				}
				break;
			}
			

			}
			if (!str.empty() && lextable.table[i].lexema!=' ')
				v.push_back(str);
			str.clear();
		}

		v.push_back(END);
		for (auto x : v)
			ofile << x << endl;
		ofile.close();
	};
}