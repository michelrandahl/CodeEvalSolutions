import sys
from functools import reduce

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
