async function lockedProfile() {
    const profileDivMusterEl = document.getElementsByClassName('profile')[0];
    profileDivMusterEl.remove();

    const mainEl = document.getElementById('main');
    console.log(mainEl);


    const profileRes = await fetch('http://localhost:3030/jsonstore/advanced/profiles');
    const profilesData = await profileRes.json();
    const objProfiles = Object.values(profilesData);
    // console.log(objProfiles);

    for (const profile of objProfiles) {
        const profileDivEl = document.createElement('div');
        profileDivEl.classList.add('profile');

        const imgEl = document.createElement('img');
        imgEl.src = './iconProfile2.png';
        imgEl.classList.add('userIcon');

        const labelLockEl = document.createElement('label');
        labelLockEl.textContent = 'Lock';

        const inputLockEl = document.createElement('input');
        inputLockEl.type = 'radio';
        inputLockEl.name = `user1Locked`;
        inputLockEl.value = 'lock';
        inputLockEl.checked = true;

        const labelUnlockEl = document.createElement('label');
        labelUnlockEl.textContent = 'Unlock';

        const inputUnlockEl = document.createElement('input');
        inputUnlockEl.type = 'radio';
        inputUnlockEl.name = `user1Locked`;
        inputUnlockEl.value = 'unlock';

        const brEl = document.createElement('br');
        const hrEl = document.createElement('hr');

        const labelUsernameEl = document.createElement('label');
        labelUsernameEl.textContent = 'Username';

        const inputUsernameEl = document.createElement('input');
        inputUsernameEl.type = 'text';
        inputUsernameEl.name = `user1Username`;
        inputUsernameEl.value = profile.username;
        inputUsernameEl.setAttribute('value', profile.username);
        inputUsernameEl.disabled = true;
        inputUsernameEl.readOnly = true;
        console.log(inputUsernameEl.outerHTML);

        const hiddenFieldsDivEl = document.createElement('div');
        hiddenFieldsDivEl.classList.add(`hiddenInfo`); // i dont think it is correct

        // another hr needed to be append here

        const labelEmailEl = document.createElement('label');
        labelEmailEl.textContent = 'Email:';

        const inputEmailEl = document.createElement('input');
        inputEmailEl.type = 'email';
        inputEmailEl.name = `user1Email`;
        inputEmailEl.value = profile.email;
        inputEmailEl.disabled = true;
        inputEmailEl.readOnly = true;

        const labelAgeEl = document.createElement('label');
        labelAgeEl.textContent = 'Age:';

        const inputAgeEl = document.createElement('input');
        inputAgeEl.type = 'number';
        inputAgeEl.name = `user1Age`;
        inputAgeEl.value = profile.age;
        inputAgeEl.disabled = true;
        inputAgeEl.readOnly = true;

        hiddenFieldsDivEl.appendChild(hrEl);
        hiddenFieldsDivEl.appendChild(labelEmailEl);
        hiddenFieldsDivEl.appendChild(inputEmailEl);
        hiddenFieldsDivEl.appendChild(labelAgeEl);
        hiddenFieldsDivEl.appendChild(inputAgeEl);

        const btnEl = document.createElement('button');
        btnEl.textContent = 'Show more';

        btnEl.addEventListener('click', toggleProfileInfo);

        profileDivEl.appendChild(imgEl);
        profileDivEl.appendChild(labelLockEl);
        profileDivEl.appendChild(inputLockEl);
        profileDivEl.appendChild(labelUnlockEl);
        profileDivEl.appendChild(inputUnlockEl);
        profileDivEl.appendChild(brEl);
        profileDivEl.appendChild(hrEl);
        profileDivEl.appendChild(labelUsernameEl);
        profileDivEl.appendChild(inputUsernameEl);
        profileDivEl.appendChild(hiddenFieldsDivEl);
        profileDivEl.appendChild(btnEl);

        mainEl.appendChild(profileDivEl);

    }


    function toggleProfileInfo(e) {
        e.preventDefault();

        const profileDivEl = e.target.parentElement;
        // console.log(profileDivEl);

        const inputUnlockEl = profileDivEl.querySelector('input[type="radio"][value="unlock"]');
        const hiddenFieldsDivEl = profileDivEl.querySelector('.hiddenInfo');
        const allHiddenElements = hiddenFieldsDivEl.querySelectorAll('label, input');
        console.log(allHiddenElements);


        if (inputUnlockEl.checked) {
            if (e.target.textContent === 'Show more') {
                allHiddenElements.forEach(el => el.style.display = 'block');
                e.target.textContent = 'Hide it';
            }
            else {
                allHiddenElements.forEach(el => el.style.display = 'none');
                e.target.textContent = 'Show more';
            }
        }

    }
}