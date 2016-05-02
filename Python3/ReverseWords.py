test = "U1dtzfnrgg 3Q u LZ guoxLzJGdVY 7Z4r1PqeGIYnS1S1a3WHe5K"
result = " ".join(
    reversed(
        test.split(' ')
    )
)
print(result)

import sys

with open(sys.argv[1], 'r') as test_cases:
    for test in test_cases:
        result = [x for x in
                  reversed(test.strip().split(' '))]
        print(' '.join(result))
