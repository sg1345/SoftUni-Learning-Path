sum_prime = 0
sum_non_prime = 0

while True:
    command = input()
    is_prime = True
    if command == 'stop':
        break

    number = int(command)

    if number < 0:
        print('Number is negative.')
        continue
    elif number == 0 or number == 1:
        sum_prime += number
    elif number > 1:
        for i in range(2, number):
            if number % i == 0:
                is_prime = False
                sum_non_prime += number
                break

        if is_prime:
            sum_prime += number

print(f"Sum of all prime numbers is: {sum_prime}")
print(f"Sum of all non prime numbers is: {sum_non_prime}")