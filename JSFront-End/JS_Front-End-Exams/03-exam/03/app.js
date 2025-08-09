//Elements for general use
const divListEl = document.querySelector('#list');
const inputWorkoutEl = document.querySelector('#workout');
const inputLocationEl = document.querySelector('#location');
const inputDateEl = document.querySelector('#date');

//Elements for events
const addBtnEl = document.querySelector('#add-workout');
const editBtnEl = document.querySelector('#edit-workout');
const loadBtnEl = document.querySelector('#load-workout');

//Other shit
addBtnEl.addEventListener('click', addWorkout);
editBtnEl.addEventListener('click', editWorkout);
loadBtnEl.addEventListener('click', loadData);


let currentId = '';
divListEl.innerHTML = '';

async function loadData() {
    divListEl.innerHTML = '';
    const recordsRes = await fetch('http://localhost:3030/jsonstore/workout/');
    const recordsData = await recordsRes.json();
    const objRecordsArr = Object.values(recordsData);
    console.log(objRecordsArr);

    for (const record of objRecordsArr) {

        const divContainerEl = document.createElement('div');

        const workoutH2El = document.createElement('h2');
        const dateH3El = document.createElement('h3');
        const locationH3El = document.createElement('h3');
        const divButtonsEl = document.createElement('div');

        const changeBtnEl = document.createElement('button');
        const deleteBtnEl = document.createElement('button');

        divContainerEl.classList.add('container');
        divContainerEl.setAttribute('record-id', record._id);
        divButtonsEl.classList.add('buttons-container');

        workoutH2El.textContent = record.workout;
        dateH3El.textContent = record.date;
        locationH3El.setAttribute('id', 'location');
        locationH3El.textContent = record.location;

        changeBtnEl.classList.add('change-btn');
        changeBtnEl.textContent = 'Change';
        changeBtnEl.addEventListener('click', changeWorkout);

        deleteBtnEl.classList.add('delete-btn');
        deleteBtnEl.textContent = 'Done';
        deleteBtnEl.addEventListener('click', deleteWorkout);

        divButtonsEl.appendChild(changeBtnEl);
        divButtonsEl.appendChild(deleteBtnEl);

        divContainerEl.appendChild(workoutH2El);
        divContainerEl.appendChild(dateH3El);
        divContainerEl.appendChild(locationH3El);
        divContainerEl.appendChild(divButtonsEl);

        divListEl.appendChild(divContainerEl);

    }


}

async function addWorkout() {
    const workout = inputWorkoutEl.value.trim();
    const location = inputLocationEl.value.trim();
    const date = inputDateEl.value.trim();

    if (!workout || !location || !date) {
        return;
    }

    await fetch('http://localhost:3030/jsonstore/workout/', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({
            workout,
            location,
            date

        })
    });

    inputWorkoutEl.value = '';
    inputLocationEl.value = '';
    inputDateEl.value = '';

    loadData();

}

async function editWorkout() {
    console.log(currentId);

    await fetch(`http://localhost:3030/jsonstore/workout/${currentId}`, {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({
            workout: inputWorkoutEl.value.trim(),
            location: inputLocationEl.value.trim(),
            date: inputDateEl.value.trim(),
            _id: currentId
        })
    });

    editBtnEl.disabled = true;
    addBtnEl.disabled = false;

    inputWorkoutEl.value = '';
    inputLocationEl.value = '';
    inputDateEl.value = '';
    currentId = '';
    loadData();
}

async function deleteWorkout(e) {
    const currentDivEl = e.target.parentElement.parentElement;
    currentId = currentDivEl.getAttribute('record-id');
    // console.log(currentDivEl.getAttribute('record-id'));

    await fetch(`http://localhost:3030/jsonstore/workout/${currentId}`, {
        method: 'DELETE'
    });

    currentId = '';
    loadData();
}

function changeWorkout(e) {
    const currentDivEl = e.target.parentElement.parentElement;
    currentId = currentDivEl.getAttribute('record-id');
    console.log(currentId);

    inputWorkoutEl.value = currentDivEl.children[0].textContent;
    inputLocationEl.value = currentDivEl.children[2].textContent;
    inputDateEl.value = currentDivEl.children[1].textContent;

    currentDivEl.remove();

    editBtnEl.disabled = false;
    addBtnEl.disabled = true;
}