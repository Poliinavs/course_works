#include "stdafx.h"

namespace Error
{
	/*0 � 200 	��������� ������
		1	2
		200 � 299	������ ������������ �������
		300 � 399	������ �������������� �������
		600 � 699	������ ��������������� ������� GRB
		400 - 499, 700 - 999 	����������������� ���� ������*/

	using namespace std;

	ERROR errors[ERROR_MAX_ENTRY] =
	{
		
	ERROR_ENTRY(0,"[���������]:���������� ��� ������"),
	ERROR_ENTRY(1,"[���������]:��������� ����"),
	ERROR_ENTRY(2,"[���������]:�������� ��������� ���������"), 

	ERROR_ENTRY_NODEF(3), ERROR_ENTRY_NODEF(4), ERROR_ENTRY_NODEF(5),
	ERROR_ENTRY_NODEF(6), ERROR_ENTRY_NODEF(7), ERROR_ENTRY_NODEF(8), ERROR_ENTRY_NODEF(9),
	ERROR_ENTRY_NODEF10(10), ERROR_ENTRY_NODEF10(20), ERROR_ENTRY_NODEF10(30), ERROR_ENTRY_NODEF10(40), ERROR_ENTRY_NODEF10(50),
	ERROR_ENTRY_NODEF10(60), ERROR_ENTRY_NODEF10(70), ERROR_ENTRY_NODEF10(80), ERROR_ENTRY_NODEF10(90),
	ERROR_ENTRY(100,"[���������]:�������� -in ������ ���� �����"),
	ERROR_ENTRY_NODEF(101),ERROR_ENTRY_NODEF(102),ERROR_ENTRY_NODEF(103),
	ERROR_ENTRY(104,"[���������]:��������� ����� �������� ���������"),
	ERROR_ENTRY_NODEF(105),ERROR_ENTRY_NODEF(106),ERROR_ENTRY_NODEF(107),
	ERROR_ENTRY_NODEF(108),ERROR_ENTRY_NODEF(109),
	ERROR_ENTRY(110,"[���������]:������ ��� �������� ����� � �������� ����� (-in)"),
	ERROR_ENTRY(111,"[����������� ������]:������������ ������ � �������� ����� (-in)"),
	ERROR_ENTRY(112,"[���������]:������ ��� �������� ����� ��������� (-log)"),
	
	ERROR_ENTRY(200,"[�����������]:������ ��� �������� ������� ������: ��������� ������������ ���������� �����"),
	ERROR_ENTRY(201,"[�����������]:������ ��� ����������: ��������� ������������ ���������� ����� � ������� ������"),
	ERROR_ENTRY(202,"[�����������]:������ ��� ���������� �������"),
	ERROR_ENTRY(203,"[�����������]:�������� ������ ���������������"),
	ERROR_ENTRY(204,"[�����������]:�������� ������ ������"),
	//ERROR_ENTRY_NODEF(119),
	ERROR_ENTRY_NODEF10(120),ERROR_ENTRY_NODEF10(130),ERROR_ENTRY_NODEF10(140),ERROR_ENTRY_NODEF10(150),
	ERROR_ENTRY_NODEF10(160),ERROR_ENTRY_NODEF10(170),ERROR_ENTRY_NODEF10(180),ERROR_ENTRY_NODEF10(190),
	
	//////////������ 
	ERROR_ENTRY(300,"[�������������]:����� ����� ����� ����� main"),
	ERROR_ENTRY(301,"[�������������]:����������� ����� ����� main"),
	ERROR_ENTRY(302,"[�������������]:���� ��������� �� ��������� ��� �����������"),
	ERROR_ENTRY(303,"[�������������]:������������� ������������� ����������"),
	ERROR_ENTRY(304,"[�������������]:������ �� 0 ������"),
	ERROR_ENTRY(305,"[�������������]:���� ��������� �� ��������� � �������� �����������"),
	ERROR_ENTRY(306,"[�������������]:������ �������������� �������� �� �������� ��� ������"),
	ERROR_ENTRY(307,"[�������������]:��� ������� �� ��������� � ����� ������������� ��������"),
	ERROR_ENTRY(308,"[�������������]:������������� ����������� ����������"),
	ERROR_ENTRY(309,"[�������������]:���������, ������������ � �������, �� ��������� � ������ ���������� � ���������� �������"),
	ERROR_ENTRY(310,"[�������������]:������������� ����� �� ����� ���������� � 0"),
	ERROR_ENTRY(311,"[�������������]:������ �������������� �� ����� ���� ��������������� ������ �� ������"),
	ERROR_ENTRY(312,"[�������������]:������������ ������������� ����������"),
	ERROR_ENTRY(313,"[�������������]:�������� ������ ���������� � ������� ��� ���������"),
	ERROR_ENTRY(314,"[�������������]:�������� ������ ���������� � ������� ��� ���������"),
	ERROR_ENTRY(315,"[�������������]:������������� ������� ���������� �������� �����������"),
	ERROR_ENTRY(316,"[�������������]:��������� ������ '.��������, �� ������ ��������� ������� "),
	ERROR_ENTRY(317,"[�������������]:������������ ������������� �������"),
	ERROR_ENTRY(318,"[�������������]:�������� �������� ���������"),
	ERROR_ENTRY(319,"[�������������]:�������� ��������� �����������	"),
	ERROR_ENTRY(320,"[�������������]:��������� ������� �� ������"),
	ERROR_ENTRY(321,"[�������������]:�������� ������������ ��������� ����������� �������"),
	ERROR_ENTRY(322,"[�������������]:�������������� ����� �������� ������ �� ���� ������� ��������"),
	ERROR_ENTRY(323,"[�������������]:����������� ������������������� ��������"),

	

	ERROR_ENTRY(600,"[��������������]:�������� ��������� ���������"),
	ERROR_ENTRY(601,"[��������������]:������ � ���������� �������"),
	ERROR_ENTRY(602,"[��������������]:������ � ���������� ����������"),
	ERROR_ENTRY(603,"[��������������]:������ � ����������� ��������� ���������"),
	ERROR_ENTRY(604,"[��������������]:������ � ���� ��������� ��������� "),
	ERROR_ENTRY(605,"[��������������]:������ � ���� �������"),
	ERROR_ENTRY(606,"[��������������]:������ � ���������� ���������� �������"),
	ERROR_ENTRY(607,"[��������������]:������ � ����������"),
	ERROR_ENTRY(608,"[��������������]:������ � ���������"),
	ERROR_ENTRY(609,"[��������������]:������ � ��������� else"),
	ERROR_ENTRY(610,"[��������������]:������ � ���������� �������"),
	ERROR_ENTRY(611,"[��������������]:������ � ���������� �������"),
	ERROR_ENTRY(612,"[��������������]:������ � ������������� ����������"),
	ERROR_ENTRY(613,"[��������������]:������ ����������� ����������� �������"),
	ERROR_ENTRY(614,"[��������������]:������ � ����������� while"),

	
	ERROR_ENTRY(801,"������ ��� ������� �������"),
	ERROR_ENTRY_NODEF10(620),ERROR_ENTRY_NODEF10(630),ERROR_ENTRY_NODEF10(640),
	ERROR_ENTRY_NODEF10(650),ERROR_ENTRY_NODEF10(660),ERROR_ENTRY_NODEF10(670),ERROR_ENTRY_NODEF10(680),
	ERROR_ENTRY_NODEF10(690),
	ERROR_ENTRY_NODEF100(700),
	ERROR_ENTRY_NODEF100(800),
	
	ERROR_ENTRY_NODEF100(900)
	};
	
	ERROR geterror(int id) {
		for (int i=0; i<= ERROR_MAX_ENTRY; i++) 
		{
			if (errors[i].id == id)
				return errors[i];
		}
		return errors[0];
	}

	ERROR geterrorin(int id, int line, int col) {

		for (int i = 0; i <= ERROR_MAX_ENTRY; i++)
		{
			if (errors[i].id == id) {
				errors[i].inext.col = col;
				errors[i].inext.line = line;
				return errors[i];
			}	
		}
		return errors[0];
	}









	//ERROR geterror(int id)
	//{
	//	if (id > 0 && id < ERROR_MAX_ENTRY)
	//		return errors[id];
	//	else
	//		return errors[0];
	//}

	//ERROR geterrorin(int id, int line = -1, int col = -1)
	//{
	//	if (id > 0 && id < ERROR_MAX_ENTRY) {
	//		errors[id].inext.col = col;
	//		errors[id].inext.line = line;
	//		return errors[id];
	//	}
	//	else
	//		return errors[0];
	//}

}