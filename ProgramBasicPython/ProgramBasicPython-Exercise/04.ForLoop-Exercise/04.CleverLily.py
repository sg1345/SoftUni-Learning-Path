count = int(input())
price_washing_machine = float(input())
toy_price = int(input())

birthday_money_gift = 10
total_gathered = 0
toys_money_gathered = 0
money_gift_gathered = 0

message = ''

for i in range(1,count + 1):
    if i % 2 == 1:
        toys_money_gathered += toy_price
    else:
        money_gift_gathered += birthday_money_gift - 1
        birthday_money_gift += 10

total_gathered = toys_money_gathered + money_gift_gathered

if total_gathered >= price_washing_machine:
    message = f'Yes!'
else:
    message = f'No!'

message += f' {abs(total_gathered - price_washing_machine):.2f}'

print(message)
