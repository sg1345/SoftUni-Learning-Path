dog_food_count = int(input())
cat_food_count = int(input())

dog_food_price = 2.5
cat_food_price = 4

cat_food_total = cat_food_count * cat_food_price
dog_food_total = dog_food_count * dog_food_price

total_price =cat_food_total + dog_food_total

print(f'{total_price} lv.')