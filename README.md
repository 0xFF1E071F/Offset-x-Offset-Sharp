# Offset-x-Offset-Sharp
[![License: MIT](https://img.shields.io/badge/License-MIT-blue.svg?style=flat)](https://github.com/cobrce/Offset-x-Offset-Sharp/blob/master/LICENSE)

## Description 
Offset x Offset sharp is the C# version of the program (offset x offset) that I've written in assembly around 2011 
Its purpose is to find the viral signature of your programs i.e which part of the program is rising the flag, so you can change your program to avoid fake AV detections.

## How it works
After selecting the "variable range" and the fixed ranges (optional) OXOSharp will create copies of the input file in the output folder, in each copy a range of bytes (from the variable range with the selected size) is replaced by dummy values (as configured).
If the false viral signature is inside the selected "variable range" it's possible that atleast one of the created file has it overwritten.
This explains how the "Fixed size" mode works, it this fails because of the impossiblity to find exactly the beginning and the end of range (a very big signature), the unknown size modes can be used

## Features 
* Easy to use : Auto calculating step, selecting range from PE sections and the easy reintegration of previous result make the process easier
* Various bytes operation : can replace bytes by fixed value, by boolean not or xor with a random value.
* Fixed ranges : in case of large signature which is a signe of multiple signatures, a fixed range can be added, this range will have bytes replaced in every created file.
* Different modes :
    * Fixed size range : the range (that get bytes replaced) for every created file is adjacent to the previous and have the same size.
    * Unknown size from start/end : the range for every created file has the same end (resp. start) offset and moving start (resp. end) offset and the range is included in the previous and smaller in size.
* Auto/Manual save session : the current session (ranges) is saved and load automatically when close/open the program, you can also save them manually 
* Scan button : you can configure the program for the location of a console antivirus and its command line

## How to use
Drop a file in the "File" textbox
In variable range input a range (or leave the default)

![alt text](https://raw.githubusercontent.com/cobrce/Offset-x-Offset-Sharp/master/screenshots/1_variable_range_.png)

(optional) You can select a fixed range from sections (in first tab) or enter it manually (in the second tab), if you don't know what to put don't use it

![alt text](https://raw.githubusercontent.com/cobrce/Offset-x-Offset-Sharp/master/screenshots/2_fixed_ranges.png)

In byte operations select how the bytes should be replaced (personally I use only "xor with random", the other modes are adde because other users may have different preference)

![alt text](https://raw.githubusercontent.com/cobrce/Offset-x-Offset-Sharp/master/screenshots/3_bytes_operation.png)

Select the mode (explained above, or you can press the "?" button to see how it works)
![alt text](https://raw.githubusercontent.com/cobrce/Offset-x-Offset-Sharp/master/screenshots/4_mode.png)

Press Go, the progress bar will fill, ones done scan the output folder, repeat selecting variable/fixed range(s) until you get the smallest undetected range which represent the viral signature.

## What to do with the signature
Depending on the nature of the signature, data or code (in which sections it's found), is the program native or .net:
* Native :
  * Code : you can move the code to a code cave or replace it with an equivalent one i.e different/obfuscated/encrypted instruction that do the same function.
  * Data : I not used by the program (some stuff added by the compiler) fill it with blank, if used try to encrypt/decryp them or inline them (depends of the size)
* .Net :
  * Metadata : it's possible that the name of methods/classes cause detections, rename them
  * Code : try obfuscating the detected method

## Got signature, but none of the above work
Maybe the detection is not signature base but heuristic (based on behaviour), and the work of OXOSharp just broke the program (so its execution inside AV loader didn't yield any suspect behaviour).
This program doesn't work for this cas

## Disclaimar
The purpose of this program is to get rid of the false AV detections, you're the only responsible of what you do
