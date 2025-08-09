function solve() {
   let search = document.getElementById("searchText");
   let towns = document.querySelectorAll("#towns li");
   let results = document.getElementById("result");
   let matchesCount = 0;
   // console.log(search);
   // console.log(towns);

   towns.forEach( town => {

      // console.log(town.textContent);
      // console.log(search.value);
      
      // console.log(town.textContent.includes(search.value));
      
      if(town.textContent.includes(search.value)){

         town.style.fontWeight = "bold";
         town.style.opacity = 1;
         town.style.textDecoration = "underline";
         // console.log('ok');
         matchesCount++;          
      }
      else{
         town.style.fontWeight = "";
         town.style.opacity = '';
         town.style.textDecoration = "";
      }

   });

   results.textContent = `${matchesCount} matches found`;
}