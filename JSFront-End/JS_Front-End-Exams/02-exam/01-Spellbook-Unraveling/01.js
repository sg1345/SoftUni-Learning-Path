function decoder(dataArr) {
    let word = dataArr.shift();

    while (dataArr[0] !== "End") {
        const token = dataArr.shift().split('!');
        const command = token[0];

        if (command === "RemoveEven") {
            let newWord = '';
            for (let i = 0; i < word.length; i++) {
                if ((i + 1) % 2 !== 0) {
                    newWord += word[i];
                }
            }
            word = newWord;
        }
        else if (command === 'TakePart') {
            const startIndex = Number(token[1]);
            const endIndex = Number(token[2]);
            //maybe ckeck for valid indices

            word = word.substring(startIndex, endIndex);
        }
        else {
            const substring = token[1];
            if (word.includes(substring)) {
                const reversedSubstring = substring.split('').reverse().join('');
                word = word.replace(substring, '');
                word += reversedSubstring;
            } else {
                console.log("Error");
                continue;
            }
        }

        console.log(word);

    }

    console.log(`The concealed spell is: ${word}`);

}


decoder(["asAsl2adkda2mdaczsa",
    "RemoveEven",
    "TakePart!1!9",
    "Reverse!maz",
    "End"]);