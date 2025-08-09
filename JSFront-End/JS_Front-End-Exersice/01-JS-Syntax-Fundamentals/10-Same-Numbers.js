function SameNumbers(numbers){

    let numbersToString = numbers.toString();
    let currentNumber = numbersToString[0];
    let isTheSame = true;
    let sum = 0;

    for (let i = 0; i < numbersToString.length; i++) {
        
        if(currentNumber != numbersToString[i]){
            isTheSame = false                                 
        }

        sum += parseInt(numbersToString[i]);
        currentNumber = numbersToString[i];    
    }

    console.log(isTheSame);
    console.log(sum);
}

SameNumbers(2222222);
SameNumbers(1234);