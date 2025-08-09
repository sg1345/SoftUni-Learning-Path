gameStarting();
const loadGamesBtnEl = document.getElementById('load-games');
// const changeBtnEl = document.querySelector('.change-btn');
// const deleteBtnEl = document.querySelector('.delete-btn');
const addGameBtnEl = document.querySelector('div[id="btn-container"] button[id="add-game"]');
const editGameBtnEl = document.querySelector('div[id="btn-container"] button[id="edit-game"]');

loadGamesBtnEl.addEventListener('click', loadGames);
// changeBtnEl.addEventListener('click', changeInfo);
// deleteBtnEl.addEventListener('click', deleteGame);
addGameBtnEl.addEventListener('click', addGame);
editGameBtnEl.addEventListener('click', editGame);

let currentEditId = '';

async function loadGames(e) {
    const sectionGamesEl = document.querySelector('section[id="games"]');
    const divGamesListEl = sectionGamesEl.querySelector('#games-list');
    // console.log(divGamesListEl);
    divGamesListEl.innerHTML = '';

    const gamesRes = await fetch('http://localhost:3030/jsonstore/games/');
    const gamesData = await gamesRes.json();
    console.log(gamesData);
    const objGamesArr = Object.values(gamesData);
    // console.log(objGamesArr.length);

    for (const game of objGamesArr) {
        // console.log(game);

        const divBoardGameEl = document.createElement('div');
        divBoardGameEl.classList.add('board-game');
        // console.log(game._id);

        divBoardGameEl.setAttribute('data-id', game._id);

        const divContentEl = document.createElement('div');
        divContentEl.classList.add('content');

        const pNameEl = document.createElement('p');
        pNameEl.textContent = game.name;

        const pPlayersEl = document.createElement('p');
        pPlayersEl.textContent = game.players;

        const pTypeEl = document.createElement('p');
        pTypeEl.textContent = game.type;

        divContentEl.appendChild(pNameEl);
        divContentEl.appendChild(pPlayersEl);
        divContentEl.appendChild(pTypeEl);

        const divBtnsEl = document.createElement('div');
        divBtnsEl.classList.add('buttons-container');

        const changeBtnEl = document.createElement('button');
        changeBtnEl.classList.add('change-btn');
        changeBtnEl.textContent = 'Change';

        changeBtnEl.addEventListener('click', changeInfo);

        const deleteBtnEl = document.createElement('button');
        deleteBtnEl.classList.add('delete-btn');
        deleteBtnEl.textContent = 'Delete';

        deleteBtnEl.addEventListener('click', deleteGame);

        divBtnsEl.appendChild(changeBtnEl);
        divBtnsEl.appendChild(deleteBtnEl);

        divBoardGameEl.appendChild(divContentEl);
        divBoardGameEl.appendChild(divBtnsEl);

        divGamesListEl.appendChild(divBoardGameEl);

    }
}

async function addGame(e) {
    const formEl = e.target.parentElement.parentElement;
    // console.log(formEl);

    const inputGameNameEl = formEl.querySelector('input[id ="g-name"]');
    const inputTypeEl = formEl.querySelector('input[id="type"]');
    const inputMaxPlayersEl = formEl.querySelector('input[id="players"]');
    // console.log(inputGameNameEl, inputTypeEl, inputMaxPlayersEl);

    await fetch('http://localhost:3030/jsonstore/games/', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({
            name: inputGameNameEl.value.trim(),
            type: inputTypeEl.value.trim(),
            players: inputMaxPlayersEl.value.trim()
        })
    });

    loadGames();
    inputGameNameEl.value = '';
    inputTypeEl.value = '';
    inputMaxPlayersEl.value = '';

}

async function deleteGame(e) {
    const boardGameEl = e.target.parentElement.parentElement;
    console.log(boardGameEl);

    const gamesRes = await fetch('http://localhost:3030/jsonstore/games/');
    const gamesData = await gamesRes.json();
    // console.log(gamesData);
    const objGamesArr = Object.values(gamesData);

    const gameName = boardGameEl.querySelector('p:nth-child(1)').textContent;
    const gameId = objGamesArr.find(game => game.name === gameName)._id;
    // console.log(gameId);

    await fetch(`http://localhost:3030/jsonstore/games/${gameId}`, {
        method: 'DELETE'
    });

    loadGames();
}

async function editGame(e) {
    e.preventDefault();
    const formEl = e.target.parentElement.parentElement;

    const inputGameNameEl = formEl.querySelector('input[id ="g-name"]');
    const inputTypeEl = formEl.querySelector('input[id="type"]');
    const inputMaxPlayersEl = formEl.querySelector('input[id="players"]');

    const gamesRes = await fetch('http://localhost:3030/jsonstore/games/');
    const gamesData = await gamesRes.json();
    const objGamesArr = Object.values(gamesData);

    const gameId = currentEditId;
    currentEditId = '';


    await fetch(`http://localhost:3030/jsonstore/games/${gameId}`, {
        method: 'PUT',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({
            name: inputGameNameEl.value.trim(),
            type: inputTypeEl.value.trim(),
            players: inputMaxPlayersEl.value.trim(),
            _id: gameId
        })
    });
    addGameBtnEl.disabled = false;
    editGameBtnEl.disabled = true;

    loadGames();
    inputGameNameEl.value = '';
    inputTypeEl.value = '';
    inputMaxPlayersEl.value = '';
}

function changeInfo(e) {
    const boardGameEl = e.target.parentElement.parentElement;
    const formEl = document.querySelector('form');

    console.log(boardGameEl);
    currentEditId = boardGameEl.getAttribute('data-id');
    console.log(currentEditId);

    const pNameEl = boardGameEl.querySelector('p:nth-child(1)');
    const pPlayersEl = boardGameEl.querySelector('p:nth-child(2)');
    const pTypeEl = boardGameEl.querySelector('p:nth-child(3)');

    // console.log(pNameEl, pTypeEl, pPlayersEl);


    const inputGameNameEl = formEl.querySelector('input[id ="g-name"]');
    const inputTypeEl = formEl.querySelector('input[id="type"]');
    const inputMaxPlayersEl = formEl.querySelector('input[id="players"]');
    // console.log(inputGameNameEl, inputTypeEl, inputMaxPlayersEl);


    inputGameNameEl.value = pNameEl.textContent;
    inputTypeEl.value = pTypeEl.textContent;

    inputMaxPlayersEl.value = pPlayersEl.textContent;

    addGameBtnEl.disabled = true;
    editGameBtnEl.disabled = false;

}

function gameStarting() {
    const divGamesListEl = document.querySelector('#games-list');
    divGamesListEl.innerHTML = '';
}
