function calculate(fruitType, weight, price) {

    let kg = weight / 1000;
    let totalPrice = price * kg;

    console.log('I need $' + totalPrice.toFixed(2) + ' to buy ' + kg.toFixed(2) + ' kilograms ' + fruitType + '.');

}

calculate('orange', 2500, 1.80)