

include windows.inc
include kernel32.inc
include user32.inc
includelib kernel32.lib
includelib user32.lib

include c:\masm32\macros\macros.asm

Process proto lpBuffer:DWORD,dwBufferSize:DWORD,dwType:DWORD,dwFill:DWORD,dwStart:DWORD,dwEnd:DWORD,dwSize:DWORD,dwCallBack:DWORD
CopyBuffer proto lpSourceBuffer:DWORD,lpDestinationBuffer:DWORD,RelativeStartAddress:DWORD,SizeOfInterval:DWORD
FreeTempBuffer proto lpTempBuffer:DWORD

.const
; how to fill the range
_value equ 0
_not equ 1
_random equ 2

; how the range is made (fixed size or unknows size that varies with step)
_normal equ 0
_unknownFromStart equ 256
_unknownFromEnd equ 512


.data
hInstance HINSTANCE ?
dwStep dword ? ; the step from range start to actual range
dwStop dword ? ; endof range reached
;lpTempBuffer dword ? ; contains a pointer to the allocated memory, used by FreeTempBuffer function in case of thread stoped before the memory is freed
_dwBufferSize dword ? ; a copy of dwBufferSize to be used by FreeTempBuffer function

if debug
lpszText db "Process called",00
lpszCaption db "OxO",00
endif

.code
Random proc uses edx
	rdtsc	
	.if !al
		inc al ; insure a non null random value
	.endif
	Ret
Random EndP