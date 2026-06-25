number = int(input())

count = 0
is_over = False
for row in range(1, number + 1):
    for col in range(1, row + 1):
        count += 1
        print(count, end=' ')
        if count == number:
            is_over = True
            break
    if is_over:
        break

    print()