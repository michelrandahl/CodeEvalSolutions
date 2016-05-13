import sys
from itertools import islice

with open(sys.argv[1], 'r') as test_cases:
    lines = [test for test in test_cases]
    N = int(lines[0])
    top_N = islice(
        reversed(sorted(lines[1:], key=len)),
        N
    )
    for line in top_N:
        print(line)


