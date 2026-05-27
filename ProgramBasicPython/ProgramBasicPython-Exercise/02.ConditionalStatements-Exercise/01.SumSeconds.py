time_first = int(input())
time_second = int(input())
time_third = int(input())

time_total = time_first + time_second + time_third

time_minutes = time_total // 60
time_seconds = time_total % 60

if time_seconds >= 10:
    print(f"{time_minutes}:{time_seconds}")
else:
    print(f"{time_minutes}:0{time_seconds}")
