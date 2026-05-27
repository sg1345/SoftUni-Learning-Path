budget = float(input())
count_extras = int(input())
price_costumes_for_extras = float(input())

decor = budget * 0.1
discount = 0.0
output_message = ''

if count_extras > 150:
    discount = 0.1

total_amount_for_extras = count_extras * price_costumes_for_extras
total_needed = decor + (total_amount_for_extras - (total_amount_for_extras * discount))

if total_needed > budget:
    money_needed = total_needed - budget
    output_message = f'Not enough money!\nWingard needs {money_needed:.2f} leva more.'
else:
    money_left = budget - total_needed
    output_message = f'Action!\nWingard starts filming with {money_left:.2f} leva left.'

print(output_message)