count_chicken_menus = int(input())
count_fish_menus = int(input())
count_vegetarian_menus = int(input())

price_chicken_menu  = 10.35
price_fish_menu = 12.40
price_vegetarian_menu = 8.15

total_price_chicken_menu = count_chicken_menus * price_chicken_menu
total_price_fish_menu = count_fish_menus * price_fish_menu
total_price_vegetarian_menu = count_vegetarian_menus * price_vegetarian_menu
total_price_all_menus = total_price_chicken_menu + total_price_fish_menu + total_price_vegetarian_menu

price_desert = total_price_all_menus * 0.2
delivery = 2.50

final_offer =total_price_all_menus + price_desert + delivery

print(f'{final_offer:.2f}')