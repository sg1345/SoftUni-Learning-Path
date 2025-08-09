function stringSubstring( word, text){
    let copyText = text.toLowerCase().split(' ');
    let copyWord = word.toLowerCase();

    if(copyText.includes(copyWord)){
        console.log(word);
        
    }
    else{
        console.log(`${word} not found!`);      
    }
}

stringSubstring('javascript', 'JavaScript is the best programming language');