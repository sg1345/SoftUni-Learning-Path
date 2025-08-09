const phonebookUlEl = document.getElementById('phonebook');
const btnLoadEl = document.getElementById('btnLoad');

const inputPersonEl = document.getElementById('person');
const inputPhoneEl = document.getElementById('phone');
const btnCreateEl = document.getElementById('btnCreate');

function attachEvents() {
    btnLoadEl.addEventListener('click', loadPhonebook);
    btnCreateEl.addEventListener('click', createContact);
}

attachEvents();

async function loadPhonebook() {

    phonebookUlEl.innerHTML = '';
    const phonebookRes = await fetch('http://localhost:3030/jsonstore/phonebook');
    const phonebookData = await phonebookRes.json();
    const objPhonebook = Object.values(phonebookData);
    // console.log(objPhonebook);

    for (const contact of objPhonebook) {
        const newLiEl = document.createElement('li');
        newLiEl.textContent = `${contact.person}: ${contact.phone}`;

        const deleteBtn = document.createElement('button');
        deleteBtn.textContent = 'Delete';

        phonebookUlEl.appendChild(newLiEl);
        newLiEl.appendChild(deleteBtn);

        deleteBtn.addEventListener('click', deleteContact);

        async function deleteContact() {
            await fetch(`http://localhost:3030/jsonstore/phonebook/${contact._id}`, {
                method: 'DELETE'
            });

            loadPhonebook();
        }
    }

}

async function createContact() {
    const person = inputPersonEl.value;
    const phone = inputPhoneEl.value;

    await fetch('http://localhost:3030/jsonstore/phonebook', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({ person, phone })
    });

    inputPersonEl.value = '';
    inputPhoneEl.value = '';
    loadPhonebook();
}