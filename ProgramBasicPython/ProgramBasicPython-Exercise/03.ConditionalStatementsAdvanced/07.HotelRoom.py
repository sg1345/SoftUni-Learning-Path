month = input()
count_nights = int(input())

price_studio = 0.0
price_apartment = 0.0
discount_rate_studio = 0.0
discount_rate_apartment = 0.0
total_studio = 0.0
total_apartment = 0.0

if month == 'May' or month == 'October':
    price_studio = 50
    price_apartment = 65
elif month == 'June' or month == 'September':
    price_studio = 75.2
    price_apartment = 68.7
elif month == 'July' or month == 'August':
    price_studio = 76
    price_apartment = 77

if 14 > count_nights > 7 and (month == 'May' or month == 'October'):
    discount_rate_studio =  0.05
elif count_nights > 14 and (month == 'May' or month == 'October'):
    discount_rate_studio = 0.30
elif count_nights > 14 and (month == 'June' or month == 'September'):
    discount_rate_studio = 0.20

if count_nights > 14:
    discount_rate_apartment = 0.1

total_studio = count_nights * price_studio * (1 - discount_rate_studio)
total_apartment = count_nights * price_apartment * (1 - discount_rate_apartment)

print(f'Apartment: {total_apartment:.2f} lv.')
print(f'Studio: {total_studio:.2f} lv.')