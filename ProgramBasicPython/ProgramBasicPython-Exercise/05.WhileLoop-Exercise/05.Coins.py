change = float(input())

monet_count = 0

while True:

    if change == 0:
        break

    if change - 2 >= 0:
        change -= 2
    elif change - 1 >= 0:
        change -= 1
    elif change - 0.5 >= 0:
        change -= 0.5
    elif change - 0.2 >= 0:
        change -= 0.2
    elif change - 0.1 >= 0:
        change -= 0.1
    elif change - 0.05 >= 0:
        change -= 0.05
    elif change - 0.02 >= 0:
        change -= 0.02
    elif change - 0.01 >= 0:
        change -= 0.01

    change = round(change, 2)
    monet_count += 1

print(monet_count)