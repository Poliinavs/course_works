#include "stdafx.h"
#include <stack>
#include <locale>
#include <cwchar>
#include <fstream>
#include <iostream>
#include <string.h> 
#include <stack>

using namespace std;
string scope = "";
int mainAmount = 0;
int amountLiteral = 0;
bool compare = false;
string scopeBuf = "";
bool flag = false;
bool inicial = false;
int brace = 0;

void LexAnalize(In::IN in, // входной поток
	LT::LexTable& lextable, // таблица лексем
	IT::IdTable& idtable) {
	In::IN letters;
	int numbLine = 1;

	string word = "";
	vector<string> words;

	for (int i = 0; i <= strlen((char*)in.text); i++)
	{
		string str = "";
		
			
		for (int m = 0; m < 5; m++) {
			if (in.text[i] == '\'' && in.text[i - 1] != '=') {
				i++;
				if (words[words.size() - 2] == "if" ||words[words.size() - 4] == "if") {
					throw ERROR_THROW(318);
				}
				while (in.text[i] != '\'') {
					word += in.text[i];
					i++;
				}
				
				words.push_back("'");
				words.push_back(word);
				search(word, lextable, idtable, numbLine, words);
				word = "";
				i++;
			}
			if (letters.code[(int)in.text[i]] == In::IN::S || in.text[i] == '\n') {//для добавления слов
				if (word != "" && word != "}") {

					words.push_back(word);
					search(word, lextable, idtable, numbLine, words);
					word = "";
				}
				if (in.text[i] != ' ' && in.text[i] != '!' && in.text[i] != '>' && in.text[i] != '<') { //для добавления пунктуации
					word = in.text[i];
					words.push_back(word);
					search(word, lextable, idtable, numbLine, words);
					word = "";
				}
				if ((in.text[i] == ',' || in.text[i] == '=') && (in.text[i + 1] == ' ') || in.text[i + 1] == '\n') {//для () функций тк после запятой пробелили \n
					i++;
					if (in.text[i + 1] == '\n')
						numbLine += 1;
				}

				if (in.text[i] == '\n') {
					numbLine += 1;
				}
				//////////////////////////////////////////////////////////////////////////////////////////////// 
				if (in.text[i] == '=' && in.text[i + 1] == '=') {//значит == для if
					word += "==";
					words.pop_back();
					words.push_back(word);
					search(word, lextable, idtable, numbLine, words);
					word = "";

					i += 2;///может еще ++.......................................
					break;
				}
				if (in.text[i] == '!' && in.text[i + 1] == '=') {//значит != для if
					word += "!=";
					words.push_back(word);
					search(word, lextable, idtable, numbLine, words);
					word = "";
					i += 2;///может еще ++.......................................
					break;
				}
				////////////////////////////////////////////////////////
				if (in.text[i] == '>') {//значит > || >= для if

					if (in.text[i + 1] == '=') {
						word += ">=";
						i += 2;
					}
					else { //значит просто >
						word += ">";
						i += 1;
					}
					words.push_back(word);
					search(word, lextable, idtable, numbLine, words);
					word = "";
					break;
				}
				if (in.text[i] == '<') {//значит > || >= для if

					if (in.text[i + 1] == '=') {
						word += "<=";
						i += 2;
					}
					else { //значит просто >
						word += "<";
						i += 1;
					}

					words.push_back(word);
					search(word, lextable, idtable, numbLine, words);
					word = "";
					break;
				}

				//////////////////////////////////////////////////////////////////////////////////////////////// 
				i++;
				if (words.back() == "=") {
					word = "";

					while (in.text[i] != ';') {
						if(in.text[i] =='\n')
							throw ERROR_THROW(2);
						word += in.text[i];
						i++;
					}
					words.push_back(word);
					search(word, lextable, idtable, numbLine, words);
					word = "";

					break;
				}
			}
		}
		if (in.text[i] == '.') {
			if(in.text[i+1] != '.')
				throw ERROR_THROW(319);
			while (in.text[i] != '\n')
				i++;
			//i++;
			continue;
		}
		word += in.text[i];
		compare = false;
	}
	if (word.size() != 1)
		throw ERROR_THROW(2);
	if (brace != 0)
		throw ERROR_THROW(613);
	if(mainAmount==0)
		throw ERROR_THROW(301);
	if (mainAmount != 1)
		throw ERROR_THROW(300);
}

