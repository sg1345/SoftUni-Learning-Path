function PascalCaseSplitter(word){
    let pattern = /[A-Z][a-z]*/g;

    let matches = word.match(pattern);

    let result = '';

    for (const match of matches) {
        result+=`${match} `;
    }
    console.log(matches.join(', '));
    
}

PascalCaseSplitter('SplitMeIfYouCanHaHaYouCantOrYouCan');