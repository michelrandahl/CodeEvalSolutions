import sys
from itertools import islice, dropwhile

list(islice([1,2,3], 1))

def readMore(input: str) -> str:
    trimmed = input.strip()
    if len(trimmed) <= 55:
        return trimmed
    else:
        xs = list(islice(trimmed, 0, 40))
        res = ""
        if " " in xs:
            xs_rev = list(dropwhile(lambda x: x != " ", reversed(xs)))[1:]
            res = "".join(reversed(xs_rev))
        else:
            res = "".join(xs)
        return res + "... <Read More>"

test = "Truck off'n your outside turn round that they wondered what you would have."
len(test)
readMore(test)
len(readMore(test))

with open(sys.argv[1], 'r') as test_cases:
    for test in test_cases:
        print(readMore(test))
