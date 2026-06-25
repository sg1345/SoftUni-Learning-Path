number_1 = int(input())
number_2 = int(input())

for x in range(number_1, number_2 + 1):
    odd1 = int(x % 10 / 1)
    even1 = int(x % 100 / 10)
    odd2 = int(x % 1000 / 100)
    even2 = int(x % 10000 / 1000)
    odd3 = int(x % 100000 / 10000)
    even3 = int(x % 1000000 / 100000)

    sum_odd = odd1 + odd2 + odd3
    sum_even = even1 + even2 + even3

    if sum_even == sum_odd:
        print(x, end=' ')