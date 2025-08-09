function Vacation(numberOfPeople,type,day){

    let totalPrice = 0;
    let pricePerPerson = 0;
    if(day === 'Friday'){
        if(type === 'Students'){
            pricePerPerson = 8.45;
        }
        else if (type === 'Business'){
            pricePerPerson = 10.90;
        }
        else{
            pricePerPerson = 15;
        }
    }
    else if(day === 'Saturday'){
        if(type === 'Students'){
            pricePerPerson = 9.80;
        }
        else if (type === 'Business'){
            pricePerPerson = 15.60;
        }
        else{
            pricePerPerson = 20;
        }
    }
    else{
        if(type === 'Students'){
            pricePerPerson = 10.46;
        }
        else if (type === 'Business'){
            pricePerPerson = 16;
        }
        else{
            pricePerPerson = 22.50;
        }
    }
    totalPrice = pricePerPerson * numberOfPeople;

    if(type === 'Students' && numberOfPeople >= 30){
        totalPrice *= 0.85;
    }
    else if(type === 'Business' && numberOfPeople >= 100){
        totalPrice -= pricePerPerson*10;
    }
    else if (type === 'Regular' && (numberOfPeople >= 10 && numberOfPeople <= 20)){
        totalPrice *= 0.95;
    }

    // totalPrice = totalPrice.toFixed(2);

    console.log(`Total price: ${totalPrice.toFixed(2)}`);
    
}

Vacation(30, 'Students', 'Sunday');
Vacation(40, 'Regular', 'Saturday');