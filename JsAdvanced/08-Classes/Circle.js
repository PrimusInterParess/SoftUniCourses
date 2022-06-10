class Circle {
    constructor(radius) {
        this.radius = radius;
    }

    get diameter() {
        return this.radius * 2;
    }
}

const c = new Circle(4);

console.log(c.diameter);
