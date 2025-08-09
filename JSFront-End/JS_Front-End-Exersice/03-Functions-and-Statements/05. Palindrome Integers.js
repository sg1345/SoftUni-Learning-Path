function palidromeIntegers(arrayNums){

    for (const number of arrayNums) {

        let digits = numberToArrayOfDigits(number);
        let isPalindrome = true;

        for (let i = 0; i < digits.length / 2; i++) {

            let firstDigit = digits[i];
            let lastDigit = digits[digits.length-1-i];

            if( firstDigit !== lastDigit){
                isPalindrome = false;
                break;
            }            
        }

        console.log(isPalindrome);
        
    }

    function numberToArrayOfDigits(number){
        return  number.toString().split('').map(Number);
    }
    
}

palidromeIntegers([123,323,421,121]);