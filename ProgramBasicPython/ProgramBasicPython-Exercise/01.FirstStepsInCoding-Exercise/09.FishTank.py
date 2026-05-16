length_cm = int(input())
width_cm = int(input())
height_cm = int(input())
percentage_taken = float(input())

tank_volume_litres = length_cm * width_cm * height_cm * 0.001
percentage_rate_taken = percentage_taken / 100

water_needed_litres =tank_volume_litres * (1 - percentage_rate_taken)

print(water_needed_litres)
