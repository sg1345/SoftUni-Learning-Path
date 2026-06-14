import sys

min_num = sys.maxsize

while True:
    command = input()

    if command == "Stop":
        break

    num = int(command)

    if num < min_num:
        min_num = num

print(f"{min_num}")