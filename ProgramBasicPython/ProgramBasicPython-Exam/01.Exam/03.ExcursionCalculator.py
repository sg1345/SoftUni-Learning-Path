count_people = int(input())
season = input()

summer_discount = 0.85
winter_increase = 1.08

total_cost = 0.0

if count_people <= 5:
    if season == "spring":
        total_cost = count_people * 50
    elif season == "summer":
        total_cost = (count_people * 48.5) * summer_discount
    elif season == "autumn":
        total_cost = count_people * 60
    elif season == "winter":
        total_cost = (count_people * 86) * winter_increase
elif count_people > 5:
    if season == "spring":
        total_cost = count_people * 48
    elif season == "summer":
        total_cost = (count_people * 45) * summer_discount
    elif season == "autumn":
        total_cost = count_people * 49.5
    elif season == "winter":
        total_cost = (count_people * 85) * winter_increase

print(f"{total_cost:.2f} leva.")