function biggerHalf(arr) {

    arr.sort((a, b) => a - b);
    let end = arr.length;
    let start = arr.length/2;
    return arr.slice(start, end);
}


console.log(biggerHalf([6,5,4,3,2,1]));