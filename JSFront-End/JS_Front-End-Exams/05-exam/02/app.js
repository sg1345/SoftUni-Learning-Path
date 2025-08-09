window.addEventListener("load", solve);

function solve() {
  //elements for general use
  const inputModelEl = document.querySelector("#laptop-model");
  const inputStorageEl = document.querySelector("#storage");
  const inputPriceEl = document.querySelector("#price");
  const laptopsListUlEl = document.querySelector('#laptops-list');

  //element for events
  const addBtnEl = document.querySelector('#add-btn');
  const clearBtnEl = document.querySelector('.btn.clear');

  addBtnEl.addEventListener('click', addLaptop);
  clearBtnEl.addEventListener('click', clearLaptops);


  function addLaptop(e) {
    e.preventDefault();
    const checkListUlEl = document.querySelector('#check-list');

    const model = inputModelEl.value.trim();
    const storage = inputStorageEl.value.trim();
    const price = inputPriceEl.value.trim();

    if (!model || !storage || !price) {
      return;
    }

    const liEl = document.createElement('li');

    const articleEl = document.createElement('article');

    const pModelEl = document.createElement('p');
    const pStorageEl = document.createElement('p');
    const pPriceEl = document.createElement('p');

    const editBtnEl = document.createElement('button');
    const okBtnEl = document.createElement('button');

    liEl.classList.add('laptop-item');

    pModelEl.textContent = model;
    pStorageEl.textContent = `Memory: ${storage} TB`;
    pStorageEl.setAttribute('memory', storage);
    pPriceEl.textContent = `Price: ${price}$`;
    pPriceEl.setAttribute('price', price);

    editBtnEl.classList.add('btn', 'edit');
    editBtnEl.textContent = 'edit';
    editBtnEl.addEventListener('click', editInfo);
    okBtnEl.classList.add('btn', 'ok');
    okBtnEl.textContent = 'ok';
    okBtnEl.addEventListener('click', addToWishlist);

    articleEl.appendChild(pModelEl);
    articleEl.appendChild(pStorageEl);
    articleEl.appendChild(pPriceEl);

    liEl.appendChild(articleEl);
    liEl.appendChild(editBtnEl);
    liEl.appendChild(okBtnEl);

    checkListUlEl.appendChild(liEl);

    addBtnEl.disabled = true;

    inputModelEl.value = '';
    inputStorageEl.value = '';
    inputPriceEl.value = '';

  }

  function clearLaptops(e) {
    e.preventDefault();
    laptopsListUlEl.innerHTML = '';
  }

  function editInfo(e) {
    const currentLiEl = e.target.parentElement;
    // console.log(currentLiEl);
    const currentArticleEl = currentLiEl.querySelector('article');

    inputModelEl.value = currentArticleEl.querySelector('p:nth-child(1)').textContent;
    inputStorageEl.value = currentLiEl.querySelector('p:nth-child(2)').getAttribute('memory');
    inputPriceEl.value = currentLiEl.querySelector('p:nth-child(3)').getAttribute('price');

    addBtnEl.disabled = false;
    currentLiEl.remove();
  }

  function addToWishlist(e) {
    const currentLiEl = e.target.parentElement;
    const currentArticleEl = currentLiEl.querySelector('article');

    const liEl = currentLiEl.cloneNode(true);
    liEl.innerHTML = '';
    const articleEl = currentArticleEl.cloneNode(true);

    liEl.appendChild(articleEl);

    laptopsListUlEl.appendChild(liEl);

    addBtnEl.disabled = false;
    currentLiEl.remove();
  }

}
