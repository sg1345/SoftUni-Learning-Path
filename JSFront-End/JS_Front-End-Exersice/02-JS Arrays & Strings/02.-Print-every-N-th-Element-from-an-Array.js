function PrintEveryNthElementFromAnArray(arr,number){

    let newArr = [];

    for (let i = 0; i < arr.length; i+=number) {
        newArr.push(arr[i]);
        
        // console.log(arr[i]);
        
    }

    return newArr;
    
}