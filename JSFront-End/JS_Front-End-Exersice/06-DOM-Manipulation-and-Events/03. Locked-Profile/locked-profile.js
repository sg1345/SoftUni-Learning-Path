document.addEventListener('DOMContentLoaded', solve);

function solve() {
  const ShwoBtnEls = document.querySelectorAll('button');

  ShwoBtnEls.forEach(btnEl => btnEl.addEventListener('click', controlShowProfile));

    function controlShowProfile(e){
        const fullProfileEl = e.target.parentElement;
        // console.log(fullProfileEl);
        
        const inputLocked = fullProfileEl.querySelector('.radio-group input');
        // console.log(inputLocked);
        const hidenEl = fullProfileEl.querySelector('.hidden-fields.active');

        if(!inputLocked.checked){
            // console.log('UnLocked');
            if(e.target.textContent === 'Show more'){
                e.target.textContent = 'Show less';
                
                hidenEl.style.display = 'block';
                
            }
            else{
                e.target.textContent = 'Show more'
                hidenEl.style.display = '';
            }
            
        }
        
    }
}