window.addEventListener("load", solve);

function solve() {
  //elements for general use
  const inputTypeEl = document.querySelector("#type");
  const inputAgeEl = document.querySelector("#age");
  const inputGenderEl = document.querySelector("#gender");
  const registeredListUlEl = document.querySelector("#registered-list");
  const confirmedListUlEl = document.querySelector("#confirmed-list");

  //element for events
  const registerBtnEl = document.querySelector("#register-btn");


  registerBtnEl.addEventListener("click", registerDonor); //maybe "submit"

  function registerDonor(e) {
    e.preventDefault();
    const type = inputTypeEl.value;
    const age = Number(inputAgeEl.value);
    const gender = inputGenderEl.value;

    if (!type || !age || !gender) {
      return;
    }

    const liEl = document.createElement('li');

    const articleEl = document.createElement('article');
    const divBtnEl = document.createElement('div');

    const pTypeEl = document.createElement('p');
    const pGenderEl = document.createElement('p');
    const pAgeEl = document.createElement('p');

    const editBtnEl = document.createElement('button');
    const doneBtnEl = document.createElement('button');

    divBtnEl.classList.add('buttons');

    pTypeEl.textContent = `Blood Type: ${type}`;
    pTypeEl.setAttribute('data-type', type);
    pGenderEl.textContent = `Gender: ${gender}`;
    pGenderEl.setAttribute('data-gender', gender);
    pAgeEl.textContent = `Age: ${age}`;
    pAgeEl.setAttribute('data-age', age);

    editBtnEl.classList.add('edit-btn');
    editBtnEl.textContent = 'Edit';
    editBtnEl.addEventListener('click', editInfo);
    doneBtnEl.classList.add('done-btn');
    doneBtnEl.textContent = 'Confirm';
    doneBtnEl.addEventListener('click', confirmDonor);

    articleEl.appendChild(pTypeEl);
    articleEl.appendChild(pGenderEl);
    articleEl.appendChild(pAgeEl);

    divBtnEl.appendChild(editBtnEl);
    divBtnEl.appendChild(doneBtnEl);

    liEl.appendChild(articleEl);
    liEl.appendChild(divBtnEl);

    registeredListUlEl.appendChild(liEl);
    // console.log(liEl);

    inputTypeEl.value = '';
    inputAgeEl.value = '';
    inputGenderEl.value = '';
  }

  function editInfo(e) {
    const liEl = e.target.parentElement.parentElement;
    const articleEl = liEl.querySelector('article');
    const pTypeEl = articleEl.querySelector('p[data-type]');
    const pGenderEl = articleEl.querySelector('p[data-gender]');
    const pAgeEl = articleEl.querySelector('p[data-age]');

    inputTypeEl.value = pTypeEl.getAttribute('data-type');
    inputGenderEl.value = pGenderEl.getAttribute('data-gender');
    inputAgeEl.value = pAgeEl.getAttribute('data-age');
    // console.log(pTypeEl, pGenderEl, pAgeEl);

    liEl.remove();
  }

  function confirmDonor(e) {
    const liEl = e.target.parentElement.parentElement;
    const articleEl = liEl.querySelector('article');

    const newLiEl = document.createElement('li');
    const NewArticleEl = articleEl.cloneNode(true);
    const clearBtnEl = document.createElement('button');

    clearBtnEl.classList.add('clear-btn');
    clearBtnEl.textContent = 'Clear';
    clearBtnEl.addEventListener('click', clearDonor);

    newLiEl.appendChild(NewArticleEl);
    newLiEl.appendChild(clearBtnEl);

    confirmedListUlEl.appendChild(newLiEl);

    liEl.remove();
  }

  function clearDonor(e) {
    const liEl = e.target.parentElement;

    liEl.remove();
  }
}
