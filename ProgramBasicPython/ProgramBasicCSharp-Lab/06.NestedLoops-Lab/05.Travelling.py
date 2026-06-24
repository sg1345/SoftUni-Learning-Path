while True:
    command =  input()
    if command == "End":
        break

    money_needed = float(input())
    destination = command
    money = 0.0

    while money < money_needed:
        money += float(input())

    print(f"Going to {destination}!")