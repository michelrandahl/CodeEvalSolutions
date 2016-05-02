import sys


def stackImplementation(input: str):
    stack = input.split(' ')
    result = ""
    while True:
        result = "%s %s" % (result, stack.pop())
        if not stack: break
        stack.pop()
        if not stack: break
    return result.lstrip()


test = "1 2 3 4"
print(stackImplementation(test))

with open(sys.argv[1], 'r') as test_cases:
    for test in test_cases:
        print(stackImplementation(test.strip()))
