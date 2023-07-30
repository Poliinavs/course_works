#include "stdafx.h"

#define GRB_ERROR_SERIES 600

namespace GRB
{
#define NS(n) Rule::Chain::N(n)
#define TS(n) Rule::Chain::T(n)

	Rule::Chain::Chain(short symbolCount, GRBALPHABET s, ...)
	{
		this->size = symbolCount;
		this->chainOfTerm_nTerm = new GRBALPHABET[symbolCount];
		int* ptr = (int*)&s;
		for (int i = 0; i < symbolCount; i++)
		{
			this->chainOfTerm_nTerm[i] = (GRBALPHABET)ptr[i];
		}
	}

	Rule::Rule(GRBALPHABET pnn, int piderror, short psize, Chain c, ...)
	{
		this->nn = pnn;
		this->iderror = piderror;
		this->size = psize;
		this->chains = new Chain[psize];
		Chain* p = &c;
		for (int i = 0; i < size; i++)
		{
			this->chains[i] = p[i];
		}
	}

	Greibach::Greibach(GRBALPHABET pstartN, GRBALPHABET pstbottom, short psize, Rule r, ...)
	{
		this->startN = pstartN;
		this->stbottomT = pstbottom;
		this->size = psize;
		this->rules = new Rule[psize];
		Rule* p = &r;
		for (int i = 0; i < size; i++)
		{
			rules[i] = p[i];
		}
	}

	short Greibach::getRule(GRBALPHABET pnn, Rule& prule)
	{
		short rc = -1, k = 0;
		while (k < this->size && rules[k].nn != pnn)
		{
			k++;
		}
		if (k < this->size)
		{
			rc = k;
			prule = rules[k];
		}
		return rc;
	}

	Rule Greibach::getRule(short n)
	{
		Rule rc;
		if (n < this->size)
		{
			rc = rules[n];
		}
		return rc;
	}
	char* Rule::Chain::getCChain(char* b)
	{
		for (int i = 0; i < this->size; i++)
		{
			b[i] = Chain::alphabet_to_char(this->chainOfTerm_nTerm[i]);
		}
		b[this->size] = 0x00;
		return b;
	}

	char* Rule::getCRule(char* b, short nchain)
	{
		char bchain[200];
		b[0] = Chain::alphabet_to_char(this->nn);
		b[1] = '-';
		b[2] = '>';
		b[3] = 0x00;
		this->chains[nchain].getCChain(bchain);
		strcat_s(b, sizeof(bchain) + 5, bchain);
		return b;
	}

