function vikingSaga(dataArr) {
    const numberOfVikings = Number(dataArr.shift());

    const vikings = {};

    for (let i = 0; i < numberOfVikings; i++) {
        const [name, weapon, strengthString] = dataArr.shift().split("-");

        let strength = Number(strengthString);
        // console.log(name, weapon, strength);

        vikings[name] = {
            name,
            weapon,
            strength,
            weapons: []
        };
        vikings[name].weapons.push(weapon);

        if (vikings[name].strength > 100) {
            vikings[name].strength = 100;
        }

        if (vikings[name].strength < 0) {
            vikings[name].strength = 0;
        }
    }

    // console.log(vikings);

    while (dataArr[0] !== "The Saga Ends") {
        const [command, vikingName, ...args] = dataArr.shift().split(" -> ");

        if (command === 'Raid') {
            const [weapon, strengthRequiredString] = args;
            const strengthRequired = Number(strengthRequiredString);

            if (vikings[vikingName].weapons.includes(weapon) && vikings[vikingName].strength >= strengthRequired) {
                vikings[vikingName].strength -= strengthRequired;
                console.log(`${vikings[vikingName].name} fought bravely with ${weapon} and now has ${vikings[vikingName].strength} strength!`);
            }
            else {
                console.log(`${vikings[vikingName].name} couldn't join the raid with ${weapon}!`);
            }
        }
        else if (command === 'Train') {
            const [strengthGainedString] = args;
            const strengthGained = Number(strengthGainedString);

            if (vikings[vikingName].strength === 100) {
                console.log(`${vikings[vikingName].name} is already at full strength!`);
            }
            else {

                vikings[vikingName].strength += strengthGained;
                if (vikings[vikingName].strength > 100) {
                    const addedStrength = strengthGained - (vikings[vikingName].strength - 100);
                    vikings[vikingName].strength = 100;
                    console.log(`${vikings[vikingName].name} trained hard and gained ${addedStrength} strength!`);
                }
                else {
                    console.log(`${vikings[vikingName].name} trained hard and gained ${strengthGained} strength!`);
                }
            }
        }
        else if (command === 'Forge') {
            const [newWeapon] = args;

            if (vikings[vikingName].weapons.includes(newWeapon)) {
                console.log(`${vikings[vikingName].name} already wields ${newWeapon}.`);
            }
            else {
                vikings[vikingName].weapons.push(newWeapon);
                console.log(`${vikings[vikingName].name} has forged a new weapon: ${newWeapon}!`);
            }
        }
    }

    for (const vikingName in vikings) {
        console.log(`Warrior: ${vikings[vikingName].name}\n - Weapons: ${vikings[vikingName].weapons.join(", ")}\n - Strength: ${vikings[vikingName].strength}`);
    }

}

vikingSaga([
    "3",
    "Ragnar-Axe-80",
    "Lagertha-Spear-95",
    "Bjorn-Sword-100",
    "Raid -> Ragnar -> Axe -> 30",
    "Forge -> Ragnar -> Shield",
    "Train -> Lagertha -> 10",
    "Train -> Bjorn -> 5",
    "Forge -> Lagertha -> Spear",
    "The Saga Ends"
]);
