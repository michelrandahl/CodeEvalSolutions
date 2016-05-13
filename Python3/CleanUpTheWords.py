import sys
import re

def swapNumbers(word: str):
    m = re.match(r"(?P<d1>\d+)(?P<word>.+)(?P<d2>\d+)", word)
    gd = m.groupdict()
    return gd['d2'] + gd['word'] + gd['d1']

def cleanUpWords(messy_text: str):
    ms = re.findall(r"[a-zA-Z]+", messy_text)
    for m in ms:
        yield m.lower()

" ".join(
    cleanUpWords(";H//!Hu~Z-\KKSwV&lK#s\Wf%Ruc>QH10|pz)wznvjTYn$neXHI`@")
)

with open(sys.argv[1], 'r') as test_cases:
    for test in test_cases:
        print(" ".join(
            cleanUpWords(test)
        ))


