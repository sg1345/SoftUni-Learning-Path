function Fruit(fruit,weightInGrams,pricePerKilogram){

    weightInKilograms =weightInGrams/1000;
    totalPrice = weightInKilograms*pricePerKilogram;

    console.log(`I need $${totalPrice.toFixed(2)} to buy ${weightInKilograms.toFixed(2)} kilograms ${fruit}.`);
    
}

Fruit('orange', 2500, 1.80);
Fruit('apple', 1563, 2.35);