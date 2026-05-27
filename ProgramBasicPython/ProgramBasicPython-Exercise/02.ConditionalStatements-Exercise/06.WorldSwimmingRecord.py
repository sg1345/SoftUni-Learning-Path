world_record = float(input())
distance_needed = float(input())
seconds_one_meter = float(input())

time = distance_needed * seconds_one_meter
extra_time = (int(distance_needed / 15)) * 12.5
total_time = time + extra_time
output_message = ''

if total_time < world_record:
    output_message = f'Yes, he succeeded! The new world record is {total_time:.2f} seconds.'
else:
    time_diff = total_time - world_record
    output_message = f'No, he failed! He was {time_diff:.2f} seconds slower.'

print(output_message)