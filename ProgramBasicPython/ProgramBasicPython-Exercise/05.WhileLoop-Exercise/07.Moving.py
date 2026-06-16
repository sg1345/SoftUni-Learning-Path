length = int(input())
width = int(input())
height = int(input())

space =  length * width * height

while True:
    command = input()

    if command == "Done":
        break

    space_taken = int(command)
    space -= space_taken

    if space < 0:
        break

if space < 0:
    print(f"No more free space! You need {abs(space)} Cubic meters more.")
else:
    print(f"{space} Cubic meters left.")