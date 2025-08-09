const textareaEl = document.querySelector('#messages');
const btnSubmitEl = document.querySelector('#submit');
const btnRefreshEl = document.querySelector('#refresh');
const inputAuthorEl = document.querySelector('input[name="author"]');
const inputContentEl = document.querySelector('input[name="content"]');

function attachEvents() {

    btnSubmitEl.addEventListener('click', onSubmit);
    btnRefreshEl.addEventListener('click', onRefresh);
}

attachEvents();

async function onSubmit() {
    const author = inputAuthorEl.value.trim();
    const content = inputContentEl.value.trim();

    const message = { author, content };

    await fetch('http://localhost:3030/jsonstore/messenger', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(message)
    });

}

async function onRefresh() {
    const messagesRes = await fetch('http://localhost:3030/jsonstore/messenger');
    const messagesData = await messagesRes.json();
    // console.log(messagesData);
    const objArrMessagesData = Object.values(messagesData);
    // console.log(objArrMessagesData);
    let messagesArr = [];

    for (const message of objArrMessagesData) {
        messagesArr.push(`${message.author}: ${message.content}`);
    }
    textareaEl.value = messagesArr.join('\n');
}
