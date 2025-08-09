function ListOfNames(arr){

    [...arr].sort((a, b) => a.localeCompare(b)).forEach((element,index) => {
        console.log(`${1+index}.${element}`);
        
    });
    
    // arr.sort((a, b) => a.localeCompare(b));
    
    // for (let i = 0; i < arr.length; i++) {
    //     console.log(`${i+1}.${arr[i]}`);
        
        
    // }
}

ListOfNames(["John", "Bob", "Christina", "Ema"]);
ListOfNames([]);
// ListOfNames(['Name']);