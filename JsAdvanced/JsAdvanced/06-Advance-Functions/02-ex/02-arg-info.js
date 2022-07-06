function argInfo(...arguments) {

    let counter = {};

    const args = Array.from(arguments);



    for (const arg of args) {

        let type = typeof arg;
        if (counter[type] == undefined) {
            counter[type] = 0;
        }
        counter[type] += 1;
        console.log(`${type}: ${arg}`)
    }

    let result = Object.entries(counter).sort((a, b) => {
        return b[1] - a[1]
    });

    for (const [type, count] of result) {
        console.log(`${type} = ${count}`);
    }

}

let args = argInfo('cat', 42, function () { console.log('Hello world!'); });


