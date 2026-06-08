count = int(input())

max_num = 0
total = 0
message_one = ''
message_two = ''


for i in range(count):
    number = int(input())

    if number > max_num:
        max_num = number

    total += number

total -= abs(max_num)

if total == max_num:
    message_one = 'Yes'
    message_two = f'Sum = {total}'
else:
    message_one = 'No'
    message_two = f'Diff = {abs(total - max_num)}'

print(message_one)
print(message_two)