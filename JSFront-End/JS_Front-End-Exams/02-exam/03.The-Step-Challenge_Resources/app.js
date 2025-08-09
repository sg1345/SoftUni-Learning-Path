//general HTML for use
const listUlElement = document.querySelector('ul[id="list"]');
listUlElement.innerHTML = ''; //clearing just in case

const inputNameEl = document.querySelector('input[id="p-name"]');
const inputStepsEl = document.querySelector('input[id="steps"]');
const inputCaloriesEl = document.querySelector('input[id="calories"]');

//buttons for events
const loadBtnEl = document.querySelector('button[id="load-records"]');
const addBtnEl = document.querySelector('button[id="add-record"]');
const editBtnEl = document.querySelector('button[id="edit-record"]');

loadBtnEl.addEventListener('click', loadRecords);
addBtnEl.addEventListener('click', addRecord);
editBtnEl.addEventListener('click', editRecord);


//id currently in use
let currentRecordId = '';

async function loadRecords() {
    listUlElement.innerHTML = '';
    const recordsRes = await fetch('http://localhost:3030/jsonstore/records/');
    const recordsData = await recordsRes.json();

    const objRecordsArr = Object.values(recordsData);
    // console.log(objRecordsArr);

    for (const record of objRecordsArr) {
        const liEl = document.createElement('li');
        liEl.classList.add('record');
        liEl.setAttribute('record-id', record._id);

        const divInfoEl = document.createElement('div');
        divInfoEl.classList.add('info');

        const pNameEl = document.createElement('p');
        pNameEl.textContent = record.name;

        const pStepsEl = document.createElement('p');
        pStepsEl.textContent = record.steps;

        const pCaloriesEl = document.createElement('p');
        pCaloriesEl.textContent = record.calories;

        divInfoEl.appendChild(pNameEl);
        divInfoEl.appendChild(pStepsEl);
        divInfoEl.appendChild(pCaloriesEl);

        const divBtnsEl = document.createElement('div');
        divBtnsEl.classList.add('btn-wrapper');

        const changeBtnEl = document.createElement('button');
        changeBtnEl.classList.add('change-btn');
        changeBtnEl.textContent = 'Change';
        changeBtnEl.addEventListener('click', changeRecord);

        const deleteBtnEl = document.createElement('button');
        deleteBtnEl.classList.add('delete-btn');
        deleteBtnEl.textContent = 'Delete';
        deleteBtnEl.addEventListener('click', deleteRecord);

        divBtnsEl.appendChild(changeBtnEl);
        divBtnsEl.appendChild(deleteBtnEl);

        liEl.appendChild(divInfoEl);
        liEl.appendChild(divBtnsEl);

        listUlElement.appendChild(liEl);
    }

}

async function addRecord(e) {

    if (inputNameEl.value === '' || inputStepsEl.value === '' || inputCaloriesEl.value === '') {
        return;
    }

    await fetch('http://localhost:3030/jsonstore/records/', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({
            name: inputNameEl.value,
            steps: inputStepsEl.value,
            calories: inputCaloriesEl.value
        })
    });

    inputNameEl.value = '';
    inputStepsEl.value = '';
    inputCaloriesEl.value = '';
    loadRecords();

}

async function editRecord(e) {

    await fetch(`http://localhost:3030/jsonstore/records/${currentRecordId}`, {
        method: 'PUT',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({
            name: inputNameEl.value.trim(),
            steps: inputStepsEl.value.trim(),
            calories: inputCaloriesEl.value.trim(),
            _id: currentRecordId
        })
    });

    currentRecordId = '';

    addBtnEl.disabled = false;
    editBtnEl.disabled = true;

    inputNameEl.value = '';
    inputStepsEl.value = '';
    inputCaloriesEl.value = '';
    loadRecords();

}

async function deleteRecord(e) {
    const currentLiEl = e.target.parentElement.parentElement;
    currentRecordId = currentLiEl.getAttribute('record-id')
    await fetch(`http://localhost:3030/jsonstore/records/${currentRecordId}`, {
        method: 'DELETE'
    });

    // loadRecords();
    currentLiEl.remove();
}

function changeRecord(e) {
    const currentLiEl = e.target.parentElement.parentElement;
    currentRecordId = currentLiEl.getAttribute('record-id');

    inputNameEl.value = currentLiEl.querySelector('p:nth-child(1)').textContent;
    inputStepsEl.value = currentLiEl.querySelector('p:nth-child(2)').textContent;
    inputCaloriesEl.value = currentLiEl.querySelector('p:nth-child(3)').textContent;

    addBtnEl.disabled = true;
    editBtnEl.disabled = false;
}