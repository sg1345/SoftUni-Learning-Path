daily_money = float(input())
sales_money = float(input())
expense = float(input())
price_present = float(input())

total_days = 5

daily_total = daily_money * total_days
total_sales = sales_money * total_days
total_money = total_sales + daily_total
total_saved = total_money - expense
if total_saved >= price_present:
    print(f"Profit: {total_saved:.2f} BGN, the gift has been purchased.")
else:
    print(f"Insufficient money: {abs(total_saved-price_present):.2f} BGN.")