class Person {
    constructor(firstName, lastName, age, email, secret) {
        this.firstName = firstName;
        this.lastName = lastName;
        this.age = age;
        this.email = email;

        this.secretField = () => secret;
    }

    ctrMethod = function () {
        console.log('Creeateing method through constructor');
    }


    toString() {
        return `${this.firstName} ${this.lastName} ${this.age} ${this.email}`;
    }
}

// class Person {
//     constructor(firstName, lastName, age, email) {
//         Object.assign(this, {
//             firstName,
//             lastName,
//             age,
//             email,
//             ctrMethod: function () {
//                 console.log('Creeateing method through constructor');
//             }
//         });

//     }

//     static cheer() {
//         console.log('dumbo');
//     }

//     static CompareTo(a, b) {
//         return a.age - b.age;
//     }

//     toString() {
//         return `${this.firstName} ${this.lastName} ${this.age} ${this.email}`;
//     }

// }

const perso1 = new Person('dani', 23, 'secret message');
const perso2 = new Person('mani', 22)
const perso3 = new Person('tani', 24)
const perso4 = new Person('kani', 26)

// const arrayOfPeople = [perso1, perso2, perso3, perso4];

// arrayOfPeople.sort(Person.CompareTo);


Person.cheer();