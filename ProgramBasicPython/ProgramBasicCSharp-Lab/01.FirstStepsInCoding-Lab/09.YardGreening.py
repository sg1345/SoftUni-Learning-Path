square_meters = float(input())

price_per_square_meter = 7.61
total_price = square_meters * price_per_square_meter
discount = total_price * 0.18
price_with_discount = total_price - discount

print(f'The final price is: {price_with_discount} lv.')
print(f'The discount is: {discount} lv.')