import sys
from math import sqrt
from typing import List, Iterable

def createMatrix(input: str) -> Iterable[List[str]]:
    input_list = input.split(" ")
    N = int(sqrt(len(input_list)))
    for n in range(0,N):
        begin = n*N
        yield input_list[begin:(begin+N)]

def rotateMatrix(matrix: List[List[str]]) -> List[List[str]]:
    return list(zip(*matrix[::-1]))

with open(sys.argv[1], 'r') as test_cases:
    for test in test_cases:
        m = list(createMatrix(test.strip()))
        rotated = rotateMatrix(m)
        print(
            " ".join([" ".join(x) for x in rotated])
        )
