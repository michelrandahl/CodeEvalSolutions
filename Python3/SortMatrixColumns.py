import sys
from typing import List, Iterable, Tuple
from itertools import groupby, chain

from matplotlib.cbook import todate

input = """
4 83 19 -13 -19 | 56 34 17 25 4 | -1 37 86 68 19 | -7 59 -15 98 -86 | 41 51 8 -38 -93
-3 29 -3 | -17 69 -17 | 44 3 8
25 39 -26 -21 | -81 -98 -91 27 | 32 -87 67 98 | -90 -79 18 9
26 -10 39 | -62 66 97 | 22 85 36
"""

input2 = "-3 29 -3 | -17 69 -17 | 44 3 8"

def parseLine(line: str) -> Iterable[List[int]]:
    for xs in line.split("|"):
        yield [int(x) for x in xs.strip().split(" ")]

def sortAndCreateMask(matrix_row: List[int]) -> Tuple[List[int], List[int]]:
    indexed_row = zip(range(0, len(matrix_row)), matrix_row)
    sorted_indexed = sorted(
        indexed_row,
        key=lambda entry: entry[1]
    )
    sorted_row = [entry[1] for entry in sorted_indexed]
    mask = [entry[0] for entry in sorted_indexed]
    return sorted_row, mask

def orderRowByMask(row: List[int], mask: List[int]) -> Iterable[Tuple[int, int]]:
    for i in range(0, len(row)): yield row[mask[i]], mask[i]

def splitRowIntoSortedGroups(prev_row: List[int], mask_sorted_row: List[Tuple[int, int]]) -> Iterable[List[Tuple[int, int]]]:
    for k, g in groupby(zip(prev_row, mask_sorted_row), lambda e: e[0]):
        yield list(sorted(
            map(lambda e: e[1], g),
            key=lambda e: e[0]
        ))

def allNumbersUnique(xs: List[int]) -> bool:
    return len(xs) == len(set(xs))

def sortMatrixColumns(input: str) -> Iterable[List[int]]:
    parsed_matrix = list(parseLine(input))
    first_row_sorted, mask = sortAndCreateMask(parsed_matrix[0])
    yield first_row_sorted
    prev_row = first_row_sorted

    mask_stable = allNumbersUnique(first_row_sorted)

    for row_id in range(1, len(parsed_matrix)):
        ordered_by_mask = list(orderRowByMask(parsed_matrix[row_id], mask))
        if not mask_stable:
            sorted_row_and_mask = list(zip(*chain(
                *splitRowIntoSortedGroups(prev_row, ordered_by_mask)
            )))
            sorted_row = list(sorted_row_and_mask[0])
            mask_stable = allNumbersUnique(sorted_row)
            mask = list(sorted_row_and_mask[1])
            prev_row = sorted_row
            yield sorted_row
        else:
            sorted_row = [x[0] for x in ordered_by_mask]
            prev_row = sorted_row
            yield sorted_row

def printSortedMatrix(matrix: Iterable[List[int]]) -> None:
    result = " | ".join([" ".join(map(str, row)) for row in matrix])
    print(result)

printSortedMatrix(sortMatrixColumns(input2))

with open(sys.argv[1], 'r') as test_cases:
    for test in test_cases:
        matrix = sortMatrixColumns(test)
        printSortedMatrix(matrix)
