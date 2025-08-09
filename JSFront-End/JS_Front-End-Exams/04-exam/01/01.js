function spaceExplorationCrewManagement(dataArr) {

    let crewCount = Number(dataArr.shift());
    // console.log(crewCount);

    let crew = {};

    for (let i = 0; i < crewCount; i++) {
        const [name, spacecraftSection, args] = dataArr.shift().split(" ");
        const skills = args.split(",");

        crew[name] = {
            name,
            spacecraftSection,
            skills
        };
    }

    // console.log(crew);

    while (dataArr[0] !== "End") {
        const [command, name, ...args] = dataArr.shift().split(" / ");

        if (command === "Perform") {
            const [spacecraftSection, skill] = args;

            if (crew[name].spacecraftSection === spacecraftSection && crew[name].skills.includes(skill)) {
                console.log(`${name} has successfully performed the skill: ${skill}!`);
            }
            else {
                console.log(`${name} cannot perform the skill: ${skill}.`);
            }

        }
        else if (command === "Learn Skill") {
            const [newSkill] = args;

            if (crew[name].skills.includes(newSkill)) {
                console.log(`${name} already knows the skill: ${newSkill}.`);
            }
            else {
                crew[name].skills.push(newSkill);
                console.log(`${name} has learned a new skill: ${newSkill}.`);
            }
        }
        else if (command === "Transfer") {
            const [newSpacecraftSection] = args;

            crew[name].spacecraftSection = newSpacecraftSection;

            console.log(`${name} has been transferred to: ${newSpacecraftSection}`);

        }

    }

    for (const member in crew) {
        console.log(`Astronaut: ${member}, Section: ${crew[member].spacecraftSection}, Skills: ${crew[member].skills.sort((a, b) => a.localeCompare(b)).join(", ")}`);
    }

}

spaceExplorationCrewManagement([
    "2",
    "Alice command_module piloting,communications",
    "Bob engineering_bay repair,maintenance",
    "Perform / Alice / command_module / piloting",
    "Perform / Bob / command_module / repair",
    "Learn Skill / Alice / navigation",
    "Perform / Alice / command_module / navigation",
    "Transfer / Bob / command_module",
    "Perform / Bob / command_module / maintenance",
    "End"
]
);