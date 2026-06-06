count = int(input())

num_max = 0
num_min = 0

for i in range(count):
    number = int(input())

    if i == 0:
        num_max = number
        num_min = number
    else:
        if number > num_max:
            num_max = number

        if number < num_min:
            num_min = number

print(f'Max number: {num_max}')
print(f'Min number: {num_min}')