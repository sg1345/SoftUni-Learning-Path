async function solution() {
    const sectionEl = document.getElementById('main');

    const articlesRes = await fetch('http://localhost:3030/jsonstore/advanced/articles/list');
    const objArticles = await articlesRes.json();
    // console.log(objArticles);

    for (const article of objArticles) {
        const divAccordionEl = document.createElement('div');
        divAccordionEl.classList.add('accordion');

        const divHeadEl = document.createElement('div');
        divHeadEl.classList.add('head');

        const spanEl = document.createElement('span');
        spanEl.textContent = article.title;

        const buttonEl = document.createElement('button');
        buttonEl.classList.add('button');
        buttonEl.id = article._id;
        buttonEl.textContent = 'More';

        divHeadEl.appendChild(spanEl);
        divHeadEl.appendChild(buttonEl);

        buttonEl.addEventListener('click', showDetails);

        const divExtraEl = document.createElement('div');
        divExtraEl.classList.add('extra');

        const pEl = document.createElement('p');

        const detailsRes = await fetch(`http://localhost:3030/jsonstore/advanced/articles/details/${article._id}`);
        const detailsObj = await detailsRes.json();
        // console.log(detailsObj);
        pEl.textContent = detailsObj.content;

        divExtraEl.appendChild(pEl);

        divAccordionEl.appendChild(divHeadEl);
        divAccordionEl.appendChild(divExtraEl);

        sectionEl.appendChild(divAccordionEl);

        async function showDetails(e) {

            if (e.target.textContent === 'More') {
                e.target.textContent = 'Less';
                divExtraEl.style.display = 'block';
            }
            else {
                e.target.textContent = 'More';
                divExtraEl.style.display = 'none';
            }
        }
    }

}

solution();