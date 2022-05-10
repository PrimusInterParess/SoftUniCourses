function printNelements(array, step) {

    let result = [];
    
    for (let index = 0; index < array.length; index += step) {
       

        result.push(array[index]);

    }

    return result;
}


let print = printNelements(['5', 
'20', 
'31', 
'4', 
'20'], 
2
);

console.log(print);