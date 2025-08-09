function PrintAndSum(start, end){
    
    let sum=0;
    let sequence='';

    for(let i = start; i <= end; i++){
        sequence += `${i} `;
        sum+=i;            
    }

    console.log(sequence);
    console.log(`Sum: ${sum}`);
    
}

PrintAndSum(0, 5);