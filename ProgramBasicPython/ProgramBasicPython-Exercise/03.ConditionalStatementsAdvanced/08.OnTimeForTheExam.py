exam_hour = int(input())
exam_minute = int(input())
arrival_hour = int(input())
arrival_minute = int(input())

hour_to_minutes_exam = exam_hour * 60 + exam_minute
hour_to_minutes_arrival = arrival_hour * 60 + arrival_minute
difference = hour_to_minutes_exam - hour_to_minutes_arrival
message_one = ''
message_two = ''

if difference == 0:
    message_one = 'On time'
    print(message_one)
    quit()

if  30 >= difference > 0:
    message_one = 'On time'
    message_two = f'{difference} minutes before the start'
elif 59 >= difference > 30:
    message_one = 'Early'
    message_two = f'{difference} minutes before the start'
elif difference >= 60:
    message_one = 'Early'
    hour = int(difference / 60)
    minutes:int = difference % 60
    message_two = f'{hour}:{minutes:02} hours before the start'
elif -59 <= difference < 0:
    message_one = 'Late'
    message_two = f'{abs(difference)} minutes after the start'
elif difference <= -60:
    message_one = 'Late'
    hour = int(abs(difference) / 60)
    minutes = abs(difference) % 60
    message_two = f'{hour}:{minutes:02} hours after the start'

print(message_one)
print(message_two)
