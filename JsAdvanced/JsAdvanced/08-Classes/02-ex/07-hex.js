class Hex {
    constructor(value) {
        this.number = value;
    }

    valueOf() {
        return this.number;
    }

    plus(obj) {
        let result = this.number + Number(obj.valueOf());

        return new Hex(result);
    }

    minus(obj) {
        let result = this.number - Number(obj.valueOf());
        return new Hex(result);

    }

    toString() {
        return '0x' + this.number.toString(16).toUpperCase();
    }

    parse(str) {
        return parseInt(str, 16);
    }
}