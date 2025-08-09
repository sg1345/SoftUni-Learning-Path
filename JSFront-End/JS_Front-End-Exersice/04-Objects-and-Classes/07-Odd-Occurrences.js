function oddOccurences(str){
    let words = str.split(' ').map(word => word.toLowerCase());

    let wordCount = {};

    for (const word of words) {
        if(wordCount[word] === undefined){
            wordCount[word] = 0;
        }

        wordCount[word]++;
    }

    let result = [];

    for (const [word, count] of Object.entries(wordCount).sort((a,b) => b[1] - a[1])) {
        if(count % 2 === 1){
            result.push(word);
        }
    }

    console.log(result.join(' '));
    
}

oddOccurences('Java C# Php PHP Java PhP 3 C# 3 1 5 C#');