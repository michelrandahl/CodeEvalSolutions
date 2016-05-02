import sys


def longestWord(words):
    l = len(words)
    if l == 1:
        return words[0]
    elif l >= 2:
        if len(words[1]) > len(words[0]):
            return longestWord([words[1]] + words[2:])
        else:
            return longestWord([words[0]] + words[2:])


with open(sys.argv[1], 'r') as test_cases:
    for test in test_cases:
        result = longestWord(
            test.strip().split(' ')
        )
        print(result)
