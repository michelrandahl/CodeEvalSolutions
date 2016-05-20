import sys
from typing import List, Tuple

def parseLine(line: str) -> Tuple[str,List[int]]:
    line_args = line.split(";")
    text = line_args[0]
    order = [int(x) for x in line_args[1].split(" ")]
    return text, order

def addMissingNumbers(n: int, order: List[int]) -> List[int]:
    numbers = set(range(1,n+1))
    order_set = set(order)
    return order + list(sorted(numbers - order_set))

def reorder(text: str, order: List[int]) -> str:
    words = text.split(" ")
    num_words = len(words)

    return " ".join(map(
        lambda x: x[1],
        sorted(
            zip(
                addMissingNumbers(num_words, order),
                words
            ),
            key=lambda x: x[0]
        )
    ))

with open(sys.argv[1], 'r') as test_cases:
    for line in test_cases:
        print(reorder(*parseLine(line)))
