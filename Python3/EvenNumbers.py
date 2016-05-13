import sys

with open(sys.argv[1], 'r') as test_cases:
    for test in test_cases:
        if int(test) % 2 == 0:
            print(1)
        else:
            print(0)
