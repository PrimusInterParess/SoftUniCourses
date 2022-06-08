function add(first) {
    let sum = first;

    function addFunc(second) {
        sum += second;

        return addFunc;
    }

    addFunc.toString = () => {
        return sum;
    }

    return addFunc;


}


add(1)(2)(3)(4);
let res = add(2).toString();

console.log(result);