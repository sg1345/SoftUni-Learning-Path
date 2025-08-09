window.addEventListener("load", solve);

function solve() {
    const inputEmailEl = document.querySelector("#email");
    const inputEventEl = document.querySelector("#event");
    const inputLocationel = document.querySelector("#location");

    const nextBtnEl = document.querySelector("#next-btn");
    nextBtnEl.addEventListener("click", onClick);

    function onClick() {
        const previewListUlEl = document.querySelector("#preview-list");

        const email = inputEmailEl.value.trim();
        const event = inputEventEl.value.trim();
        const location = inputLocationel.value.trim();

        if (!email || !event || !location) {
            return;
        }

        const liEl = document.createElement("li");
        liEl.classList.add("application");

        const articleEl = document.createElement("article");
        const editBtnEl = document.createElement("button");
        const applyBtnEl = document.createElement("button");

        const h4El = document.createElement("h4");
        const eventPEl = document.createElement('p');
        const locationPEl = document.createElement('p');

        const strongEventEl = document.createElement('strong');
        const brEventEl = document.createElement('br');

        const strongLocationEl = document.createElement('strong');
        const brLocationEl = document.createElement('br');

        editBtnEl.classList.add("action-btn");
        editBtnEl.classList.add("edit");
        editBtnEl.textContent = 'Edit';
        editBtnEl.addEventListener('click', editEvent);

        applyBtnEl.classList.add("action-btn");
        applyBtnEl.classList.add("apply");
        applyBtnEl.textContent = 'Apply';
        applyBtnEl.addEventListener('click', applyEvent);

        h4El.textContent = email;
        strongEventEl.textContent = 'Event:';
        strongLocationEl.textContent = 'Location:';

        eventPEl.appendChild(strongEventEl);
        eventPEl.appendChild(brEventEl);
        eventPEl.appendChild(document.createTextNode(event));

        locationPEl.appendChild(strongLocationEl);
        locationPEl.appendChild(brLocationEl);
        locationPEl.appendChild(document.createTextNode(location));

        articleEl.appendChild(h4El);
        articleEl.appendChild(eventPEl);
        articleEl.appendChild(locationPEl);

        liEl.appendChild(articleEl);
        liEl.appendChild(editBtnEl);
        liEl.appendChild(applyBtnEl);

        previewListUlEl.appendChild(liEl);
        // console.log(liEl);

        inputEmailEl.value = '';
        inputEventEl.value = '';
        inputLocationel.value = '';

        nextBtnEl.disabled = true;

    }

    function editEvent(e) {
        const liEl = e.target.parentElement;

        const email = liEl.querySelector('h4').textContent;
        const event = liEl.querySelector('article p:nth-child(2)').textContent.split(':')[1].trim();
        const location = liEl.querySelector('article p:nth-child(3)').textContent.split(':')[1].trim();

        inputEmailEl.value = email;
        inputEventEl.value = event;
        inputLocationel.value = location;

        liEl.remove();

        nextBtnEl.disabled = false;
    }

    function applyEvent(e) {
        const currentLiEl = e.target.parentElement;
        // console.log(currentLiEl);

        const cloneLiEl = currentLiEl.cloneNode(true);

        cloneLiEl.children[1].remove();
        cloneLiEl.children[1].remove();
        // console.log(cloneLiEl);




        const eventListEl = document.querySelector("#event-list");
        // console.log(eventListEl);


        eventListEl.appendChild(cloneLiEl);
        currentLiEl.remove();

        nextBtnEl.disabled = false;

    }
}
