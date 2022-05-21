function findPrice(array) {

    let products = {}



    for (const part of array) {
        let [townName, product, price] = part.split(' | ');

        if (!products.hasOwnProperty(product)) {
            products[product] = {};
        }

        products[product][townName] = price;

    }

  

    for (const product in products) {

        let sorted = Object.entries(products[product]).sort((a, b) => a[1] - b[1]);

        console.log(`${product} -> ${sorted[0][0]} (${sorted[0][1]})`);


    }
}

findPrice(['Sample Town | Sample Product | 1000',
    'Sample Town | Orange | 2',
    'Sample Town | Peach | 1',
    'Sofia | Orange | 3',
    'Sofia | Peach | 2',
    'New York | Sample Product | 1000.1',
    'New York | Burger | 10']
)


