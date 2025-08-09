function farmManagementSystem(dataArr) {
    const number = Number(dataArr.shift());
    // console.log(number);

    let farmers = [];
    for (let i = 0; i < number; i++) {
        const [name, area, args] = dataArr.shift().split(" ");

        const tasks = args.split(",");

        farmers[name] = {
            name,
            area,
            tasks
        };
    }

    // console.log(farmersPlaceAndTasks);

    while (dataArr[0] !== "End") {
        const [command, ...args] = dataArr.shift().split(" / ");

        // console.log(args);


        if (command === 'Execute') {
            const [name, area, task] = args;

            if (farmers[name].area === area && farmers[name].tasks.includes(task)) {
                console.log(`${farmers[name].name} has executed the task: ${task}!`);
            }
            else {
                console.log(`${farmers[name].name} cannot execute the task: ${task}.`);
            }
        }
        else if (command === 'Change Area') {
            const [name, area] = args;
            farmers[name].area = area;
            console.log(`${farmers[name].name} has changed their work area to: ${area}`);

        }
        else if (command === 'Learn Task') {
            const [name, task] = args;

            if (farmers[name].tasks.includes(task)) {
                console.log(`${farmers[name].name} already knows how to perform ${task}.`);
            }
            else {
                console.log(`${farmers[name].name} has learned a new task: ${task}.`);
                farmers[name].tasks.push(task);
            }

        }
    }

    for (const farmer in farmers) {
        console.log(`Farmer: ${farmers[farmer].name}, Area: ${farmers[farmer].area}, Tasks: ${farmers[farmer].tasks.sort().join(", ")}`);
    }
}

farmManagementSystem([
    "2",
    "John garden watering,weeding",
    "Mary barn feeding,cleaning",
    "Execute / John / garden / watering",
    "Execute / Mary / garden / feeding",
    "Learn Task / John / planting",
    "Execute / John / garden / planting",
    "Change Area / Mary / garden",
    "Execute / Mary / garden / cleaning",
    "End"
]
);