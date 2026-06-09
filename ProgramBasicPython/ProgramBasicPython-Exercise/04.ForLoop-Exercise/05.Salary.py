count_tabs = int(input())
salary = int(input())

has_no_salary = False
for i in range(count_tabs):
    tab = input()

    if tab == 'Facebook':
        salary -= 150
    elif tab == 'Instagram':
        salary -= 100
    elif tab == 'Reddit':
        salary -= 50

    if salary <= 0:
        has_no_salary = True
        break

if has_no_salary:
    print('You have lost your salary.')
else:
    print(salary)

