function sort(array) {

     array.sort((a, b) => 
    a.length - b.length  || a.localeCompare(b)
    )

    array.forEach(element => {
         console.log(element)        
    });
}


 sort(['alpha',
    'beta',
    'gamma']
);
