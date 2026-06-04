type_flowers = input()
count_flowers = int(input())
budget = int(input())

price_rose = 5.0
price_dahlia = 3.8
price_tulip = 2.8
price_narcissus = 3.0
price_gladiolus = 2.5

total = 0.0

if type_flowers == 'Roses':

    if count_flowers > 80:
        total = (price_rose * count_flowers) * 0.9
    else:
        total = price_rose * count_flowers

elif type_flowers == 'Dahlias':

    if count_flowers > 90:
        total = (price_dahlia * count_flowers) * 0.85
    else:
        total = price_dahlia * count_flowers

elif type_flowers == 'Tulips':

    if count_flowers > 80:
        total = (price_tulip * count_flowers) * 0.85
    else:
        total = price_tulip * count_flowers

elif type_flowers == 'Narcissus':

    if count_flowers < 120:
        total = (price_narcissus * count_flowers) * 1.15
    else:
        total = price_narcissus * count_flowers

elif type_flowers == 'Gladiolus':

    if count_flowers < 80:
        total = (price_gladiolus * count_flowers) * 1.2
    else:
        total = price_gladiolus * count_flowers

diff = abs(total - budget)

if total > budget:
    print(f'Not enough money, you need {diff:.2f} leva more.')
else:
    print(f'Hey, you have a great garden with {count_flowers} {type_flowers} and {diff:.2f} leva left.')