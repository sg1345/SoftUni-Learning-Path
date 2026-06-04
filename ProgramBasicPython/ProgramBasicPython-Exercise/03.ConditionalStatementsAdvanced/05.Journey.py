budget = float(input())
season = input()

destination = ''
cost = 0.0
type_of_destination = ''

if budget <= 100:
    destination = 'Bulgaria'
elif budget <= 1000:
    destination = 'Balkans'
elif budget > 1000:
    destination = 'Europe'

if season == 'winter' or destination == 'Europe':
    type_of_destination = 'Hotel'
else:
    type_of_destination = 'Camp'

if destination == 'Bulgaria':
    if season == 'summer':
        cost = budget * 0.3
    elif season == 'winter':
        cost = budget * 0.7
elif destination == 'Balkans':
    if season == 'summer':
        cost = budget * 0.4
    elif season == 'winter':
        cost = budget * 0.8
elif destination == 'Europe':
    cost = budget * 0.9

print(f'Somewhere in {destination}')
print(f'{type_of_destination} - {cost:.2f}')