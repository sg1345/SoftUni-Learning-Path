name = input()

count_passed_classes = 1
total_grades = 0
fails = 0

while True:
    grade = float(input())

    if grade < 4:
        fails += 1

        if fails == 2:
            break

        continue

    total_grades += grade

    if count_passed_classes == 12:
        break

    count_passed_classes += 1

if count_passed_classes == 12:
    print(f"{name} graduated. Average grade: {(total_grades / count_passed_classes):.2f}")
else:
    print(f"{name} has been excluded at {count_passed_classes} grade")