function piccolo(arr){

    let carsIn = [];

    for (const element of arr) {
        let currentCar =  element.split(', ')

        if(currentCar[0] === 'IN'){
            if(!carsIn.includes(currentCar[1])){
                carsIn.push(currentCar[1]);
            }

        }
        else{
            if(carsIn.includes(currentCar[1])){
                let index = carsIn.indexOf(currentCar[1]);
                carsIn.splice(index,1);
            }
        }
    }

    if(carsIn.length === 0){
        console.log("Parking Lot is Empty");
        
    }
    else{
        for (const car of carsIn.sort((a,b) => a.localeCompare(b))) {
            console.log(car);
            
        }
    }
}

piccolo([
    'IN, CA2844AA',
    'IN, CA1234TA',
    'OUT, CA2844AA',
    'IN, CA9999TT',
    'IN, CA2866HI',
    'OUT, CA1234TA',
    'IN, CA2844AA',
    'OUT, CA2866HI',
    'IN, CA9876HH',
    'IN, CA2822UU'
]);