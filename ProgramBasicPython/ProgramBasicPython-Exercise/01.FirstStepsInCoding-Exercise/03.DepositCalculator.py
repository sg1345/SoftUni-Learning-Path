deposit_amount = float(input())
deposit_period_months = int(input())
year_interest_percentage = float(input())

year_interest_rate = year_interest_percentage / 100

total_ammout_recieved = deposit_amount + deposit_period_months * ((deposit_amount * year_interest_rate) / 12)

print(total_ammout_recieved)