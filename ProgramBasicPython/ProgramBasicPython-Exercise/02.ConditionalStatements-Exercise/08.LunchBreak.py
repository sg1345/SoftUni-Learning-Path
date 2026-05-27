import math

series_name = input()
episode_duration = int(input())
lunch_break_duration = int(input())

lunch_time = lunch_break_duration * 0.125
free_time = lunch_break_duration * 0.25
time_left_for_episode = lunch_break_duration - lunch_time - free_time

output_message = ''

if episode_duration > time_left_for_episode:
    time_needed = episode_duration - time_left_for_episode
    output_message = f"You don't have enough time to watch {series_name}, you need {math.ceil(time_needed)} more minutes."
else:
    time_left = time_left_for_episode - episode_duration
    output_message = f"You have enough time to watch {series_name} and left with {math.ceil(time_left)} minutes free time."

print(output_message)