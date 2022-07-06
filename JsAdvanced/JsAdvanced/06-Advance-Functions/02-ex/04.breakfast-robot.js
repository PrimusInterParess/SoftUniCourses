function solution() {

    const recipes = {
        apple: {
            carbohydrate: 1,
            flavour: 2,
        },
        lemonade: {
            carbohydrate: 10,
            flavour: 20
        },

        burger: {
            carbohydrate: 5,
            fat: 7,
            flavour: 3,
        },
        eggs: {
            protein: 5,
            fat: 1,
            flavour: 1
        },
        turkey: {
            protein: 10,
            carbohydrate: 10,
            fat: 10,
            flavour: 10
        }
    }

    let storage = {
        protein: 0,
        carbohydrate: 0,
        fat: 0,
        flavour: 0,

    }

    return function(args) {
        let [operation, type, amount] = args.split(' ');

        switch (operation) {
            case 'restock':
                return restock(type, Number(amount));
            case 'prepare':
                return prepare(type, Number(amount));
            case 'report':
                return report();
        }

    }

    function restock(type, amount) {

        storage[type] += amount;

        return 'Success';
    }

    function prepare(type, amount) {

        let order = {};
        Object.keys(recipes[type])
            .forEach(e =>
                order[e] = recipes[type][e] * amount
            );

        let [isEnough, resultMessage] = isSufficientAmount(order, storage)

        if (!isEnough) {
            return resultMessage;
        }

        reduceAmounts(order, storage);

        return 'Success';

    }

    function report() {
        return Object.keys(storage).map(k => `${k}=${storage[k]}`).join(' ');
    }

    function isSufficientAmount(order, storage) {
        for (const key in order) {
            if (storage[key] <= order[key]) {
                return [false, `Error: not enough ${key} in stock`]
            }
        }

        return [true, ''];
    }

    function reduceAmounts(order, storage) {
        for (const key in order) {
            storage[key] -= order[key];
        }
    }
}


let manager = solution();

console.log(manager('restock flavour 50 '));
console.log(manager('prepare lemonade 4 '));
console.log(manager('restock carbohydrate 10'));
console.log(manager('restock flavour 10'));
console.log(manager('prepare apple 1'));
console.log(manager('restock fat 10'));
console.log(manager('prepare burger 1'));
console.log(manager('report'));