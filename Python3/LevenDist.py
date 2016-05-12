import sys
from itertools import takewhile, dropwhile, islice
from typing import List


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

@mem
def levenshteinDist(word1: str, word2: str):
    word1_len = len(word1)
    word2_len = len(word2)
    if word1_len == 0:
        return word2_len
    elif word2_len == 0:
        return word1_len
    else:
        dist = min(
            levenshteinDist(word1[1:], word2) + 1,
            levenshteinDist(word1, word2[1:]) + 1,
            levenshteinDist(word1[1:], word2[1:]) + indicatorFun(word1[0], word2[0])
        )
        return dist

def levenDist(s: str, t: str):
    s_len = len(s)
    t_len = len(t)
    v0 = list(range(0, t_len))
    v1 = []

    for i in range(0, s_len):
        if len(v1) == 0:
            v1.append(i + 1)
        else:
            v1[0] = i + 1

        for j in range(0, t_len):
            cost = 0 if s[i] == t[j] else 1
            res = min(v1[j] + 1, v0[j + 1] + 1, v0[j] + cost)
            if j + 1 >= len(v1):
                v1.append(res)
            else:
                v1[j + 1] = res

        for j in range(0, len(v0)):
            v0[j] = v1[j]

    return v1[t_len]

levenshteinDist("kitten", "sitting")
levenDist("kitten", "sitting")


def findFriends(initial: str, potential_friends: List[str]):
    discovered = set()
    friends_queue = [initial]
    while len(friends_queue) > 0:
        friend = friends_queue.pop(0)
        yield friend
        for f in potential_friends:
            if f in discovered: continue
            if levenshteinDist(friend, f) == 1:
                friends_queue.append(f)
                discovered.add(f)

with open(sys.argv[1], 'r') as lines:
    test_cases = []
    is_test_cases = True
    potential_friends = []
    for line in lines:
        clean_line = line.strip()
        if clean_line == "END OF INPUT":
            is_test_cases = False
            continue
        if is_test_cases:
            test_cases.append(clean_line)
        else:
            potential_friends.append(clean_line)

    for test in test_cases:
        friends = list(findFriends(test, potential_friends))
        print(len(friends))



