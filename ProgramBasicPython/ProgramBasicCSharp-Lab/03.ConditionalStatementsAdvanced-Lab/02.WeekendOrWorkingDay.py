day_input = input()

if day_input == "Monday" or day_input == "Tuesday" or day_input == "Wednesday" or day_input == "Thursday" or day_input == "Friday":
    print("Working day")
elif day_input == "Saturday" or day_input == "Sunday":
    print("Weekend")
else:
    print("Error")