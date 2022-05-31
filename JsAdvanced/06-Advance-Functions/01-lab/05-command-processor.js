function solution() {

    let result = '';

    return {
        append,
        removeStart,
        removeEnd,
        print
    }

    function append(string) {
        result += string;
    }

    function removeStart(n) {
        result = result.slice(n);
    }

    function removeEnd(n) {
        result = result.slice(n,-1);
    }

    function print() {
        console.log(result);
    }

}

let firstZeroTest = solution();

firstZeroTest.append('hello');
firstZeroTest.append('again');
firstZeroTest.removeStart(3);
firstZeroTest.removeEnd(4);
firstZeroTest.print();
