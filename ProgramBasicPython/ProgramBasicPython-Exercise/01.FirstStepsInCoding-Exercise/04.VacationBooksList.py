count_pages = int(input())
count_pages_per_hour = int(input())
count_days_completion = int(input())

total_hours_needed = int(count_pages / count_pages_per_hour)
count_hours_per_day = int(total_hours_needed/ count_days_completion)

print(count_hours_per_day)