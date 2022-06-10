const person = {
    name: 'peter',
    age: 28
}


Object.getOwnPropertyDescriptors(person);

for (const key in person) {
    console.log(`${key} -> ${person[key]}`);
}