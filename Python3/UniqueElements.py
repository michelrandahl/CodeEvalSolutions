import sys


test = "1,1,1,2,2,3,3,4,4"
numbers = test.strip().split(',')
numbers_set = set(numbers)
print(numbers_set)

with open(sys.argv[1], 'r') as test_cases:
    for test in test_cases:
        numbers = test.strip().split(',')
        numbers_set = set(map(int, numbers))
        print(",".join(map(str, sorted(numbers_set))))
