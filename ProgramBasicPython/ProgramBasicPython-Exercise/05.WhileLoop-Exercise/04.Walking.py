goal_steps = 10000
total_steps = 0
while True:
    command = input()

    if command == "Going home":
        steps = int(input())
        total_steps += steps
        break

    steps = int(command)
    total_steps += steps

    if total_steps >= goal_steps:
        break

if total_steps < goal_steps:
    print(f"{goal_steps - total_steps} more steps to reach goal.")
else:
    print("Goal reached! Good job!")
    print(f"{total_steps - goal_steps} steps over the goal!")