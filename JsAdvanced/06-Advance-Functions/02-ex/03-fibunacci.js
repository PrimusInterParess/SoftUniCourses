function fib() {
    let n1 = 0;
    let n2 = 1;

    return function () {
        let sum = n1 + n2;
        n1 = n2
        n2 = sum;

        return n1;
    }
}
let fibo = fib();

console.log(fibo());
console.log(fibo());
console.log(fibo());
console.log(fibo());
