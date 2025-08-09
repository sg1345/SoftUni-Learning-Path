function scienceExperimentation(dataArr) {
    const numberOfChemicals = Number(dataArr[0]);

    const chemicals = {};
    for (let i = 1; i < numberOfChemicals + 1; i++) {
        const [name, quantityString] = dataArr[i].split(' # ');
        let quantity = Number(quantityString);

        chemicals[name] = {
            name,
            quantity
        };
    }
    // console.log(chemicals);

    while (dataArr[0] !== 'End') {
        const [command, name, ...args] = dataArr.shift().split(' # ');

        // console.log(command, name, args);

        if (command === 'Mix') {
            const secondChemicalName = args[0];
            const amount = Number(args[1]);

            if (chemicals[name].quantity >= amount && chemicals[secondChemicalName].quantity >= amount) {
                chemicals[name].quantity -= amount;
                chemicals[secondChemicalName].quantity -= amount;

                console.log(`${chemicals[name].name} and ${chemicals[secondChemicalName].name} have been mixed. ${amount} units of each were used.`);
            }
            else {
                console.log(`Insufficient quantity of ${chemicals[name].name}/${chemicals[secondChemicalName].name} to mix.`);
            }

        }
        else if (command === 'Replenish') {
            const amount = Number(args[0]);

            if (!chemicals[name]) {
                console.log(`The Chemical ${name} is not available in the lab.`);
                continue;
            }

            chemicals[name].quantity += amount;

            //maybe needs to be >= not sure
            if (chemicals[name].quantity > 500) {
                const addedAmount = amount - (chemicals[name].quantity - 500);
                chemicals[name].quantity = 500;

                console.log(`${chemicals[name].name} quantity increased by ${addedAmount} units, reaching maximum capacity of 500 units!`);
            }
            else {
                console.log(`${chemicals[name].name} quantity increased by ${amount} units!`);
            }
        }
        else if (command === 'Add Formula') {
            const formula = args[0];

            if (!chemicals[name]) {
                console.log(`The Chemical ${name} is not available in the lab.`);
                continue;
            }

            chemicals[name].formula = formula;
            console.log(`${chemicals[name].name} has been assigned the formula ${formula}.`);
            //possible to have multiple formulas. If yes, i need to change the code
        }
    }

    for (const name in chemicals) {
        if (chemicals[name].formula) {
            console.log(`Chemical: ${chemicals[name].name}, Quantity: ${chemicals[name].quantity}, Formula: ${chemicals[name].formula}`);
        }
        else {
            console.log(`Chemical: ${chemicals[name].name}, Quantity: ${chemicals[name].quantity}`);
        }
    }
}


scienceExperimentation([
    '4',
    'Water # 200',
    'Salt # 100',
    'Acid # 50',
    'Base # 80',
    'Mix # Water # Salt # 50',
    'Replenish # Salt # 150',
    'Add Formula # Acid # H2SO4',
    'End']
);