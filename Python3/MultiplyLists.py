import sys

test = "25 39 41 18 | 30 86 47 64"

test.split("|")

numbers_dirty = map(
    lambda s: map(
        lambda x: x.strip(),
        s.split(" ")
    ),
    test.split("|")
)
list(
    map(
        lambda xs: [int(x) for x in xs if x != ""],
        numbers_dirty
    )
)

res = map(
    lambda xy: str(xy[0]*xy[1]),
    zip(
        *[[int(x) for x in xs.split(' ') if x != ""]
          for xs in test.split('|')]
    )
)
print(" ".join(res))


with open(sys.argv[1], 'r') as test_cases:
    for test in test_cases:
        res = map(
            lambda xy: str(xy[0]*xy[1]),
            zip(
                *[[int(x) for x in xs.split(' ') if x != ""]
                  for xs in test.split('|')]
            )
        )
        print(" ".join(res))

