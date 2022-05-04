function smallestTwo(arr) {

    arr.sort((a, b) => a - b);

    return arr.slice(0, 2);
}

var result = smallestTwo([1, 2, 3, 4, -1]);