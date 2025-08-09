window.addEventListener("load", solve);

function solve() {
    //Elements for general use
    const inputEventNameEl = document.getElementById("event");
    const inputNoteEl = document.getElementById("note");
    const inputDateEl = document.getElementById("date");
    const ulUpcomingEventsEl = document.getElementById("upcoming-list");
    const eventListUlEl = document.getElementById("events-list");

    // console.log(inputEventNameEl, inputNoteEl, inputDateEl);


    const saveBtnEl = document.getElementById("save");
    const deleteBtnEl = document.querySelector(".btn.delete");
    // console.log(saveBtnEl, deleteBtnEl);


    saveBtnEl.addEventListener("click", saveEvent);
    deleteBtnEl.addEventListener("click", deleteEvent);

    function saveEvent() {

        if (!inputEventNameEl.value || !inputNoteEl.value || !inputDateEl.value) {
            return;
        }

        const liEl = document.createElement("li");
        liEl.classList.add("event-item");

        const divEventContainerEl = document.createElement("div");
        divEventContainerEl.classList.add("event-container");

        const articleEl = document.createElement("article");

        const pEventNameEl = document.createElement("p");
        pEventNameEl.textContent = `Name: ${inputEventNameEl.value}`;

        const pNoteEl = document.createElement("p");
        pNoteEl.textContent = `Note: ${inputNoteEl.value}`;

        const pDateEl = document.createElement("p");
        pDateEl.textContent = `Date: ${inputDateEl.value}`;

        articleEl.appendChild(pEventNameEl);
        articleEl.appendChild(pNoteEl);
        articleEl.appendChild(pDateEl);

        const divButtonsEl = document.createElement("div");
        divButtonsEl.classList.add("buttons");

        const editBtnEl = document.createElement("button");
        editBtnEl.classList.add("btn", "edit");
        editBtnEl.textContent = "Edit";
        editBtnEl.addEventListener("click", editEvent);

        const doneBtnEl = document.createElement("button");
        doneBtnEl.classList.add("btn", "done");
        doneBtnEl.textContent = "Done";
        doneBtnEl.addEventListener("click", endEvent);

        divButtonsEl.appendChild(editBtnEl);
        divButtonsEl.appendChild(doneBtnEl);

        divEventContainerEl.appendChild(articleEl);
        divEventContainerEl.appendChild(divButtonsEl);

        liEl.appendChild(divEventContainerEl);

        ulUpcomingEventsEl.appendChild(liEl);

        inputEventNameEl.value = "";
        inputNoteEl.value = "";
        inputDateEl.value = "";

    }

    function editEvent(e) {
        const liEl = e.target.parentElement.parentElement.parentElement;
        // console.log(liEl);

        const articleEl = liEl.querySelector("article");
        const eventName = articleEl.querySelector("p:nth-child(1)").textContent.split(": ")[1].trim();
        const note = articleEl.querySelector("p:nth-child(2)").textContent.split(": ")[1].trim();
        const date = articleEl.querySelector("p:nth-child(3)").textContent.split(": ")[1].trim();

        // console.log(eventName, note, date);

        inputEventNameEl.value = eventName;
        inputNoteEl.value = note;
        inputDateEl.value = date;

        liEl.remove();

    }

    function endEvent(e) {
        const liEl = e.target.parentElement.parentElement.parentElement;

        console.log(liEl);

        const newLiEl = document.createElement('li');
        newLiEl.classList.add("event-item");

        const articleEl = liEl.querySelector("article");

        const newArticleEl = articleEl.cloneNode(true);

        // console.log(newArticleEl);

        newLiEl.appendChild(newArticleEl);
        eventListUlEl.appendChild(newLiEl);

        liEl.remove();
    }

    function deleteEvent() {
        eventListUlEl.innerHTML = "";
    }
}

