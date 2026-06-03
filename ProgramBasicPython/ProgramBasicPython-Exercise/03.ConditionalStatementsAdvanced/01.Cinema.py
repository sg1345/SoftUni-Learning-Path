screen_type = input()
rows = int(input())
columns = int(input())

seats = rows * columns
seat_price = 0

if screen_type == 'Premiere':
    seat_price = 12.0
elif screen_type == 'Normal':
    seat_price = 7.5
else:
    seat_price = 5.0

total_price = seat_price * seats

print(f'{total_price:.2f} leva')