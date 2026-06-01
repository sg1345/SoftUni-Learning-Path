hour = int(input())
day = input()

office = ''
if day == "Sunday":
    office = 'closed'
else:
    if 10 <= hour <= 18:
        office = 'open'
    else:
        office = 'closed'

print(office)