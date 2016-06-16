import sys


def mthLast(input: str):
    xs = input.split(' ')
    n = int(xs[-1]) + 1
    i = len(xs) - n
    if i >= 0: return xs[i]
    else:     return ""

with open(sys.argv[1], 'r') as test_cases:
    for line in test_cases:
        res = mthLast(line)
        if res != "": print(res)
