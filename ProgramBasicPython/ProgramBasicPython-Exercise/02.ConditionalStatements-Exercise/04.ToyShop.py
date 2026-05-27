trip_price = float(input())
count_puzzles = int(input())
count_talking_dolls = int(input())
count_teddy_bears = int(input())
count_minions = int(input())
count_truck_toys = int(input())

price_puzzle = 2.60
price_talking_doll = 3
price_teddy_bear = 4.10
price_minion = 8.20
price_truck_toy = 2
discount = 0.0
percentile_after_rent = 0.9

output_message = 'something'
total_count = count_puzzles + count_talking_dolls + count_teddy_bears + count_minions + count_truck_toys

if total_count >= 50:
    discount = 0.25

total_before_discount = (price_puzzle * count_puzzles +
                price_talking_doll * count_talking_dolls +
                price_teddy_bear * count_teddy_bears +
                price_minion * count_minions +
                price_truck_toy * count_truck_toys)

total_after_discount = total_before_discount - (total_before_discount * discount)

total_after_rent = total_after_discount * percentile_after_rent

if total_after_rent >= trip_price:
    money_left = total_after_rent - trip_price
    output_message = f'Yes! {money_left:.2f} lv left.'
else:
    money_needed = trip_price - total_after_rent
    output_message = f'Not enough money! {money_needed:.2f} lv needed.'

print(output_message)