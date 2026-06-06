count = int(input())

sum_even = 0
sum_odd = 0
message_one = ''
message_two = ''

for i in range(1, count+1):
    number = int(input())
    if i % 2 == 0:
        sum_even += number
    else:
        sum_odd += number

if sum_even == sum_odd:
    message_one = 'Yes'
    message_two = f'Sum = {sum_odd}'
else:
    message_one = 'No'
    message_two = f'Diff = {abs(sum_even - sum_odd)}'


print(message_one)
print(message_two)