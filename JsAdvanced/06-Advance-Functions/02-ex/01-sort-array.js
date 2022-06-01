function sorter(array, sortingOrder) {

    if (sortingOrder == 'asc') {
        return array.sort((a, b) => a - b);
    } else {
        return array.sort((a, b) => b - a);
    }
}


let result = sorter([14, 7, 17, 6, 8], 'desc');

console.log(result);