function solve() {
   let table = document.querySelectorAll(".container tbody tr");
   let searchWord = document.getElementById("searchField");

   // console.log(searchWord.value);
   
   // console.log(table);
   if(searchWord.value === ''){
      table.forEach(row =>{
         if(row.classList = "select"){
            row.classList.remove("select");
         }
      })
   }
   else
   {
      table.forEach(row => {
         if(row.textContent.includes(searchWord.value)){
            row.classList.add("select");
            // console.log(temp);
         }
         else{
            row.classList.remove("select");
         }
         // console.log(row.textContent.includes(searchWord.value));
      });
   } 
}