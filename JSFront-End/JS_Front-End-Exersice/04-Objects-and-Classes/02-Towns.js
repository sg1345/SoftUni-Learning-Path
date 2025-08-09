function towns(arr){

    // class Town{
    //     constructor(town, latitude, longitude){
    //         this.town = town;
    //         this.latitude = parseFloat(latitude).toFixed(2);
    //         this.longitude = parseFloat(longitude).toFixed(2);
    //     }
    // }
    

    let towns = [];

    for (const info of arr) {
        let townInfo = info.split(' | ');

        // let currentTown = new Town(townInfo[0],townInfo[1], townInfo[2]);
        let currentTown = {
            town : townInfo[0],
            latitude : parseFloat(townInfo[1]).toFixed(2),
            longitude :  parseFloat(townInfo[2]).toFixed(2)
        };
        towns.push(currentTown);
    }

    for (const town of Object.values(towns)) {
        console.log(town);
    }
    
    
    
}

towns(['Sofia | 42.696552 | 23.32601', 'Beijing | 39.913818 | 116.363625']);