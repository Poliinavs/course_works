#pragma once
#include "stdafx.h"


#define SEPSTREMP  "\n;---------------\n"
#define SEPSTR(x)  "\n;------------- " + string(x) + " --------------\n"


#define BEGIN ".586\n"\
".model flat, stdcall\n"\
"includelib libucrt.lib\n"\
"includelib kernel32.lib\n"\
"includelib \"Project2.lib\n"\
"ExitProcess PROTO:DWORD \n"\
".stack 4096\n"

#define EXTERN "\n  EXTRN outnum:proc\n"\
"\n EXTRN outstr:proc\n"\
"\n EXTERN compare :PROC\n"\
"\n EXTERN concat :PROC\n"\
"\n EXTERN npow :PROC\n"\

//"\n  EXTRN lenght:proc\n"\

#define FUNC_LENGHT "\n  lenght:\n"\
"mov eax, 0\n"\
"@1:\n"\
"inc eax\n"\
"cmp byte ptr[eax + edi], 0\n"\
"jnz @1\n"\
"\nret\n"\

#define DEL "\n  mov edx, 0\n"\
"\n cmp edx, "\

#define END "push 0\nmain ENDP\ncall ExitProcess\nend main"

#define ITENTRY(x)  idtable.table[lextable.table[x].idxTI]
#define LEXEMA(x)   lextable.table[x].lexema


#define CONST ".const\n\t\tnewline byte 13, 10, 0"
#define DATA ".data\n\t\ttemp sdword ?\n\t\tbuffer byte 256 dup(0)"
#define CODE ".code\nerror:call ExitProcess\n"

namespace Gener
{
	void CodeGeneration(LT::LexTable& lextable, IT::IdTable& idtable);
};