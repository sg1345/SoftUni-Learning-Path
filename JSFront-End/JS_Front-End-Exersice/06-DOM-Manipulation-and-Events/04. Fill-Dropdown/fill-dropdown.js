document.addEventListener('DOMContentLoaded', solve);

function solve() {
    const AddButtonEl = document.querySelector('input[type="submit"]');
    // console.log(AddButtonEl);

    AddButtonEl.addEventListener("click", addFormToMenu);

    function addFormToMenu(e){
        e.preventDefault();
        const formEl = e.target.parentElement;
        // console.log(formEl);
        
        const text = formEl.querySelector('p #newItemText');
        const value = formEl.querySelector('p #newItemValue');
        console.log(text);
        console.log(value);
        
        const newOptionEl = document.createElement('option');
        newOptionEl.textContent = text.value.trim();
        newOptionEl.value = value.value.trim();
        // console.log(newOptionEl);

        const selectMenuEl = document.getElementById('menu');
        selectMenuEl.appendChild(newOptionEl);
        // console.log(selectMenuEl); 
        
        text.value = '';
        value.value = '';
    }   
}