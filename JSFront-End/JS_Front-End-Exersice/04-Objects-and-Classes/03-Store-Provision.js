function storeProvision(stockProducts, delivery){

    let products = {};
    
    for (let index = 0; index < stockProducts.length; index+=2) {
        

            let product = stockProducts[index];
            let quantity = parseInt(stockProducts[index + 1]);
            products[product] = quantity;
       
    }

    for (let index = 0; index < delivery.length; index+=2) {

        let product = delivery[index];
        let quantity = parseInt(delivery[index + 1]);

        if(product in products)
        {
            products[product] += quantity;
        }
        else{
            products[product] = quantity;
        }
        
    }

    for (const [product, quantity] of Object.entries(products)) {
        console.log(`${product} -> ${quantity}`);
    }
    
}

storeProvision(
    ['Chips', '5', 'CocaCola', '9', 'Bananas', '14', 'Pasta', '4', 'Beer', '2'], 
    ['Flour', '44', 'Oil', '12', 'Pasta', '7', 'Tomatoes', '70', 'Bananas', '30']
);