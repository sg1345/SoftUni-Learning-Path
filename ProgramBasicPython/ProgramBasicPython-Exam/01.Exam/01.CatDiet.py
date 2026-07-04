perc_fat = int(input())
perc_protein = int(input())
perc_carb = int(input())
total_calories = int(input())
perc_water = int(input())

fat_grams = ((total_calories / 100) * perc_fat) / 9
protein_grams = ((total_calories / 100) * perc_protein) / 4
carb_grams = ((total_calories / 100) * perc_carb) / 4

total_grams = fat_grams + protein_grams + carb_grams

avg_calories_per_gram = total_calories / total_grams

perc_food_in_one_gram = 100 - perc_water

calories_in_one_gram = (avg_calories_per_gram / 100) * perc_food_in_one_gram

print(f"{calories_in_one_gram:.4f}")