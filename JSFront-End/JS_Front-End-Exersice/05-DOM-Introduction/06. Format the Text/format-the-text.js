function solve() {
  let textArea = document.getElementById("input");
  let result= document.getElementById("output");

  result.innerHTML = "";

  let textArray = textArea.value.trim().split(".").filter(item => item !=="");
  console.log(textArray);
  
  let sentenceCounter = 0;
  
  let temp = '';
  while (true) {

    if(textArray.length === 0){
      if(temp.length !== 0){
        let paragraph = document.createElement("p");
        paragraph.textContent = temp;
        temp= '';
        result.appendChild(paragraph);
      }
      break;
    }

    if(sentenceCounter === 3){
      sentenceCounter = 0;
      let paragraph = document.createElement("p");
      paragraph.textContent = temp;
      temp= '';
      result.appendChild(paragraph);
      
      continue;
    }

    temp += textArray.shift().trim() + ".";
    sentenceCounter++; 
  }
}