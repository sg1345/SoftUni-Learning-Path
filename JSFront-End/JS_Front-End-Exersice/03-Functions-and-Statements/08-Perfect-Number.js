function perfectNumber(number){
    if (number % 2 === 1){
        printPerfectNumberNotFound();
        return;       
    }

    if(perfectNumberChecker(number)){
        console.log("We have a perfect number!");
        
    }
    else{
        printPerfectNumberNotFound();
    }

    function printPerfectNumberNotFound(){
        console.log("It's not so perfect.");  
    }
    function perfectNumberChecker(number){
        sum = 0;

        for (let i = 1; i <= number / 2; i++) {
            if (number % i === 0){
                sum+=i;
            }
            
        }

        return sum === number;
    }
}

perfectNumber(28);