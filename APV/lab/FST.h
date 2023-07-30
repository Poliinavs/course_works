#pragma once
#include "stdafx.h"

namespace FST
{
	struct RELATION // �����:������ -> ������� ����� ��������� ��
	{
		char symbol; // ������ ��������
		int nnode; // ����� ������� �������

		RELATION(
			char c = 0x00, // ������ ��������
			short ns = 0 // ����� ���������
		);
	};

	struct NODE // ������� ����� ���������
	{
		short n_relation; // ���������� ������������ �����
		RELATION* relations; // ������ ������������ �����

		NODE();

		NODE(
			short n, // ���������� ������������ �����
			RELATION rel, // ������ �����
			... // ������ �����
		);
	};
	struct graph{
		int a;
		NODE b;
	};
	struct FST // ������������������� �������� �������
	{
		char* string; // �������(������ ����������� 0x00)
		short position; // ������� ������� � �������
		short nstates; // ���������� ��������� ��
		NODE* nodes; // ���� ���������: [0] - ��������� ���������, [nstate-1] - ��������
		short* rstates; // ��������� ��������� �������� �� ������ �������

		FST(
			char* s, // �������
			short ns, // ���������� ���������
			NODE n, // ���� ���������/ ������ ���������
			...
		);
	};

	bool execute( // ��������� ������������� �������
		FST& fst // ������������������� �������� �������
	);

	short* setRelState( // ���������� ������ ��������� ���������
		char symb, // ������
		FST& fst, // ������������������� �������� �������
		short* pNRStates, // ���������� ��������� ���������
		short* rstates); // ������ ��������� ���������

	bool isAllowed( // ���������, ��������� �� ������� ��������� �� ������ ���������
		char symb, // ������
		short*& rstates, // ������ ��������� ���������
		short nNRStates, // ���������� ��������� ���������
		FST& fst); // ������������������� �������� �������

	bool isLastState( // ��������, ��������� �� ������ ��������� � �������
		short* rstates, // ������ ��������� ���������
		short length, // ���������� ��������� ���������
		short countStates); // ���������� ��������� ��

}


#define COMPARE  8, \
	FST::NODE(1, FST::RELATION('c', 1)), \
	FST::NODE(1, FST::RELATION('o', 2)), \
	FST::NODE(1, FST::RELATION('m', 3)), \
	FST::NODE(1, FST::RELATION('p', 4)), \
	FST::NODE(1, FST::RELATION('a', 5)), \
	FST::NODE(1, FST::RELATION('r', 6)), \
	FST::NODE(1, FST::RELATION('e', 7)), \
	FST::NODE()

#define LENGHT  7, \
	FST::NODE(1, FST::RELATION('l', 1)), \
	FST::NODE(1, FST::RELATION('e', 2)), \
	FST::NODE(1, FST::RELATION('n', 3)), \
	FST::NODE(1, FST::RELATION('g', 4)), \
	FST::NODE(1, FST::RELATION('h', 5)), \
	FST::NODE(1, FST::RELATION('t', 6)), \
	FST::NODE()

#define CONCAT  7, \
	FST::NODE(1, FST::RELATION('c', 1)), \
	FST::NODE(1, FST::RELATION('o', 2)), \
	FST::NODE(1, FST::RELATION('n', 3)), \
	FST::NODE(1, FST::RELATION('c', 4)), \
	FST::NODE(1, FST::RELATION('a', 5)), \
	FST::NODE(1, FST::RELATION('t', 6)), \
	FST::NODE()

#define NPOW  5, \
	FST::NODE(1, FST::RELATION('n', 1)), \
	FST::NODE(1, FST::RELATION('p', 2)), \
	FST::NODE(1, FST::RELATION('o', 3)), \
	FST::NODE(1, FST::RELATION('w', 4)), \
	FST::NODE()

#define NUMBER  7, \
	FST::NODE(1, FST::RELATION('n', 1)), \
	FST::NODE(1, FST::RELATION('u', 2)), \
	FST::NODE(1, FST::RELATION('m', 3)), \
	FST::NODE(1, FST::RELATION('b', 4)), \
	FST::NODE(1, FST::RELATION('e', 5)), \
	FST::NODE(1, FST::RELATION('r', 6)), \
	FST::NODE()

