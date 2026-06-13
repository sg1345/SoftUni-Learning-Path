goal_number = int(input())

counter = 0

while True:
    counter = (counter * 2) + 1

    if counter > goal_number:
        break

    print(counter)