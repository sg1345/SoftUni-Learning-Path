sq_meters_plastic = int(input())
litres_paint = int(input())
diluent_litres = int(input())
hour_needed_to_complete = int(input())

price_plastic_sq_meter = 1.50
price_paint_liter = 14.50
price_diluent_liter = 5.00
price_plastic_bags = 0.40

additional_paint_percentage = 10
additional_nylon_cubic_meters = 2


total_price_nylon = (sq_meters_plastic + additional_nylon_cubic_meters) * price_plastic_sq_meter
total_price_paint = (litres_paint + (litres_paint * (additional_paint_percentage/100))) * price_paint_liter
total_price_diluent = diluent_litres * price_diluent_liter
total_price_materials = total_price_nylon + total_price_paint + total_price_diluent + price_plastic_bags

price_work_per_hour = total_price_materials * 0.30

total_price_work = hour_needed_to_complete * price_work_per_hour

final_offer = total_price_work + total_price_materials

print(final_offer)