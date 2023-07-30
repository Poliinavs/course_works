#pragma once

#define LEXEMA_FIXSIZE 1 // ������������� ������ �������
#define LT_MAXSIZE 4096 // ������������ ���������� ����� � ������� ������
#define LT_TI_NULLIDX 0xffffffff // ��� �������� ������� ����������������


#define LEX_MORE		 '>'	// 
#define LEX_LESS		 '<'	// 
#define LEX_EQUALS       '='
#define LEX_NOTEQUALS	 '!'	//


#define LEX_WHILE '#' //��� if
#define LEX_MOD '%'
#define LEX_ELSE		'e' //��� else
#define LEX_NEWLINE		 '^'
#define LEX_CONDITION '?' //��� if
#define LEX_NUMBER 't' // ������� ��� integer
#define LEX_LINE 't' // ������� ��� line
#define LEX_BOOL 't' // ������� ��� line
#define LEX_ID 'i' // ������� ��� ��������������
#define LEX_LITERAL 'l' // ������� ��� ��������
#define LEX_FUNCTION 'f' // ������� ��� �������
#define LEX_NEW 'n' // ������� ��� new
#define LEX_RETURN 'r' // ������� ��� return
#define LEX_PRINT 'p' // ������� ��� print
#define LEX_SEMICOLON ';' // ������� ��� ;
#define LEX_COMMA ',' // ������� ��� ,
#define LEX_LEFTBRACE '{' // ������� ��� {
#define LEX_RIGHTBRACE '}' // ������� ��� }
#define LEX_LEFTHESIS '(' // ������� ��� (
#define LEX_RIGHTHESIS ')' // ������� ��� )
#define LEX_PLUS '+' // ������� ��� +
#define LEX_MINUS '-' // ������� ��� -
#define LEX_STAR '*' // ������� ��� *
#define LEX_DIRSLASH '/' // ������� ��� /
#define LEX_MAIN 'm' // ������� ��� main
#include "stdafx.h"
namespace LT // ������� ������
{


	struct Entry
	{
		char lexema; // �������
		int sn; // ����� ������
		int idxTI; // ������ � ������� ���������������
		int amount;
		int priority;
	};

	struct LexTable
	{
		int maxsize; // ������������ ������ �������
		int size; // ������� ������ �������
		Entry* table; // ������� ������
	};

	LexTable Create( // �������� ������� ������
		int size // ������������ ������ �������
	);

	void Add( // ���������� ������� � �������
		LexTable& lextable, // ������� ������
		Entry entry // �������
	);

	Entry GetEntry( // ��������� ������� �� �������
		LexTable& lextable, // ������� ������
		int n // ����� �������
	);

	void Delete( // �������� ������� ������
		LexTable& lextable // ������� ������
	);
}