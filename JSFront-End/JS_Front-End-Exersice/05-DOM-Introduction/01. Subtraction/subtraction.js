function subtract() {
    let firstNumber = document.getElementById("firstNumber");
    let secondNumber = document.getElementById("secondNumber");

    console.log(firstNumber.value);
    

    let result = document.getElementById("result");
    result.textContent = `${parseFloat(firstNumber.value) - parseFloat(secondNumber.value)}`;
    // console.log(firstNumber);
    
}