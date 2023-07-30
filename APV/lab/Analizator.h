#pragma once
#include "stdafx.h"

void LexAnalize(In::IN in, // входной поток
	LT::LexTable& lextable, // таблица лексем
	IT::IdTable& idtable); // таблица идентификаторов


void search(
	std::string text,
	LT::LexTable& lextable,
	IT::IdTable& idtable,
	int nLine,
	std::vector<std::string> words
);
void getid(int amount, char* id, std::vector<std::string> words, int m);
void getName(IT::Entry& idn, std::string scope, std::string word);
void getLex(LT::Entry& lex, IT::Entry& idn, int nLine, std::vector<std::string> words, std::string word);

