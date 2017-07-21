; oxoSharp is a project based on OffsetXoffset with .Net GUI and an asm core (this dll)

.686
.model flat,stdcall
option casemap:none

debug equ FALSE

include OxOsharp.inc


.Code
Start:
dllentrypoint proc hinstance:HINSTANCE,dwReason:DWORD,dwReserved:DWORD

	.if dwReason == DLL_PROCESS_ATTACH
		push hinstance
		pop hInstance
	.endif
	xor eax,eax
	inc eax
	Ret
dllentrypoint EndP

comment ^

      /~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~/
     / This is the most important function of the dll,  /
    / the code looks somehow dirty and it could be     /
   / easily cleaner, but it's optimized for speed     /
  / not for readability. However, I tried to comment /
 / as much as possible.                             /
/~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~/

^
Process Proc uses esi edi ebx lpBuffer:DWORD,dwBufferSize:DWORD,dwType:DWORD,dwFill:DWORD,dwStart:DWORD,dwEnd:DWORD,dwSize:DWORD,dwCallBack:DWORD

	local fill:BYTE,rangeType:BYTE,lpTempBuffer:DWORD
	

if debug
	invoke MessageBox,0,addr lpszText,addr lpszCaption,MB_ICONINFORMATION
endif
	;-----------------------------------------------;
	; Create a temporary memory and copy data to it ;
	;-----------------------------------------------;
	mov lpTempBuffer,rv(VirtualAlloc,0,dwBufferSize,MEM_COMMIT or MEM_RESERVE,PAGE_READWRITE)
	push dwBufferSize ; copy to a global variable (to be used in FreeTempBuffer)
	pop _dwBufferSize
	invoke CopyBuffer,lpBuffer,lpTempBuffer,0,dwBufferSize

	;-------------------;
	; Check parameteers ;
	;-------------------;
	mov eax,dwBufferSize
	.if dwEnd > eax
		push eax
		pop dwEnd
	.endif
	
	;----------------------------------------------;
	; Rename registers to make code easier to read ;
	;----------------------------------------------;
	size_of_interval equ ecx
	absolute_start_address equ edi
	absolute_end_address equ edx
	relative_start_address equ ebx
	
	;------------------------------;
	; calculate <size_of_interval> ;
	;------------------------------;
	mov eax,dwType
	mov rangeType,ah ; normal range, unknown size move from start, unknown size move from end
	mov fill,al
	.if ah ; _unknownFromStart or _unknownFromEnd
		mov size_of_interval,dwEnd
		sub size_of_interval,dwStart	
	.else
		mov size_of_interval,dwSize
	.endif
	
	
	;------------------------------------;
	; calculate <absolute_start_address> ;
	;------------------------------------;	
	mov edx,lpTempBuffer
	mov absolute_start_address,dwStart
	add absolute_start_address,edx
	
	;----------------------------------;
	; calculate <absolute_end_address> ;
	;----------------------------------;	
	add absolute_end_address,dwEnd
	
	; use a while loop to create each time a file with a different range filled according to
	; parameters
	.While absolute_start_address < absolute_end_address
		
		; check for "out of interval"
		mov eax,absolute_end_address
		sub eax,absolute_start_address
		.if eax < size_of_interval ; if size > end-start then size = end-start
			mov size_of_interval,eax
		.endif
		
		; calculate <relative_start_address> to be used later to restore the filled bytes
		; relative = absolute - lpTempBuffer 
		mov relative_start_address,absolute_start_address
		sub relative_start_address,lpTempBuffer
		
		; save current values
		push absolute_start_address
		push size_of_interval
			
		;;;;;;                                      ;;;;;
		;;                                             ;; 
		;; THE JOB IS DONE INSIDE THIS CALLED FUNCTION ;;
		;;                                             ;;
		;;                                             ;;
			mov al, byte ptr[dwFill]
			mov ah,fill
			call FillIntervalLoop
		;;                                             ;;
		;;                                             ;; 
		;; THE JOB IS DONE INSIDE THIS CALLED FUNCTION ;;
		;;                                             ;;
		;;;;;;                                      ;;;;;
		
			; based on the C# definition of the callbak method
			; ...void CallBackDelegate(byte* buffer, int CurrentStart, int CurrentEnd, int size);
			
			mov eax,dword ptr[esp+4] ; saved absolute_start_address
			pushad
				mov ecx,lpTempBuffer
				neg ecx
				
				add eax,ecx ; now eax is relative_start_address
				
				; actually edi is  the end of the freshly filled interval
				add ecx,absolute_start_address;  now ecx is relative_end_address
				
				push dwBufferSize ; size
				push ecx ; CurrentEnd
				push eax ; CurrentStart
				push lpTempBuffer ; buffer
				mov eax,dwCallBack
				call eax ;
				
