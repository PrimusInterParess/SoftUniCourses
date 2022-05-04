function ordering(arr){

    let result= new Array();

    for (let index = 0; index < arr.length; index++) {
        
        if(arr[index]<0){
            result.unshift(arr[index]);
        }
        else{
            result.push(arr[index]);
        }
    }

    return result;
}


var output= ordering([7, -2, 8, 9]);