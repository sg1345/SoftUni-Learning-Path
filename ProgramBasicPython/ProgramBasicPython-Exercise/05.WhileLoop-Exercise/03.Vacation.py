needed_money = float(input())
owned_money = float(input())

spend_days_count = 0
day_count = 0
can_save = False
while True:

    command = input()
    day_count += 1

    if command == "spend":
        money = float(input())
        spend_days_count += 1
        owned_money -= money

        if owned_money < 0:
            owned_money = 0

        if spend_days_count >= 5:
            break

        continue

    spend_days_count = 0
    money = float(input())
    owned_money += money

    if owned_money >= needed_money:
        can_save = True
        break

if can_save:
    print(f"You saved the money for {day_count} days.")
else:
    print("You can't save the money.")
    print(day_count)