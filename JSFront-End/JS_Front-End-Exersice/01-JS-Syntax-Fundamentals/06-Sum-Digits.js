function SumDigits(number){
    sum=0;
    let digits = number.toString();
    for (let i = 0; i < digits.length; i++) {
        let currentNumber = parseInt(digits[i]);
        sum += currentNumber;
        
    }
    console.log(sum);
    
}

SumDigits(245678);