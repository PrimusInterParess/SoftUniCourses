function rotateArray(arr,rotations){
    
    for (let index = 0; index < rotations; index++) {
        
        let current = arr.pop();
        arr.unshift(current);
    }
     
    return arr.join(' ');
        
 }

var result = rotateArray(['1', 
'2', 
'3', 
'4'], 
2
);

console.log(result);