	short Rule::getNextChain(GRBALPHABET t, Rule::Chain& pchain, short j)
	{
		short rc = -1;
		while (j < this->size && this->chains[j].chainOfTerm_nTerm[0] != t)
		{
			++j;
		}
		rc = (j < this->size ? j : -1);
		if (rc >= 0)
		{
			pchain = chains[rc];
		}
		return rc;
	}
	//SFOZCTNWvEABDIG
	Greibach greibach(NS('S'), TS('$'),
		15,
		Rule(
			NS('A'), GRB_ERROR_SERIES + 11,// объявление функции
			1, //fi(F)
			Rule::Chain(5, TS('f'), TS('i'), TS('('), NS('F'), TS(')'))
		),
		Rule(
			NS('S'), GRB_ERROR_SERIES + 0, //структура программы
			4, // S -> |tA{N};S | m{N}; | tA{N}S | m{N} | 
			Rule::Chain(7, TS('t'), NS('A'), TS('{'), NS('N'), TS('}'), TS(';'), NS('S')),
			Rule::Chain(6, TS('t'), NS('A'), TS('{'), NS('N'), TS('}'), NS('S')),
			Rule::Chain(4, TS('m'), TS('{'), NS('N'), TS('}')),
			Rule::Chain(5, TS('m'), TS('{'), NS('N'), TS('}'), TS(';'))
		),
		Rule(
			NS('F'), GRB_ERROR_SERIES + 1, //параметры
			2, // F -> ti | ti,F
			Rule::Chain(2, TS('t'), TS('i')),
			Rule::Chain(4, TS('t'), TS('i'), TS(','), NS('F'))
		),
		Rule(
			NS('O'), GRB_ERROR_SERIES + 2, //логические операторы 
			6, // C -> c(i==i){}| ?(i==i){N}
			Rule::Chain(1, TS('>')),
			Rule::Chain(1, TS('<')),
			Rule::Chain(2, TS('<'), TS('=')),
			Rule::Chain(2, TS('>'), TS('=')),
			Rule::Chain(2, TS('='), TS('=')),
			Rule::Chain(2, TS('!'), TS('='))
		),
		Rule(
			NS('I'), GRB_ERROR_SERIES + 14, //конструкция цикла
			4, //I->iOiN| lOi| iOl| lOl
			Rule::Chain(3, TS('i'), NS('O'), TS('i')),
			Rule::Chain(3, TS('l'), NS('O'), TS('i')),
			Rule::Chain(3, TS('l'), NS('O'), TS('l')),
			Rule::Chain(3, TS('i'), NS('O'), TS('l'))
		),
		Rule(
			NS('Z'), GRB_ERROR_SERIES + 10, //конструкции условия
			6, // C -> c(i==i){}| (i==i){N} |c(i==i){}e{N}| (i==i){N}|e{N}
			Rule::Chain(3, TS('i'), NS('O'), TS('i')),
			Rule::Chain(3, TS('l'), NS('O'), TS('i')),
			Rule::Chain(3, TS('l'), NS('O'), TS('l')),
			Rule::Chain(3, TS('i'), NS('O'), TS('l')),
			Rule::Chain(1, TS('l')),
			Rule::Chain(1, TS('i'))
		),
		Rule(
			NS('B'), GRB_ERROR_SERIES + 9, //конструкции else
			2, // e{N} ||e{} 
			Rule::Chain(4, TS('e'), TS('{'), NS('T'), TS('}')),
			Rule::Chain(3, TS('e'), TS('{'), TS('}'))

		),
		Rule(
			NS('C'), GRB_ERROR_SERIES + 3, //конструкции условия
			4, // C -> c(Z){}| (Z){N} |c(Z){}B| (Z){N}|B | 
			Rule::Chain(5, TS('('), NS('Z'), TS(')'), TS('{'), TS('}')),
			Rule::Chain(6, TS('('), NS('Z'), TS(')'), TS('{'), NS('T'), TS('}')),
			Rule::Chain(6, TS('('), NS('Z'), TS(')'), TS('{'), TS('}'), NS('B')),
			Rule::Chain(7, TS('('), NS('Z'), TS(')'), TS('{'), NS('T'), TS('}'), NS('B'))
		),
		Rule(
			NS('G'), GRB_ERROR_SERIES + 3, //конструкции while
			2, // C -> (Z){}| (Z){N} |c(Z){}B| (Z){N}|B | 
			Rule::Chain(5, TS('('), NS('I'), TS(')'), TS('{'), TS('}')),
			Rule::Chain(6, TS('('), NS('I'), TS(')'), TS('{'), NS('T'), TS('}'))
		),
		Rule(
			NS('D'), GRB_ERROR_SERIES + 12, //инициализация переменной
			1, // D->ti=E
			Rule::Chain(4, TS('t'), TS('i'), TS('='), NS('E'))
		),
		Rule(
			NS('T'), GRB_ERROR_SERIES + 4, //процедура
			16, // T -> nti; | nti=E; | i=E; | nA; | pE; | ^npE|C |nti;T | nti=E;T | i=E;T | nA;T | pE;T | ^pE;T| CT;
			Rule::Chain(4, TS('n'), TS('t'), TS('i'), TS(';')),
			Rule::Chain(3, TS('n'), NS('D'), TS(';')),
			Rule::Chain(4, TS('i'), TS('='), NS('E'), TS(';')),
			Rule::Chain(4, TS('n'), TS('t'), NS('A'), TS(';')),
			Rule::Chain(3, TS('p'), NS('E'), TS(';')),
			Rule::Chain(4, TS('^'), TS('p'), NS('E'), TS(';')),
			Rule::Chain(5, TS('n'), TS('t'), TS('i'), TS(';'), NS('T')),
			Rule::Chain(2, TS('?'), NS('C')), //для if
			Rule::Chain(2, TS('#'), NS('G')),
			Rule::Chain(3, TS('#'), NS('G'),  NS('T')),
			Rule::Chain(3, TS('?'), NS('C'), NS('T')),
			Rule::Chain(4, TS('n'), NS('D'), TS(';'), NS('T')),
			Rule::Chain(5, TS('i'), TS('='), NS('E'), TS(';'), NS('T')),
			Rule::Chain(5, TS('n'), TS('t'), NS('A'), TS(';'), NS('T')),
			Rule::Chain(4, TS('p'), NS('E'), TS(';'), NS('T')),
			Rule::Chain(5, TS('^'), TS('p'), NS('E'), TS(';'), NS('T'))
		),
		
		Rule(
			NS('N'), GRB_ERROR_SERIES + 5, //тело функции
			9, // N -> nti;N | nti=E;N | i=E;N | nA;N | pE;N | ^pE;N | rE; | CN
			Rule::Chain(5, TS('n'), TS('t'), TS('i'), TS(';'), NS('N')),
			Rule::Chain(3,  TS('?'), NS('C'),  NS('N')), //для if
			Rule::Chain(3, TS('#'), NS('G'), NS('N')), 
			Rule::Chain(4, TS('n'), NS('D'), TS(';'), NS('N')),
			Rule::Chain(5, TS('i'), TS('='), NS('E'), TS(';'), NS('N')),
			Rule::Chain(5, TS('n'), TS('t'), NS('A'), TS(';'), NS('N')),
			Rule::Chain(4, TS('p'), NS('E'), TS(';'), NS('N')),
			Rule::Chain(5, TS('^'), TS('p'), NS('E'), TS(';'), NS('N')),
			Rule::Chain(3, TS('r'), NS('E'), TS(';'))
		),
		Rule(
			NS('W'), GRB_ERROR_SERIES + 6, //параметры в передаваемую функцию
			4, // W -> i | l | i,W | l,W |
			Rule::Chain(1, TS('i')),
			Rule::Chain(1, TS('l')),
			Rule::Chain(3, TS('i'), TS(','), NS('W')),
			Rule::Chain(3, TS('l'), TS(','), NS('W'))
		),
		Rule(
			NS('v'), GRB_ERROR_SERIES + 7, //операторы
			5,				// v -> * | / | - | +
			Rule::Chain(1, TS('+')),
			Rule::Chain(1, TS('-')),
			Rule::Chain(1, TS('*')),
			Rule::Chain(1, TS('/')),
			Rule::Chain(1, TS('%'))
		),
		Rule(
			NS('E'), GRB_ERROR_SERIES + 8, //выражения
			12, // E -> i | l | (E) | i(W) | ivE | lvE | (E)vE | i(W)vE, f(E)|
			Rule::Chain(1, TS('i')),
			Rule::Chain(1, TS('l')),
			Rule::Chain(6, TS('f'), TS('('), NS('E'), TS(')'), NS('v'), NS('E')),
			Rule::Chain(8, TS('f'), TS('('), NS('E'), TS(','), NS('E'), TS(')'), NS('v'), NS('E')),
			Rule::Chain(4, TS('f'), TS('('), NS('E'), TS(')')),
			Rule::Chain(6, TS('f'), TS('('), NS('E'), TS(','), NS('E'), TS(')')),
			Rule::Chain(3, TS('('), NS('E'), TS(')')),
			Rule::Chain(4, TS('i'), TS('('), NS('W'), TS(')')),
			
			Rule::Chain(3, TS('i'), NS('v'), NS('E')),
			Rule::Chain(3, TS('l'), NS('v'), NS('E')),
			Rule::Chain(5, TS('('), NS('E'), TS(')'), NS('v'), NS('E')),
			Rule::Chain(6, TS('i'), TS('('), NS('W'), TS(')'), NS('v'), NS('E'))
		)
		
	);

	Greibach getGreibach()
	{
		return greibach;
	}
}