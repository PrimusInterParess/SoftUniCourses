function getEvenPosition(arr){
    let result='';

    for (let index = 0; index < arr.length; index+=2) {
      
        result+=`${arr[index]} `
    }

    console.log(result);
}

getEvenPosition([1,2,3,4,5,6,7,8])