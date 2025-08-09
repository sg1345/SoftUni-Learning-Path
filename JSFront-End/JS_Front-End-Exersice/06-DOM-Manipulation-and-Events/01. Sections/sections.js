document.addEventListener('DOMContentLoaded', solve);

function solve() {
   const formEl = document.getElementById("task-input");
   const textEl = document.querySelector('#task-input input[type="text"]');
   const contentEl = document.getElementById("content")

   formEl.addEventListener('submit',creatingElements);

   function creatingElements(e){
      e.preventDefault();  
      
      let ElementsArr = textEl.value.split(', ');
      
      for (const element of ElementsArr) {

         const newDivEl = document.createElement("div");
         const newPEl = document.createElement("p");

         newPEl.textContent = element;
         newPEl.style.display = "none";

         contentEl.appendChild(newDivEl); 

         newDivEl.addEventListener("click", e=>{
            if(newPEl.style.display === "none"){
               newPEl.style.display = "block";
            }
            else{
               newPEl.style.display = "none";
            }                      
         });
         newDivEl.appendChild(newPEl);         
      }
      
   }
}