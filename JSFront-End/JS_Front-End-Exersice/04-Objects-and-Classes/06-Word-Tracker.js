function wordTracker(arr){

    let wordsToSearchTemp = arr[0].split(' ');
    let words = arr.slice(1);

    let wordsToSearch = {};

    for (const wordTosSearchTemp of wordsToSearchTemp) {
        
        wordsToSearch[wordTosSearchTemp] = 0;

        for (const currentWord of words) {

            if(currentWord === wordTosSearchTemp){
                wordsToSearch[wordTosSearchTemp]++;
            }
        }
    }


    for (const [word, count] of Object.entries(wordsToSearch).sort((a,b) => b[1] - a[1])) {
        console.log(`${word} - ${count}`);
        
    }
}

wordTracker([
'this sentence', 
'In', 'this', 'sentence', 'you', 'have', 'to', 'count', 'the', 'occurrences', 'of', 'the', 'words', 'this', 'and', 'sentence', 'because', 'this', 'is', 'your', 'task'
]
);