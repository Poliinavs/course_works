#include <iostream>

extern "C" {
	
	int outstr(char* ptr)									
	{
		setlocale(LC_ALL, "Russian");
		if (ptr == nullptr)
			std::cout << std::endl;
		for (int i = 0; ptr[i] != '\0'; i++)
			std::cout << ptr[i];
		return 0;
	}
	
	int outnum(int value)
	{
			std::cout << value;
		return 0;
	}
	int lenght( char* str)					// вычисление длины строки
	{
		if (str == nullptr)
			return 0;
		int len = 0;
		for (int i = 0; i < 256; i++)
			if (str[i] == '\0')
			{
				len = i; break;
			}
		return len;
	}
	unsigned short compare(char* a, char* b)
	{
		if (strcmp(a, b) < 0)
		{
			std::cout << "strings are not equal: " ;
			return 0;
		}
		if (strcmp(a, b) == 0)
		{
			std::cout << "strings are equal: ";
			return 1;
		}
		if (strcmp(a, b) > 0)
		{
			std::cout << "strings are not equal ";
			return 2;
		}
	}
	char* concat(char* buffer, char* str)				// копирование строк
	{
		setlocale(LC_ALL, "Russian");
		int i = NULL, len1 = NULL, len2 = NULL;
		len1 = lenght(buffer);
		len2 = lenght(str);
		char* newSTR=new char[len1 + len2];
		for (int j = 0; buffer[j] != '\0'; j++)
		{
			newSTR[j] = buffer[j];
		}
		for (int j = 0; str[j] != '\0'; j++)
		{
			newSTR[len1 + j] = str[j];
		}
		newSTR[len1 + len2] = '\0';
		return newSTR;
	}
	
	int npow(int num, int exp) {
		return pow(num, exp);
	}

	int getmin(int arr[], int size)
	{
		int min = 2147483647;
		for (int i = 0; i < size; i++)
		{
			if (min > arr[i])
			{
				min = arr[i];
			}
		}
		return min;
	}

	int getmax(int arr[], int size)
	{
		int max = -2147483648;
		for (int i = 0; i < size; i++)
		{
			if (max < arr[i])
			{
				max = arr[i];
			}
		}
		return max;
	}
}