number_one = int(input())
number_two = int(input())
operator = input()

result = 0.0
is_int = False
message = ''

if number_two == 0 and (operator == '/' or operator == '%'):
    print(f'Cannot divide {number_one} by zero')
    quit()

if operator == '+':
    result = number_one + number_two
    is_int = True
elif operator == '-':
    result = number_one - number_two
    is_int = True
elif operator == '*':
    result = number_one * number_two
    is_int = True
elif operator == '/':
    result = number_one / number_two
elif operator == '%':
    result = number_one % number_two

if is_int:
    if result % 2 == 0:
        message = f'{number_one} {operator} {number_two} = {result} - even'
    else:
        message = f'{number_one} {operator} {number_two} = {result} - odd'
elif operator == '%':
    message = f'{number_one} {operator} {number_two} = {result}'
else:
    message = f'{number_one} {operator} {number_two} = {result:.2f}'

print(message)
