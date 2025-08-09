function charactersInRange(char1, char2){
    if(char1 > char2){
        characterPrinter(char2, char1);
    }
    else{
        characterPrinter(char1,char2);
    }

    function characterPrinter(smallerCharCode,biggerCharCode){
        let forPrinting = [];
        for (let i = smallerCharCode.charCodeAt(0)+1; i < biggerCharCode.charCodeAt(0); i++) {
            forPrinting.push(String.fromCharCode(i));
                      
        }

        console.log(forPrinting.join(' '));
        
    }
}

charactersInRange('d','a');
charactersInRange('a','d');
