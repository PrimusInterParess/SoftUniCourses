class Person {
    constructor(firstName, lastName, age, email) {
        this.firstName = firstName;
        this.lastName = lastName;
        this.age = age;
        this.email = email;

    }

    toString() {
        return `${this.firstName} ${this.lastName} (age: ${this.age} email: ${this.email})`;
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

let person = new Person('Anna', 'Simpson', 22, 'anna@yahoo.com');
console.log(person.toString());


// const arrayOfPeople = [perso1, perso2, perso3, perso4];

// arrayOfPeople.sort(Person.CompareTo);


