length  = int(input())
width = int(input())

size =  length * width

while True:
    command = input()

    if command == 'STOP':
        break

    pieces_of_cake = int(command)
    size -= pieces_of_cake

    if size <= 0:
        break

if size >= 0:
    print(f"{size} pieces are left.")
else:
    print(f"No more cake left! You need {abs(size)} pieces more.")