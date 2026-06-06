count = int(input())

sum_left = 0
sum_right = 0
message = ''

for i in range(count):
    number = int(input())
    sum_left += number

for i in range(count):
    number = int(input())
    sum_right += number

if sum_left == sum_right:
    message = f'Yes, sum = {sum_left}'
else:
    message = f'No, diff = {abs(sum_right - sum_left)}'

print(message)