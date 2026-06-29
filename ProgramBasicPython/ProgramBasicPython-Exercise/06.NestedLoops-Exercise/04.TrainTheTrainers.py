juries = int(input())

total_grades = 0
count_presentations = 0

while True:
    command = input()

    if command == 'Finish':
        break

    presentation = command
    count_presentations += 1
    sum_grades = 0.0
    for jury in range(juries):
        grade = float(input())
        sum_grades += grade

    avg_grade = sum_grades / juries
    total_grades += sum_grades
    print(f"{presentation} - {avg_grade:.2f}.")

avg_grade_total = total_grades / (juries * count_presentations)

print(f"Student's final assessment is {avg_grade_total:.2f}.")