import operator
import sys
from functools import reduce
from typing import List
import math

def chunkList(xs, n):
    for i in range(0, len(xs), n):
        yield xs[i:i+n]

test = "4;2,1,3,2,3,2,1,4,1,4,2,3,2,3,4,1"

def createSudoku(input: str):
    line_args = input.strip().split(";")
    N = int(line_args[0])
    numbers = line_args[1].split(",")

    if len(numbers) != N**2: raise Exception("error in args")

    for n in range(0,N):
        start = n*N
        yield numbers[start:start+N]

def checkRows(m: List[List[str]]) -> bool:
    if len(m) == 0: return True
    else:
        row = m[0]
        if len(set(row)) == len(row):
            return checkRows(m[1:])
        else: return False

def getColumns(m: List[List[str]]) -> List[List[str]]:
    for i in range(0,len(m)):
        yield [row[i] for row in m]

def checkColumns(m: List[List[str]]) -> bool:
    return checkRows(
        list(getColumns(m))
    )

def getSquares(m: List[List[str]]) -> List[List[str]]:
    N = len(m)
    n = int(math.sqrt(N))
    row_chunks = list(map(lambda xs: list(chunkList(xs, n)), m))
    return reduce(
        operator.add,
        [[reduce(operator.add, xs) for xs in getColumns(chunk)]
         for chunk in chunkList(row_chunks, n)]
    )

def checkSquares(m: List[List[str]]) -> bool:
    return checkRows(
        list(getSquares(m))
    )

def checkSudoku(m: List[List[str]]) -> bool:
    return checkRows(m) and checkColumns(m) and checkSquares(m)


#m = list(createSudoku(test))
m = [['8', '7', '1', '4', '6', '9', '3', '5', '2'], ['4', '2', '6', '3', '5', '1', '8', '9', '7'], ['5', '9', '3', '7', '2', '8', '4', '6', '1'], ['3', '5', '2', '9', '4', '7', '6', '1', '8'], ['6', '4', '9', '1', '8', '2', '5', '7', '3'], ['1', '8', '7', '5', '3', '6', '2', '4', '9'], ['9', '6', '4', '2', '1', '3', '7', '8', '5'], ['7', '3', '8', '6', '9', '5', '1', '2', '4'], ['2', '1', '5', '8', '7', '4', '9', '3', '6']]
m
N = len(m)
n = int(math.sqrt(N))
#row_chunks = [row[i*n:i*n+n] for row in m for i in range(0,n)]
row_chunks = list(map(lambda xs: list(chunkList(xs, n)), m))
row_chunks
xs = reduce(operator.add, [[reduce(operator.add, xs) for xs in getColumns(chunk)] for chunk in chunkList(row_chunks, n)])
xs
getSquares(m)
list(getColumns(m))
checkSudoku(m)

with open(sys.argv[1], 'r') as test_cases:
    for line in test_cases:
        if checkSudoku(list(createSudoku(line))):
            print("True")
        else: print("False")


