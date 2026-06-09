count = int(input())
points = int(input())

tournaments_won = 0
points_gathered = 0
points_win = 2000
points_finals = 1200
points_semifinals = 720

message_one = ''
message_two = ''
message_three = ''

for i in range(count):
    result = input()

    if result == 'W':
        tournaments_won += 1
        points_gathered += points_win
    elif result == 'F':
        points_gathered += points_finals
    elif result == 'SF':
        points_gathered += points_semifinals

points += points_gathered
avg_points = int(points_gathered / count)
win_perc = tournaments_won / count * 100
message_one = f'Final points: {points}'
message_two = f'Average points: {avg_points}'
message_three = f'{win_perc:.2f}%'

print(message_one)
print(message_two)
print(message_three)

