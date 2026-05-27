hours = int(input())
minutes = int(input())

additional_minutes = 15
text = f'0:00'

minutes = minutes + additional_minutes

if minutes >= 60:
    hours = hours + 1
    minutes = minutes - 60

if hours >= 24:
    hours = hours - 24

text =f'{hours}:{minutes:02}'

print(text)