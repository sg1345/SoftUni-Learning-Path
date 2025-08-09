function matrixCreator(number){

    for (let i = 0; i < number; i++) {

        rowPrinter(number);
        
    }


    function rowPrinter(number){
        let row = [];

        for (let j = 0; j < number; j++) {
            row.push(number);                       
        }
        
        console.log(row.join(' '));
    }
}

matrixCreator(7);