function SortingNumbers(arr){
    let sortedArray = [];
    arr.sort((a,b) => a - b);

    while(arr.length !== 0){
        sortedArray.push(arr.shift());
        
        if(arr.length === 0){
            break;
        }

        sortedArray.push(arr.pop());
    }

    return sortedArray;
}