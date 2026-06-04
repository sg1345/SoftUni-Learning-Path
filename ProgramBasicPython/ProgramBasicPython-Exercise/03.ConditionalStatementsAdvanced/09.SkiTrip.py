count_days = int(input())
type_room = input()
rating = input()

price_one_room_apartment = 18.00
price_apartment = 25.00
price_president_apartment = 35.00
count_nights = count_days - 1

discount_rate = 0.0
price_room = 0.0
total = 0.0

if type_room == 'apartment':
    price_room = price_apartment
    if count_nights < 10:
        discount_rate = 0.3
    elif 10 <= count_nights <= 15:
        discount_rate = 0.35
    elif count_nights > 15:
        discount_rate = 0.5
elif type_room == 'president apartment':
    price_room = price_president_apartment
    if count_nights < 10:
        discount_rate = 0.1
    elif 10 <= count_nights <= 15:
        discount_rate = 0.15
    elif count_nights > 15:
        discount_rate = 0.2
else:
    price_room = price_one_room_apartment

total = count_nights * price_room
total *= (1 - discount_rate)

if rating == 'positive':
    total *= 1.25
elif rating == 'negative':
    total *= 0.9

print(f'{total:.2f}')