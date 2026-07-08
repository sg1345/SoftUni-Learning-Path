days = int(input())

total_liters = 0
total_degrees = 0

for day in range(days):
    liters = float(input())
    degrees = float(input())

    total_liters += liters
    total_degrees += liters * degrees

avg_degrees = total_degrees / total_liters
print(f"Liter: {total_liters:.2f}")
print(f"Degrees: {avg_degrees:.2f}")

if avg_degrees < 38:
    print("Not good, you should baking!")
elif avg_degrees < 42:
    print("Super!")
else:
    print("Dilution with distilled water!")
