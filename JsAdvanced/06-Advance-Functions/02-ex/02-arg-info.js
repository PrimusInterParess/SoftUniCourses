function argInfo(...arguments) {

    let counter = {};
    let result = [];

    arguments.forEach(arg => {

        if (!counter.hasOwnProperty(arg)) {
            counter[typeof arg] = 0;
        }
        counter[typeof arg] += 1;
        result.push(`${typeof arg}: ${arg}`)
    })

    console.log(result.sort((a, b) => b - a).join('\n'));
    console.log(Object.keys(counter).map(k => `${k} = ${counter[k]}`).sort((a, b) => b - a).join('\n'))
}

let args = argInfo('cat', 42, function () { console.log('Hello world!'); });


