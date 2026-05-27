budget = float(input())
count_gpu = int(input())
count_cpu = int(input())
count_ram = int(input())

price_gpu = 250
amount_gpu = count_gpu * price_gpu

price_cpu = amount_gpu * 0.35
amount_cpu = count_cpu * price_cpu

price_ram = amount_gpu * 0.1
amount_ram = count_ram * price_ram

total_amount = amount_gpu + amount_cpu + amount_ram
total_price = total_amount

if count_gpu > count_cpu:
    total_price = total_amount * 0.85

output_message = ''

if budget >= total_price:
    money_left = budget - total_price
    output_message = f'You have {money_left:.2f} leva left!'
else:
    money_needed = total_price - budget
    output_message = f'Not enough money! You need {money_needed:.2f} leva more!'

print(output_message)