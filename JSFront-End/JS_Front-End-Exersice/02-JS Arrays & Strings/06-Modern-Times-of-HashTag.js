function HashTagFinder(text){
    let pattern = /\#[A-Za-z]+/g;

    let matches = text.match(pattern);

    // if (!matches) return; 


    for (const match of matches) {
        console.log(match.substring(1));
        
        
    }
    // console.log(matches);
    
}

HashTagFinder('Nowadays everyone uses # to tag a #special word in #socialMedia');