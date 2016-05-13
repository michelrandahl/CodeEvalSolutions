import sys
import math


def mymod(n: int, m: int) -> int:
    return n - math.floor(n / m) * m

mymod(20, 7)

with open(sys.argv[1], 'r') as test_cases:
    for test in test_cases:
        args = test.split(",")
        n = int(args[0])
        m = int(args[1])
        print(mymod(n, m))