void search(
	std::string word,
	LT::LexTable& lextable,
	IT::IdTable& idtable,
	int nLine,
	vector<string> words
) {
	LT::Entry lex;
	IT::Entry idn;

	if (word == ">=")
	{
		lex.lexema = LEX_MORE;
		lex.sn = nLine;
		lex.idxTI = LT_TI_NULLIDX;
		LT::Add(lextable, lex);
		lex.lexema = LEX_EQUALS;
		LT::Add(lextable, lex);
		return;
	}
	if (word == "<=")
	{
		lex.lexema = LEX_LESS;
		lex.sn = nLine;
		lex.idxTI = LT_TI_NULLIDX;
		LT::Add(lextable, lex);
		lex.lexema = LEX_EQUALS;
		LT::Add(lextable, lex);
		return;
	}
	if (word == "<")
	{
		lex.lexema = LEX_LESS;
		lex.sn = nLine;
		lex.idxTI = LT_TI_NULLIDX;
		LT::Add(lextable, lex);
		return;
	}
	if (word == ">")
	{
		lex.lexema = LEX_MORE;
		lex.sn = nLine;
		lex.idxTI = LT_TI_NULLIDX;
		LT::Add(lextable, lex);
		return;
	}
	if (word == "==")
	{
		lex.lexema = LEX_EQUALS;
		lex.sn = nLine;
		lex.idxTI = LT_TI_NULLIDX;
		LT::Add(lextable, lex);
		lex.lexema = LEX_EQUALS;
		lex.sn = nLine;
		lex.idxTI = LT_TI_NULLIDX;
		LT::Add(lextable, lex);
		return;
	}
	if (word == "!=")
	{
		lex.lexema = LEX_NOTEQUALS;
		lex.sn = nLine;
		lex.idxTI = LT_TI_NULLIDX;
		LT::Add(lextable, lex);
		lex.lexema = LEX_EQUALS;
		LT::Add(lextable, lex);
		return;
	}
		char* cstr = new char[word.length() + 1];
		strcpy(cstr, word.c_str());
		//string s[2] = { "IF"," ELSE" };
		FST::FST fstIF(cstr, IF);
		if (execute(fstIF))
		{
			lex.lexema = LEX_CONDITION;
			lex.sn = nLine;
			lex.idxTI = LT_TI_NULLIDX;
			LT::Add(lextable, lex);
			return;
		}
		FST::FST fstBOOL(cstr, BOL);
		if (execute(fstBOOL))
		{
			lex.lexema = LEX_BOOL;
			lex.sn = nLine;
			lex.idxTI = LT_TI_NULLIDX;
			LT::Add(lextable, lex);
			return;
		}
		
		FST::FST fstWHILE(cstr, WHILE);
		if (execute(fstWHILE))
		{
			lex.lexema = LEX_WHILE;
			lex.sn = nLine;
			lex.idxTI = LT_TI_NULLIDX;
			LT::Add(lextable, lex);
			return;
		}
		FST::FST fstNEWLINE(cstr, NEWLINE);
		if (execute(fstNEWLINE))
		{
			lex.lexema = LEX_NEWLINE;
			lex.sn = nLine;
			lex.idxTI = LT_TI_NULLIDX;
			LT::Add(lextable, lex);
			return;
		}
		FST::FST fstNUMBER(cstr, NUMBER);
		if (execute(fstNUMBER))
		{
			lex.lexema = LEX_NUMBER;
			lex.sn = nLine;
			lex.idxTI = LT_TI_NULLIDX;
			LT::Add(lextable, lex);
			return;
		}

		FST::FST fstLINE(cstr, LINE);
		if (execute(fstLINE))
		{
			lex.lexema = LEX_LINE;
			lex.sn = nLine;
			lex.idxTI = LT_TI_NULLIDX;
			LT::Add(lextable, lex);
			return;
		}
		FST::FST fstFUNCTION(cstr, FUNCTION);
		if (execute(fstFUNCTION))
		{
			lex.lexema = LEX_FUNCTION;
			lex.sn = nLine;
			lex.idxTI = LT_TI_NULLIDX;
			LT::Add(lextable, lex);
			return;

		}
		FST::FST fstNEW(cstr, NEW);
		if (execute(fstNEW)) {
			lex.lexema = LEX_NEW;
			lex.sn = nLine;
			lex.idxTI = LT_TI_NULLIDX;
			LT::Add(lextable, lex);
			return;
		}
		FST::FST fstMAIN(cstr, MAIN);
		if (execute(fstMAIN))
		{
			lex.lexema = LEX_MAIN;
			lex.sn = nLine;
			lex.idxTI = LT_TI_NULLIDX;
			scope = "mn"+'_';
			scopeBuf = "mn" + '_';
			LT::Add(lextable, lex);
			mainAmount++;
			return;
		}
		FST::FST fstPRINT(cstr, PRINT);
		if (execute(fstPRINT))
		{
			lex.lexema = LEX_PRINT;
			lex.sn = nLine;
			lex.idxTI = LT_TI_NULLIDX;
			LT::Add(lextable, lex);
			return;
		}
		FST::FST fstRETURN(cstr, RETURN);
		if (execute(fstRETURN))
		{
			lex.lexema = LEX_RETURN;
			lex.sn = nLine;
			lex.idxTI = LT_TI_NULLIDX;
			LT::Add(lextable, lex);
			return;
		}
		FST::FST fstELSE(cstr, ELSE);
		if (execute(fstELSE))
		{
			lex.lexema = LEX_ELSE;
			lex.sn = nLine;
			lex.idxTI = LT_TI_NULLIDX;
			LT::Add(lextable, lex);
			return;
		}
	if (word == ";")
	{
		lex.lexema = LEX_SEMICOLON;
		lex.sn = nLine;
		lex.idxTI = LT_TI_NULLIDX;
		LT::Add(lextable, lex);
		return;
	}
	if (word == ",")
	{
		lex.lexema = LEX_COMMA;
		lex.sn = nLine;
		lex.idxTI = LT_TI_NULLIDX;
		LT::Add(lextable, lex);
		return;
	}
	if (word == "{")
	{
		lex.lexema = LEX_LEFTBRACE;
		lex.sn = nLine;
		lex.idxTI = LT_TI_NULLIDX;
		LT::Add(lextable, lex);
		brace++;
		return;
	}
	if (word == "}")
	{
		lex.lexema = LEX_RIGHTBRACE;
		lex.sn = nLine;
		lex.idxTI = LT_TI_NULLIDX;
		LT::Add(lextable, lex);
		brace--;
	 flag = false;
	 return;
	}
	if (word == "(")
	{
		lex.lexema = LEX_LEFTHESIS;
		lex.sn = nLine;
		lex.idxTI = LT_TI_NULLIDX;
		LT::Add(lextable, lex);
		return;
	}
	if (word == ")")
	{
		lex.lexema = LEX_RIGHTHESIS;
		lex.sn = nLine;
		lex.idxTI = LT_TI_NULLIDX;
		LT::Add(lextable, lex);

		if (scopeBuf != scope)
			scope = scopeBuf + '_';
		return;
	}
	if (word == "+")
	{
		lex.lexema = LEX_PLUS;
		lex.sn = nLine;
		lex.idxTI = LT_TI_NULLIDX;
		LT::Add(lextable, lex);
		return;
	}
	if (word == "-")
	{
		lex.lexema = LEX_MINUS;
		lex.sn = nLine;
		lex.idxTI = LT_TI_NULLIDX;
		LT::Add(lextable, lex);
		return;
	}
	if (word == "%")
	{
		lex.lexema = LEX_MOD;
		lex.sn = nLine;
		lex.idxTI = LT_TI_NULLIDX;
		LT::Add(lextable, lex);
		return;
	}
	if (word == "*")
	{
		lex.lexema = LEX_STAR;
		lex.sn = nLine;
		lex.idxTI = LT_TI_NULLIDX;
		LT::Add(lextable, lex);
		return;
	}
	if (word == "/")
	{
		lex.lexema = LEX_DIRSLASH;
		lex.sn = nLine;
		lex.idxTI = LT_TI_NULLIDX;
		LT::Add(lextable, lex);
		return;
	}
	int SizeW = words.size();
	if (SizeW >= 3) {//для заполнен табл индентиф
		
		if (words[SizeW - 2] != "=" && (word == "true" || word == "false")) {
			getLex(lex, idn, nLine, words, word);
			lex.idxTI = idtable.size;
			lex.sn = nLine;
			LT::Add(lextable, lex);
			idn.idxfirstLE = lextable.size;
			IT::Add(idtable, idn);
			flag = true;
			return;
		}
		if (words[SizeW - 3] == "if" || words[SizeW - 3] == "while") { //if(x==b) для x ЛЮБОЙ ОПЕРАТОР ГЛАВНОЕ ПОСЛЕ if
			char* id = new char[ID_MAXSIZE];
			getid(1, id, words, 0);
			int index1 = IT::IsId(idtable, id);
			if (index1 != TI_NULLIDX) {
				lex.idxTI = index1; //
				lex.lexema = LEX_ID;
				lex.sn = nLine;
				LT::Add(lextable, lex);
			}
			else {
				getLex(lex, idn, nLine, words, word);
				lex.idxTI = idtable.size;
				lex.sn = nLine;
				LT::Add(lextable, lex);
				idn.idxfirstLE = lextable.size;
				IT::Add(idtable, idn);
			}
			return;
		}
		if (words.size() >= 5 &&( words[SizeW - 5] == "if"|| words[SizeW - 5] == "while")&& !(flag)) { //if(x==b) для b////////////////////////////////////
			char* id = new char[ID_MAXSIZE];
			getid(1, id, words, 0);
			int index1 = IT::IsId(idtable, id);
			lex.idxTI = index1;
			if (index1 != TI_NULLIDX) {
				lex.idxTI = index1; //
				lex.lexema = LEX_ID;
				lex.sn = nLine;
				LT::Add(lextable, lex);
			}
			else {
				getLex(lex, idn, nLine, words, word);
				lex.idxTI = idtable.size;
				lex.sn = nLine;
				LT::Add(lextable, lex);
				idn.idxfirstLE = lextable.size;
				IT::Add(idtable, idn);
			}
			return;
		}
		if (words[SizeW - 2] == "return") { //return z; return 0;для z или 0
			bool numb = false;
			for (int i = 0; i < word.size(); i++) {
				if ((int)word[i] < 47 || (int)word[i] > 58)
					numb = false;
				else {
					numb = true;
					break;
				}
			}
			if (numb) {
				getLex(lex, idn, nLine, words, word);
				idn.idxfirstLE = lextable.size;
				lex.idxTI = idtable.size;
				IT::Add(idtable, idn);
			}
			else {
				lex.lexema = LEX_ID;
				getName(idn, scope, word);
				int index1 = IT::IsId(idtable, idn.id);
				lex.idxTI = index1;
			}
			lex.sn = nLine;
			LT::Add(lextable, lex);
			return;
		}
		if ((words[SizeW - 2] == "print" || words[SizeW - 3] == "print") && word != ";") { //print z; return 0;для z или 0 //////////////////////////////////////////////////////////////////////////////
			if (word.size() > 8) {
				words.back() = word.substr(0, 8);
			}
			char* id = new char[ID_MAXSIZE];
			getid(1, id, words, 0);
			int index1 = IT::IsId(idtable, id);
			if (index1 != TI_NULLIDX) { //значит print x но может и lenght
				lex.idxTI = index1;
				lex.lexema = LEX_ID;
			}
			else {
				getLex(lex, idn, nLine, words, word);
				lex.idxTI = idtable.size;
				idn.idxfirstLE = lextable.size;
				IT::Add(idtable, idn);
			}
			lex.sn = nLine;
			LT::Add(lextable, lex);
			return;
		}
		if (words[SizeW - 3] == "number" && words[SizeW - 2] == "function") { //number function fi добавл в табл  fi
			idn.iddatatype = IT::INT;
			idn.idtype = IT::F;
			idn.idxfirstLE = lextable.size;

			lex.idxTI = idtable.size;
			lex.lexema = LEX_ID;
			lex.sn = nLine;
			idn.value.vint = 0;

			if (words.back().size() > 8) {
				words.back() = words.back().substr(0, 8);
			}
			string id2 = words.back();
			strcpy(idn.id, id2.c_str());
			idn.id[id2.size()] = '\0';
			
			if (words.size() >= 4 && words[SizeW - 4] == "new") {
				scopeBuf = scope + '_';
			}
			else {
				scopeBuf = words.back() + '_';
			}
			scope = words.back() + '_'; //чтобы найти от какой функции
			LT::Add(lextable, lex);
			IT::Add(idtable, idn);
			return;
		}
		if (words[SizeW - 3] == "line" && words[SizeW - 2] == "function") { //line function fx добавл в табл  fx
			idn.iddatatype = IT::STR;
			idn.idtype = IT::F;
			idn.idxfirstLE = lextable.size;

			lex.idxTI = idtable.size;
			lex.lexema = LEX_ID;
			lex.sn = nLine;

			if (words.back().size() + 1 > ID_MAXSIZE)
				throw ERROR_THROW(203);

			for (int i = 0; i < words.back().size(); i++) {
				idn.id[i] = words.back()[i];
			}
			idn.id[words.back().size()] = '\0';
			strcpy(idn.value.vstr->str, "");
			if (words.size() >= 4 && words[SizeW - 4] == "new") {
				scopeBuf = scope + '_';
			}
			else {
				scopeBuf = words.back() + '_';
			}
			scope = words.back() + '_'; //чтобы найти от какой функции
			LT::Add(lextable, lex);
			IT::Add(idtable, idn);
			return;
		}
		int m;

		if (
			(words[SizeW - 2] == "line" || words[SizeW - 2] == "number") //(integer x, integer y) для x/y
			&&
			(words[SizeW - 3] == "(" || words[SizeW - 3] == ",")
			)
		{
			idn.iddatatype = (words[SizeW - 2] == "line" ? IT::STR : IT::INT);
			idn.idtype = IT::P;
			idn.idxfirstLE = lextable.size;

			lex.idxTI = idtable.size;
			lex.lexema = LEX_ID;
			lex.sn = nLine;
			if (words.back().size() + 1 + scope.size() > ID_MAXSIZE)//название фукции + сам id+ \0
				throw ERROR_THROW(203);

			for (int i = 0; i < scope.size(); i++) {
				idn.id[i] = scope[i];
			}
			m = 0;
			for (int i = scope.size(); i < words.back().size() + scope.size(); i++) {
				idn.id[i] = words.back()[m];
				m++;
			}
			idn.id[words.back().size() + scope.size()] = '\0';
			if (idn.iddatatype == IT::INT)
			{
				idn.value.vint = 0;
			}
			else
			{
				strcpy(idn.value.vstr->str, "");
			}

			LT::Add(lextable, lex);
			IT::Add(idtable, idn);
			return;
		}
		if (words.back() != ")"
			&&
			words.back() != ","
			&&
			(compare) //compare(x,y) lenght(x)
			&&
			(words[SizeW - 2] == "(" || words[SizeW - 2] == ",")
			)
		{
			idn.iddatatype = (words[SizeW - 2] == "line" ? IT::STR : IT::INT);
			idn.idtype = IT::P;
			idn.idxfirstLE = lextable.size;

			lex.idxTI = idtable.size;
			lex.lexema = LEX_ID;
			lex.sn = nLine;
			if (words.back().size() + 1 + scope.size() > ID_MAXSIZE)//название фукции + сам id+ \0
				throw ERROR_THROW(203);

			for (int i = 0; i < scope.size(); i++) {
				idn.id[i] = scope[i];
			}
			m = 0;
			for (int i = scope.size(); i < words.back().size() + scope.size(); i++) {
				idn.id[i] = words.back()[m];
				m++;
			}
			idn.id[words.back().size() + scope.size()] = '\0';
			if (idn.iddatatype == IT::INT)
			{
				idn.value.vint = 0;
			}
			else
			{
				strcpy(idn.value.vstr->str, "");
			}

			LT::Add(lextable, lex);
			IT::Add(idtable, idn);
			return;
		}
		if (words[SizeW - 3] == "new" && words[SizeW - 2] == "line" && scope == scopeBuf && word != "function") { //  new line z; для z
			idn.iddatatype = IT::STR;
			idn.idtype = IT::V;
			idn.idxfirstLE = lextable.size;

			lex.idxTI = idtable.size;
			lex.lexema = LEX_ID;
			lex.sn = nLine;
			getName(idn, scope, word);
			strcpy_s(idn.value.vstr->str, "");

			LT::Add(lextable, lex);
			IT::Add(idtable, idn);
			return;
		}

		if (words[SizeW - 3] == "new" && words[SizeW - 2] == "bool" && scope == scopeBuf && word != "function") { //  new number z; для z
			idn.iddatatype = IT::BOOL;
			idn.idtype = IT::V;
			idn.idxfirstLE = lextable.size;

			lex.idxTI = idtable.size;
			lex.lexema = LEX_ID;
			lex.sn = nLine;

			idn.value.vbool =0;

			getName(idn, scope, word);
			LT::Add(lextable, lex);
			IT::Add(idtable, idn);
			return;
		}


		if (words[SizeW - 3] == "new" && words[SizeW - 2] == "number" && scope == scopeBuf && word != "function") { //  new number z; для z
			idn.iddatatype = IT::INT;
			idn.idtype = IT::V;
			idn.idxfirstLE = lextable.size;

			lex.idxTI = idtable.size;
			lex.lexema = LEX_ID;
			lex.sn = nLine;

			idn.value.vint = 0;

			getName(idn, scope, word);
			LT::Add(lextable, lex);
			IT::Add(idtable, idn);
			return;
		}
	
		if (words[SizeW - 2] == "=" && !compare) { //для инициал перменных x = '1234';
			char* id = new char[ID_MAXSIZE]; //получаем id переменной
			getid(3, id, words, 0);
			int index1 = IT::IsId(idtable, id);
		
			lex.idxTI = index1; //общий вид i=
			lex.lexema = LEX_ID;
			lex.sn = nLine;
			if (words[SizeW - 5] != "new")
				LT::Add(lextable, lex);
			lex.idxTI = -1;
			lex.lexema = '=';
			lex.sn = nLine;
			LT::Add(lextable, lex);

			if (word[0] == '\'') { //значит строка
				if (word.size() > TI_STR_MAXSIZE)
					throw ERROR_THROW(204);
				char* newSTR = new char[TI_STR_MAXSIZE];

				for (int i = 0; i < word.size() - 2; i++)
					newSTR[i] = word[i + 1];

				newSTR[word.size() - 2] = '\0';
				getLex(lex, idn, nLine, words, word);
				idn.idxfirstLE = lextable.size;
				lex.idxTI = idtable.size;
				LT::Add(lextable, lex);
				IT::Add(idtable, idn);
			}
			else { //здесь и цифры и функции. Если цифр isNumb=true
				if (word[0] == '-' || word[0] == '+') {
					throw ERROR_THROW(311);
				}
				int finction = true;
				///////////////////////////////////
			//INTEGER_LITERAL
			char* cstr = new char[word.length() + 1];
			strcpy(cstr, word.c_str());
			FST::FST fstINTEGER(cstr, INTEGER_LITERAL);
			
		if (execute(fstINTEGER))//=5
		{
			if (word[0] == '0' && word.size() != 1) {
				throw ERROR_THROW(310);
			}
			getLex(lex, idn, nLine, words, word);
			lex.idxTI = idtable.size;
			LT::Add(lextable, lex);
			idn.idxfirstLE = lextable.size;
			IT::Add(idtable, idn);
			finction =false;
		}
		FST::FST fstBINARY(cstr, BINARY_LITERAL);
		if (execute(fstBINARY)) //=d1010
		{
			word.erase(word.begin());
			int result = 0;
			for (int i = 0; i < word.size();i++) {
				result <<= 1;
				result += word[i] - '0';
			};
			
			getLex(lex, idn, nLine, words, to_string(result));
			lex.idxTI = idtable.size;
			LT::Add(lextable, lex);
			idn.idxfirstLE = lextable.size;
			IT::Add(idtable, idn);
			finction = false;
		}
		if (word == "true" || word == "false") {

			getLex(lex, idn, nLine, words, word);
			lex.idxTI = idtable.size;
			LT::Add(lextable, lex);
			idn.idxfirstLE = lextable.size;
			IT::Add(idtable, idn);
			finction = false;
		}
		////////
				if(finction) {//функц z= x*(x+y);
					bool lenght = false;
					string inf = "";
					string simv = "";
					In::IN letters;
					for (int k = 0; k < word.size(); k++) {
						if (letters.code[(int)word[k]] == In::IN::S) { //значит символ
							simv = word[k];
							words.push_back(simv);
							search(simv, lextable, idtable, nLine, words); //добавляем
							inf = "";
						}
						else { //значит символ выводим строку
							inf += word[k];
							char* id1 = new char[TI_STR_MAXSIZE];
							if (((letters.code[(int)word[k + 1]] == In::IN::S) || ((k == word.size() - 1) && inf != ""))) { //след символ значит надо выводить

								char* cstr = new char[inf.length() + 1];
								strcpy(cstr, inf.c_str());
								FST::FST fstINTEGER(cstr, INTEGER_LITERAL);
								FST::FST fstLITERAL(cstr, STRING_LITERAL);
								if (execute(fstINTEGER)|| execute(fstLITERAL))
								{
									if (inf[0] == '0' && inf.size() != 1) {
										throw ERROR_THROW(118);
									}
									getLex(lex, idn, nLine, words, inf);
									lex.idxTI = idtable.size;
									LT::Add(lextable, lex);
									idn.idxfirstLE = lextable.size;
									IT::Add(idtable, idn);
									inf = "";
									continue;
								}
								
								if (inf == "lenght"|| inf == "compare" || inf == "concat" ||inf == "npow") {

									lex.lexema = LEX_FUNCTION;
									lex.sn = nLine; 
									lex.idxTI = idtable.size;
									LT::Add(lextable, lex);
									compare = true;
									if(inf=="concat")
										idn.iddatatype = IT::STR;
									else {
										idn.iddatatype = IT::INT;
									}
									
									idn.idtype = IT::F;
									idn.idxfirstLE = lextable.size;
									idn.value.vint = 0;

									strcpy(idn.id, inf.c_str());
									idn.id[words.back().size()] = '\0';
									IT::Add(idtable, idn);
								}
								if (inf != "lenght" && inf != "compare" && inf != "concat" && inf != "npow") {
									
									strncpy(id1, inf.c_str(), 8);
									//strcpy(id1, inf.c_str()); //для функций
									id1[8] = '\0';
									getName(idn, scope, inf);
									if (inf != "") {
										int index = 0;
										if (IT::IsId(idtable, idn.id) != TI_NULLIDX) {
											index = IT::IsId(idtable, idn.id);
											lex.lexema = LEX_ID;
											lex.idxTI = index; 
										}
										else {//функции и литералы
											index = IT::IsId(idtable, id1);
											if (index != TI_NULLIDX) {
												lex.lexema = LEX_ID;
												lex.idxTI = index;
											}
											else {
												getLex(lex, idn, nLine, words, word);
												lex.idxTI = idtable.size - 1;
												idn.idxfirstLE = lextable.size;
												IT::Add(idtable, idn);
											}
										}
										lex.sn = nLine;
										LT::Add(lextable, lex);
									}
								}
							}
						}
					}
				}
			}
			return;
		}
	
	}
	//if (word != ""&& word != "=" && word != "\n") {
	//	throw ERROR_THROW(323);
	//}
}
void getLex(LT::Entry& lex, IT::Entry& idn, int nLine, vector<string> words, string word) {
	int SizeW = words.size();
	if (word == "true" || word == "false") {
		idn.iddatatype = IT::BOOL;
		char* newSTR = new char[TI_STR_MAXSIZE];

		strcpy(newSTR, word.c_str());
		newSTR[word.size()] = '\0';
		if(word=="true")
		idn.value.vbool = 1;
		else
			idn.value.vbool = 0;
	}
	else if (words[SizeW - 2] == "'" ||word[0]=='\'') {
		if (word.length() > TI_STR_MAXSIZE)
			throw ERROR_THROW(204);
		if (word[0] == '\'') {
			word.erase(word.begin());
			if (word.back()  != '\'')
				throw ERROR_THROW(320);
			word.erase(word.length()-1);
		}
		idn.iddatatype = IT::STR;
		char* newSTR = new char[TI_STR_MAXSIZE];
		if(word.size()==0)
			throw ERROR_THROW(315);
		for (int i = 0; i < word.size(); i++)
			if (word[i] == '\'')
				throw ERROR_THROW(316);
		strcpy(newSTR, word.c_str());
		newSTR[word.size()] = '\0';
		strcpy(idn.value.vstr->str, newSTR);
	}
	else {
		char* cstr = new char[word.length() + 1];
		 strcpy(cstr, word.c_str());
		FST::FST fstINTEGER(cstr, INTEGER_LITERAL);

		if (execute(fstINTEGER)) {
			idn.iddatatype = IT::INT;
			idn.value.vint = atoi(word.c_str());
			if (idn.value.vint > 429496729)
				throw ERROR_THROW(317);
		}
		else
			throw ERROR_THROW(312);
		
	}
	idn.idtype = IT::L;
	string id = "L" + to_string(amountLiteral);
	amountLiteral++;
	strcpy(idn.id, id.c_str());
	idn.id[id.size()] = '\0';
	lex.lexema = LEX_LITERAL;

}
void getid(int amount, char* id, vector<string> words, int m) {
	int SizeW = words.size();
	
	if (words[SizeW - amount].size() > 8) {
		words[SizeW - amount] = words[SizeW - amount].substr(0, 8);
	}
	string id2 = scope + words[SizeW - amount];
	strcpy(id, id2.c_str());
	id[id2.size()] = '\0';
}
void getName(IT::Entry& idn, std::string scope, std::string word) {
	char* cstr = new char[word.length() + 1];
	strcpy(cstr, word.c_str());
	FST::FST fstIDENTIFICATOR(cstr, IDENTIFICATOR);

	if (!execute(fstIDENTIFICATOR))
		throw ERROR_THROW(322);
	if (word.size() > 8) {
		word = word.substr(0, 8);
	}
	string id2 = scope + word;
	strcpy(idn.id, id2.c_str());
	idn.id[id2.size()] = '\0';
}
