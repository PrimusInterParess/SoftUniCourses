function solution() {


    const recipes = {
        apple: {
            carbohydrate: 1,
            flavour: 2,
        },
        lemande: {
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
        flavour: 0,
        fat: 0,
    }

    return function (args) {
        let [operation, type, amount] = args.split(' ');

        switch (operation) {
            case 'restock': return restock(type, Number(amount));
            case 'prepare': return prepare(type, Number(amount));
            case 'report': return report();
        }

    }


    function restock(type, amount) {

        storage[type] += amount;

        return 'Succsess';
    }

    function prepare(type, amount) {
        let ingredientsNeeded = Object.keys(recipes[type]).map(function (e) { return { e: recipes[e] * Number(amount) } });

        console.log(ingredientsNeeded);
    }

    function report() {
        return 'hello from report'
    }

}


let manager = solution();

console.log(manager('restock flavour 50'));

console.log(manager('prepare lemande 40'));

console.log(manager('report'));