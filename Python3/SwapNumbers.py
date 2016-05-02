import sys
import re

test = "4Always0 5look8 4on9 7the2 4bright8 9side7 3of8 5life5"
test.split(' ')


def swapNumbers(word: str):
    m = re.match(r"(?P<d1>\d+)(?P<word>.+)(?P<d2>\d+)", word)
    gd = m.groupdict()
    return gd['d2'] + gd['word'] + gd['d1']

' '.join([swapNumbers(w) for w in test.split(' ')])


with open(sys.argv[1], 'r') as test_cases:
    for test in test_cases:
        print(
            ' '.join([swapNumbers(w) for w in
                      test.strip().split(' ')])
        )
