function loadingBar(percentage){

    let firstLine = '';
    if(percentage <= 9){
        firstLine = loadingScreen(0);
    }
    else if (percentage <= 19)
    {
        firstLine = loadingScreen(10);
    }
    else if(percentage <=29){
        firstLine = loadingScreen(20);
    }
    else if (percentage <= 39){
        firstLine = loadingScreen(30);
    }
    else if (percentage <= 49){
        firstLine = loadingScreen(40);
    }
    else if (percentage <= 59){
       firstLine = loadingScreen(50);
    }
    else if (percentage <= 69){
        firstLine = loadingScreen(60);
    }
    else if (percentage <= 79){
        firstLine = loadingScreen(70);
    }
    else if (percentage <= 89){
        firstLine = loadingScreen(80);
    }
    else if (percentage <= 99){
        firstLine = loadingScreen(90);
    }
    else{
        console.log(loadingScreen(100));
        console.log('[%%%%%%%%%%]');
        return;        
    }
    console.log(firstLine);
    console.log('Still loading...');
    

    function loadingScreen(number){
        if(number<100){
            return `${number}% [${'%'.repeat(number / 10)}${'.'.repeat(10-(number / 10))}]`;
        }
        else{
            return '100% Complete!'
        }
        
    }
}


//30% [%%%.......]