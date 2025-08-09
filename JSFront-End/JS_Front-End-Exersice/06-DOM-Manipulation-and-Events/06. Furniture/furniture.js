document.addEventListener('DOMContentLoaded', solve);

function solve() {
  const generateFormEl = document.querySelector('#input');
  const buyFormEl = document.querySelector('#shop');
  // console.log(buyFormEl);
  
  
  generateFormEl.addEventListener("submit", generataFurniture);
  buyFormEl.addEventListener("submit", buyFurniture);

  function generataFurniture(e) {
    e.preventDefault();
    
    const jsonObj = JSON.parse(e.target.querySelector('textarea').value);
    
    for (const element of jsonObj) {
      const tbodyEl = document.querySelector('tbody');

      const newTr = document.createElement('tr');
      const imgTd = document.createElement('td');
      const nameTd = document.createElement('td');
      const priceTd = document.createElement('td');
      const decFactorTd = document.createElement('td');
      const markTd = document.createElement('td');
      
      const imgEl = document.createElement('img');
      const pNameEl = document.createElement('p');
      const pPriceEl = document.createElement('p');
      const pDecFactorEl = document.createElement('p');
      const inputCheckboxEl = document.createElement('input');


      imgEl.src = element.img; 
      pNameEl.textContent = element.name;
      pPriceEl.textContent = element.price;
      pDecFactorEl.textContent = element.decFactor;
      inputCheckboxEl.type = 'checkbox';
      
      imgTd.appendChild(imgEl);
      nameTd.appendChild(pNameEl);

      priceTd.appendChild(pPriceEl);
      decFactorTd.appendChild(pDecFactorEl);
      markTd.appendChild(inputCheckboxEl);
       
      newTr.appendChild(imgTd);
      newTr.appendChild(nameTd);
      newTr.appendChild(priceTd);
      newTr.appendChild(decFactorTd);
      newTr.appendChild(markTd);

      tbodyEl.appendChild(newTr);
    
    }   
  }
  
  function buyFurniture(e) {
    e.preventDefault();

    const furnitureEls =e.target.querySelectorAll('tbody tr');
    const textareaEl = e.target.querySelector('textarea');
    
    let boughtFurniture = [];
    let totalPrice = 0;
    let avgDecFactor = 0;
    let furnitureNames = '';

    furnitureEls.forEach(element => {
      const checkboxEl = element.querySelector('td input');

      if (checkboxEl.checked) {
      
        const name = element.querySelector('td:nth-of-type(2) p').textContent;
        const price = Number(element.querySelector('td:nth-of-type(3) p').textContent);
        const decFactor = Number(element.querySelector('td:nth-of-type(4) p').textContent);
        
        const furnitureInfo = {
          name,
          price,
          decFactor
        };

        boughtFurniture.push(furnitureInfo);
      }      
    });
    
    totalPrice = boughtFurniture.reduce((sum, item) => sum + item.price, 0);
    avgDecFactor = boughtFurniture.reduce((sum, item) => sum + item.decFactor, 0)/boughtFurniture.length;
    furnitureNames = boughtFurniture.map(item => item.name).join(', ');
    
    textareaEl.value = `Bought furniture: ${furnitureNames}\nTotal price: ${totalPrice}\nAverage decoration factor: ${avgDecFactor}`;
    
    
  }
}