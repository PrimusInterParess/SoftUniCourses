class Garden {
    constructor(spaceAvailable) {
        this.spaceAvailable = spaceAvailable;
        this.plants = [];
        this.storage = [];
    }

    addPlant(plantName, spaceRequired) {
        if (this.spaceAvailable < spaceRequired) {
            throw new Error('Not enough space in the garden.');
        }

        this.plants.push({ plantName, spaceRequired, ripe: false, quantity: 0 });

        this.spaceAvailable -= spaceRequired;

        return `The ${plantName} has been successfully planted in the garden.`;

        // Have on mind that plant names are unique!
    }

    ripenPlant(plantName, quantity) {

        let plant = this._getPlantByName(plantName);

        this._throwErrorWhenNoPlant(plant, plantName);

        if (this._isPlantRipe(plant)) {
            throw new Error(`The ${plantName} is already ripe.`);
        }

        if (quantity <= 0) {
            throw new Error(`The quantity cannot be zero or negative.`);
        }

        plant.ripe = true;

        plant.quantity += quantity;

        return quantity == 1 ?
            `${quantity} ${plantName} has successfully ripened.` :
            `${quantity} ${plantName}s have successfully ripened.`;

    }

    harvestPlant(plantName) {
        let plant = this._getPlantByName(plantName);
        this._throwErrorWhenNoPlant(plant, plantName);

        if (!this._isPlantRipe(plant)) {
            throw new Error(`The ${plantName} cannot be harvested before it is ripe."`);
        }

        this.plants = this.plants.filter(pl => pl !== plant);
        this.spaceAvailable += plant.spaceRequired;

        this.storage.push({
            plantName,
            quantity: plant.quantity
        });

        return `The ${plantName} has been successfully harvested.`

    }

    generateReport() {



        let result = ''


        result += `The garden has ${ this.spaceAvailable } free space left.\n`
        result += `Plants in the garden: ` + this.plants.map(p => p.plantName).sort((a, b) => {
            return a.localeCompare(b);
        }).join(', ') + `\n`;

        result += this.storage.length == 0 ? 'Plants in storage: The storage is empty.' : `Plants in storage:` + (this.storage.map(p => `${p.plantName} (${p.quantity})`)).join(', ');

        return result.trimEnd('\n');
    }



    _getPlantByName(plantName) {
        return this.plants.find(p => p.plantName == plantName);
    }

    _throwErrorWhenNoPlant(plant, plantName) {
        if (plant == undefined) {
            throw new Error(`There is no ${plantName} in the garden.`);
        }
    }

    _isPlantRipe(plant) {
        return plant.ripe == true;
    }



}

const myGarden = new Garden(250)
console.log(myGarden.addPlant('apple', 20));
console.log(myGarden.addPlant('orange', 200));
console.log(myGarden.addPlant('raspberry', 10));
console.log(myGarden.ripenPlant('apple', 10));
console.log(myGarden.ripenPlant('orange', 1));
console.log(myGarden.harvestPlant('orange'));
console.log(myGarden.generateReport());