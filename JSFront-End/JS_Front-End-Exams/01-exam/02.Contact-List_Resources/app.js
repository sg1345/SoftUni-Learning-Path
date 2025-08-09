window.addEventListener("load", solve);

function solve() {
  const btnAddEl = document.getElementById("add-btn");

  btnAddEl.addEventListener("click", AddContactToCheckList);

  function AddContactToCheckList(e) {
    const formEl = e.target.parentElement;
    const inputNameEl = formEl.querySelector("#name");;
    const inputPhoneEl = formEl.querySelector("#phone");
    const selectCategoryEl = formEl.querySelector("#category");
    const checkListUlEl = document.querySelector("#check-list");

    const name = inputNameEl.value.trim();
    const phone = inputPhoneEl.value.trim();
    const category = selectCategoryEl.value;
    // console.log(phone);


    const isValidContact = name !== '' && phone !== '' && category !== '' && !isNaN(phone);;

    if (isValidContact) {
      const liEl = document.createElement("li");
      const articleEl = document.createElement("article");

      const namePEl = document.createElement("p");
      namePEl.textContent = `name:${name}`;

      const phonePEl = document.createElement("p");
      phonePEl.textContent = `phone:${phone}`;

      const categoryPEl = document.createElement("p");
      categoryPEl.textContent = `category:${category}`;

      articleEl.appendChild(namePEl);
      articleEl.appendChild(phonePEl);
      articleEl.appendChild(categoryPEl);

      const divBtnsEl = document.createElement("div");
      divBtnsEl.classList.add("buttons");


      const editBtnEl = document.createElement("button");
      editBtnEl.classList.add("edit-btn");
      editBtnEl.textContent = "Edit";

      editBtnEl.addEventListener('click', editContact);

      const saveBtnEl = document.createElement("button");
      saveBtnEl.classList.add("save-btn");
      saveBtnEl.textContent = "Save";

      saveBtnEl.addEventListener('click', saveContact);

      divBtnsEl.appendChild(editBtnEl);
      divBtnsEl.appendChild(saveBtnEl);

      liEl.appendChild(articleEl);
      liEl.appendChild(divBtnsEl);

      checkListUlEl.appendChild(liEl);

      inputNameEl.value = '';
      inputPhoneEl.value = '';
      selectCategoryEl.value = '';
    }

  }

  function editContact(e) {
    const liEl = e.target.parentElement.parentElement;
    const inputNameEl = document.getElementById("name");
    const inputPhoneEl = document.getElementById("phone");
    const selectCategoryEl = document.getElementById("category");

    const name = liEl.querySelector("p:nth-child(1)").textContent.split(':')[1].trim();
    const phone = liEl.querySelector("p:nth-child(2)").textContent.split(':')[1].trim();
    const category = liEl.querySelector("p:nth-child(3)").textContent.split(':')[1].trim();

    inputNameEl.value = name;
    inputPhoneEl.value = phone;
    selectCategoryEl.value = category;

    liEl.remove();
  }

  function saveContact(e) {
    const targetLiEl = e.target.parentElement.parentElement;
    const contactListUlEl = document.querySelector("#contact-list");

    const namePTextContent = targetLiEl.querySelector("p:nth-child(1)").textContent;
    const phonePTextContent = targetLiEl.querySelector("p:nth-child(2)").textContent;
    const categoryPTextContent = targetLiEl.querySelector("p:nth-child(3)").textContent;

    const newLiSavedEl = document.createElement("li");
    const articleEl = document.createElement("article");

    const namePEl = document.createElement("p");
    namePEl.textContent = namePTextContent

    const phonePEl = document.createElement("p");
    phonePEl.textContent = phonePTextContent;

    const categoryPEl = document.createElement("p");
    categoryPEl.textContent = categoryPTextContent;

    articleEl.appendChild(namePEl);
    articleEl.appendChild(phonePEl);
    articleEl.appendChild(categoryPEl);

    const deleteBtnEl = document.createElement("button");
    deleteBtnEl.classList.add("del-btn");
    deleteBtnEl.textContent = "Delete";

    deleteBtnEl.addEventListener('click', deleteContact);

    newLiSavedEl.appendChild(articleEl);
    newLiSavedEl.appendChild(deleteBtnEl);

    contactListUlEl.appendChild(newLiSavedEl);

    targetLiEl.remove();
  }

  function deleteContact(e) {
    const targetLiEl = e.target.parentElement;
    targetLiEl.remove();
  }
}
