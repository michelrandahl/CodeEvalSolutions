import sys
from typing import List

test_input = """
aa
aahed
aahs
aalii
"""

def permute(xs: List[int]):
    if len(xs) > 0:
        x = xs[0]
        for y in xs[1:]:
            yield x, y
        yield from permute(xs[1:])

def indicatorFun(a: chr, b: chr):
    if a == b:
        return 0
    else:
        return 1

def mem(f):
    cache = {}

    def memoizedF(*args):
        if args not in cache:
            cache[args] = f(*args)
        return cache[args]
    memoizedF.cache = cache
    return memoizedF

leven_cache = {}
def levenshteinDist(word1: str, word2: str):
    if (word1, word2) not in leven_cache:
        word1_len = len(word1)
        word2_len = len(word2)
        if word1_len == 0:
            leven_cache[(word1, word2)] = word2_len
            return word2_len
        elif word2_len == 0:
            leven_cache[(word1, word2)] = word1_len
            return word1_len
        else:
            dist = min(
                levenshteinDist(word1[1:], word2) + 1,
                levenshteinDist(word1, word2[1:]) + 1,
                levenshteinDist(word1[1:], word2[1:]) + indicatorFun(word1[0], word2[0])
            )
            leven_cache[(word1, word2)] = dist
            return dist
    else:
        return leven_cache[(word1, word2)]

levenshteinDist("kitten", "macrographies")

tests = """
recursiveness
elastic
macrographies
END OF INPUT
aa
aahed
aahs
aalii
zymoses
zymosimeters
"""

sdfs = [x.split('\n') for xs in tests.split("END OF INPUT")]
print(sdfs)

network = [x for x in tests.split('\n') if x != ""]
[f for f in network if levenshteinDist("elastic", f) == 1]
[levenshteinDist("recursiveness", f) for f in network]
[levenshteinDist("macrographies", f) for f in network]

with open(sys.argv[1], 'r') as lines:
    test_cases = []
    for line in lines:
        if line == "END OF INPUT": break
        test
