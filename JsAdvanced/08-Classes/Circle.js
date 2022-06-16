class Circle {
    constructor(radius) {
        this.radius = radius;
    }

    get diameter() {
        return 2*Math.PI*this.radius;
    }

    get area() {
        return  Math.PI * this.radius * this.radius;
    }
}

const c = new Circle(4);

console.log(c.diameter);
