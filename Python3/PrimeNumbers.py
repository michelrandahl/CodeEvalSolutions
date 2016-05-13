from itertools import takewhile
import sys


def primeNumbers():
    n = 1
    while True:
        n += 1
        if n == 2 or n == 3:
            yield n
        elif n % 2 == 0 or n % 3 == 0:
            continue
        else:
            i = 5
            while i*i <= n:
                if n % i == 0 or n % (i+2) == 0:
                    break
                i += 1
            else: yield n


with open(sys.argv[1], 'r') as test_cases:
    for test in test_cases:
        n = int(test)
        primes = takewhile(
            lambda p: p < n,
            primeNumbers()
        )
        print(",".join(map(str, primes)))
