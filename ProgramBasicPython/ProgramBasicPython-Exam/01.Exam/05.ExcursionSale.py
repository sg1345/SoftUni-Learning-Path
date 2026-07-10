sea_package = int(input())
mountain_package = int(input())
profit = 0
while sea_package > 0 or mountain_package > 0:
    command = input()

    if command == 'Stop':
        break

    package_type = command


    if package_type == "sea":
        if sea_package > 0:
            sea_package -= 1
            profit += 680
        else:
            continue
    elif package_type == "mountain":
        if mountain_package > 0:
            mountain_package -= 1
            profit += 499
        else:
            continue

if sea_package + mountain_package == 0:
    print("Good job! Everything is sold.")

print(f"Profit: {profit} leva.")