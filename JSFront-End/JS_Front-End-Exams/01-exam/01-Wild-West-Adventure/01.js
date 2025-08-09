function wildWestAdventure(data) {
    const numberOfPlayers = Number(data.shift());
    const players = {};

    for (let i = 0; i < numberOfPlayers; i++) {
        const [name, health, ammo] = data.shift().split(' ');

        players[name] = {
            health: Number(health),
            ammo: Number(ammo)
        };
    }
    // console.log(players);

    // console.log(data);

    while (data[0] !== "Ride Off Into Sunset") {
        const [command, playersName, ...args] = data.shift().split(' - ');

        if (command === "FireShot") {
            const target = args[0];
            const ammoUsed = 1;

            if (players[playersName].ammo >= ammoUsed) {
                players[playersName].ammo -= ammoUsed;

                console.log(`${playersName} has successfully hit ${target} and now has ${players[playersName].ammo} bullets!`);

            }
            else {
                console.log(`${playersName} doesn't have enough bullets to shoot at ${target}!`);
            }
        }
        else if (command === 'TakeHit') {
            const damage = Number(args[0]);
            const attacker = args[1];

            players[playersName].health -= damage;

            if (players[playersName].health > 0) {
                console.log(`${playersName} took a hit for ${damage} HP from ${attacker} and now has ${players[playersName].health} HP!`);
            }
            else {

                console.log(`${playersName} was gunned down by ${attacker}!`);
                delete players[playersName];
            }
        }
        else if (command === 'Reload') {

            if (players[playersName].ammo < 6) {
                console.log(`${playersName} reloaded ${6 - players[playersName].ammo} bullets!`);
                players[playersName].ammo = 6;
            }
            else {
                console.log(`${playersName}'s pistol is fully loaded!`);
            }
        }
        else if (command === 'PatchUp') {

            const amount = Number(args[0]);

            if (players[playersName].health < 100) {
                players[playersName].health += amount;

                let difference = players[playersName].health - 100;
                let amountReccived = 0;

                if (difference <= 0) {
                    amountReccived = amount;
                    console.log(`${playersName} patched up and recovered ${amountReccived} HP!`);
                }
                else {
                    amountReccived = amount - difference;
                    players[playersName].health = 100;
                    console.log(`${playersName} patched up and recovered ${amountReccived} HP!`);
                }

            }
            else {
                console.log(`${playersName} is in full health!`);
            }
        }

    }

    for (const player in players) {

        console.log(`${player}\nHP: ${players[player].health}\nBullets: ${players[player].ammo}`);

    }
    // console.log(players);

}

wildWestAdventure(["2",
    "Gus 100 0",
    "Walt 100 6",
    "FireShot - Gus - Bandit",
    "TakeHit - Gus - 100 - Bandit",
    "Reload - Walt",
    "Ride Off Into Sunset"]
);