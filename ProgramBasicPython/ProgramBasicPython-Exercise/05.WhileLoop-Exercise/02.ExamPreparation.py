failed_threshold = int(input())

total_grades = 0
count_solved_problems = 0
count_failed_problems = 0
is_failing = False
last_problem = ""

while True:
    command = input()

    if command == "Enough":
        break

    grade = int(input())


    if grade <= 4:
        count_failed_problems += 1
        if count_failed_problems == failed_threshold:
            is_failing = True
            break

    count_solved_problems += 1
    total_grades += grade
    last_problem = command

if is_failing:
    print(f"You need a break, {failed_threshold} poor grades.")
else:
    avg_score = total_grades / count_solved_problems
    print(f"Average score: {avg_score:.2f}")
    print(f"Number of problems: {count_solved_problems}")
    print(f"Last problem: {last_problem}")
