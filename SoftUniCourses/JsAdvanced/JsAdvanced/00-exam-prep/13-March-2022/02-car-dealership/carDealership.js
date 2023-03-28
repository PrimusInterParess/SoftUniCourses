class CarDealership {
    name;
    availableCars = [];
    soldCars = [];
    totalIncome = 0;
    constructor(name) {
        this.name = name;
    }

    addCar(model, horsepower, price, mileage) {

        if (this._checkForEmptySpaces(model) ||
            this._checkForNegativeNumbers(Number(horsepower)) ||
            this._checkForNegativeNumbers(Number(price)) ||
            this._checkForNegativeNumbers(Number(mileage))) {
            throw new Error('Invalid input!');
        }

        this.availableCars.push({ model, horsepower, price, mileage })

        return `New car added: ${model} - ${horsepower} HP - ${mileage.toFixed(2)} km - ${price.toFixed(2)}$`;
    }

    sellCar(model, desiredMileage) {
        let car = this.availableCars.find(c => c.model == model);

        if (car == undefined) {
            throw new Error(`${model} was not found!`);
        }

        let soldPrice = car.price;
        if (car.mileage <= desiredMileage) {
            soldPrice = Number(car.price);
        } else if (car.mileage - desiredMileage <= 40000) {
            soldPrice = Number(car.price * 0.95);
        } else {
            soldPrice = Number(car.price * 0.90);
        }

        this.availableCars = this.availableCars.filter(c => c !== car);


        let horsepower = car.horsepower;
        this.soldCars.push({
            model,
            horsepower,
            soldPrice
        });

        this.totalIncome += soldPrice;

        return `${model} was sold for ${soldPrice.toFixed(2)}$`;

    }

    currentCar() {
        let result = '-Available cars:\n';
        this.availableCars.length == 0 ? result = 'There are no available cars' :
            this.availableCars.forEach(c => result += `---${c.model} - ${c.horsepower} HP - ${c.mileage.toFixed(2)} km - ${c.price.toFixed(2)}$\n`);

        return result.trimEnd('\n');
    }

    salesReport(criteria) {
        if (this._checkForEmptySpaces(criteria) ||
            this._invalidCriteria(criteria)) {
            throw new Error('Invalid criteria!');
        }


        if (criteria == 'horsepower') {
            this.soldCars = this.soldCars.sort((c1, c2) => {
                return c2.horsepower - c1.horsepower;
            });
        } else {
            this.soldCars = this.soldCars.sort((c1, c2) => {
                return c1.model.localeCompare(c2.model);
            });
        }


        let result = `-${this.name} has a total income of ${this.totalIncome.toFixed(2)}$\n`;
        result += `-${this.soldCars.length} cars sold:\n`
        this.soldCars.forEach(c => result += `---${c.model} - ${c.horsepower} HP - ${c.soldPrice.toFixed(2)}$\n`);

        return result.trimEnd('\n');

    }

    _invalidCriteria(criteria) {
        return criteria != 'model' && criteria != 'horsepower';
    }

    _checkForEmptySpaces(value) {
        return value == '' ||
            value == undefined ||
            value == null;
    }

    _checkForNegativeNumbers(value) {
        return value < 0;
    }
}

let dealership = new CarDealership('SoftAuto');
dealership.addCar('Toyota Corolla', 100, 3500, 190000);
dealership.addCar('Mercedes C63', 300, 29000, 187000);
dealership.addCar('Audi A3', 120, 4900, 240000);
dealership.sellCar('Toyota Corolla', 230000);
dealership.sellCar('Mercedes C63', 110000);
dealership.sellCar('Audi A3', 500)
console.log(dealership.salesReport('model'));