annual_price_basketball = int(input())

price_basketball_sneakers = annual_price_basketball - (annual_price_basketball * 0.40)
price_jersey_kit = price_basketball_sneakers  - (price_basketball_sneakers * 0.20)
price_ball = price_jersey_kit * 0.25
price_accessories = price_ball * 0.20

total_price = annual_price_basketball + price_basketball_sneakers + price_jersey_kit + price_ball + price_accessories

print(total_price)