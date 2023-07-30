.586
.model flat, stdcall
includelib libucrt.lib
includelib kernel32.lib
includelib "Project2.lib
ExitProcess PROTO:DWORD 
.stack 4096


  EXTRN outnum:proc

 EXTRN outstr:proc

 EXTERN compare :PROC

 EXTERN concat :PROC

 EXTERN npow :PROC

.const
		newline byte 13, 10, 0
		L0 byte 'word', 0
		L1 byte 'hellow ', 0
		L2 byte 'concat(ma,mb): ', 0
		L3 sdword 5
		L4 byte 'x pow y=', 0
		L5 sdword 10
		L6 byte 'вывод четных чисел', 0
		L7 sdword 0
		L8 sdword 2
		L9 sdword 0
		L10 sdword 1
		L11 sdword 1
		L12 sdword 5
		L13 byte '(x+y)*5=', 0
		L14 sdword 5
		L15 sdword 4
		L16 sdword 2
		L17 byte 'dskl', 0
		L18 byte 'dskl', 0
		L19 byte 'lenght(ma): ', 0
		L20 byte 'compare(ma,mb): ', 0
		L21 byte 'dddddddddddskl', 0
		L22 byte 'second condition', 0
		L23 byte 'dddddddddddskl', 0
		L24 byte 'oooosssn', 0
		L25 byte '1+(3+5)/4=', 0
		L26 sdword 0
.data
		temp sdword ?
		buffer byte 256 dup(0)
		kvadr_mk dword ?
		kvadr_ma dword ?
		kvadr_mb dword ?
		kvadr_m sdword 0
		fi_j sdword 0
		fi_b sdword 0
		fi_m sdword 0
		fi_ba sdword 0
		k sdword 0
		p sdword 0
		m sdword 0
		ffffffff sdword 0
		ma dword ?
		mb dword ?
.code
error:call ExitProcess


  lenght:
mov eax, 0
@1:
inc eax
cmp byte ptr[eax + edi], 0
jnz @1

ret


;------------- kvadr --------------
kvadr PROC,
	kvadr_x : sdword, kvadr_y : sdword, 
; ---------------------
push ebx
push edx
; -------------------------------
mov kvadr_mb, offset L0
mov kvadr_ma, offset L1
push kvadr_mb
push kvadr_ma
call concat
push eax

pop ebx
mov kvadr_mk, ebx

push offset newline
call outstr


push offset L2
call outstr


push kvadr_mk
call outstr

push L3
push kvadr_x
call npow
push eax

pop ebx
mov kvadr_m, ebx

push offset newline
call outstr


push offset L4
call outstr


push kvadr_m
call outnum

; ------------------
pop edx
pop ebx
; -------------------------------
mov eax, kvadr_m
ret
kvadr ENDP
;---------------


;------------- fi --------------
fi PROC,
	fi_x : sdword, fi_y : sdword, 
; ---------------------
push ebx
push edx
; -------------------------------
push L5

pop ebx
mov fi_j, ebx


push offset L6
call outstr

mov edx, fi_j
cmp edx, L7

jg right1
jl wrong1

right1:
push fi_j
push L8
pop ebx 
mov edx, 0 
pop eax 
idiv ebx 
push edx 
mov eax, edx

pop ebx
mov fi_b, ebx

mov edx, fi_b
cmp edx, L9

jz right2
jnz wrong2

right2:
push offset newline
call outstr


push fi_j
call outnum

wrong2:
push fi_j
push L10
pop ebx
pop eax
sub eax, ebx
push eax

pop ebx
mov fi_j, ebx


mov edx, fi_j
cmp edx, L7

jg right1
wrong1:
push L11

pop ebx
mov fi_ba, ebx

mov edx, fi_ba
cmp edx, 1 

jz right3
jnz wrong3

right3:
push fi_x
push fi_y
pop ebx
pop eax
add eax, ebx
push eax
push L12
pop ebx
pop eax
imul eax, ebx
push eax

pop ebx
mov fi_m, ebx

wrong3:
push offset newline
call outstr


push offset L13
call outstr

; ------------------
pop edx
pop ebx
; -------------------------------
mov eax, fi_m
ret
fi ENDP
;---------------


;------------- MAIN --------------
main PROC
push L14

pop ebx
mov k, ebx

push L15

pop ebx
mov p, ebx

push p
push k
call fi
push eax

pop ebx
mov k, ebx


push k
call outnum

push p
push L16
call kvadr
push eax

pop ebx
mov p, ebx

mov edx, k
cmp edx, p

jg right4
jl wrong4

right4:
mov ma, offset L17
mov mb, offset L18
push ma
call lenght
push eax

pop ebx
mov m, ebx

push offset newline
call outstr


push offset L19
call outstr


push ma
call outstr


push m
call outnum

push offset newline
call outstr


push offset L20
call outstr

push mb
push ma
call compare
push eax

pop ebx
mov ffffffff, ebx


push ffffffff
call outnum


mov eax, 1 
jz osn4
wrong4:

push offset L21
call outstr


osn4:
mov edx, k
cmp edx, p

jg right5
jl wrong5

right5:
push offset newline
call outstr


push offset L22
call outstr


mov eax, 1 
jz osn5
wrong5:

push offset L23
call outstr


osn5:
push offset newline
call outstr


push offset L24
call outstr

push offset newline
call outstr


push offset L25
call outstr


push k
call outnum

push 0
main ENDP
call ExitProcess
end main
