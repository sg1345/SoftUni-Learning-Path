function employees(arr){
    let personalInfo = {};

    for (const employee of arr) {
        personalInfo[employee] = employee.length;
    }

    for (const [person,personalNumber] of Object.entries(personalInfo)) {
        console.log(`Name: ${person} -- Personal Number: ${personalNumber}`);
        
    }
}

employees([
'Samuel Jackson',
'Will Smith',
'Bruce Willis',
'Tom Holland'
]);