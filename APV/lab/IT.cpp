#include "stdafx.h"
#include<iomanip>
namespace IT
{
	IdTable Create(int size) {
		if (size > TI_MAXSIZE)
		{
			throw ERROR_THROW(113);
		}
		IdTable idtable;
		idtable.maxsize = size;
		idtable.size = 0;
		idtable.table = new Entry[size];
		return idtable;
	}
	void Add(
		IdTable& idtable, // таблица идентификаторов
		Entry entry // строка таблицы идентификаторов
	) {
		if (idtable.size >= idtable.maxsize)
				{
					throw ERROR_THROW(114);
				}
		idtable.table[idtable.size] = entry;
		idtable.size++;
	}
	void Replace(
		IdTable& idtable, // таблица идентификаторов
		Entry entry, // строка таблицы идентификаторов
		int place
	) {

		idtable.table[place] = entry;

	}

	Entry GetEntry( // получение записи из таблицы идентификаторов
		IdTable& idtable, // таблица идентификаторов
		int n // номер записи в таблице идентификаторов
	) {
			if (n >= idtable.size || n < 0)
		{
			throw ERROR_THROW(115 );
		}

		return idtable.table[n];
	}


	int IsId( // поиск идентификатора в таблице идентификаторов вернуть индекс или TI_NULLIDX
		IdTable& idtable, // таблица идентификаторов
		char id[ID_MAXSIZE] // идентификатор
	) {
		for (int i = 0; i < idtable.size; i++) {
			if (strcmp(idtable.table[i].id, id) == 0)
				return i;
		}
		return TI_NULLIDX;
	}

	void Delete(IdTable& idtable) {
			delete[] idtable.table;
			idtable.size = 0;
			idtable.maxsize = 0;
	}
}