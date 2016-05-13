
def fib(n: int):
    n1, n2, count = 0, 0, 0
    while True:
        if count == n: return n2
        else:
            if count == 0:
                n1, n2, count = 0, 1, 1
            else:
                n1, n2, count = n2, (n1 + n2), (count + 1)

print(fib(22))

x = "42"
int(x)