#define NEWLINE  8, \
	FST::NODE(1, FST::RELATION('n', 1)), \
	FST::NODE(1, FST::RELATION('e', 2)), \
	FST::NODE(1, FST::RELATION('w', 3)), \
	FST::NODE(1, FST::RELATION('l', 4)), \
	FST::NODE(1, FST::RELATION('i', 5)), \
	FST::NODE(1, FST::RELATION('n', 6)), \
	FST::NODE(1, FST::RELATION('e', 7)), \
	FST::NODE()
	#define LINE  5, \
	FST::NODE(1, FST::RELATION('l', 1)), \
	FST::NODE(1, FST::RELATION('i', 2)), \
	FST::NODE(1, FST::RELATION('n', 3)), \
	FST::NODE(1, FST::RELATION('e', 4)), \
	FST::NODE()

	#define WHILE  6, \
	FST::NODE(1, FST::RELATION('w', 1)), \
	FST::NODE(1, FST::RELATION('h', 2)), \
	FST::NODE(1, FST::RELATION('i', 3)), \
	FST::NODE(1, FST::RELATION('l', 4)), \
	FST::NODE(1, FST::RELATION('e', 5)), \
	FST::NODE()

	#define BOL  5, \
	FST::NODE(1, FST::RELATION('b', 1)), \
	FST::NODE(1, FST::RELATION('o', 2)), \
	FST::NODE(1, FST::RELATION('o', 3)), \
	FST::NODE(1, FST::RELATION('l', 4)), \
	FST::NODE()

	#define IF  3, \
	FST::NODE(1, FST::RELATION('i', 1)), \
	FST::NODE(1, FST::RELATION('f', 2)), \
	FST::NODE()

	#define NEW  4, \
	FST::NODE(1, FST::RELATION('n', 1)), \
	FST::NODE(1, FST::RELATION('e', 2)), \
	FST::NODE(1, FST::RELATION('w', 3)), \
	FST::NODE()

	#define RETURN  7, \
	FST::NODE(1, FST::RELATION('r', 1)), \
	FST::NODE(1, FST::RELATION('e', 2)), \
	FST::NODE(1, FST::RELATION('t', 3)), \
	FST::NODE(1, FST::RELATION('u', 4)), \
	FST::NODE(1, FST::RELATION('r', 5)), \
	FST::NODE(1, FST::RELATION('n', 6)), \
	FST::NODE()

	#define PRINT  6, \
	FST::NODE(1, FST::RELATION('p', 1)), \
	FST::NODE(1, FST::RELATION('r', 2)), \
	FST::NODE(1, FST::RELATION('i', 3)), \
	FST::NODE(1, FST::RELATION('n', 4)), \
	FST::NODE(1, FST::RELATION('t', 5)), \
	FST::NODE()

	#define ELSE  5, \
	FST::NODE(1, FST::RELATION('e', 1)), \
	FST::NODE(1, FST::RELATION('l', 2)), \
	FST::NODE(1, FST::RELATION('s', 3)), \
	FST::NODE(1, FST::RELATION('e', 4)), \
	FST::NODE()

	#define MAIN  5, \
	FST::NODE(1, FST::RELATION('m', 1)), \
	FST::NODE(1, FST::RELATION('a', 2)), \
	FST::NODE(1, FST::RELATION('i', 3)), \
	FST::NODE(1, FST::RELATION('n', 4)), \
	FST::NODE()

	#define FUNCTION  9, \
	FST::NODE(1, FST::RELATION('f', 1)), \
	FST::NODE(1, FST::RELATION('u', 2)), \
	FST::NODE(1, FST::RELATION('n', 3)), \
	FST::NODE(1, FST::RELATION('c', 4)), \
	FST::NODE(1, FST::RELATION('t', 5)), \
	FST::NODE(1, FST::RELATION('i', 6)), \
	FST::NODE(1, FST::RELATION('o', 7)), \
	FST::NODE(1, FST::RELATION('n', 8)), \
	FST::NODE()

	#define BINARY_LITERAL  3, \
	FST::NODE(1, FST::RELATION('d', 1)), \
	FST::NODE(4, FST::RELATION('0', 1),FST::RELATION('1', 1), FST::RELATION('0', 2),FST::RELATION('1', 2) ), \
	FST::NODE()

	#define INTEGER_LITERAL 1,\
	FST::NODE(10,FST::RELATION('0', 0),\
	FST::RELATION('1', 0),\
	FST::RELATION('2', 0),\
	FST::RELATION('3', 0),\
	FST::RELATION('4', 0),\
	FST::RELATION('5', 0),\
	FST::RELATION('6', 0),\
	FST::RELATION('7', 0),\
	FST::RELATION('8', 0),\
	FST::RELATION('9', 0)),\
	FST::NODE()

	#define IDENTIFICATOR 1,\
	FST::NODE(26,\
	FST::RELATION('a', 0),\
	FST::RELATION('b', 0),\
	FST::RELATION('c', 0),\
	FST::RELATION('d', 0),\
	FST::RELATION('e', 0),\
	FST::RELATION('f', 0),\
	FST::RELATION('g', 0),\
	FST::RELATION('h', 0),\
	FST::RELATION('i', 0),\
	FST::RELATION('j', 0),\
	FST::RELATION('k', 0),\
	FST::RELATION('l', 0),\
	FST::RELATION('m', 0),\
	FST::RELATION('n', 0),\
	FST::RELATION('o', 0),\
	FST::RELATION('p', 0),\
	FST::RELATION('q', 0),\
	FST::RELATION('r', 0),\
	FST::RELATION('s', 0),\
	FST::RELATION('t', 0),\
	FST::RELATION('u', 0),\
	FST::RELATION('v', 0),\
	FST::RELATION('w', 0),\
	FST::RELATION('x', 0),\
	FST::RELATION('y', 0),\
	FST::RELATION('z', 0)),\
	FST::NODE()

	#define STRING_LITERAL 3,\
	FST::NODE(1, FST::RELATION('\'', 1)),\
	FST::NODE(85,FST::RELATION('a', 1),\
	FST::RELATION('b', 1),\
	FST::RELATION('c', 1),\
	FST::RELATION('d', 1),\
	FST::RELATION('e', 1),\
	FST::RELATION('f', 1),\
	FST::RELATION('g', 1),\
	FST::RELATION('h', 1),\
	FST::RELATION('i', 1),\
	FST::RELATION('j', 1),\
	FST::RELATION('k', 1),\
	FST::RELATION('l', 1),\
	FST::RELATION('m', 1),\
	FST::RELATION('n', 1),\
	FST::RELATION('o', 1),\
	FST::RELATION('p', 1),\
	FST::RELATION('q', 1),\
	FST::RELATION('r', 1),\
	FST::RELATION('s', 1),\
	FST::RELATION('t', 1),\
	FST::RELATION('u', 1),\
	FST::RELATION('v', 1),\
	FST::RELATION('w', 1),\
	FST::RELATION('x', 1),\
	FST::RELATION('y', 1),\
	FST::RELATION('z', 1),\
	FST::RELATION('0', 1),\
	FST::RELATION('1', 1),\
	FST::RELATION('2', 1),\
	FST::RELATION('3', 1),\
	FST::RELATION('4', 1),\
	FST::RELATION('5', 1),\
	FST::RELATION('6', 1),\
	FST::RELATION('7', 1),\
	FST::RELATION('8', 1),\
	FST::RELATION('9', 1),\
	FST::RELATION('�', 1),\
	FST::RELATION('�', 1),\
	FST::RELATION('�', 1),\
	FST::RELATION('�', 1),\
	FST::RELATION('�', 1),\
	FST::RELATION('�', 1),\
	FST::RELATION('�', 1),\
	FST::RELATION('�', 1),\
	FST::RELATION('�', 1),\
	FST::RELATION('�', 1),\
	FST::RELATION('�', 1),\
	FST::RELATION('�', 1),\
	FST::RELATION('�', 1),\
	FST::RELATION('�', 1),\
	FST::RELATION('�', 1),\
	FST::RELATION('�', 1),\
	FST::RELATION('�', 1),\
	FST::RELATION('�', 1),\
	FST::RELATION('�', 1),\
	FST::RELATION('�', 1),\
	FST::RELATION('�', 1),\
	FST::RELATION('�', 1),\
	FST::RELATION('�', 1),\
	FST::RELATION('�', 1),\
	FST::RELATION('�', 1),\
	FST::RELATION('�', 1),\
	FST::RELATION('�', 1),\
	FST::RELATION('�', 1),\
	FST::RELATION('�', 1),\
	FST::RELATION('�', 1),\
	FST::RELATION('�', 1),\
	FST::RELATION('�', 1),\
	FST::RELATION('�', 1),\
	FST::RELATION(' ', 1),\
	FST::RELATION('=', 1),\
	FST::RELATION('+', 1),\
	FST::RELATION('-', 1),\
	FST::RELATION('*', 1),\
	FST::RELATION('/', 1),\
	FST::RELATION('(', 1),\
	FST::RELATION(')', 1),\
	FST::RELATION('{', 1),\
	FST::RELATION('}', 1),\
	FST::RELATION(';', 1),\
	FST::RELATION(',', 1),\
	FST::RELATION('?', 1),\
	FST::RELATION('!', 1),\
	FST::RELATION('\'', 2)),\
	FST::NODE()