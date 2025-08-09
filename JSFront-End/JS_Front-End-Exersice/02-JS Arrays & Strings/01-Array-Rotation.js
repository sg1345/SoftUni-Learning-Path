function ArrayRotation(arr,number){
    for (let i = 0; i < number; i++) {
        // let currentNumber = arr.shift();
        arr.push(arr.shift());
        
    }

    console.log(arr.join(' '));
    
}


ArrayRotation([51, 47, 32, 61, 21], 2);