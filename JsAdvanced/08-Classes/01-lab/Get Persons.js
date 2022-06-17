function getPersons(inputData) {

    let result = [];

    for (const args of inputData) {

        let [firstName, lastName, age, email] = args;

        result.push(new Person(firstName, lastName, age, email));
    }


}



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

let persons = getPersons(['Anna', 'Simpson', 22, 'anna@yahoo.com'])
