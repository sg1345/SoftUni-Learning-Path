function factorialDivision(num1, num2){

    let factorialOne = factorial(num1);
    let factorialTwo = factorial(num2);

    console.log((factorialOne/factorialTwo).toFixed(2));
    

    function factorial(number){
        let result = 1;

        if(number === 0){
            return result;
        }

        for (let i = 1; i <= number; i++) {
            
            result *=i;
            
        }

        return result;
    }
}

factorialDivision(5,2);