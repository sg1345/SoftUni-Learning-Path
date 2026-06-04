group_budget = int(input())
season = input()
count_fishermen = int(input())

loan_boat_spring = 3000
loan_boat_summer = 4200
loan_boat_autumn = 4200
loan_boat_winter = 2600

discount_rate = 0.0
additional_discount_rate = 0.0
price_boat = 0.0

if count_fishermen <= 6:
    discount_rate = 0.10
elif 7 <= count_fishermen <= 12:
    discount_rate = 0.15
elif count_fishermen > 12:
    discount_rate = 0.25

if count_fishermen % 2 == 1 or season == 'Autumn':
    additional_discount_rate = 0.0
else:
    additional_discount_rate = 0.05

if season == 'Autumn':
    price_boat = loan_boat_autumn
elif season == 'Winter':
    price_boat = loan_boat_winter
elif season == 'Spring':
    price_boat = loan_boat_spring
elif season == 'Summer':
    price_boat = loan_boat_summer

total = price_boat*(1-discount_rate)*(1-additional_discount_rate)
diff = abs(total - group_budget)

if group_budget >= total:
    print(f'Yes! You have {diff:.2f} leva left.')
elif group_budget < total:
    print(f'Not enough money! You need {diff:.2f} leva.')