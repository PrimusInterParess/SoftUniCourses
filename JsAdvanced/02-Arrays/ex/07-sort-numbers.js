function sortNumbers(array) {
    let result = [];

    array.sort((a, b) => a - b);

    while (array.length > 0) {
        let small = array.shift();
        let big = array.pop();

        result.push(small, big);
    }
    return result;
}

console.log(sortNumbers([1, 65, 3, 52, 48, 63, 31, -3, 18, 56]));