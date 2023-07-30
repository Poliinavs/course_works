#include "stdafx.h"

namespace Error
{
	/*0 – 200 	Системные ошибки
		1	2
		200 – 299	Ошибки лексического анализа
		300 – 399	Ошибки семантического анализа
		600 – 699	Ошибки синтаксического анализа GRB
		400 - 499, 700 - 999 	Зарезервированные коды ошибок*/

	using namespace std;

	ERROR errors[ERROR_MAX_ENTRY] =
	{
		
	ERROR_ENTRY(0,"[Системная]:Недопустим код ошибки"),
	ERROR_ENTRY(1,"[Системная]:Системный сбой"),
	ERROR_ENTRY(2,"[Системная]:Неверная структура программы"), 

	ERROR_ENTRY_NODEF(3), ERROR_ENTRY_NODEF(4), ERROR_ENTRY_NODEF(5),
	ERROR_ENTRY_NODEF(6), ERROR_ENTRY_NODEF(7), ERROR_ENTRY_NODEF(8), ERROR_ENTRY_NODEF(9),
	ERROR_ENTRY_NODEF10(10), ERROR_ENTRY_NODEF10(20), ERROR_ENTRY_NODEF10(30), ERROR_ENTRY_NODEF10(40), ERROR_ENTRY_NODEF10(50),
	ERROR_ENTRY_NODEF10(60), ERROR_ENTRY_NODEF10(70), ERROR_ENTRY_NODEF10(80), ERROR_ENTRY_NODEF10(90),
	ERROR_ENTRY(100,"[Системная]:Параметр -in должен быть задан"),
	ERROR_ENTRY_NODEF(101),ERROR_ENTRY_NODEF(102),ERROR_ENTRY_NODEF(103),
	ERROR_ENTRY(104,"[Системная]:Превышена длина входного параметра"),
	ERROR_ENTRY_NODEF(105),ERROR_ENTRY_NODEF(106),ERROR_ENTRY_NODEF(107),
	ERROR_ENTRY_NODEF(108),ERROR_ENTRY_NODEF(109),
	ERROR_ENTRY(110,"[Системная]:Ошибка при открытии файла с исходным кодом (-in)"),
	ERROR_ENTRY(111,"[Лексическая ошибка]:Недопустимый символ в исходном файле (-in)"),
	ERROR_ENTRY(112,"[Системная]:Ошибка при создании файла протокола (-log)"),
	
	ERROR_ENTRY(200,"[Лексическая]:Ошибка при создании таблицы лексем: привышено максимальное количество строк"),
	ERROR_ENTRY(201,"[Лексическая]:Ошибка при добавлении: привышено максимальное количество строк в таблице лексем"),
	ERROR_ENTRY(202,"[Лексическая]:Ошибка при нахождении лексемы"),
	ERROR_ENTRY(203,"[Лексическая]:Привышен размер индентифекатора"),
	ERROR_ENTRY(204,"[Лексическая]:Привышен размер строки"),
	//ERROR_ENTRY_NODEF(119),
	ERROR_ENTRY_NODEF10(120),ERROR_ENTRY_NODEF10(130),ERROR_ENTRY_NODEF10(140),ERROR_ENTRY_NODEF10(150),
	ERROR_ENTRY_NODEF10(160),ERROR_ENTRY_NODEF10(170),ERROR_ENTRY_NODEF10(180),ERROR_ENTRY_NODEF10(190),
	
	//////////семант 
	ERROR_ENTRY(300,"[Семантическая]:Более одной точки входа main"),
	ERROR_ENTRY(301,"[Семантическая]:Отстутсвует точка входа main"),
	ERROR_ENTRY(302,"[Семантическая]:Типы операндов не совпадают при присаивании"),
	ERROR_ENTRY(303,"[Семантическая]:Множественная инициализация переменной"),
	ERROR_ENTRY(304,"[Семантическая]:Делить на 0 нельзя"),
	ERROR_ENTRY(305,"[Семантическая]:Типы операндов не совпадают в условной конструкции"),
	ERROR_ENTRY(306,"[Семантическая]:Данная арифметическая операция не доступна для строки"),
	ERROR_ENTRY(307,"[Семантическая]:Тип функции не совпадает с типом возвращаемого значения"),
	ERROR_ENTRY(308,"[Семантическая]:Инициализация неизвестной переменной"),
	ERROR_ENTRY(309,"[Семантическая]:аргументы, передаваемые в функцию, не совпадают с типами параметров в объявлении функции"),
	ERROR_ENTRY(310,"[Семантическая]:Инициализация цифры не может начинаться с 0"),
	ERROR_ENTRY(311,"[Семантическая]:Данные индентифекатор не может быть инициализирован числом со знаком"),
	ERROR_ENTRY(312,"[Семантическая]:Используется необъявленная переменная"),
	ERROR_ENTRY(313,"[Семантическая]:Передано больше аргументов в функцию чем ожидалось"),
	ERROR_ENTRY(314,"[Семантическая]:Передано меньше аргументов в функцию чем ожидалось"),
	ERROR_ENTRY(315,"[Семантическая]:Использование пустого строкового литерала недопустимо"),
	ERROR_ENTRY(316,"[Семантическая]:Обнаружен символ '.Возможно, не закрыт строковый литерал "),
	ERROR_ENTRY(317,"[Семантическая]:Недопустимый целочисленный литерал"),
	ERROR_ENTRY(318,"[Семантическая]:Неверное условное выражение"),
	ERROR_ENTRY(319,"[Семантическая]:Неверная структура комментария	"),
	ERROR_ENTRY(320,"[Семантическая]:Строковый литерал не закрыт"),
	ERROR_ENTRY(321,"[Семантическая]:Переданы неправильный параметры статической функции"),
	ERROR_ENTRY(322,"[Семантическая]:индентификатор может состоять только из букв ниженго регистра"),
	ERROR_ENTRY(323,"[Семантическая]:неизвестная последователльность символов"),

	

	ERROR_ENTRY(600,"[Синтаксическая]:Неверная структура программы"),
	ERROR_ENTRY(601,"[Синтаксическая]:Ошибка в параметрах функции"),
	ERROR_ENTRY(602,"[Синтаксическая]:Ошибка в логических операторах"),
	ERROR_ENTRY(603,"[Синтаксическая]:Ошибка в конструкции условного оператора"),
	ERROR_ENTRY(604,"[Синтаксическая]:Ошибка в теле условного оператора "),
	ERROR_ENTRY(605,"[Синтаксическая]:Ошибка в теле функции"),
	ERROR_ENTRY(606,"[Синтаксическая]:Ошибка в параметрах вызываемой функции"),
	ERROR_ENTRY(607,"[Синтаксическая]:Ошибка в операторах"),
	ERROR_ENTRY(608,"[Синтаксическая]:Ошибка в выражении"),
	ERROR_ENTRY(609,"[Синтаксическая]:Ошибка в структуре else"),
	ERROR_ENTRY(610,"[Синтаксическая]:Ошибка в параметрах условия"),
	ERROR_ENTRY(611,"[Синтаксическая]:Ошибка в объявлении функции"),
	ERROR_ENTRY(612,"[Синтаксическая]:Ошибка в инициализации переменной"),
	ERROR_ENTRY(613,"[Синтаксическая]:Ошибка отсутствует закрывающая лексема"),
	ERROR_ENTRY(614,"[Синтаксическая]:Ошибка в конструкции while"),

	
	ERROR_ENTRY(801,"Ошибка при разборе цепочек"),
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