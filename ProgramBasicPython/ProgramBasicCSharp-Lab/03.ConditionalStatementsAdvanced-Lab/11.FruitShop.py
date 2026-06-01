product =  input()
day = input()
quantity = float(input())

working_days = ['Monday', 'Tuesday', 'Wednesday', 'Thursday', 'Friday']
weekend = ['Saturday', 'Sunday']
product_price = 0
is_correct = True

if day in working_days:
    if product == 'banana':
        product_price = 2.5
    elif product == 'apple':
        product_price = 1.2
    elif product == 'orange':
        product_price = 0.85
    elif product == 'grapefruit':
        product_price = 1.45
    elif product == 'kiwi':
        product_price = 2.7
    elif product == 'pineapple':
        product_price = 5.5
    elif product == 'grapes':
        product_price = 3.85
    else:
        is_correct = False

elif day in weekend:
    if product == 'banana':
        product_price = 2.7
    elif product == 'apple':
        product_price = 1.25
    elif product == 'orange':
        product_price = 0.9
    elif product == 'grapefruit':
        product_price = 1.6
    elif product == 'kiwi':
        product_price = 3.0
    elif product == 'pineapple':
        product_price = 5.6
    elif product == 'grapes':
        product_price = 4.2
    else:
        is_correct = False

else:
    is_correct = False

if is_correct:
    total_price = product_price * quantity
    print(f"{total_price:.2f}")
else:
    print('error')