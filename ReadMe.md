# EdHouse homework - find a lunch spot for drivers

This program finds a lunch spot for drivers where their tracks intersect and when it is time for a lunch break.

## Usage

Program looks primarly for input from file `input.txt` in the same folder as .exe file. 
If that file is not found, new file path can be specified in an argument at the start of the program in the way such as:
```bash
./EdHouseHW.exe newFile.txt
```
If file `input.txt` is not found and no other file is specified in arguments, program starts to expecting input from standard input, such as keyboard.

## Format of the input

Input has be formatted.
Example:
```
5-10
3E,4N,4W,2S
2W,3N,3E,3N
```
First line is for lunch break interval.
Second line is for specifying directions of the first driver.
Second line is for specifying directions of the second driver.
