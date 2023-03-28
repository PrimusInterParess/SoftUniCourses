function solve(n,m){
    let numberOne=Number(n);
    let numberTwo=Number(m);

    let result=0;

    for (let index = numberOne; index <=numberTwo; index++) {
        result+=index;
        
    }

    return result;
}

let result = solve('1','5');

