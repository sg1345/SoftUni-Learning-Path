num_1 = int(input())
num_2 = int(input())
result = int(input())

counter = 0
is_found = False

for x1 in range(num_1,num_2+1):
    for x2 in range(num_1,num_2+1):
        counter += 1
        sum = x1 + x2
        if sum == result:
            is_found = True
            print(f"Combination N:{counter} ({x1} + {x2} = {sum})")
            break
    if is_found:
        break

if not is_found:
    print(f"{counter} combinations - neither equals {result}")