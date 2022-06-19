class Stringer {
    constructor(str, lentgh) {
        this.innerString = str;
        this.innerLength = lentgh;
    }

    increase(num) {
        this.innerLength += num;
    }

    decrease(num) {


        this.innerLength -= num;
        if (this.innerLength < 0) {
            this.innerLength = 0
        }
    }

    toString() {

        if (this.innerLength == 0) {
            return '...';
        } else if (this.innerLength >= this.innerString.length) {
            return this.innerString;
        } else {

            let toShow = this.innerLength - this.innerString.length;
            return `${this.innerString.slice(0,toShow)}...`;
        }
    }
}

let test = new Stringer("Test", 5);
console.log(test.toString()); // Test

test.decrease(3);
console.log(test.toString()); // Te...

test.decrease(5);
console.log(test.toString()); // ...

test.increase(4);
console.log(test.toString()); // Test