//elements for general use
const inputTitleEl = document.querySelector('#title');
const inputDirectorEl = document.querySelector('#director');
const inputYearEl = document.querySelector('#year');
const movieListEl = document.querySelector('#movie-list');

//elements for events
const addMovieBtnEl = document.querySelector('#add-movie');
const editMovieBtnEl = document.querySelector('#edit-movie');
const loadMoviesBtnEl = document.querySelector('#load-movies');

addMovieBtnEl.addEventListener('click', addRecord);
editMovieBtnEl.addEventListener('click', editRecord);
loadMoviesBtnEl.addEventListener('click', loadRecords);


let currentRecordId = '';
movieListEl.innerHTML = '';

async function loadRecords() {
    movieListEl.innerHTML = '';
    const recordRes = await fetch('http://localhost:3030/jsonstore/movies/');
    const recordData = await recordRes.json();
    const objDataArr = Object.values(recordData);
    console.log(objDataArr);

    for (const record of objDataArr) {
        const title = record.title;
        const director = record.director;
        const year = record.year;
        const id = record._id;

        const divMovieEl = document.createElement('div');
        const divContentEl = document.createElement('div');
        const pTitleEl = document.createElement('p');
        const pDirectorEl = document.createElement('p');
        const pYearEl = document.createElement('p');
        const divBtnContainerEl = document.createElement('div');
        const changeBtnEl = document.createElement('button');
        const deleteBtnEl = document.createElement('button');

        divMovieEl.classList.add('movie');
        divContentEl.classList.add('content');
        divBtnContainerEl.classList.add('buttons-container');
        changeBtnEl.classList.add('change-btn');
        deleteBtnEl.classList.add('delete-btn');

        pTitleEl.textContent = title;
        pDirectorEl.textContent = director;
        pYearEl.textContent = year;
        changeBtnEl.textContent = 'Change';
        deleteBtnEl.textContent = 'Delete';

        changeBtnEl.addEventListener('click', changeInfo);
        deleteBtnEl.addEventListener('click', deleteRecord);

        divMovieEl.setAttribute('record-id', id);

        divContentEl.appendChild(pTitleEl);
        divContentEl.appendChild(pDirectorEl);
        divContentEl.appendChild(pYearEl);

        divBtnContainerEl.appendChild(changeBtnEl);
        divBtnContainerEl.appendChild(deleteBtnEl);

        divMovieEl.appendChild(divContentEl);
        divMovieEl.appendChild(divBtnContainerEl);

        movieListEl.appendChild(divMovieEl);
    }

}

async function addRecord(e) {
    e.preventDefault();

    const title = inputTitleEl.value.trim();
    const director = inputDirectorEl.value.trim();
    const year = inputYearEl.value.trim();

    if (!title || !director || !year) {
        return;
    }

    const recordRes = await fetch('http://localhost:3030/jsonstore/movies/', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({
            title,
            director,
            year
        })
    });

    inputTitleEl.value = '';
    inputDirectorEl.value = '';
    inputYearEl.value = '';

    loadRecords();
}

async function editRecord(e) {
    e.preventDefault();
    // console.log(currentRecordId);
    const title = inputTitleEl.value.trim();
    const director = inputDirectorEl.value.trim();
    const year = inputYearEl.value.trim();
    const _id = currentRecordId;

    await fetch(`http://localhost:3030/jsonstore/movies/${_id}`, {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({
            title,
            director,
            year,
            _id
        })
    });

    currentRecordId = '';
    inputTitleEl.value = '';
    inputDirectorEl.value = '';
    inputYearEl.value = '';

    addMovieBtnEl.disabled = false;
    editMovieBtnEl.disabled = true;

    loadRecords();

}

async function deleteRecord(e) {
    e.preventDefault();

    currentRecordId = e.target.parentElement.parentElement.getAttribute('record-id');

    const recordRes = await fetch(`http://localhost:3030/jsonstore/movies/${currentRecordId}`, {
        method: 'DELETE'
    });

    currentRecordId = '';
    loadRecords();
}

function changeInfo(e) {
    e.preventDefault();
    const currentMovieDivEl = e.target.parentElement.parentElement;
    const contentDivEl = currentMovieDivEl.querySelector('.content');
    console.log(currentMovieDivEl);

    const title = contentDivEl.querySelector('p:nth-child(1)').textContent;
    const director = contentDivEl.querySelector('p:nth-child(2)').textContent;
    const year = contentDivEl.querySelector('p:nth-child(3)').textContent;
    currentRecordId = currentMovieDivEl.getAttribute('record-id');
    // console.log(title, director, year, currentRecordId);

    inputTitleEl.value = title;
    inputDirectorEl.value = director;
    inputYearEl.value = year;

    addMovieBtnEl.disabled = true;
    editMovieBtnEl.disabled = false;

    currentMovieDivEl.remove();
}