//elements for general use
const inputModelEl = document.querySelector('#car-model');
const inputServiceEl = document.querySelector('#car-service');
const inputDateEl = document.querySelector('#date');
const appointmentsListUlEl = document.querySelector('#appointments-list');

//elements for events
const addBtnEl = document.querySelector('#add-appointment');
const editBtnEl = document.querySelector('#edit-appointment');
const loadBtnEl = document.querySelector('#load-appointments');

//events
addBtnEl.addEventListener('click', addAppointment);
editBtnEl.addEventListener('click', editAppointment);
loadBtnEl.addEventListener('click', loadAppointments);


let currentRecordId = '';

async function loadAppointments() {
    appointmentsListUlEl.innerHTML = '';

    const recordRes = await fetch('http://localhost:3030/jsonstore/appointments/');
    const recordData = await recordRes.json();
    const objDataArr = Object.values(recordData);
    // console.log(objDataArr);

    for (const record of objDataArr) {
        const date = record.date;
        const model = record.model;
        const service = record.service;
        const id = record._id;

        // console.log(model, service, date, id);


        const liEl = document.createElement('li');

        const h2ModelEl = document.createElement('h2');
        const h3DateEl = document.createElement('h3');
        const h3ServiceEl = document.createElement('h3');

        const divBtnsEl = document.createElement('div');
        const changeBtnEl = document.createElement('button');
        const deleteBtnEl = document.createElement('button');

        liEl.classList.add('appointment');
        liEl.setAttribute('record-id', id);

        h2ModelEl.textContent = model;
        h3DateEl.textContent = date;
        h3ServiceEl.textContent = service;

        changeBtnEl.classList.add('change-btn');
        changeBtnEl.textContent = 'Edit';
        changeBtnEl.addEventListener('click', changeInfo);
        deleteBtnEl.classList.add('delete-btn');
        deleteBtnEl.textContent = 'Delete';
        deleteBtnEl.addEventListener('click', deleteAppointment);

        divBtnsEl.appendChild(changeBtnEl);
        divBtnsEl.appendChild(deleteBtnEl);

        liEl.appendChild(h2ModelEl);
        liEl.appendChild(h3DateEl);
        liEl.appendChild(h3ServiceEl);
        liEl.appendChild(divBtnsEl);

        appointmentsListUlEl.appendChild(liEl);
    }
}

async function addAppointment(e) {
    e.preventDefault();

    const model = inputModelEl.value.trim();
    const service = inputServiceEl.value.trim();
    const date = inputDateEl.value.trim();

    if (!model || !service || !date) {
        return;
    }

    await fetch('http://localhost:3030/jsonstore/appointments/', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({
            model,
            service,
            date
        })
    });

    inputModelEl.value = '';
    inputServiceEl.value = '';
    inputDateEl.value = '';

    loadAppointments();
}

async function editAppointment(e) {
    e.preventDefault();

    const model = inputModelEl.value.trim();
    const service = inputServiceEl.value.trim();
    const date = inputDateEl.value.trim();

    if (!model || !service || !date) {
        return;
    }

    await fetch(`http://localhost:3030/jsonstore/appointments/${currentRecordId}`, {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({
            model,
            service,
            date,
            _id: currentRecordId
        })
    });

    currentRecordId = '';

    inputModelEl.value = '';
    inputServiceEl.value = '';
    inputDateEl.value = '';

    addBtnEl.disabled = false;
    editBtnEl.disabled = true;

    loadAppointments();
}

async function deleteAppointment(e) {
    e.preventDefault();
    const currentLiEl = e.target.parentElement.parentElement;
    currentRecordId = currentLiEl.getAttribute('record-id');
    // console.log(currentRecordId);

    await fetch(`http://localhost:3030/jsonstore/appointments/${currentRecordId}`, {
        method: 'DELETE'
    });

    currentRecordId = '';
    loadAppointments();
}

function changeInfo(e) {
    e.preventDefault();
    const currentLiEl = e.target.parentElement.parentElement;
    console.log(currentLiEl);
    const model = currentLiEl.querySelector('h2').textContent.trim();
    const service = currentLiEl.querySelector('h3:nth-child(3)').textContent;
    const date = currentLiEl.querySelector('h3:nth-child(2)').textContent;
    // console.log(model, service, date);

    currentRecordId = e.target.parentElement.parentElement.getAttribute('record-id');
    inputModelEl.value = model;
    inputServiceEl.value = service;
    inputDateEl.value = date;

    addBtnEl.disabled = true;
    editBtnEl.disabled = false;

    currentLiEl.remove();
}