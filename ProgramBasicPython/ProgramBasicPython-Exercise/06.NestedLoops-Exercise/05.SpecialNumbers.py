number = int(input())

for i in range(1111, 9999+1, 1):
    num1 = int(str(i)[0])
    num2 = int(str(i)[1])
    num3 = int(str(i)[2])
    num4 = int(str(i)[3])

    if num1 != 0 and num2 != 0 and num3 != 0 and num4 != 0:
        if number % num1 == 0 and number % num2 == 0 and number % num3 == 0 and number % num4 == 0:
            print(i, end = ' ')