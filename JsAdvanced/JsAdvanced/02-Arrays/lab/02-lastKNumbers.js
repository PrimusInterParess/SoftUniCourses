function lastKElements(n, k) {

    let arr = new Array(n);
    arr[0] = 1;

    for (let index = 1; index < n; index++) {

        if (index < k) {
            arr[index] = sumLastElements(arr, arr[index - 1], index - 1);
        }
        else {

            arr[index] = sumKElements(arr, k, index);
        }
    }

    function sumLastElements(arr, acc, i) {
        let start = 0;
        let sum = acc;

        for (let index = start; index < i; index++) {

            sum += arr[index];
        }

        return sum;
    }

    function sumKElements(arr, k, i) {

        let start = i - k;
        let sum = 0;

        for (let index = start; index < i; index++) {

            sum += arr[index];
        }


        return sum;
    }

    return arr;

}





let n = 8;

let k = 2;


result= lastKElements(n, k);

console.log(result);
