function oddAndEvenSum(number){
    let array = numberToArrayOfDigits(number);


    console.log(`Odd sum = ${oddSum(array)}, Even sum = ${evenSum(array)}`);
    

    function evenSum(arrNums){
        let sumEven = 0;

        for (const digit of arrNums) {

            if(digit % 2 === 0){
                sumEven+=digit
            }
            
        }
        return sumEven;
    }

    function oddSum(arrNums){
        let sumOdd = 0;

        for (const digit of arrNums) {

            if(digit % 2 === 1){
                sumOdd+=digit
            }
            
        }
        return sumOdd;
    }
    
    
    function numberToArrayOfDigits(number){
        return  number.toString().split('').map(Number);
    };
}

oddAndEvenSum(100435);