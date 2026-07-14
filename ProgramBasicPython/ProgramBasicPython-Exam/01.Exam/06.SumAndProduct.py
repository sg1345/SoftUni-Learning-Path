import math
number = int(input())

is_done = False
for a in range(1, 10):
    for b in range(9, a-1, -1):
        for c in range(0, 10):
            for d in range(9, c-1, -1):
                if a + b + c + d == a * b * c * d and str(number)[-1] == "5":
                    print(f"{a}{b}{c}{d}")
                    is_done = True
                    break
                if math.floor((a * b * c * d) / (a + b + c + d)) == 3 and number % 3 == 0:
                    print(f"{d}{c}{b}{a}")
                    is_done = True
                    break
            if is_done:
                break
        if is_done:
            break
    if is_done:
        break

if not is_done:
    print("Nothing found")