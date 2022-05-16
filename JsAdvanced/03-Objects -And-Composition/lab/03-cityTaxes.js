function cityTaxes(name, population, treasury) {
    return {
        name, population, treasury,
        taxRate: 10,
        collectTaxes() {
            this.treasury += this.population * this.taxRate;
        },
        applyGrowth(percent) {
            this.population += Math.floor(this.population * percent / 100);
        },
        applyRecession(percent) {
            this.treasury -= Math.floor(this.treasury * percent / 100);
        },
    };
}


function createRecord(name, population, treasury) {
    return {
        name, population, treasury,
        taxRate: 10,
        collectTaxes() {
            this.treasury += this.population * this.taxRate;
        },
        applyGrowth(percent) {
            this.population += Math.floor(this.population * percent / 100);
        },
        applyRecession(percent) {
            this.treasury -= Math.floor(this.treasury * percent / 100);
        },
    };
}





function cityTaxes(name, population, treasury) {
    let obj = {
        name,
        population,
        treasury,
        taxRate: 10,
        collectTaxes: function () {
            this.treasury += this.population * this.taxRate;
        },
        applyGrowth: function (percentage) {
            this.population += Math.floor(this.population * (percentage / 100));
        },
        applyRecession: function (percentage) {
            this.treasury -= Math.floor(this.treasury * (percentage / 100));
        }
    };
    return obj;
}


const record =
    cityTaxes('Tortuga',
        7000,
        15000);
console.log(record);


const city =
    cityTaxes('Tortuga',
        7000,
        15000);


console.log(city.treasury)
console.log(city.collectTaxes())
console.log(city.treasury)

