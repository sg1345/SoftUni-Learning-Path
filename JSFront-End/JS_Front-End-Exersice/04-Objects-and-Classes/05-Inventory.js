function heroRegister(arr){
    
    let heroes = [];

    for (const element of arr) {
        let temp = element.split(' / ');
        

        let newCharacter = {
            name: temp[0],
            level: parseInt(temp[1]),
            items: temp[2]
        };

        heroes.push(newCharacter);
    }

    for (const hero of heroes.sort((a,b)=>a.level - b.level)) {
        
        console.log(`Hero: ${hero.name}`);
        console.log(`level => ${hero.level}`);
        console.log(`items => ${hero.items}`);
                
    }
    
    

}

heroRegister([
    'Isacc / 25 / Apple, GravityGun',
    'Derek / 12 / BarrelVest, DestructionSword',
    'Hes / 1 / Desolator, Sentinel, Antara'
]);