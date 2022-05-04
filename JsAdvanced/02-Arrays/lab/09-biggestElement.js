function biggestElement(arr){
    arr.sort((a, b) => b - a);

    return arr[0];
}

let result = biggestElement([1,2,3,4,5,6,5,4,43,5,6,7,7,65,45,4,5455])