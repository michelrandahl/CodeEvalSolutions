import sys
from itertools import islice
from typing import List

def permutations(xs: List[int]):
    N = len(xs)
    for to_take in range(1,N+1):
        for to_skip in range(0,N):
            if to_take + to_skip <= N:
                yield islice(xs,to_skip,to_skip+to_take)

with open(sys.argv[1], 'r') as test_cases:
    for test in test_cases:
        xs = list(map(int, test.split(",")))
        result = max(map(sum, permutations(xs)))
        print(result)
