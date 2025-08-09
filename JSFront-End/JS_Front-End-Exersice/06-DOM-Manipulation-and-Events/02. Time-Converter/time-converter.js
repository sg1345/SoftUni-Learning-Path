document.addEventListener('DOMContentLoaded', solve);

function solve() {

    document.addEventListener('submit', convertTime);
    
    function convertTime(e){
        e.preventDefault();

        const daysInputEl = document.getElementById('days-input');
        const hoursInputEl = document.getElementById('hours-input');
        const minutesInputEl = document.getElementById('minutes-input');
        const secondsInputEl = document.getElementById('seconds-input');


        let days = 0;

        if(daysInputEl.value > 0 ){
            
            days = Number(daysInputEl.value).toFixed(2);
            hoursInputEl.value = Number(days*24).toFixed(2);
            minutesInputEl.value = Number(days*1440).toFixed(2);
            secondsInputEl.value = Number(days*86400).toFixed(2);
                        
            
        }
        else if(hoursInputEl.value > 0){
            days = Number(hoursInputEl.value/24).toFixed(2);
            daysInputEl.value = Number(days).toFixed(2);
            minutesInputEl.value = Number(days*1440).toFixed(2);
            secondsInputEl.value = Number(days*86400).toFixed(2);
        }
        else if(minutesInputEl.value > 0){
            days = Number(minutesInputEl.value/1440).toFixed(2);
            daysInputEl.value = Number(days).toFixed(2);
            hoursInputEl.value = Number(days*24).toFixed(2);
            secondsInputEl.value = Number(days*86400).toFixed(2);

        }
        else if(secondsInputEl.value > 0){
            days = Number(secondsInputEl.value/86400).toFixed(2);
            daysInputEl.value = Number(days).toFixed(2);
            hoursInputEl.value = Number(days*24).toFixed(2);
            minutesInputEl.value = Number(days*1440).toFixed(2);       
        }       
    }
}