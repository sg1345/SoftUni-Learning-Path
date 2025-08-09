function solve() {
  let text = document.getElementById("text");
  let namingConvention = document.getElementById("naming-convention");
  let result = document.getElementById("result");
  let temp = '';

  if(namingConvention.value === 'Camel Case'){
    temp = text.value.split(' ').map(word => upperCaseFirstLetter(word)).join('');
    temp = temp[0].toLowerCase() + temp.slice(1);
    result.textContent = temp;
  }
  else if (namingConvention.value === 'Pascal Case'){
    temp = text.value.split(' ').map(word => upperCaseFirstLetter(word)).join('');
    result.textContent = temp;
  }
  else{
    temp = "Error!";
    result.textContent = temp;
  }
  
  function upperCaseFirstLetter(word){
    return word[0].toUpperCase() + word.slice(1).toLowerCase();
  }
 
}