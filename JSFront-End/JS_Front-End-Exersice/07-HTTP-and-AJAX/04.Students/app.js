const formElement = document.getElementById('form');


formElement.addEventListener('submit', submitStudent);

loadStudents();

async function loadStudents(e) {
    const tBodyEl = document.querySelector('tbody');
    tBodyEl.innerHTML = '';

    const studentsRes = await fetch('http://localhost:3030/jsonstore/collections/students');
    const studentsData = await studentsRes.json();
    const objStudentsArr = Object.values(studentsData);
    // console.log(objStudentsArr);

    for (const student of objStudentsArr) {
        const newTrEl = document.createElement('tr');

        const firstNameTdEl = document.createElement('td');
        firstNameTdEl.textContent = student.firstName;

        const lastNameTdEl = document.createElement('td');
        lastNameTdEl.textContent = student.lastName;

        const facultyNumberTdEl = document.createElement('td');
        facultyNumberTdEl.textContent = student.facultyNumber;

        const gradeTdEl = document.createElement('td');
        gradeTdEl.textContent = student.grade;

        newTrEl.appendChild(firstNameTdEl);
        newTrEl.appendChild(lastNameTdEl);
        newTrEl.appendChild(facultyNumberTdEl);
        newTrEl.appendChild(gradeTdEl);

        tBodyEl.appendChild(newTrEl);
    }

}

async function submitStudent(e) {
    e.preventDefault();

    const firstName = e.target.firstName.value;
    console.log(firstName);
    const lastName = e.target.lastName.value;
    console.log(lastName);
    const facultyNumber = e.target.facultyNumber.value;
    console.log(facultyNumber);
    const grade = Number(e.target.grade.value);
    console.log(grade);

    await fetch('http://localhost:3030/jsonstore/collections/students', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({
            firstName,
            lastName,
            facultyNumber,
            grade
        })
    });


    loadStudents();
}