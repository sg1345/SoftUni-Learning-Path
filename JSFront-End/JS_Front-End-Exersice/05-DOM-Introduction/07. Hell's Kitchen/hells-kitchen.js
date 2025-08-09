function solve() {
    let inputTextarea = document.querySelector("textarea");
    let bestRestaurantEl = document.querySelector("#bestRestaurant p");
    let bestRestaurantWorkersEl = document.querySelector('#workers p');

    if(bestRestaurantEl.textContent !== ''){
        bestRestaurantEl.textContent = '';

    }
    if(bestRestaurantWorkersEl.textContent !==''){
        bestRestaurantWorkersEl.textContent = '';
    }

    let textareaIntoArray = JSON.parse(inputTextarea.value);

    let RestaurantWorkers = {};

    for (const element of textareaIntoArray) {
        let [restaurant, workersStr ] = element.split(" - ");

        if(!(restaurant in RestaurantWorkers)){
            RestaurantWorkers[restaurant] = [];
        }
        
        let workersArr = workersStr.split(', ');

        for (const workerElement of workersArr) {
            let [name, salary] = workerElement.split(' ');
            salary = Number(salary);
            RestaurantWorkers[restaurant].push({
                name,
                salary
            });
            // workerSalary[name] = Number(salary);     
        }      
        
        

        // RestaurantWorkers[restaurant].push(workerSalary); 
        
                      
    }

    // console.log(RestaurantWorkers);
    
    let bestAvgSalary = 0;
    let bestRestaurant = '';
    let bestSalary = 0;

    for (const [restaurant,workers] of Object.entries(RestaurantWorkers)) {

        // console.log(Object.entries(workers));
        // console.log(restaurant);
        
        let currentAvg = 0;
        let sumAllSalaries = 0;
        
        for (const worker of workers) {
            // console.log(worker.salary);

            sumAllSalaries += worker.salary;
        }
        
        currentAvg = sumAllSalaries / Object.entries(workers).length;
        // console.log(currentAvg);
        
        if(bestAvgSalary < currentAvg){
            bestAvgSalary = currentAvg;
            bestRestaurant = restaurant;
            bestSalary = workers.sort((a, b) => b.salary -a.salary)[0].salary; 
            // console.log(workers.sort((a, b) => b.salary -a.salary)[0].salary);
            
            
            
        }       
    
    }

    bestRestaurantEl.textContent = `Name: ${bestRestaurant} Average Salary: ${bestAvgSalary.toFixed(2)} Best Salary: ${bestSalary.toFixed(2)}`;
    
    // console.log(RestaurantWorkers['PizzaHut'].sort((a,b) => b.salary - a.salary));
    

    for (const worker of RestaurantWorkers[bestRestaurant].sort((a,b) => b.salary - a.salary)) {
        bestRestaurantWorkersEl.textContent += `Name: ${worker.name} With Salary: ${worker.salary} `;
        
        
    }
    // console.log(bestRestaurant);
    // console.log(AvgSalary);
    // console.log(bestSalary);
    // console.log(bestRestaurantEl);

}