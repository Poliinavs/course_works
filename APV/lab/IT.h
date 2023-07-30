#pragma once

#define ID_MAXSIZE 16 // ������������ ���������� �������� � ��������������
#define TI_MAXSIZE 4096 // ������������ ���������� ������� � ������� ���������������
#define TI_INT_DEFAULT 0x00000000 // �������� �� ��������� ��� ���� integer
#define TT_STR_DEFAULT 0x00 // �������� �� ��������� ��� ���� string
#define TI_NULLIDX -5// ��� �������� � ������� ���������������
#define TI_STR_MAXSIZE 20  //������������ ������ ������

namespace IT
{
	enum IDDATATYPE // ���� ������ ���������������
	{
		INT = 1,
		STR = 2,
		BOOL =3
	};

	enum IDTYPE // ���� ���������������
	{
		V = 1, // ����������
		F = 2, // �������
		P = 3, // ��������
		L = 4, // �������
		S = 5, //����������� �������
		O = 6 //���������
	};

	struct Entry // ������ � ������� ���������������
	{
		int idxfirstLE; // ������ ������ ������ � ������� ������
		char id[ID_MAXSIZE]; // �������������
		IDDATATYPE iddatatype; // ��� ������ ��������������
		IDTYPE idtype; // ��� ��������������
		char parentBlockName[ID_MAXSIZE];

		union
		{
			int parms;
			int vint; // �������� ��� ���� integer
			int vbool;
			struct
			{
				char len; // ���������� �������� � string
				char str[TI_STR_MAXSIZE - 1]; // ������� string

			} vstr[TI_STR_MAXSIZE]; // �������� ��� ���� string

		} value;
	};

	struct IdTable // ��������� ������� ���������������
	{
		int maxsize; // ������������ ���������� ������� � ������� ��������������� < TI_MAXSIZE
		int size; // ������� ������ ������� ��������������� < maxsize
		Entry* table; // ������ ����� ������� ���������������
	};

	IdTable Create(int size); // �������� ������� ���������������

	void Add( // ���������� ������ � ������� ���������������
		IdTable& idtable, // ������� ���������������
		Entry entry // ������ ������� ���������������
	);

	Entry GetEntry( // ��������� ������ �� ������� ���������������
		IdTable& idtable, // ������� ���������������
		int n // ����� ������ � ������� ���������������
	);

	int IsId( // ����� �������������� � ������� ��������������� ������� ������ ��� TI_NULLIDX
		IdTable& idtable, // ������� ���������������
		char id[ID_MAXSIZE] // �������������
	);

	void Delete(IdTable& idtable); // �������� ������� ���������������
	void Replace(
		IdTable& idtable, // ������� ���������������
		Entry entry, // ������ ������� ���������������
		int place
	);

}