nominee = input()
points =  float(input())
count = int(input())

goal_points = 1250.5
message = ''
has_won = False

for i in range(count):
    name = input()
    vote_points = float(input())

    name_len = len(name)
    current_points = ((name_len * vote_points)/2)
    points += current_points

    if points >= goal_points:
        has_won = True
        break


if not has_won:
    diff = abs(goal_points - points)
    message = f'Sorry, {nominee} you need {diff:.1f} more!'
else:
    message = f'Congratulations, {nominee} got a nominee for leading role with {points:.1f}!'

print(message)