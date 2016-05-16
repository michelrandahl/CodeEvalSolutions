import sys

def findDuplicate(xs):
    if len(xs) >= 2:
        x = xs.pop(0)
        if x == xs[0]:
            return x
        else:
            return findDuplicate(xs)

with open(sys.argv[1], 'r') as test_cases:
    for test in test_cases:
        xs = [int(x) for x in test.split(";")[1].split(",")]
        print(
            findDuplicate(sorted(xs))
        )
