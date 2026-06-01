product = input()

fruits = ['banana', 'apple', 'kiwi', 'cherry', 'lemon', 'grapes']
vegetables = ['tomato', 'cucumber', 'pepper', 'carrot']

product_type = ''

if product in fruits:
    product_type = 'fruit'
elif product in vegetables:
    product_type = 'vegetable'
else:
    product_type = 'unknown'

print(product_type)