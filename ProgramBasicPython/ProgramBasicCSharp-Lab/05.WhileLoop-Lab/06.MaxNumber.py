import sys

max_num = -sys.maxsize - 1

while True:
    command = input()

    if command == "Stop":
        break

    num = int(command)

    if num > max_num:
        max_num = num

print(f"{max_num}")
