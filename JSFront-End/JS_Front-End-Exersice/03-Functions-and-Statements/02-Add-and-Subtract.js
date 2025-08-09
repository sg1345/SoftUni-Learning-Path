function addAndSubtract(num1,num2,num3){

    let result = subtract(sum(num1,num2),num3);
    console.log(result);
    

    function sum(num1, num2){
        return num1+num2;        
    }
    function subtract(num1, num2){
        return num1-num2;
    }
}