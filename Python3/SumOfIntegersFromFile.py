import sys

with open(sys.argv[1], 'r') as test_cases:
    xs = [int(number) for number in test_cases]
    print(sum(xs))
