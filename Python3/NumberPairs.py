import sys
from typing import List


def permute(xs: List[int]):
    if len(xs) > 0:
        x = xs[0]
        for y in xs[1:]:
            yield x, y
        yield from permute(xs[1:])

with open(sys.argv[1], 'r') as test_cases:
    for test in test_cases:
        test_list = test.split(";")
        numbers = [int(x) for x in test_list[0].split(",")]
        sum = int(test_list[1])
        pairs = list(filter(
            lambda x: x[0] + x[1] == sum,
            permute(numbers)
        ))
        if len(pairs) == 0:
            print("NULL")
        else:
            print(
                ";".join(["%d,%d" % (x[0], x[1]) for x in
                         sorted(pairs, key=lambda x: x[0])])
            )


