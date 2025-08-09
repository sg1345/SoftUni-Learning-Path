function RevealWords(words,text){

    let pattern = /[a-zA-Z]+/g;

    let matches = words.match(pattern);

    let newTex ='';

    for (const match of matches) {
        text = text.replace('*'.repeat(match.length), match)

    }
    
    console.log(text);
       
}

RevealWords('great', 'softuni is ***** place for learning new programming languages');
RevealWords('great, learning', 'softuni is ***** place for ******** new programming languages');