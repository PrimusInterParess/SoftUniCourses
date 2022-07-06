class List {

    constructor() {
        this.list = [];
        this.size = 0;
    }
    add(el) {

        this.list.push(el);
        this.list.sort((a, b) => {
            return a - b;
        })
        this.size = this.list.length
    }

    remove(indx) {
        if (indx => 0 && indx < this.list.length) {
            this.list.splice(indx, 1);
            this.size = this.list.length
        }
    }

    get(indx) {
        if (indx => 0 && indx < this.list.length) {
            return this.list[indx];
        }
    }
}
let list = new List();
list.add(5);
list.add(6);
list.add(7);
console.log(list.get(1));
console.log(list.size);

list.remove(1);
console.log(list.get(1));
console.log(list.size);