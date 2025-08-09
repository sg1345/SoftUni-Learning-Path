function solve() {
    let tableRowEl = document.querySelectorAll("table tbody tr");
    let tableHeadEl = document.querySelectorAll("table thead tr th");
    let textOutput = document.getElementById("output");
    // console.log(tableRowEl);
    // console.log(tableHeadEl);

    let report = {};
    let checkBoxIndexes= [];


    tableHeadEl.forEach((el,index) =>{
        if(el.querySelector("input").checked){
            checkBoxIndexes.push(index);
            report[index] = [];
            
        }
        // console.log(el.checked);
        // console.log(index);    
    });
    
    // console.log(checkBoxIndexes);
    // console.log(report);
    
    
    for (const checkBoxIndex of checkBoxIndexes) {
        tableRowEl.forEach((el, index) =>{
        
            let currentColumn = el.querySelectorAll('td');
        
            currentColumn.forEach((el,columnIndex)=>{
                if(columnIndex == checkBoxIndex){
                    report[checkBoxIndex].push(el.textContent);
                }
            });

            // console.log(index);  
        });
    }
    
    let generalReportArr = [];
    for (let index = 0; index < tableRowEl.length; index++) {
        let generalReport = {}; 

        for (const checkBoxIndex of checkBoxIndexes) {
           let word = tableHeadEl[checkBoxIndex].textContent.toLocaleLowerCase().trim();
           generalReport[word] = report[checkBoxIndex][index];
            // console.log(tableHeadEl[checkBoxIndex].textContent);    
        }
        generalReportArr.push(generalReport);
        
    }
    // console.log(JSON.stringify(generalReportArr));

    textOutput.value = JSON.stringify(generalReportArr);
    // console.log(textOutput.value = JSON.stringify(generalReportArr));

    // let data = JSON.parse(textOutput.value);
    // // data[0].department = "Facilities/Engineering";
    // console.log(data[0].department);
    
    
    
}