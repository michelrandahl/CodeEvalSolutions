sum(
    map(
        int,
        filter(
            lambda c: c != '\n',
            list("123\n")
        )
    )
)
list("123")

import sys


with open(sys.argv[1], 'r') as test_cases:
    for test in test_cases:
        result = sum(
            map(
                int,
                filter(
                    lambda c: c != '\n',
                    list(test)
                )
            )
        )
        print(result)