;				test eax,eax
;				je @end
				.if !eax
					ret;
				.endif
			popad
			; at this point the file is created
			; call the GUI callback method between pushad/popad and check if continue or leave
		
		; restore size_of_interval (it's actually ecx which is null after the loop, so we restore it)
		pop size_of_interval
		
		;-------------------------------------------------------------;
		; Restore the TempBuffer by recopying just the replaced bytes ;
		;-------------------------------------------------------------;
		invoke CopyBuffer,lpBuffer,lpTempBuffer,relative_start_address,size_of_interval
		
		;--------------------------------------------------------;
		; update <absolute_start_address> and <size_of_interval> ;
		;--------------------------------------------------------;
		.if rangeType ; range type is either _unknownFromStart or _unknownFromEnd
			; in this case edi should be restored...
			pop absolute_start_address
			; and sizeo_of_interval is reduced by dwSize which is used in this mode as "step" instead of actual "size" 
			.if size_of_interval < dwSize
				xor size_of_interval,size_of_interval
			.else
				sub size_of_interval,dwSize
			.endif
			
			.if rangeType == (_unknownFromStart / 256) ; because the flag was shifted to the right
				; in _unknownFromStart the interval should be moved from the start
				add absolute_start_address, dwSize
			.else
				sub absolute_end_address,dwSize
			.endif
		.else
			; this is in the case of _normal rangeType absolue_start_address already has
			; the correct value so we discard what we saved in the stack
			add esp,4 ; clear edi from stack
		.endif
	.endw
@end:
	invoke FreeTempBuffer,lpTempBuffer
	Ret
Process EndP

; this function doesn't copy the buffer, it writes over the original one
FillFixedRange proc lpBuffer:DWORD,dwBufferSize:DWORD,dwType:DWORD,dwFill:DWORD,dwStart:DWORD,dwEnd:DWORD
	
	;-------------------;
	; Check parameteers ;
	;-------------------;
	mov eax,dwBufferSize
	.if dwEnd > eax
		push eax
		pop dwEnd
	.endif
	
	mov eax,dwType
	mov ah,al
	mov al,byte ptr[dwFill]
		
	mov ecx,dwStart
	mov absolute_start_address,lpBuffer
	add absolute_start_address,ecx
	
	neg size_of_interval
	add size_of_interval,dwEnd
	
	call FillIntervalLoop
	Ret
FillFixedRange EndP

; parameter already in registers
FillIntervalLoop proc
	fill equ ah
	; fill interval according to parameters
	.if fill == _value ; in _value mode fill the interval with desired value  
		; al must already contain dwFill
		rep stosb
	.else ; _random or _not
		@@:
			.if fill == _not ; apply "not" to every byte of the interval
				not byte ptr[edi]
			.else ; _random
				call Random
				xor byte ptr[edi],al ; make sure that value actually changes 
			.endif
			inc edi
		loop @b
	.endif
	Ret
FillIntervalLoop EndP

CopyBuffer proc lpSourceBuffer:DWORD,lpDestinationBuffer:DWORD,RelativeStartAddress:DWORD,SizeOfInterval:DWORD

	pushad
	
	mov esi,lpSourceBuffer
	add esi,RelativeStartAddress
	
	mov edi,lpDestinationBuffer
	add edi,RelativeStartAddress
	
	mov ecx,SizeOfInterval
	push ecx
		shr ecx,2
		rep movsd
	pop ecx
	and ecx,3
	rep movsb
	
	popad

	Ret
CopyBuffer EndP
FreeTempBuffer proc lpTempBuffer:DWORD
	.if lpTempBuffer
		invoke VirtualFree,lpTempBuffer,0,MEM_RELEASE
		mov lpTempBuffer,00
	.endif
	Ret
FreeTempBuffer EndP

End Start