#include "stdafx.h"

namespace Semantic
{
	bool semanticsCheck(LT::LexTable& lextable, IT::IdTable& idtable) {
		bool sem_ok = true;// флаг верной семантики
		
		for (int i = 0; i < idtable.size-1; i++)
			for (int j = i + 1; j < idtable.size; j++) {
				if (strcmp(idtable.table[i].id, idtable.table[j].id) == 0)
					throw ERROR_THROW_IN(303, lextable.table[i].sn, i);	
			}

		for (int i = 0; i < lextable.size; i++)
		{
			switch (lextable.table[i].lexema)
			{
			case LEX_DIRSLASH:
			{
				int k = i;
				if (lextable.table[i + 1].lexema==LEX_LITERAL &&idtable.table[lextable.table[i + 1].idxTI].value.vint == 0)
				{
					throw ERROR_THROW_IN(304, lextable.table[i + 1].sn, i);
				}
				if (lextable.table[i + 1].lexema == LEX_ID || lextable.table[i -1 ].lexema == LEX_ID) 
				{
					if(idtable.table[lextable.table[i + 1].idxTI].iddatatype== 2 || idtable.table[lextable.table[i -1].idxTI].iddatatype == 2) //дл€ k
						throw ERROR_THROW_IN(306, lextable.table[i].sn, i);
				}
				break;
			}
			case '=':// выражение
			{
				if(lextable.table[i - 1].idxTI== TI_NULLIDX)
					throw ERROR_THROW_IN(308, lextable.table[i-1].sn, i-1);
					IT::IDDATATYPE lefttype =  idtable.table[ lextable.table[i - 1].idxTI].iddatatype;
					IT::IDDATATYPE righttype;
					
					bool ignore = false;
					if (lextable.table[i+1].idxTI != LT_TI_NULLIDX)
						righttype = idtable.table[lextable.table[i+1].idxTI].iddatatype;
					for (int k = i + 1;  lextable.table[k].lexema != LEX_SEMICOLON; k++)
					{
					
						if ( lextable.table[k].idxTI != LT_TI_NULLIDX) // если идентификатор - проверить совпадение типов
						{
								
								if (lefttype != righttype)// типы данных в выражении не совпадают
								{
									throw ERROR_THROW_IN(302, lextable.table[i + 1].sn, i + 1);
									sem_ok = false;
									break;
								}
						}
						if (idtable.table[lextable.table[i + 1].idxTI].idtype == IT::IDTYPE::F) {

							FST::FST fstCOMPARE(idtable.table[lextable.table[i + 1].idxTI].id, COMPARE);
							FST::FST fstCONCAT(idtable.table[lextable.table[i + 1].idxTI].id, CONCAT);
							FST::FST fstLENGHT(idtable.table[lextable.table[i + 1].idxTI].id, LENGHT);
							FST::FST fstNPOW(idtable.table[lextable.table[i + 1].idxTI].id, NPOW);
							int amount = -1;
							if(execute(fstCOMPARE)|| execute(fstCONCAT)|| execute(fstLENGHT))
							{
								while (lextable.table[k].lexema != '@') {
									k++;
									amount++;
									i = k;
									if (lextable.table[k].idxTI != LT_TI_NULLIDX)
										if (idtable.table[lextable.table[k].idxTI].iddatatype != IT::STR)
											throw ERROR_THROW_IN(321, lextable.table[k].sn, k);
								}
								if (execute(fstLENGHT)) {
									if (amount != 1)
										throw ERROR_THROW_IN(321, lextable.table[k].sn, k);
								}
									else
										if (amount != 2)
											throw ERROR_THROW_IN(321, lextable.table[k].sn, k);
							}
							if (execute(fstNPOW) )
							{
								while (lextable.table[k].lexema != '@') {
									k++;
									amount++;
									if (lextable.table[k].idxTI != LT_TI_NULLIDX)
										if (idtable.table[lextable.table[k].idxTI].iddatatype != IT::INT)
											throw ERROR_THROW_IN(321, lextable.table[k].sn, k);
								}
								if (amount != 2)
									throw ERROR_THROW_IN(321, lextable.table[k].sn, k);
							}
							
							while (lextable.table[k].lexema != '@') {
								k++;
								break;
							}
								
							
						}
						if (lefttype == IT::IDDATATYPE::STR)// нельз€ арифметические действи€ над строкой 
						{
							char l =  lextable.table[k].lexema;
							if (l == LEX_PLUS || l == LEX_MINUS || l == LEX_STAR || l == LEX_DIRSLASH)
							{
								throw ERROR_THROW_IN(306, lextable.table[k].sn, k);
								sem_ok = false;
								break;
							}
						}
					}
				break;
			}
			case  LEX_RETURN: {
				IT::IDDATATYPE returntype = idtable.table[lextable.table[i + 1].idxTI].iddatatype;

				int m = i;
				while (true) {
					if (lextable.table[m].lexema == LEX_MAIN) {
						IT::IDDATATYPE functype = IT::IDDATATYPE::INT;
						if (functype == returntype)
							break;
						else
							throw ERROR_THROW_IN(307, lextable.table[m].sn, m);
					}
					if (lextable.table[m].lexema == '(' && lextable.table[m - 2].lexema == LEX_FUNCTION) {
					
						IT::IDDATATYPE functype = idtable.table[lextable.table[m -1].idxTI].iddatatype;
						if (functype == returntype)
							break;
						else
							throw ERROR_THROW_IN(307, lextable.table[m].sn, m);
					}
					m--;
				}
				
				break;
			}
			case  LEX_CONDITION:
			case  LEX_WHILE: { //проверка на то, чтобы присравнении был один тип if(k>=p)
				IT::IDDATATYPE lefttype = idtable.table[lextable.table[i +2].idxTI].iddatatype;
				if (lefttype == IT::BOOL)
					break;
				IT::IDDATATYPE righttype;
				if(lextable.table[i + 4].idxTI!= LT_TI_NULLIDX)//значит><
					righttype = idtable.table[lextable.table[i + 4].idxTI].iddatatype;
				else//>= <= == !=
				 righttype = idtable.table[lextable.table[i +5].idxTI].iddatatype;
				if (lefttype == IT::STR || righttype == IT::STR){
					throw ERROR_THROW_IN(318, lextable.table[i].sn, i);
				}
				if (lefttype == righttype) {
					i += 5;
					break;
				}
				else
					throw ERROR_THROW_IN(305, lextable.table[i].sn, i);
			}
			case  LEX_ID: { //аргументы, передаваемые в функцию совпадают с типами параметров в объ€влении функции
				if (lextable.table[i].idxTI != LT_TI_NULLIDX && idtable.table[lextable.table[i].idxTI].idtype == IT::IDTYPE::F && lextable.table[i+2].lexema != LEX_LINE) {
					IT::IDDATATYPE paramtype ;
					IT::IDDATATYPE argtype ;
					int k = 1;
					int m = i;
					i++;
					if (lextable.table[i].idxTI == LT_TI_NULLIDX)
						break;
					while (idtable.table[lextable.table[m].idxTI + k].idtype == IT::P) {
					 paramtype = idtable.table[lextable.table[m].idxTI+k].iddatatype;
					 if(lextable.table[i].idxTI == LT_TI_NULLIDX)
						 throw ERROR_THROW_IN(314, lextable.table[i].sn, i);
					 argtype = idtable.table[lextable.table[i].idxTI].iddatatype;
					 k++;
					 i++;
					 if(paramtype!= argtype)
						 throw ERROR_THROW_IN(309, lextable.table[i].sn, i);
						 
					}
					if(lextable.table[i].amount != --k)
						throw ERROR_THROW_IN(313, lextable.table[i].sn, i); 
					if (idtable.table[lextable.table[m].idxTI + k].idtype != IT::P) //в вызываемой меньше параметров, чем в объ€влении
						throw ERROR_THROW_IN(313, lextable.table[i].sn, i);
				}
				break;
			}

			}
		}
		
		return sem_ok;
	}
};





