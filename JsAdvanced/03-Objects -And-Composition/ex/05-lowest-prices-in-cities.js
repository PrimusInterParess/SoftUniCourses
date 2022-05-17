function findPrice(array) {
    let parts = array.split(',')

    let towns = {}

    for (const part of parts) {
        let [townName, product, price] = part.split(' | ');

      
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