window.addEventListener("load", solve);

function solve() {
  const formEl = document.querySelector("form");

  formEl.addEventListener("submit", submitForAdoption);

  function submitForAdoption(e) {
    e.preventDefault();

    const formEl = e.target;
    const inputTypeEl = formEl.querySelector("input[id='type']");
    const inputAgeEl = formEl.querySelector("input[id='age']");
    const selectGenderEl = formEl.querySelector("select[id = 'gender']");

    const typeAdoptionUlEl = document.querySelector('ul[id="adoption-info"]');

    if (inputTypeEl.value === "" || inputAgeEl.value === "" || selectGenderEl.value === "") {
      return;
    }

    const liEl = document.createElement("li");

    const articleEl = document.createElement("article");

    const pTypeEl = document.createElement("p");
    pTypeEl.textContent = `Pet:${inputTypeEl.value.trim()}`;

    pGenderEl = document.createElement("p");
    pGenderEl.textContent = `Gender:${selectGenderEl.value}`;

    const pAgeEl = document.createElement("p");
    pAgeEl.textContent = `Age:${inputAgeEl.value}`;

    articleEl.appendChild(pTypeEl);
    articleEl.appendChild(pGenderEl);
    articleEl.appendChild(pAgeEl);

    divBtnEl = document.createElement("div");
    divBtnEl.classList.add("buttons");

    const editBtnEl = document.createElement("button");
    editBtnEl.classList.add("edit-btn");
    editBtnEl.textContent = "Edit";

    editBtnEl.addEventListener("click", editInfo);

    const doneBtnEl = document.createElement("button");
    doneBtnEl.classList.add("done-btn");
    doneBtnEl.textContent = "Done";

    doneBtnEl.addEventListener("click", adoptPet);

    divBtnEl.appendChild(editBtnEl);
    divBtnEl.appendChild(doneBtnEl);

    liEl.appendChild(articleEl);
    liEl.appendChild(divBtnEl);

    typeAdoptionUlEl.appendChild(liEl);

    inputTypeEl.value = "";
    inputAgeEl.value = "";
    selectGenderEl.value = "";
  }

  function editInfo(e) {
    const liEl = e.target.parentElement.parentElement;
    // console.log(liEl);
    const pTypeEl = liEl.querySelector("p:nth-child(1)");
    const pGenderEl = liEl.querySelector("p:nth-child(2)");
    const pAgeEl = liEl.querySelector("p:nth-child(3)");

    const inputTypeEl = document.querySelector("input[id='type']");
    const inputAgeEl = document.querySelector("input[id='age']");
    const selectGenderEl = document.querySelector("select[id='gender']");

    inputTypeEl.value = pTypeEl.textContent.split(":")[1].trim();
    inputAgeEl.value = pAgeEl.textContent.split(":")[1].trim();
    selectGenderEl.value = pGenderEl.textContent.split(":")[1].trim();

    liEl.remove();
  }

  function adoptPet(e) {
    const checkInfoliEl = e.target.parentElement.parentElement;
    // console.log(checkInfoliEl);
    const typeTextContent = checkInfoliEl.querySelector("p:nth-child(1)").textContent;
    const genderTextContent = checkInfoliEl.querySelector("p:nth-child(2)").textContent;
    const ageTextContent = checkInfoliEl.querySelector("p:nth-child(3)").textContent;

    checkInfoliEl.remove();

    const adoptedUlEl = document.querySelector('ul[id="adopted-list"]');
    const newliEl = document.createElement("li");

    const articleEl = document.createElement("article");

    const pTypeEl = document.createElement("p");
    pTypeEl.textContent = typeTextContent;

    pGenderEl = document.createElement("p");
    pGenderEl.textContent = genderTextContent;

    const pAgeEl = document.createElement("p");
    pAgeEl.textContent = ageTextContent;

    articleEl.appendChild(pTypeEl);
    articleEl.appendChild(pGenderEl);
    articleEl.appendChild(pAgeEl);

    const clearBtnEl = document.createElement("button");
    clearBtnEl.classList.add("clear-btn");
    clearBtnEl.textContent = "Clear";

    clearBtnEl.addEventListener("click", clearPetInfo);

    newliEl.appendChild(articleEl);
    newliEl.appendChild(clearBtnEl);

    adoptedUlEl.appendChild(newliEl);
  }

  function clearPetInfo(e) {
    const liEl = e.target.parentElement;
    liEl.remove();
  }
}
