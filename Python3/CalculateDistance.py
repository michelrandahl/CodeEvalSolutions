import sys
import re
from math import sqrt

test = "(47, 43) (-25, -11)"
m = re.match(r"\((?P<fst_p1>-?\d+), (?P<snd_p1>-?\d+)\) \((?P<fst_p2>-?\d+), (?P<snd_p2>-?\d+)\)", test)
gd = m.groupdict()
gd["fst_p1"]

with open(sys.argv[1], 'r') as test_cases:
    euclid_dist = lambda p1, p2: sqrt(
        (p1[0] - p2[0]) ** 2 + (p1[1] - p2[1]) ** 2
    )
    for test in test_cases:
        m = re.match(
            r"\((?P<fst_p1>-?\d+), (?P<snd_p1>-?\d+)\) \((?P<fst_p2>-?\d+), (?P<snd_p2>-?\d+)\)",
            test
        )
        gd = m.groupdict()
        p1 = int(gd["fst_p1"]), int(gd["snd_p1"])
        p2 = int(gd["fst_p2"]), int(gd["snd_p2"])
        print(int(euclid_dist(p1, p2)))
