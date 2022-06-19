class List {
    list;

    constructor() {
        this.list = [];
    }

    add(el) {
        this.list.push(el);
    }
    5
    remove(index) {
        if (index < 0 && index > this.list.length - 1) {
            throw new TypeError();
        }
        this.list = this.list.slice(index, 1, 1);
    }

    get(index) {
        return this.list[index];
    }

    get size() {
        return this.list.length;
    }
}

let list = new List();
list.add(5);
list.add(6);
list.add(7);
console.log(list.get(1));
list.remove(1);
console.log(list.get(1));