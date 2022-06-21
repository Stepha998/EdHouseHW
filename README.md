# EdHouse homework - find a lunch spot for drivers

This program finds a lunch spot for drivers where their tracks intersect and when it is time for a lunch break.

## Usage

```
./EdHouseHW.exe
```

The program looks primarily for input from a file `input.txt` in the same folder as .exe file.

If that file is not found, a new file path can be specified in an argument at the start of the program in way such as:


```
./EdHouseHW.exe newFile.txt
```

If file `input.txt` is not found and no other file is specified in arguments, the program starts to expect input from standard input, such as a keyboard.

## Format of the input

Input has to be formatted.

Example:

```
5-10
3E,4N,4W,2S
2W,3N,3E,3N
```

The first line is for the lunch break interval (a closed interval).

The second line is for specifying the directions of the first driver.

The second line is for specifying the directions of the second driver.

Directions consist of a numerical value: number of steps taken, and cardinal direction: direction of the steps.

## Output

If successful, the program prints the location of the lunch (intersection of the driver's tracks).

If not successful, the program throws an exception: in case of no location found - NoPlaceForLunchFoundException, in case of error in input - InputException.

## Github

Click [here](https://github.com/Stepha998/EdHouseHW) to visit a github repository of this project.