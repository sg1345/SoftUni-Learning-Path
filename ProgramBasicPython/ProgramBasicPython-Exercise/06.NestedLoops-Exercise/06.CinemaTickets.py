total_tickets = 0
student_tickets = 0
standard_tickets = 0
kid_tickets = 0

while True:
    command = input()

    if command == "Finish":
        break

    movie = command
    free_seats = int(input())
    taken_seats = 0
    while free_seats > taken_seats:
        command = input()
        if command == "End":
            break

        taken_seats += 1

        type_ticket = command

        if type_ticket == "standard":
            standard_tickets += 1
        elif type_ticket == "student":
            student_tickets += 1
        elif type_ticket == "kid":
            kid_tickets += 1

    perc_seats_taken = 100 * taken_seats / free_seats

    print(f"{movie} - {perc_seats_taken:.2f}% full.")
    total_tickets += taken_seats

perc_student_seats_taken = 100 * student_tickets / total_tickets
perc_standard_seats_taken = 100 * standard_tickets / total_tickets
perc_kid_seats_taken = 100 * kid_tickets / total_tickets

print(f"Total tickets: {total_tickets}")
print(f"{perc_student_seats_taken:.2f}% student tickets.")
print(f"{perc_standard_seats_taken:.2f}% standard tickets.")
print(f"{perc_kid_seats_taken:.2f}% kids tickets.")
