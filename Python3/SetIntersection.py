import sys
from functools import reduce

list(
    reduce(
        set.intersection,
        map(
            lambda s: set(
                map(int, s.split(','))
            ),
            "76,77,78,79,80,81;71,72,73,74,75,76,77,78".split(';')
        )
    )
)

with open(sys.argv[1], 'r') as test_cases:
    for test in test_cases:
        result = list(
            reduce(
                set.intersection,
                map(
                    lambda s: set(
                        map(int, s.split(','))
                    ),
                    test.split(';')
                )
            )
        )
        print(
            ','.join(
                map(str, sorted(result))
            )
        )
