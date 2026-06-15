book = input()

search_count = 0
is_found = False
while True:
    command = input()

    if command == "No More Books":
        break

    if command == book:
        is_found = True
        break

    search_count += 1

if is_found:
    print(f"You checked {search_count} books and found it.")
else:
    print("The book you search is not here!")
    print(f"You checked {search_count} books.")