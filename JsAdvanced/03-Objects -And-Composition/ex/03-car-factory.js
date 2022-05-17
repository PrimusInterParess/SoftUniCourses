function assembleCar(requirements) {
    var car = {
        model: requirements.model,
        engine: getEngine(requirements.power),
        carriage: {
            type: requirements.carriage,
            color: requirements.color,
        },
        wheels: correctWheelSize(requirements.wheelsize)
    }

    function getEngine(power) {
        if (power <= 90) {
            return { power: 90, volume: 1800 }
        } else if (power > 90 && power <= 120) {
            return { power: 120, volume: 2400 }
        } else if (power > 120 && power <= 200) {
            return { power: 200, volume: 3500 };
        }
    }

    function correctWheelSize(wheelsize) {

        let checkWheelSize = Number(wheelsize);
        let size = Number(wheelsize % 2 == 0 ? wheelsize - 1 : wheelsize);

        return Array(4).fill(size);
    }
    return car;
}

let car = assembleCar({
    model: 'VW Golf II',
    power: 90,
    color: 'blue',
    carriage: 'hatchback',
    wheelsize: 14
}
)

