count = int(input())

total = 0
group_musala = 0
group_monblan = 0
group_kilimanjaro = 0
group_k2 = 0
group_everest = 0

for i in range(count):
    count_group = int(input())

    if count_group <= 5:
        group_musala += count_group
    elif 6 <= count_group <= 12:
        group_monblan += count_group
    elif 13 <= count_group <= 25:
        group_kilimanjaro += count_group
    elif 26 <= count_group <= 40:
        group_k2 += count_group
    elif 41 <= count_group:
        group_everest += count_group

    total += count_group

group_musala_perc = group_musala / total * 100
group_monblan_perc = group_monblan / total * 100
group_kilimanjaro_perc = group_kilimanjaro / total * 100
group_k2_perc = group_k2 / total * 100
group_everest_perc = group_everest / total * 100

print(f'{group_musala_perc:.2f}%')
print(f'{group_monblan_perc:.2f}%')
print(f'{group_kilimanjaro_perc:.2f}%')
print(f'{group_k2_perc:.2f}%')
print(f'{group_everest_perc:.2f}%')

