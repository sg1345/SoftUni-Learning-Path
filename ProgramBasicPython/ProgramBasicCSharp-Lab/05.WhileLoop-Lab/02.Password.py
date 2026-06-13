username = input()
password = input()

while True:
    password_input = input()

    if password == password_input:
        print(f"Welcome {username}!")
        break
