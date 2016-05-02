import sys
import re


def trailingString(line: str):
    linesplit = line.split(',')
    sentence = linesplit[0]
    word = linesplit[1]
    if re.search(word + "$", sentence):
        print(1)
    else:
        print(0)


test = "Hello CodeEval,CodeEval\n"
trailingString(test)

with open(sys.argv[1], 'r') as test_cases:
    for test in test_cases:
        trailingString(test.strip())
