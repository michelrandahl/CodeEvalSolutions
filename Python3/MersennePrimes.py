from itertools import takewhile
from math import log2, ceil
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


def mersenneNumbers():
    n = 0.0
    while True:
        yield 2.0**n - 1.0
        n += 1.0

mersenne_numbers = takewhile(
    lambda n: n <= int(test),
    mersenneNumbers()
)



def mersennePrimes(n: int):
    mersenneProperty = lambda p: (
        2.0**(ceil(log2(p))) - 1.0 == p
    )
    primes = takewhile(
        lambda p: p <= n,
        primeNumbers()
    )
    return [p for p in primes
            if mersenneProperty(p)]

mersenne_numbers = takewhile(
    lambda p: p <= 3000,
    (2.0**p - 1.0 for p in primeNumbers())
)
print(list(mersenne_numbers))


with open(sys.argv[1], 'r') as test_cases:
    for test in test_cases:
        mersenne_numbers = takewhile(
            lambda p: p <= int(test),
            (2.0**p - 1.0 for p in primeNumbers())
        )
        print(", ".join(
            map(lambda x: str(int(x)), mersenne_numbers)
        ))


