text = input()

total = 0

for char in text:
    number = 0
    if char == "a":
        number = 1
    elif char == "e":
        number = 2
    elif char == "i":
        number = 3
    elif char == "o":
        number = 4
    elif char == "u":
        number = 5
    else:
        number = 0
    total += number

print(total)